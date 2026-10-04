using System;
using System.Collections.Generic;

namespace InternationalCallingConnoisseur
{
    public static class DialingCodes
    {
        public static Dictionary<int, string> GetEmptyDictionary()
        {
            return new Dictionary<int, string>();
        }

               public static Dictionary<int, string> GetExistingDictionary()
        {
            return new Dictionary<int, string>
            {
                { 1, "United States of America" },
                { 55, "Brazil" },
                { 98, "Iran" }
            };
        }

        public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
        {
            var dict = GetEmptyDictionary();
            dict.Add(countryCode, countryName);
            return dict;
        }

          public static Dictionary<int, string> AddCountryToExistingDictionary(
            Dictionary<int, string> existingDictionary, int countryCode, string countryName)
        {
            existingDictionary.Add(countryCode, countryName);
            return existingDictionary;
        }

        public static string GetCountryNameFromDictionary(
            Dictionary<int, string> existingDictionary, int countryCode)
        {
            if (existingDictionary.TryGetValue(countryCode, out string countryName))
            {
                return countryName;
            }
            return string.Empty;
        }

           public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
        {
            return existingDictionary.ContainsKey(countryCode);
        }

           public static Dictionary<int, string> UpdateDictionary(
            Dictionary<int, string> existingDictionary, int countryCode, string countryName)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary[countryCode] = countryName;
            }
            return existingDictionary;
        }

           public static Dictionary<int, string> RemoveCountryFromDictionary(
            Dictionary<int, string> existingDictionary, int countryCode)
        {
            existingDictionary.Remove(countryCode);
            return existingDictionary;
        }

           public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
        {
            string longestName = string.Empty;

            foreach (var countryName in existingDictionary.Values)
            {
                if (countryName.Length > longestName.Length)
                {
                    longestName = countryName;
                }
            }

            return longestName;
        }
    }

      internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Pruebas de DialingCodes ---");
 
            var dict = DialingCodes.GetExistingDictionary();
            Console.WriteLine($"Conteo inicial: {dict.Count} países");

            DialingCodes.AddCountryToExistingDictionary(dict, 44, "Russia");
            Console.WriteLine($"País con código 7: {DialingCodes.GetCountryNameFromDictionary(dict, 44)}");

            Console.WriteLine($"¿Existe el código 55 (Brasil)?: {DialingCodes.CheckCodeExists(dict, 55)}");

            DialingCodes.UpdateDictionary(dict, 1, "Los Estados Unidos");
            Console.WriteLine($"Código 1 actualizado: {dict[1]}");

            //País con el nombre más largo
            string longest = DialingCodes.FindLongestCountryName(dict);
            Console.WriteLine($"Nombre más largo: {longest}");

            DialingCodes.RemoveCountryFromDictionary(dict, 91);
            Console.WriteLine($"¿Existe el código 98 tras eliminarlo?: {DialingCodes.CheckCodeExists(dict, 98)}");
        }
    }
}