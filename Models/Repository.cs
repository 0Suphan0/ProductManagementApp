namespace FormsApp.Models
{
    public static class Repository
    {
        private static readonly List<Product> _products = new List<Product>();

        private static readonly List<Category> _categories = new List<Category>();


        static Repository()
        {

        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }

        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }

        }
    }
}
