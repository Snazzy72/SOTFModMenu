using System.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SOTFModMenu.Components.Utility
{
    internal class CSV_TO_JSON_CONVERTER
    {
        static void ConvertCSV()
        {
            var csv = new List<string[]>();
            var itemData = File.ReadAllLines("./ItemList.csv");

            foreach (string item in itemData)
            {
                csv.Add(item.Split(','));
            }

            var itemProperties = itemData[0].Split(',');
            var listObject = new List<Dictionary<string, string>>();

            for (int i = 1; i < itemData.Length; ++i)
            {
                var objectResult = new Dictionary<string, string>();
                for (int j = 0; j < itemProperties.Length; ++j)
                {
                    objectResult.Add(itemProperties[j], csv[i][j]);
                }

                listObject.Add(objectResult);
            }

            var json = JsonConvert.SerializeObject(listObject);
            File.WriteAllText(@"./ItemList.json", json);
        }
    }
}
