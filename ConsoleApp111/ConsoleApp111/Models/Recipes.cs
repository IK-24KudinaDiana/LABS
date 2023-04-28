using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp111.Models
{
    public class Recipes
    {
        public List<Recipe> Recipe { get; set; }
        //models api ningi
        public Recipes() 
        { 
            Recipe= new List<Recipe>();
        }
    }
    public class Recipe
    {
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Servings { get; set; }
        public string Instructions { get; set; }
    }

}
