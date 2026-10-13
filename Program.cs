using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LINQAssignment01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Assuming ProductList and CustomerList are provided by ListGenerators.cs
            var productList = ListGenerators.ProductList;
            var customerList = ListGenerators.CustomerList;

            // ==========================================
            // LINQ - Restriction Operators
            // ==========================================
            Console.WriteLine("=== LINQ - Restriction Operators ===");

            // 1. Find all products that are out of stock[cite: 4]
            var outOfStockProducts = productList.Where(p => p.UnitsInStock == 0);

            // 2. Find all products that are in stock and cost more than 3.00 per unit[cite: 4]
            var expensiveInStockProducts = productList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00m);

            // 3. Returns digits whose name is shorter than their value[cite: 4]
            string[] digitsArr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var shorterDigits = digitsArr.Where((digit, index) => digit.Length < index);


            // ==========================================
            // LINQ - Element Operators
            // ==========================================
            Console.WriteLine("\n=== LINQ - Element Operators ===");

            // 1. Get first Product out of Stock[cite: 4]
            var firstOutOfStock = productList.FirstOrDefault(p => p.UnitsInStock == 0);

            // 2. Return the first product whose Price > 1000, unless there is no match (returns null)[cite: 4]
            var firstExpensiveProduct = productList.FirstOrDefault(p => p.UnitPrice > 1000m);

            // 3. Retrieve the second number greater than 5[cite: 4]
            int[] numbersArr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var secondGreaterThanFive = numbersArr.Where(n => n > 5).ElementAtOrDefault(1);


            // ==========================================
            // LINQ - Aggregate Operators
            // ==========================================
            Console.WriteLine("\n=== LINQ - Aggregate Operators ===");

            // 1. Uses Count to get the number of odd numbers in the array[cite: 4]
            int oddNumbersCount = numbersArr.Count(n => n % 2 != 0);

            // 2. Return a list of customers and how many orders each has[cite: 4]
            var customerOrdersCount = customerList.Select(c => new
            {
                CustomerName = c.CustomerName,
                OrderCount = c.Orders.Length
            });

            // 3. Return a list of categories and how many products each has[cite: 4]
            var categoryProductsCount = productList.GroupBy(p => p.Category)
                                                   .Select(g => new
                                                   {
                                                       Category = g.Key,
                                                       ProductCount = g.Count()
                                                   });

            // 4. Get the total of the numbers in an array[cite: 4]
            int totalSum = numbersArr.Sum();

            // Reading dictionary_english.txt into array of strings[cite: 4]
            string[] englishWords = File.Exists("dictionary_english.txt") 
                ? File.ReadAllLines("dictionary_english.txt") 
                : Array.Empty<string>();

            // 5. Total number of characters of all words in dictionary_english.txt[cite: 4]
            long totalCharacters = englishWords.Sum(w => (long)w.Length);

            // 6. Length of the shortest word in dictionary_english.txt[cite: 4]
            int shortestLength = englishWords.Length > 0 ? englishWords.Min(w => w.Length) : 0;

            // 7. Length of the longest word in dictionary_english.txt[cite: 4]
            int longestLength = englishWords.Length > 0 ? englishWords.Max(w => w.Length) : 0;

            // 8. Average length of words in dictionary_english.txt[cite: 4]
            double averageLength = englishWords.Length > 0 ? englishWords.Average(w => w.Length) : 0;


            // ==========================================
            // LINQ - Ordering Operators
            // ==========================================
            Console.WriteLine("\n=== LINQ - Ordering Operators ===");

            // 1. Sort a list of products by name[cite: 4]
            var sortedProductsByName = productList.OrderBy(p => p.ProductName);

            // 2. Custom comparer for case-insensitive sort of words in array[cite: 4]
            string[] wordsArr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var caseInsensitiveSortedWords = wordsArr.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);

            // 3. Sort products by units in stock from highest to lowest[cite: 4]
            var sortedByStockDesc = productList.OrderByDescending(p => p.UnitsInStock);

            // 4. Sort digits by length of name, then alphabetically by name itself[cite: 4]
            string[] digitsArr2 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var sortedDigits = digitsArr2.OrderBy(d => d.Length).ThenBy(d => d);

            // 5. Sort by word length, then case-insensitive sort[cite: 4]
            var sortedByLengthThenCaseInsensitive = wordsArr.OrderBy(w => w.Length)
                                                             .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            // 6. Sort products by category, then by unit price descending[cite: 4]
            var sortedByCategoryAndPriceDesc = productList.OrderBy(p => p.Category)
                                                          .ThenByDescending(p => p.UnitPrice);

            // 7. Sort by word length, then case-insensitive descending[cite: 4]
            var sortedByLengthThenCaseInsensitiveDesc = wordsArr.OrderBy(w => w.Length)
                                                                 .ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);

            // 8. Digits whose second letter is 'i', reversed from original order[cite: 4]
            var reversedDigitsWithI = digitsArr2.Where(d => d.Length > 1 && d[1] == 'i').Reverse();


            // ==========================================
            // LINQ - Transformation Operators
            // ==========================================
            Console.WriteLine("\n=== LINQ - Transformation Operators ===");

            // 1. Sequence of just product names[cite: 4]
            var productNames = productList.Select(p => p.ProductName);

            // 2. Upper and lower case versions of words (Anonymous Types)[cite: 4]
            string[] wordsArr2 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            var wordCases = wordsArr2.Select(w => new
            {
                Upper = w.ToUpper(),
                Lower = w.ToLower()
            });

            // 3. Rename UnitPrice to Price in resulting anonymous type[cite: 4]
            var productRenamedPrice = productList.Select(p => new
            {
                p.ProductID,
                p.ProductName,
                Price = p.UnitPrice
            });

            // 4. Determine if int value matches position in array[cite: 4]
            int[] arrNumberPosition = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var numberPositionMatches = arrNumberPosition.Select((num, index) => new
            {
                Number = num,
                InPlace = num == index
            });

            Console.WriteLine("Number: In-place?");
            foreach (var item in numberPositionMatches)
            {
                Console.WriteLine($"{item.Number}: {item.InPlace}");
            }

            // 5. Pairs of numbers where number from numbersA < number from numbersB[cite: 4]
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs = from a in numbersA
                        from b in numbersB
                        where a < b
                        select new { a, b };

            Console.WriteLine("\nPairs where a < b:");
            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair.a} is less than {pair.b}");
            }

            // 6. Orders where order total < 500.00[cite: 4]
            var cheapOrders = customerList.SelectMany(c => c.Orders)
                                         .Where(o => o.Total < 500.00m);

            // 7. Orders made in 1998 or later[cite: 4]
            var recentOrders = customerList.SelectMany(c => c.Orders)
                                           .Where(o => o.OrderDate.Year >= 1998);
        }
    }
}