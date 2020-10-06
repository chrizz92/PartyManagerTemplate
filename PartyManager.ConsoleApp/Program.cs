using System;
using System.IO;
using System.Text;
using PartyService;

namespace PartyManager.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] parties;
            string[] partyData;
            bool headingsNotRead = true;

            Controller controller = new Controller();

            parties = File.ReadAllLines("Parties.csv");

            foreach (string party in parties)
            {
                //Partytyp; Personenanzahl; Spezielle Deko; Tortentext;
                //B; 10; nein; Franz;
                //D; 15; nein; ;
                //D; 7; ja; ;
                //B; 5; ja; Happy Birthday;

                if (headingsNotRead)
                {
                    headingsNotRead = false;
                }
                else
                {
                    bool specialDecoration = false;
                    partyData = party.Split(';');
                    if (partyData[2].Contains("j"))
                    {
                        specialDecoration = true;
                    }
                    if (partyData[0].Contains("B"))
                    {
                        BirthdayParty birthdayParty = new BirthdayParty(Convert.ToInt32(partyData[1]), specialDecoration, partyData[3]);
                        controller.AddParty(birthdayParty);
                    }
                    else
                    {
                        DinnerParty dinnerParty = new DinnerParty(Convert.ToInt32(partyData[1]), specialDecoration);
                        controller.AddParty(dinnerParty);
                    }
                }
            }
            Console.WriteLine($"Gesamtkosten aller Parties: {controller.CalculateTotalCosts(),6}");
        }
    }
}