using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    public interface IRecipeRepository
    {
        public List<Recipe> Read(string filePath);
        public void Write(List<Recipe> recipes, string filePath);
    }
}
