namespace CookiesCookbook
{
    public abstract class Ingredient
    {
        public int ID;
        public string Name;
        private readonly string _description;
        bool isHeated;
        bool isStired;
        public string DescribeIngredient() => _description;
    }


}