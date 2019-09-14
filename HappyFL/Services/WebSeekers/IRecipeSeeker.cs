using System;
using System.Collections.Generic;
using HappyFL.Models.WebSeeker;

namespace HappyFL.Services.WebSeekers
{
    public interface IRecipeSeeker
    {
        IEnumerable<RecipeSeekResult> Scan();
    }
}
