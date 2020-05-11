using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace api_encryping.jsons
{
    public class JsonsToPaths
    {
        private class RootObject
        {
            private 
        }
        private const string PATH_TO_JSON = "./cache/secured/jsons";
        public JsonsToPaths()
        {
            if (!File.Exists(PATH_TO_JSON))
            {

            }
        }
    }
}
