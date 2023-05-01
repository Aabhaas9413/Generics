using Generics.GenericCase;
using Generics.Models;

namespace Generics { 
public class Program{

		public static void Main()
		{
			RunApp();
		}
        public static void RunApp()
		{
            //save person in excel
			var people = new List<Person>();
			PopulatePeople(people);

			var path = @"C:\Users\aabha\person.csv";
			LoadOrSaveGenerics generic = new LoadOrSaveGenerics(); 
			generic.saveData(people, path); //generic method


            //save product in excel
            var product = new List<Product>();
            PopulateProduct(product);

            var pathProd = @"C:\Users\aabha\product.csv";
            generic.saveData(product, pathProd); //generoic method

        }
		private static void PopulatePeople(List<Person> people)
		{
			var person = new Person() { FirstName = "Aabhaas-1", LastName = "Ma", Id = 1 };
			people.Add(person);
            var personTwo = new Person() { FirstName = "Shivangi", LastName = "Mu", Id = 2 };
            people.Add(personTwo);
        }

        private static void PopulateProduct(List<Product> products)
        {
            var product = new Product() { Name = "Bulb", Description = "Light bulb", Id = 1 };
            products.Add(product);
            var productTwo = new Product() { Name = "Baloon", Description = "Light baloon", Id = 2 };
            products.Add(productTwo);
        }
    }
}