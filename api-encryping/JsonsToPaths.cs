using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            public List<FILEPATH> pathes { get; set; }
        }
        private const string PATH_TO_JSON = "./cache/secured/jsons/pathes.json";
        public JsonsToPaths()
        {
            if (!File.Exists(PATH_TO_JSON))
            {

            }
        }
        public void Serialize(FILEPATH _pathes)
        {
            RootObject ro = new RootObject() { pathes = new List<FILEPATH> { _pathes } };
            string json = JsonConvert.SerializeObject(ro, Formatting.Indented);
            File.WriteAllText(PATH_TO_JSON, json);
        }
    }
}
