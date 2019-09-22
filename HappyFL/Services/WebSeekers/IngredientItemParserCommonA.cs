using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using HappyFL.DB.RecipeManagement;
using HappyFL.Models.WebSeeker;

namespace HappyFL.Services.WebSeekers
{
    public class IngredientItemParserCommonA : IIngredientItemParser
    {
        private enum TokenType
        {
            Word,
            Number,
            Symbol,
            Unit,
        }

        private class Token
        {
            protected string _raw;
            public string Raw => _raw;
            protected string _value;
            public string Value
                => _value ?? Tokens?
                .SelectMany(t => new string[] { ((Type == TokenType.Unit && t.Value == ".") ? "" : " "), t.Value })
                .DefaultIfEmpty().Aggregate((a, b) => a + b)
                .Trim();
            public TokenType Type { get; }
            public IEnumerable<Token> Tokens { get; set; }

            public Token(TokenType type, string value, string raw = null)
            {
                _raw = raw ?? value;
                _value = value.Trim();
                Type = type;
            }

            public Token(TokenType type, params Token[] tokens)
            {
                Type = type;
                Tokens = tokens.ToList().AsReadOnly();
            }

            public Token(Token token)
            {
                _raw = token.Raw;
                _value = token._value;
                Type = token.Type;
            }

            public override string ToString()
                => $"<{Type}> {Value}";
        }

        private class AmountToken : Token
        {
            protected float _amount;
            public virtual float Amount => _amount;

            static Token ValidateToken(Token token)
            {
                if (token.Type != TokenType.Number)
                    throw new ArgumentException("Non-number token is passed to AmountToken constructor.", nameof(token));
                return token;
            }
            public AmountToken(Token token)
                : base(ValidateToken(token))
            {
                var amountToken = token as AmountToken;
                if (amountToken == null)
                    _amount = float.Parse(Value.Replace(",", ""));
                else
                    _amount = amountToken._amount;
                Tokens = new List<Token> { token }.AsReadOnly();
            }

            public AmountToken(float amount, params Token[] tokens)
                : base(TokenType.Number, tokens: tokens)
            {
                _amount = amount;
            }
        }

        private class AmountRangeToken : AmountToken
        {
            AmountToken AmountFrom { get; }
            AmountToken AmountTo { get; }
            public AmountRangeToken(AmountToken amountFrom, AmountToken amountTo, params Token[] tokens)
                : base(amountTo.Amount, tokens)
            {
                AmountFrom = amountFrom;
                AmountTo = amountTo;
            }
        }

        private class AmountUnitToken : AmountToken
        {
            public UnitToken Unit { get; }
            public AmountUnitToken(float amount, UnitToken unit, params Token[] tokens)
                : base(amount, tokens)
            {
                Unit = unit;
            }
        }

        private class UnitToken : Token
        {
            public string Unit { get; }
            public UnitToken(string unit, params Token[] tokens)
                : base(TokenType.Unit, tokens)
            {
                Unit = unit;
            }
        }

        private class Keyword
        {
            public string Key { get; }
            public IEqualityComparer Comparer { get; }
            public Keyword(string key, IEqualityComparer comparer)
            {
                Key = key;
                Comparer = comparer;
            }
            public override string ToString()
                => Key;
        }

        private class KeywordComparer : IEqualityComparer<Keyword>
        {
            public bool Equals(Keyword x, Keyword y)
            {
                var c = x.Comparer;
                if (c != null)
                    return c.Equals(x.Key, y.Key);
                c = y.Comparer;
                return c?.Equals(x.Key, y.Key) ?? false;
            }

            public int GetHashCode(Keyword obj)
            {
                return StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.Key);
            }
        }

        private class NormalizedValue
        {
            public TokenType Type { get; }
            public string Value { get; }
            public NormalizedValue(TokenType type, string value)
            {
                Type = type;
                Value = value;
            }
        }

        const string NumberPattern = @"[0-9]+(?:,[0-9]+)*(?:\.[0-9]+)?";

        private Regex _lexPattern = new Regex($@"({NumberPattern})|([a-zA-Z]+)|(\s?-\s?)|([^0-9a-zA-Z\s])");
        private Regex _numberValidationPattern = new Regex($@"^{NumberPattern}$");
        private Regex _symbolValidationPattern = new Regex(@"^[^0-9a-zA-Z]+$");

        private ConcurrentDictionary<string, NormalizedValue> _normalizationMapping
            = new ConcurrentDictionary<string, NormalizedValue>(new Dictionary<string, NormalizedValue>
            {
                { "＋", new NormalizedValue(TokenType.Symbol, "+") },
                { "−", new NormalizedValue(TokenType.Symbol, "-") },
                { "×", new NormalizedValue(TokenType.Symbol, "*") },
                { "x", new NormalizedValue(TokenType.Symbol, "*") },
                { "X", new NormalizedValue(TokenType.Symbol, "*") },
                { "＊", new NormalizedValue(TokenType.Symbol, "*") },
                { "／", new NormalizedValue(TokenType.Symbol, "/") },
            });

