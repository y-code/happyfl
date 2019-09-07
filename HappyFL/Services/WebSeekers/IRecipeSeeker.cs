using System;
using System.Collections.Generic;

namespace HappyFL.Services.WebSeekers
{
    public interface IRecipeSeeker
    {
        IEnumerable<WebSeekerService.RecipeSeekResult> Scan();
    }
}
