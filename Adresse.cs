using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vertrieb
{
    public class Adresse
    {
        //Felder
        public string strasse;
        public string hausNr;
        public string plz;
        public string ort;

        //Methoden
        public override string ToString()
        {
            string s = $"Adresse: \t{strasse} {hausNr}\n\t\t{plz} {ort}";

            return s; 
        }
    }
}