        private ConcurrentDictionary<Keyword, string> _unitKeywords
            = new ConcurrentDictionary<Keyword, string>(new Dictionary<Keyword, string>
            {
                { new Keyword("teaspoon", StringComparer.InvariantCultureIgnoreCase), "teaspoon" },
                { new Keyword("teaspoons", StringComparer.InvariantCultureIgnoreCase), "teaspoon" },
                { new Keyword("heaped teaspoon", StringComparer.InvariantCultureIgnoreCase), "teaspoon" },
                { new Keyword("heaped teaspoons", StringComparer.InvariantCultureIgnoreCase), "teaspoon" },
                { new Keyword("tsp .", StringComparer.InvariantCultureIgnoreCase), "teaspoon" },
                { new Keyword("tsp", StringComparer.InvariantCultureIgnoreCase), "teaspoon" },
                { new Keyword("t", StringComparer.InvariantCulture), "teaspoon" },
                { new Keyword("tablespoon", StringComparer.InvariantCultureIgnoreCase), "tablespoon" },
                { new Keyword("tablespoons", StringComparer.InvariantCultureIgnoreCase), "tablespoon" },
                { new Keyword("heaped tablespoon", StringComparer.InvariantCultureIgnoreCase), "tablespoon" },
                { new Keyword("heaped tablespoons", StringComparer.InvariantCultureIgnoreCase), "tablespoon" },
                { new Keyword("tbl .", StringComparer.InvariantCultureIgnoreCase), "tablespoon" },
                { new Keyword("tbl", StringComparer.InvariantCultureIgnoreCase), "tablespoon" },
                { new Keyword("tbs .", StringComparer.InvariantCultureIgnoreCase), "tablespoon" },
                { new Keyword("tbs", StringComparer.InvariantCultureIgnoreCase), "tablespoon" },
                { new Keyword("tbsp .", StringComparer.InvariantCultureIgnoreCase), "tablespoon" },
                { new Keyword("tbsp", StringComparer.InvariantCultureIgnoreCase), "tablespoon" },
                { new Keyword("T", StringComparer.InvariantCulture), "tablespoon" },
                { new Keyword("fl oz", StringComparer.InvariantCultureIgnoreCase), "fl oz" },
                { new Keyword("fluid ounce", StringComparer.InvariantCultureIgnoreCase), "fl oz" },
                { new Keyword("cup", StringComparer.InvariantCultureIgnoreCase), "cup" },
                { new Keyword("cups", StringComparer.InvariantCultureIgnoreCase), "cup" },
                { new Keyword("c", StringComparer.InvariantCultureIgnoreCase), "cup" },
                { new Keyword("c .", StringComparer.InvariantCultureIgnoreCase), "cup" },
                { new Keyword("gill", StringComparer.InvariantCultureIgnoreCase), "gill" },
                { new Keyword("gills", StringComparer.InvariantCultureIgnoreCase), "gill" },
                { new Keyword("pint", StringComparer.InvariantCultureIgnoreCase), "pint" },
                { new Keyword("pints", StringComparer.InvariantCultureIgnoreCase), "pint" },
                { new Keyword("p", StringComparer.InvariantCultureIgnoreCase), "pint" },
                { new Keyword("pt", StringComparer.InvariantCultureIgnoreCase), "pint" },
                { new Keyword("pt .", StringComparer.InvariantCultureIgnoreCase), "pint" },
                { new Keyword("fl pt", StringComparer.InvariantCultureIgnoreCase), "pint" },
                { new Keyword("quart", StringComparer.InvariantCultureIgnoreCase), "quart" },
                { new Keyword("quarts", StringComparer.InvariantCultureIgnoreCase), "quart" },
                { new Keyword("q", StringComparer.InvariantCultureIgnoreCase), "quart" },
                { new Keyword("qt", StringComparer.InvariantCultureIgnoreCase), "quart" },
                { new Keyword("qt .", StringComparer.InvariantCultureIgnoreCase), "quart" },
                { new Keyword("fl qt", StringComparer.InvariantCultureIgnoreCase), "quart" },
                { new Keyword("gallon", StringComparer.InvariantCultureIgnoreCase), "gallon" },
                { new Keyword("gallons", StringComparer.InvariantCultureIgnoreCase), "gallon" },
                { new Keyword("gal", StringComparer.InvariantCultureIgnoreCase), "gallon" },
                { new Keyword("gal .", StringComparer.InvariantCultureIgnoreCase), "gallon" },
                { new Keyword("milliliter", StringComparer.InvariantCultureIgnoreCase), "ml" },
                { new Keyword("milliliters", StringComparer.InvariantCultureIgnoreCase), "ml" },
                { new Keyword("millilitre", StringComparer.InvariantCultureIgnoreCase), "ml" },
                { new Keyword("millilitres", StringComparer.InvariantCultureIgnoreCase), "ml" },
                { new Keyword("ml", StringComparer.InvariantCulture), "ml" },
                { new Keyword("mL", StringComparer.InvariantCulture), "ml" },
                { new Keyword("cc", StringComparer.InvariantCultureIgnoreCase), "cc" },
                { new Keyword("liter", StringComparer.InvariantCultureIgnoreCase), "liter" },
                { new Keyword("liters", StringComparer.InvariantCultureIgnoreCase), "liter" },
                { new Keyword("litre", StringComparer.InvariantCultureIgnoreCase), "liter" },
                { new Keyword("litres", StringComparer.InvariantCultureIgnoreCase), "liter" },
                { new Keyword("l", StringComparer.InvariantCultureIgnoreCase), "liter" },
                { new Keyword("deciliter", StringComparer.InvariantCultureIgnoreCase), "dl" },
                { new Keyword("deciliters", StringComparer.InvariantCultureIgnoreCase), "dl" },
                { new Keyword("decilitre", StringComparer.InvariantCultureIgnoreCase), "dl" },
                { new Keyword("decilitres", StringComparer.InvariantCultureIgnoreCase), "dl" },
                { new Keyword("dl", StringComparer.InvariantCulture), "dl" },
                { new Keyword("dL", StringComparer.InvariantCulture), "dl" },
                { new Keyword("pound", StringComparer.InvariantCultureIgnoreCase), "pound" },
                { new Keyword("pounds", StringComparer.InvariantCultureIgnoreCase), "pound" },
                { new Keyword("lb", StringComparer.InvariantCultureIgnoreCase), "pound" },
                { new Keyword("lb .", StringComparer.InvariantCultureIgnoreCase), "pound" },
                { new Keyword("#", StringComparer.InvariantCulture), "pound" },
                { new Keyword("ounce", StringComparer.InvariantCultureIgnoreCase), "ounce" },
                { new Keyword("ounces", StringComparer.InvariantCultureIgnoreCase), "ounce" },
                { new Keyword("oz", StringComparer.InvariantCultureIgnoreCase), "ounce" },
                { new Keyword("oz .", StringComparer.InvariantCultureIgnoreCase), "ounce" },
                { new Keyword("gram", StringComparer.InvariantCultureIgnoreCase), "g" },
                { new Keyword("grams", StringComparer.InvariantCultureIgnoreCase), "g" },
                { new Keyword("gramme", StringComparer.InvariantCultureIgnoreCase), "g" },
                { new Keyword("grammes", StringComparer.InvariantCultureIgnoreCase), "g" },
                { new Keyword("g", StringComparer.InvariantCulture), "g" },
                { new Keyword("milligram", StringComparer.InvariantCultureIgnoreCase), "mg" },
                { new Keyword("milligrams", StringComparer.InvariantCultureIgnoreCase), "mg" },
                { new Keyword("milligramme", StringComparer.InvariantCultureIgnoreCase), "mg" },
                { new Keyword("milligrammes", StringComparer.InvariantCultureIgnoreCase), "mg" },
                { new Keyword("mg", StringComparer.InvariantCulture), "mg" },
                { new Keyword("kilogram", StringComparer.InvariantCultureIgnoreCase), "kg" },
                { new Keyword("kilograms", StringComparer.InvariantCultureIgnoreCase), "kg" },
                { new Keyword("kilogramme", StringComparer.InvariantCultureIgnoreCase), "kg" },
                { new Keyword("kilogrammes", StringComparer.InvariantCultureIgnoreCase), "kg" },
                { new Keyword("kg", StringComparer.InvariantCulture), "kg" },
                { new Keyword("millimeter", StringComparer.InvariantCultureIgnoreCase), "mm" },
                { new Keyword("millimeters", StringComparer.InvariantCultureIgnoreCase), "mm" },
                { new Keyword("millimetre", StringComparer.InvariantCultureIgnoreCase), "mm" },
                { new Keyword("millimetres", StringComparer.InvariantCultureIgnoreCase), "mm" },
                { new Keyword("mm", StringComparer.InvariantCulture), "mm" },
                { new Keyword("centimeter", StringComparer.InvariantCultureIgnoreCase), "cm" },
                { new Keyword("centimeters", StringComparer.InvariantCultureIgnoreCase), "cm" },
                { new Keyword("centimetre", StringComparer.InvariantCultureIgnoreCase), "cm" },
                { new Keyword("centimetres", StringComparer.InvariantCultureIgnoreCase), "cm" },
                { new Keyword("cm", StringComparer.InvariantCulture), "cm" },
                { new Keyword("meter", StringComparer.InvariantCultureIgnoreCase), "m" },
                { new Keyword("meters", StringComparer.InvariantCultureIgnoreCase), "m" },
                { new Keyword("metre", StringComparer.InvariantCultureIgnoreCase), "m" },
                { new Keyword("metres", StringComparer.InvariantCultureIgnoreCase), "m" },
                { new Keyword("m", StringComparer.InvariantCulture), "m" },
                { new Keyword("inch", StringComparer.InvariantCultureIgnoreCase), "inch" },
                { new Keyword("in", StringComparer.InvariantCultureIgnoreCase), "inch" },
                { new Keyword("in .", StringComparer.InvariantCultureIgnoreCase), "inch" },
                { new Keyword("\"", StringComparer.InvariantCultureIgnoreCase), "inch" },
                { new Keyword("pinch", StringComparer.InvariantCultureIgnoreCase), "pinch" },
                { new Keyword("pinch of", StringComparer.InvariantCultureIgnoreCase), "pinch" },
                { new Keyword("a pinch of", StringComparer.InvariantCultureIgnoreCase), "pinch" },
                { new Keyword("pinches", StringComparer.InvariantCultureIgnoreCase), "pinch" },
                { new Keyword("pinches of", StringComparer.InvariantCultureIgnoreCase), "pinch" },
                { new Keyword("bunch", StringComparer.InvariantCultureIgnoreCase), "bunch" },
                { new Keyword("bunch of", StringComparer.InvariantCultureIgnoreCase), "bunch" },
                { new Keyword("a bunch of", StringComparer.InvariantCultureIgnoreCase), "bunch" },
                { new Keyword("bunches", StringComparer.InvariantCultureIgnoreCase), "bunch" },
                { new Keyword("bunches of", StringComparer.InvariantCultureIgnoreCase), "bunch" },
                { new Keyword("splash", StringComparer.InvariantCultureIgnoreCase), "splash" },
                { new Keyword("splash of", StringComparer.InvariantCultureIgnoreCase), "splash" },
                { new Keyword("a splash of", StringComparer.InvariantCultureIgnoreCase), "splash" },
                { new Keyword("splashes", StringComparer.InvariantCultureIgnoreCase), "splash" },
                { new Keyword("splashes of", StringComparer.InvariantCultureIgnoreCase), "splash" },
                { new Keyword("spring", StringComparer.InvariantCultureIgnoreCase), "spring" },
                { new Keyword("springs", StringComparer.InvariantCultureIgnoreCase), "spring" },
                { new Keyword("slice", StringComparer.InvariantCultureIgnoreCase), "slice" },
                { new Keyword("slices", StringComparer.InvariantCultureIgnoreCase), "slice" },
                { new Keyword("clove", StringComparer.InvariantCultureIgnoreCase), "clove" },
                { new Keyword("cloves", StringComparer.InvariantCultureIgnoreCase), "clove" },
                { new Keyword("block", StringComparer.InvariantCultureIgnoreCase), "block" },
                { new Keyword("blocks", StringComparer.InvariantCultureIgnoreCase), "block" },
                { new Keyword("stick", StringComparer.InvariantCultureIgnoreCase), "stick" },
                { new Keyword("sticks", StringComparer.InvariantCultureIgnoreCase), "stick" },
                { new Keyword("package", StringComparer.InvariantCultureIgnoreCase), "package" },
                { new Keyword("packages", StringComparer.InvariantCultureIgnoreCase), "package" },
                { new Keyword("can", StringComparer.InvariantCultureIgnoreCase), "can" },
                { new Keyword("cans", StringComparer.InvariantCultureIgnoreCase), "can" },
            },
            new KeywordComparer());
        private int _maxNumOfWordsInUnit;
        private ConcurrentBag<string> _ignorablesInUnit = new ConcurrentBag<string>(new string[] { "-", "_" });

