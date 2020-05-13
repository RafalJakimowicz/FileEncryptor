using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace api_encryping.jsons
{
    public class FILEPATH 
    { 
        public string PrevFile { get; set; }
        public string NewFile { get; set; }
    }
    public class JsonsToPaths
    {
        private class RootObject
        {
            public List<FILEPATH> Pathes { get; set; }
        }
        private const string PATH_TO_JSON = "./cache/secured/jsons/pathes.json";
        public JsonsToPaths()
        {
            if (!File.Exists(PATH_TO_JSON))
            {
                Directory.CreateDirectory("./cache/secured/jsons");
                using (FileStream f = File.Create(PATH_TO_JSON)) { }
                Serialize(new List<FILEPATH>() { new FILEPATH() { NewFile = "", PrevFile = "" } });
            }
        }
        public void Serialize(List<FILEPATH> _pathes)
        {
            RootObject ro = new RootObject() { Pathes = _pathes};
            string json = JsonConvert.SerializeObject(ro, Formatting.Indented);
            File.WriteAllText(PATH_TO_JSON, json);
        }
        public List<FILEPATH> Deserialize()
        {
            JObject o = JObject.Parse(File.ReadAllText(PATH_TO_JSON));
            JArray a = (JArray)o["Pathes"];
            return a.ToObject<List<FILEPATH>>();
        }
    }
}
