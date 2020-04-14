using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryptor
{
    class TranslateText
    {
        string path = ".\\lang";
        Langs lang;
        public TranslateText(Langs lang)
        {
            this.lang = lang;
        }


    }

    public enum Langs
    {
        lang_pol,
        lang_eng,
    }
}