        private ConcurrentBag<string> _calculusSymbols = new ConcurrentBag<string>(new List<string>
        {
            "+",
            //"-",
            "/",
            "*",
        });
        private ConcurrentDictionary<Keyword, float> _amountKeywords = new ConcurrentDictionary<Keyword, float>(
            new Dictionary<Keyword, float>
            {
                { new Keyword("a", StringComparer.InvariantCultureIgnoreCase), 1f },
                { new Keyword("a half of", StringComparer.InvariantCultureIgnoreCase), 0.5f },
                { new Keyword("¼", StringComparer.InvariantCultureIgnoreCase), 0.25f },
                { new Keyword("½", StringComparer.InvariantCultureIgnoreCase), 0.5f },
                { new Keyword("¾", StringComparer.InvariantCultureIgnoreCase), 0.75f },
                { new Keyword("⅓", StringComparer.InvariantCultureIgnoreCase), 1f / 3 },
                { new Keyword("⅔", StringComparer.InvariantCultureIgnoreCase), 2f / 3 },
                { new Keyword("a few", StringComparer.InvariantCultureIgnoreCase), 3 },
                { new Keyword("a couple of", StringComparer.InvariantCultureIgnoreCase), 2 },
                { new Keyword("one", StringComparer.InvariantCultureIgnoreCase), 1 },
                { new Keyword("two", StringComparer.InvariantCultureIgnoreCase), 2 },
                { new Keyword("three", StringComparer.InvariantCultureIgnoreCase), 3 },
                { new Keyword("four", StringComparer.InvariantCultureIgnoreCase), 4 },
                { new Keyword("five", StringComparer.InvariantCultureIgnoreCase), 5 },
                { new Keyword("six", StringComparer.InvariantCultureIgnoreCase), 6 },
                { new Keyword("seven", StringComparer.InvariantCultureIgnoreCase), 7 },
                { new Keyword("eight", StringComparer.InvariantCultureIgnoreCase), 8 },
                { new Keyword("nine", StringComparer.InvariantCultureIgnoreCase), 9 },
                { new Keyword("ten", StringComparer.InvariantCultureIgnoreCase), 10 },
                { new Keyword("eleven", StringComparer.InvariantCultureIgnoreCase), 11 },
                { new Keyword("twelve", StringComparer.InvariantCultureIgnoreCase), 12 },
                { new Keyword("thirteen", StringComparer.InvariantCultureIgnoreCase), 13 },
                { new Keyword("fourteen", StringComparer.InvariantCultureIgnoreCase), 14 },
                { new Keyword("fifteen", StringComparer.InvariantCultureIgnoreCase), 15 },
                { new Keyword("sixteen", StringComparer.InvariantCultureIgnoreCase), 16 },
                { new Keyword("seventeen", StringComparer.InvariantCultureIgnoreCase), 17 },
                { new Keyword("eighteen", StringComparer.InvariantCultureIgnoreCase), 18 },
                { new Keyword("nineteen", StringComparer.InvariantCultureIgnoreCase), 19 },
                { new Keyword("twenty", StringComparer.InvariantCultureIgnoreCase), 20 },
                { new Keyword("thirty", StringComparer.InvariantCultureIgnoreCase), 30 },
                { new Keyword("fourty", StringComparer.InvariantCultureIgnoreCase), 40 },
                { new Keyword("fifty", StringComparer.InvariantCultureIgnoreCase), 50 },
                { new Keyword("sixty", StringComparer.InvariantCultureIgnoreCase), 60 },
                { new Keyword("seventy", StringComparer.InvariantCultureIgnoreCase), 70 },
                { new Keyword("eighty", StringComparer.InvariantCultureIgnoreCase), 80 },
                { new Keyword("ninety", StringComparer.InvariantCultureIgnoreCase), 90 },
                { new Keyword("a handred", StringComparer.InvariantCultureIgnoreCase), 100 },
            },
            new KeywordComparer());
        private int _maxNumOfWordsInAmount;
        private ConcurrentBag<string> _ignorablesInAmount = new ConcurrentBag<string>(new string[] { "-", "_" });

