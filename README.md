# CompareList


 ```   
    public class Product : IComparableItem<Product>
    {
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public string GetKeysToFindAddedItems()
        {
            return Name;
        }

        public string GetKeysToFindDeletedItems()
        {
            return Name;
        }

        public string GetKeysToFindUpdatedItems()
        {
            return string.Format("{0}{1}",Name,Cost);
        }
    }
       ```
   
    //Then within main method
 
```class Program
    {
        static void Main(string[] args)
        {
            List<Product> newProductList = new List<Product> { new Product { Name = "TV", Cost = 400 }, new Product { Name = "USB", Cost=12 } };
            List<Product> oldProductList = new List<Product> { new Product { Name = "TV", Cost = 450 } , new Product { Name = "MP3 Player", Cost = 20 } };

            var comparer = new ListComparer<Product>(newProductList, oldProductList);
            var added = comparer.GetAddedItems();
            var deleted = comparer.GetDeletedItems();
            var updated = comparer.GetUpdatedItems();

            System.Console.WriteLine("Added product {0}",added.FirstOrDefault().Name);
            System.Console.WriteLine("Updated product {0}", updated.FirstOrDefault().Name);
            System.Console.WriteLine("Deleted product {0}", deleted.FirstOrDefault().Name);
        }
    }
```
