using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PartyService;
using System.IO;

namespace ConsoleParty
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isFancy;
            Controller controller=new Controller();
            StreamReader sr = new StreamReader("Parties.csv",Encoding.Default);
            //Überschrift überlesen
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] columns = sr.ReadLine().Split(';');
                if (columns[2].ToLower() == "ja")  //Text der Spalte Spezielle Deko in Bool umwandeln
                    isFancy = true;
                else
                    isFancy = false;

                if (columns[0] == "B") //Geburtstagsparty
                {
                    controller.AddParty(new BirthdayParty(Convert.ToInt32(columns[1]), isFancy, columns[3]));
                }
                else if (columns[1] == "D") //Dinnerparty
                {
                    controller.AddParty(new DinnerParty(Convert.ToInt32(columns[1]), isFancy));
                }
            }
            sr.Close();  //Datei schließen nicht vergessen!
            Console.WriteLine("Gesamtkosten aller Partys: {0:f2}", controller.CalculateTotalCosts());
            Console.ReadLine();
        }
    }
}