        private Regex _startingBracketsAdjustmentPattern = new Regex(@"([\(\[\{])\s");
        private Regex _endingBracketsAdjustmentPattern = new Regex(@"\s([\)\]\}])");
        private Regex _fractionAdjustmentPattern = new Regex($@"({NumberPattern})\s+(/)\s+({NumberPattern})");

        public IngredientItemParserCommonA()
        {
            _maxNumOfWordsInUnit = _unitKeywords.Select(k => k.Key.Key.Split(' ').Length).Max();
            _maxNumOfWordsInAmount = _amountKeywords.Select(k => k.Key.Key.Split(' ').Length).Max();
        }

        private IEnumerable<Token> Tokenize(string input)
        {
            var tokens = _lexPattern.Matches(input);
            return tokens.Select(t =>
            {
                TokenType type;
                if (_numberValidationPattern.IsMatch(t.Value))
                    type = TokenType.Number;
                else if (_symbolValidationPattern.IsMatch(t.Value))
                {

                    type = TokenType.Symbol;
                }
                else
                    type = TokenType.Word;

                NormalizedValue normalized = null;
                _normalizationMapping.TryGetValue(t.Value, out normalized);

                return new Token(
                    normalized == null ? type : normalized.Type,
                    normalized == null ? t.Value : normalized.Value,
                    t.Value);
            });
        }

