using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SOTFModMenu.Components.Validation
{
    public static class Validate
    {
        public static bool IsValidItemId(int itemID)
        {
            string workingDirectory = $"{Environment.CurrentDirectory}\\BepInEx\\plugins\\ItemList.json";
            string data = File.ReadAllText(workingDirectory);

            JArray jsonData = JArray.Parse(data);

            bool found = false;

            for (int i = 0; i < jsonData.Count; ++i)
            {
                dynamic item = jsonData[i];

                if ((int)item.ID != itemID)
                {
                    continue;
                }

                found = true;
                break;
            }

            if (!found)
            {
                return false;
            }

            return true;
        }
    }
}