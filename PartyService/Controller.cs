using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyService
{
    public class Controller
    {
        private List<Party> _parties = new List<Party>();

        public List<Party> PartyList
        {
            get
            {
                return _parties;
            }
        }

        public int CountDinnerParties
        {
            get
            {
                int numberOfParties = 0;
                foreach (Party party in _parties)
                {
                    if (party is DinnerParty)
                    {
                        numberOfParties++;
                    }
                }
                return numberOfParties;
            }
        }

        public int CountBirthdayParties
        {
            get
            {
                int numberOfParties = 0;
                foreach (Party party in _parties)
                {
                    if (party is BirthdayParty)
                    {
                        numberOfParties++;
                    }
                }
                return numberOfParties;
            }
        }

        public void AddParty(Party party)
        {
            _parties.Add(party);
            _parties.Sort();
        }

        public double CalculateTotalCosts()
        {
            double totalCosts = 0.0;
            foreach (Party party in _parties)
            {
                totalCosts += party.CalculateCosts();
            }
            return totalCosts;
        }
    }
}