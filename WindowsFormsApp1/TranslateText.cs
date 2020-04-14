using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryptor
{
    class TranslateText
    {
        string pathToFolder = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName + "\\lang";
        public string[] TranslateToTable(Langs lang)
        {
            string pathToFile = pathToFolder;
            if(lang == Langs.lang_eng)
            {
                pathToFile += "\\lang_eng.lang";
            }
            else if(lang == Langs.lang_pol)
            {
                pathToFile += "\\lang_pol.lang";
            }
            string[] table = new string[13];
            using(StreamReader sr = new StreamReader(pathToFile))
            {
                for (int i = 0; i < 13; i++)
                {
                    table[i] = sr.ReadLine();
                }
            }
            return table;
        }
    }

    public enum Langs
    {
        lang_pol,
        lang_eng,
    }
}
