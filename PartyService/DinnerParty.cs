using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyService
{
    public class DinnerParty : Party
    {
        public DinnerParty(int numberOfPeople, bool fancyDecoration) : base(numberOfPeople, fancyDecoration)
        {
        }

        public override double CalculateCleaningCosts()
        {
            return CalculateDecorationCosts() * 0.1;
        }
    }
}