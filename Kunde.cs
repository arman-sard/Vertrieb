using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vertrieb
{
    public class Kunde
    {
        //Felder
        public int kdNr;
        public string kdName;
        public Adresse kdAdresse = new Adresse();
        public string kdAnsprech;
        public string kdTel;
        public bool kdAktiv;

        //Methoden
        public override string ToString()
        {
            string s = $"Kundennummer:\t{kdNr}\nName:\t\t{kdName}\n" + kdAdresse.ToString() +
                $"\nAnsprechpartner:{kdAnsprech}\nTelefon: \t{kdTel}\nAktiv? \t\t{kdAktiv}";

            return s; 
        }
    }
}
