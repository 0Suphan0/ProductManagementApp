namespace FormsApp.Models
{
    public static class Repository
    {
        private static readonly List<Product> _products = new List<Product>();

        private static readonly List<Category> _categories = new List<Category>();


        static Repository()
        {
            _categories.Add(new Category() { CategoryId=1,Name="Telefon"});
            _categories.Add(new Category() { CategoryId = 2, Name = "Bilgisayar" });
            

            _products.Add(new Product() { ProductId=1,Name="Iphone 14",Price=50000,Image="1.jpg",IsActive=true,CategoryId=1 });
            _products.Add(new Product() { ProductId = 2, Name = "Iphone 13", Price = 40000, Image = "2.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product() { ProductId = 3, Name = "Samsung Galaxy S23", Price = 35000, Image = "3.jpg", IsActive = true, CategoryId = 1 });
            _products.Add(new Product() { ProductId = 4, Name = "Redmi Note5", Price = 15000, Image = "4.jpg", IsActive = false, CategoryId = 1 });
            _products.Add(new Product() { ProductId = 5, Name = "Macbook Pro", Price = 25000, Image = "5.jpg", IsActive = true, CategoryId = 2 });
            _products.Add(new Product() { ProductId = 6, Name = "Macbook Air", Price = 20000, Image = "6.jpg", IsActive = false, CategoryId = 2 });
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

        public static void CreateProduct(Product product)
        {
            _products.Add(product);
        }

        public static void EditProduct(Product updatedProduct)
        {
            var entity = _products.FirstOrDefault(p=> p.ProductId== updatedProduct.ProductId);
            if (entity != null)
            {
                entity.Name = updatedProduct.Name;
                entity.Price = updatedProduct.Price;
                entity.IsActive = updatedProduct.IsActive;
                entity.CategoryId = updatedProduct.CategoryId;
                entity.Image= updatedProduct.Image;
      
            }

        }

        public static void EditIsActive(Product updatedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);
            if (entity != null)
            {

                entity.IsActive = updatedProduct.IsActive;

            }

        }

        public static void DeleteProduct(Product deletedProduct)
        {
            var entity = _products.FirstOrDefault(p => p.ProductId == deletedProduct.ProductId);
            if (entity != null)
            {
                Products.Remove(entity);

            }

        }
    }
}
