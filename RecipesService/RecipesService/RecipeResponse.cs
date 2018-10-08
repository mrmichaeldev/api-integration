using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesService
{
    public class RecipeResponse
    {
        public string Title { get; set; }

        public double Version { get; set; }

        public string Href { get; set; }

        public ICollection<Result> Results { get; set; }
    }

    public class Result
    {
        public string Title { get; set; }

        public string Href { get; set; }

        public string Ingredients { get; set; }

        public string Thumbnail { get; set; }
    }
}
