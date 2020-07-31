using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vertrieb
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test-Kunde
            //KundenVerwaltung.kundenListe.Add(new Kunde());
            //KundenVerwaltung.kundenListe[0].kdNr = 1111;
            //KundenVerwaltung.kundenListe[0].kdName = "Testkunden";
            //KundenVerwaltung.kundenListe[0].kdAdresse.strasse = "Testgasse";
            //KundenVerwaltung.kundenListe[0].kdAdresse.hausNr = "11/1";
            //KundenVerwaltung.kundenListe[0].kdAdresse.plz = "11111";
            //KundenVerwaltung.kundenListe[0].kdAdresse.ort = "Musterhausen";
            //KundenVerwaltung.kundenListe[0].kdAnsprech = "Paul Peters";
            //KundenVerwaltung.kundenListe[0].kdTel = "11-11";
            //KundenVerwaltung.kundenListe[0].kdAktiv = true;

            KundenVerwaltung.Laden();

            while (true)
            {
                KundenVerwaltung.Menue();
            }
        }
    }
}
