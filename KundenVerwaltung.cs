using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Vertrieb
{
    static class KundenVerwaltung
    {
        public static List<Kunde> kundenListe = new List<Kunde>();
        public static string pfad = @"C:\Test\Kundenliste.xml";

        public static void Menue()
        {
            Console.Clear();
            Console.WriteLine("             Lug & Trug AG");
            Console.WriteLine("             -------------");
            Console.WriteLine();
            Console.WriteLine("(1)  Alle Kunden anzeigen");
            Console.WriteLine("(2)  Neuen Kunden anlegen");
            Console.WriteLine("(3)  Kundendaten ändern");
            Console.WriteLine("(4)  Aktiv / Inaktiv");
            Console.WriteLine("(5)  Programmende");
            Console.WriteLine();
            Console.Write("Bitte treffen Sie Ihre Auswahl: ");

            switch (Console.ReadLine())
            {
                case "1":
                    KundenAnzeigen();
                    break;
                case "2":
                    KundenAnlegen();
                    break;
                case "3":
                    KundenDatenAendern();
                    break;
                case "4":
                    AktivInaktiv();
                    break;
                case "5":
                    Speichern();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Bitte nur die oben angezeigten Optionen wählen.");
                    Console.WriteLine("Weiter mit beliebiger Taste");
                    Console.ReadKey();
                    break;
            }
        }
        public static void KundenAnzeigen()
        {
            Console.Clear();

            if (kundenListe.Count == 0)
            {
                Console.WriteLine("Leider kein Kunde vorhanden :(");
            }

            foreach (Kunde item in kundenListe)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine();
                Console.WriteLine("---------------------------------");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Weiter mit beliebiger Taste...");
            Console.ReadKey();
        }
        public static void KundenAnlegen()
        {
            bool check;

            Console.Clear();

            kundenListe.Add(new Kunde());

            //Eingabe KundenNummer
            do
            {
                Console.Write("Bitte geben Sie die Kundennummer ein: ");
                check = int.TryParse(Console.ReadLine(), out kundenListe[kundenListe.Count - 1].kdNr);
                if (!check)
                    Console.WriteLine("Bitte nur Ziffern eingeben. Danke!");
                else
                    check = KundenNrUeberpruefen(kundenListe[kundenListe.Count - 1].kdNr);
            } while (!check);

            //Eingabe Name des Kunden
            Console.Write("Name des Kunden: ");
            kundenListe[kundenListe.Count - 1].kdName = Console.ReadLine();

            //Eingabe Adresse
            Console.WriteLine("Kundenanschrift:");
            Console.Write("Die Strasse: ");
            kundenListe[kundenListe.Count - 1].kdAdresse.strasse = Console.ReadLine();

            Console.Write("Die Hausnummer: ");
            kundenListe[kundenListe.Count - 1].kdAdresse.hausNr = Console.ReadLine();

            Console.Write("Die Postleitzahl: ");
            kundenListe[kundenListe.Count - 1].kdAdresse.plz = Console.ReadLine();

            Console.Write("Der Ort: ");
            kundenListe[kundenListe.Count - 1].kdAdresse.ort = Console.ReadLine();

            //Eingabe Ansprechpartner
            Console.Write("Der/die Ansprechpartner/in: ");
            kundenListe[kundenListe.Count - 1].kdAnsprech = Console.ReadLine();

            //Eingabe TelefonNr
            Console.Write("Telefonnummer: ");
            kundenListe[kundenListe.Count - 1].kdTel = Console.ReadLine();

            kundenListe[kundenListe.Count - 1].kdAktiv = true;

            Console.Clear();
            Console.WriteLine("Kunde erfolgreich angelegt!");
            Console.WriteLine("Weiter mit beliebiger Taste...");
            Console.ReadKey();
        }
        public static void KundenDatenAendern()
        {
            bool check;
            int kdNr;

            Console.Clear();
            foreach (Kunde item in kundenListe)
            {
                Console.WriteLine(item.kdNr + "    " + item.kdName);
            }

            do
            {
                Console.Write("Bitte geben Sie die Kundennummer ein: ");
                check = int.TryParse(Console.ReadLine(), out kdNr);
                if (!check)
                    Console.WriteLine("Bitte nur Ziffern eingeben. Danke!");
            } while (!check);

            check = false;
            foreach (Kunde item in kundenListe)
            {
                if (kdNr == item.kdNr)
                {
                    check = true;
                    DatenAendern(item);
                }
            }

            if (!check)
            {
                Console.WriteLine("Kundenummer nicht gefunden!");
            }

            Console.WriteLine("Weiter mit beliebiger Taste...");
            Console.ReadKey();
        }
        public static void DatenAendern(Kunde k)
        {
            Console.Clear();

            //Eingabe Name des Kunden
            Console.Write("Name des Kunden: ");
            k.kdName = Console.ReadLine();

            //Eingabe Adresse
            Console.WriteLine("Kundenanschrift:");
            Console.Write("Die Strasse: ");
            k.kdAdresse.strasse = Console.ReadLine();

            Console.Write("Die Hausnummer: ");
            k.kdAdresse.hausNr = Console.ReadLine();

            Console.Write("Die Postleitzahl: ");
            k.kdAdresse.plz = Console.ReadLine();

            Console.Write("Der Ort: ");
            k.kdAdresse.ort = Console.ReadLine();

            //Eingabe Ansprechpartner
            Console.Write("Der/die Ansprechpartner/in: ");
            k.kdAnsprech = Console.ReadLine();

            //Eingabe TelefonNr
            Console.Write("Telefonnummer: ");
            k.kdTel = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Kunde erfolgreich geändert!");
        }
        public static void AktivInaktiv()
        {
            bool check;
            int kdNr;

            Console.Clear();
            foreach (Kunde item in kundenListe)
            {
                Console.WriteLine(item.kdNr + "    " + item.kdName + "    " + item.kdAktiv);
            }

            do
            {
                Console.Write("Bitte geben Sie die Kundennummer ein: ");
                check = int.TryParse(Console.ReadLine(), out kdNr);
                if (!check)
                    Console.WriteLine("Bitte nur Ziffern eingeben. Danke!");
            } while (!check);

            check = false;
            foreach (Kunde item in kundenListe)
            {
                if (kdNr == item.kdNr)
                {
                    check = true;

                    if (item.kdAktiv)
                        item.kdAktiv = false;
                    else
                        item.kdAktiv = true;
                }
            }

            if (!check)
            {
                Console.WriteLine("Kundenummer nicht gefunden!");
            }

            Console.WriteLine("Weiter mit beliebiger Taste...");
            Console.ReadKey();
        }
        public static bool KundenNrUeberpruefen(int kdNr)
        {
            for (int i = 0; i < kundenListe.Count - 1; i++)
            {
                if (kdNr == kundenListe[i].kdNr)
                {
                    Console.WriteLine("Kundennummer bereits vorhanden");
                    return false;
                }
            }

            return true;
        }
        public static void Laden()
        {
            if (File.Exists(pfad))
            {
                XmlSerializer laden = new XmlSerializer(typeof(List<Kunde>));

                using (StreamReader lesen = new StreamReader(pfad))
                {
                    kundenListe = (List<Kunde>)laden.Deserialize(lesen);
                }
            }
        }
        public static void Speichern()
        {
            XmlSerializer speichern = new XmlSerializer(typeof(List<Kunde>));

            using (StreamWriter schreiben = new StreamWriter(pfad, false))
            {
                speichern.Serialize(schreiben, kundenListe);
            }

            Console.Clear();
            Console.WriteLine("Daten erfolgreich gespeichert.");
            Console.WriteLine("Beenden mit beliebiger Taste...");
            Console.ReadKey();
        }
    }
}