        public RecipeSeekResult.IngredientItem Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new RecipeSeekResult.IngredientItem { Input = input };

            var tokens = Tokenize(input);
            tokens = RecognizeKeywords(
                tokens,
                _amountKeywords,
                _ignorablesInAmount,
                _maxNumOfWordsInAmount,
                (v, ts) => new AmountToken(v, ts));
            tokens = RecognizeKeywords(
                tokens,
                _unitKeywords,
                _ignorablesInUnit,
                _maxNumOfWordsInUnit,
                (v, ts) => new UnitToken(v, ts));
            tokens = RecognizeAmountRange(tokens);
            tokens = RecognizeAmountUnitTokens(tokens);
            tokens = RecognizeAmountTokens(tokens);

            var results = new RecipeSeekResult.IngredientItem
            {
                Input = input
            };

            for (var i = 0; i < tokens.Count(); i++)
            {
                var token = tokens.ElementAt(i) as AmountToken;
                if (token != null)
                {
                    var amount = token.Amount;
                    var unit = (token as AmountUnitToken)?.Unit?.Unit;
                    var partBefore = ConcatenateTokens(tokens.Take(i));
                    var partAfter = ConcatenateTokens(tokens.Skip(i + 1))?
                        .Split(", ", 2, StringSplitOptions.RemoveEmptyEntries);

                    if (i == 0)
                        results.Candidates.Add(new Ingredient
                        {
                            Name = partAfter?.First(),
                            Amount = token.Amount,
                            Unit = (token as AmountUnitToken)?.Unit?.Unit,
                            Note = (partAfter?.Count() ?? 0) > 1 ? partAfter.ElementAt(1) : null,
                        });
                    else if (i == tokens.Count() - 1)
                        results.Candidates.Add(new Ingredient
                        {
                            Name = partBefore,
                            Amount = token.Amount,
                            Unit = (token as AmountUnitToken)?.Unit?.Unit,
                            Note = null,
                        });
                    else
                    {
                        if (partAfter != null)
                            results.Candidates.Add(new Ingredient
                            {
                                Name = partAfter.First(),
                                Amount = token.Amount,
                                Unit = (token as AmountUnitToken)?.Unit?.Unit,
                                Note = ((partAfter?.Count() ?? 0) > 1 ? partAfter.ElementAt(1) + (partBefore != null ? ", " : "") : "") + partBefore,
                            });
                        if (partBefore != null)
                            results.Candidates.Add(new Ingredient
                            {
                                Name = partBefore,
                                Amount = token.Amount,
                                Unit = (token as AmountUnitToken)?.Unit?.Unit,
                                Note = partAfter?.Aggregate((a, b) => $"{a}, {b}"),
                            });
                    }
                }
            }

