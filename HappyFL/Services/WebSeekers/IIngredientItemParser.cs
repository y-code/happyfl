﻿using System;
using System.Collections.Generic;
using HappyFL.DB.RecipeManagement;
using HappyFL.Models.WebSeeker;

namespace HappyFL.Services.WebSeekers
{
    public interface IIngredientItemParser
    {
        RecipeSeekResult.IngredientItem Parse(string input);
    }
}
