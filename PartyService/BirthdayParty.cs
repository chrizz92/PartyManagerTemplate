using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyService
{
    public class BirthdayParty : Party
    {
        private string _cakeWriting;

        public string CakeWriting
        {
            get
            {
                if (NumberOfPeople > 4)
                {
                    if (_cakeWriting.Length <= 40)
                    {
                        return _cakeWriting;
                    }
                    else
                    {
                        return _cakeWriting.Substring(0, 40);
                    }
                }
                else
                {
                    if (_cakeWriting.Length <= 16)
                    {
                        return _cakeWriting;
                    }
                    else
                    {
                        return _cakeWriting.Substring(0, 16);
                    }
                }
            }
            set
            {
                _cakeWriting = value;
            }
        }

        public BirthdayParty(int numberOfPeople, bool fancyDecoration, string cakeWriting) : base(numberOfPeople, fancyDecoration)
        {
            CakeWriting = cakeWriting;
        }

        public override double CalculateCleaningCosts()
        {
            return CalculateDecorationCosts() * 0.15;
        }

        public override double CalculateCosts()
        {
            double costOfCake = 0.0;
            if (NumberOfPeople > 4)
            {
                costOfCake += 75;
            }
            else
            {
                costOfCake += 40;
            }

            costOfCake += CakeWriting.Length * 0.25;

            return base.CalculateCosts() + costOfCake;
        }
    }
}