            if (results.Candidates.Count == 0)
            {
                var value = ConcatenateTokens(tokens);

                if (value != null)
                {
                    var candidates = new List<string[]>();
                    candidates.Add(value
                        .Split(", ", 2, StringSplitOptions.RemoveEmptyEntries));
                    candidates.Add(new string(value.Reverse().ToArray())
                        .Split(", ", 2, StringSplitOptions.RemoveEmptyEntries)
                        .Select(p => new string(p.Reverse().ToArray()))
                        .Reverse()
                        .ToArray());
                    candidates = candidates.Where(c => c.Length > 0).ToList();

                    if (candidates.Count() > 1
                        && candidates.ElementAt(0)[0] == candidates.ElementAt(1)[0])
                        candidates.Remove(candidates.ElementAt(1));

                    foreach (var candidate in candidates)
                    {
                        results.Candidates.Add(new Ingredient
                        {
                            Name = candidate.Length > 0 ? candidate[0] : null,
                            Amount = 1,
                            Note = candidate.Length > 1 ? candidate[1] : null,
                        });
                    }
                }
            }

            return results;
        }

        private string ConcatenateTokens(IEnumerable<Token> tokens)
        {
            if (tokens == null)
                return null;

            var str = "";
            for (var i = 0; i < tokens.Count(); i++)
            {
                var token = tokens.ElementAt(i);
                if (token.Type == TokenType.Symbol)
                {
                    if (token.Value == "-")
                    {
                        if (i == 0)
                            continue; // ignore hyphen at the beginning

                        if (token.Raw.Length == 1)
                        {
                            str += "-";
                            if (++i < tokens.Count())
                                str += tokens.ElementAt(i).Value;
                            continue;
                        }
                    }
                    else if (token.Value == "," || token.Value == ".")
                    {
                        str += token.Value;
                        continue;
                    }
                }

                str += (str.Length > 0 ? " " : "") + token.Value;
            }

            if (str.Length == 0)
                return null;

            str = _startingBracketsAdjustmentPattern.Replace(str, "$1");
            str = _endingBracketsAdjustmentPattern.Replace(str, "$1");
            str = _fractionAdjustmentPattern.Replace(str, "$1$2$3");

            return str;
        }

        private class KeywordInfo<T>
        {
            public string Key { get; }
            public T Value { get; set; }
            public int Start { get; }
            public int End { get; }
            public KeywordInfo(string key, int start, int end)
            {
                Key = key;
                Start = start;
                End = end;
            }
            public override string ToString()
                => Key;
        }

        private IEnumerable<Token> RecognizeKeywords<T>(
            IEnumerable<Token> tokens,
            ConcurrentDictionary<Keyword, T> keywordsMap,
            IEnumerable<string> ignorables,
            int maxNumOfWords,
            Func<T, Token[], Token> createToken)
        {
            var keywords = FindKeywords(tokens, keywordsMap, ignorables, maxNumOfWords);

            if (keywords.Count() == 0)
                return tokens;

            keywords.OrderBy(k => k.Start);

            var adjusted = new List<Token>();
            var j = 0;
            var keyword = keywords.First();
            for (var i = 0; i < tokens.Count(); i++)
            {
                // set up next keyword, skipping overlapping
                while (keyword != null && keyword.Start < i)
                {
                    if (++j < keywords.Count())
                        keyword = keywords.ElementAt(j);
                    else
                        keyword = null;
                }

                if (keyword != null && keyword.Start == i)
                {
                    adjusted.Add(createToken(keyword.Value, tokens.Skip(keyword.Start).Take(keyword.End - keyword.Start + 1).ToArray()));
                    i = keyword.End;
                }
                else
                    adjusted.Add(tokens.ElementAt(i));
            }
            return adjusted;
        }

        private IEnumerable<KeywordInfo<T>> FindKeywords<T>(IEnumerable<Token> tokens, ConcurrentDictionary<Keyword, T> keywordsMap, IEnumerable<string> ignorables, int maxNumOfWords, int start = 0)
        {
            var candidates = Permutate<T>(tokens, ignorables, maxNumOfWords);
            var results = new List<KeywordInfo<T>>();
            foreach (var candidate in candidates)
            {
                T value;
                if (keywordsMap.TryGetValue(new Keyword(candidate.Key, null), out value))
                {
                    candidate.Value = value;
                    results.Add(candidate);
                }
            }

            return results
                .GroupBy(k => k.Start) // reduce ones starting from the same token
                .Select(g => g.OrderBy(k => k.Value.ToString().Length).Last());
        }

        private IEnumerable<KeywordInfo<T>> Permutate<T>(IEnumerable<Token> tokens, IEnumerable<string> ignorables, int maxNumOfWords, int start = 0)
        {
            var p = new List<KeywordInfo<T>>();

            if (start >= tokens.Count())
                return p;

            if (!ignorables.Contains(tokens.ElementAt(start).Value))
            {
                var tmp = tokens.ElementAt(start).Value;
                var skipCounter = 0;
                p.Add(new KeywordInfo<T>(tmp, start, start));
                for (var i = start + 1; i < Math.Min(tokens.Count(), start + maxNumOfWords + skipCounter); i++)
                {
                    if (ignorables.Contains(tokens.ElementAt(i).Value))
                    {
                        skipCounter++;
                        continue;
                    }
                    tmp += " " + tokens.ElementAt(i).Value;
                    p.Add(new KeywordInfo<T>(tmp, start, i));
                }
            }

            p.AddRange(Permutate<T>(tokens, ignorables, maxNumOfWords, start + 1));

            return p;
        }

        private IEnumerable<Token> RecognizeAmountUnitTokens(IEnumerable<Token> tokens, int start = 0)
        {
            if (start >= tokens.Count())
                return tokens;

            AmountToken amount = null;
            UnitToken unit = null;
            var first = tokens.Count() - 1;
            var i = start;
            for (; i < tokens.Count(); i++)
            {
                var token = tokens.ElementAt(i);
                if (amount == null)
                {
                    if (token.Type == TokenType.Number && !(token is AmountUnitToken))
                    {
                        first = i;
                        if (token is AmountToken)
                            amount = (AmountToken)token;
                        else
                            amount = new AmountToken(token);
                    }
                }
                else
                {
                    if (token.Type == TokenType.Symbol && token.Value == "-")
                        continue;

                    if (token.Type == TokenType.Unit)
                    {
                        unit = (UnitToken)token;
                    }
                    break;
                }

                if (token.Type == TokenType.Unit)
                {
                    if (amount == null)
                        first = i;

                    unit = (UnitToken)token;
                    break;
                }
            }

            List<Token> adjusted = null;
            if (amount != null)
            {
                adjusted = tokens.Take(first).ToList();
                adjusted.Add(new AmountUnitToken(
                    amount.Amount,
                    unit,
                    (unit == null ? new Token[] { amount } : new Token[] { amount, unit })));
                adjusted.AddRange(tokens.Skip(first + 1 + (unit == null ? 0 : i - first)));
            }
            else if (unit != null)
            {
                adjusted = tokens.Take(first).ToList();
                adjusted.Add(new AmountUnitToken(
                    1f,
                    unit,
                    new Token[] { unit }));
                adjusted.AddRange(tokens.Skip(first + 1));
            }

            return RecognizeAmountUnitTokens(adjusted ?? tokens, first + 1);
        }

        private IEnumerable<Token> RecognizeAmountTokens(IEnumerable<Token> tokens, int start = 0)
        {
            if (start >= tokens.Count())
                return tokens;

            var calcTokens = new List<Tuple<Token, AmountToken>>();
            Token symbol = null;
            int first = start;

            var i = start;
            for (; i < tokens.Count(); i++)
            {
                var token = tokens.ElementAt(i);
                if (token.Type == TokenType.Symbol)
                {
                    if (!_calculusSymbols.Contains(token.Value))
                        break;
                    symbol = token;
                }
                else if (token.Type == TokenType.Number
                    && token.Value != "a"
                    && token.Value != "A")
                {
                    if (calcTokens.Count == 0)
                    {
                        if (symbol == null)
                            first = i;
                        else
                            first = i - 1;
                    }
                    calcTokens.Add(new Tuple<Token, AmountToken>(
                        calcTokens.Count == 0 ? null : (symbol ?? new Token(TokenType.Symbol, "+", null)),
                        (token as AmountToken) ?? new AmountToken(token)));

                    /* Reset */
                    symbol = null;
                }
                else if (token.Type == TokenType.Word)
                {
                    break;
                }
            }

            /* calculation */
            List<Token> adjusted = null;
            if (calcTokens.Count > 0)
            {
                var calc = "";
                List<UnitToken> units = new List<UnitToken>();
                foreach (var entry in calcTokens)
                {
                    symbol = entry.Item1;
                    var amount = entry.Item2;

                    if (symbol != null)
                        calc += " " + symbol.Value;
                    calc += " " + amount.Amount.ToString();

                    var amountUnit = amount as AmountUnitToken;
                    if (amountUnit?.Unit != null)
                        units.Add(((AmountUnitToken)amount).Unit);
                }

                if (units.Count <= 1) // if multiple unit tokens are included, it cannot not be calculated.
                {
                    adjusted = tokens.Take(first).ToList();
                    var a = Convert.ToSingle(new DataTable().Compute(calc, null));
                    var amountToken = new AmountUnitToken(a, units.FirstOrDefault(), tokens.Skip(first).Take(i - first).ToArray());
                    adjusted.Add(amountToken);
                    adjusted.AddRange(tokens.Skip(i));
                }
            }

            return RecognizeAmountTokens(adjusted ?? tokens, first + 1);
        }

        IEnumerable<Token> RecognizeAmountRange(IEnumerable<Token> tokens, int start = 0)
        {
            if (start >= tokens.Count())
                return tokens;

            AmountToken amountFrom = null;
            AmountToken amountTo = null;
            Token symbol = null;

            var first = start;
            var i = 0;
            for (; i < tokens.Count(); i++)
            {
                var token = tokens.ElementAt(i);

                if (amountFrom == null)
                {
                    if (token.Type == TokenType.Number)
                    {
                        first = i;
                        amountFrom = token as AmountToken ?? new AmountToken(token);
                    }
                    continue;
                }

                if (symbol == null)
                {
                    if (token.Type == TokenType.Symbol && token.Value == "-")
                    {
                        symbol = token;
                        continue;
                    }
                    break;
                }

                if (token.Type == TokenType.Number)
                {
                    amountTo = token as AmountToken ?? new AmountToken(token);
                }
                break;
            }

            List<Token> adjusted = null;
            if (amountFrom != null
                && symbol != null
                && amountTo != null)
            {
                adjusted = tokens.Take(first).ToList();
                adjusted.Add(new AmountRangeToken(amountFrom, amountTo, amountFrom, symbol, amountTo));
                adjusted.AddRange(tokens.Skip(i + 1));
            }

            return adjusted == null ? tokens : RecognizeAmountRange(adjusted, first);
        }
    }
}
