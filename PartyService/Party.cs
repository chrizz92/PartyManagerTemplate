using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartyService
{
    /// <summary>
    /// Die abstrakte Basisklasse Party.
    /// <para>
    /// Stellt alle Felder, Methoden und Properties
    /// zur Verfügung, die für jede Art von Party gelten.
    /// </para>
    /// </summary>
    public abstract class Party : IComparable
    {
        //Konstante
        public const int CostOfFoodPerPerson = 25;         // Kosten der Speisen pro Person

        public const double BaseDecorationFeePerPerson = 7.50;    // Kleine Dekorationsgebühr pro Person
        public const double IncreasedDecorationFeePerPerson = 15; // Große Dekorationsgebühr pro Person
        public const double BaseDecorationFee = 30.0;             // Kleine Dekorationspauschale
        public const double IncreasedDecorationFee = 50.0;        // Große Dekorationspauschale

        private int _numberOfPeople;
        private bool _fancyDecoration;

        public bool FancyDecorations
        {
            get { return _fancyDecoration; }
        }

        public int NumberOfPeople
        {
            get { return _numberOfPeople; }
        }

        public Party(int numberOfPeople, bool fancyDecoration)
        {
            _numberOfPeople = numberOfPeople;
            _fancyDecoration = fancyDecoration;
        }

        public abstract double CalculateCleaningCosts();

        public double CalculateDecorationCosts()
        {
            double decorationCost = 0.0;
            if (FancyDecorations)
            {
                decorationCost += IncreasedDecorationFee + (IncreasedDecorationFeePerPerson * NumberOfPeople);
            }
            else
            {
                decorationCost += BaseDecorationFee + (BaseDecorationFeePerPerson * NumberOfPeople);
            }
            return decorationCost;
        }

        public virtual double CalculateCosts()
        {
            return (NumberOfPeople * CostOfFoodPerPerson) + CalculateCleaningCosts() + CalculateDecorationCosts();
        }

        public int CompareTo(object obj)
        {
            if ((obj as Party).CalculateCosts() < CalculateCosts())
            {
                return -1;
            }
            else if ((obj as Party).CalculateCosts() == CalculateCosts())
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}