
using BtokHub_MyPlans.BrokHub.BrokModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BtokHub_MyPlans.BrokHub.BrokData
{
    [Serializable]
    public static class BrokConverterXML
    {
        private readonly static string path = "BrokData\\BrokData.json";
        public static async Task WriteData(List<Plan>? plans)
        {
            try
            {
                if (!File.Exists(path))
                    await File.Create("BrokData\\BrokData.json").DisposeAsync();

                string json = JsonSerializer.Serialize(plans);
                using StreamWriter writer = new StreamWriter(path);
                await writer.WriteLineAsync(json);
            }
            catch (ObjectDisposedException invalid)
            {
                throw new ObjectDisposedException(invalid.Message);
            }
        }
        public static ObservableCollection<Plan>? ReadData()
        {
            try
            {
                if (!File.Exists(path))
                    throw new NullReferenceException("Not Found File");
                using StreamReader reader = new StreamReader(path);
                return JsonSerializer.Deserialize<ObservableCollection<Plan>>(reader.ReadToEnd());
            }
            catch (InvalidOperationException invalid)
            {
                throw new InvalidOperationException(invalid.Message);
            }
        }
    }
}
