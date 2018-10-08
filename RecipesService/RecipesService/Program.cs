using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesService
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Run().Wait();
        }

        private static Service _service = new Service();

        async Task Run()
        {
            Console.WriteLine("Input at least 2 ingredients, type 0 to continue");
            var line = string.Empty;
            var ingredients = new List<string>();
            string food;
            int count = 1;

            while (true)
            {
                line = Console.ReadLine();
                if (line.Trim() == "0")
                {
                    if (ingredients.Count < 2)
                    {
                        Console.WriteLine("You must enter at least two ingredients");
                        continue;
                    }

                    break;
                }

                ingredients.Add(line);
            }

            Console.WriteLine("Input a food type");
            while (true)
            {
                line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("You must enter a food type");
                    continue;
                }

                food = line;
                break;
            }

            var response = await _service.GetRecipe(ingredients, food, 3);

            Console.WriteLine(response);

            var hrefs = response.Results.Select(c => c.Href);

            foreach (var href in hrefs)
                Process.Start("chrome.exe", href);

            Console.Read();
        }
    }
}
