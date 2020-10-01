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
    public abstract class Party
    {
        //Konstante
        public const int CostOfFoodPerPerson = 25;         // Kosten der Speisen pro Person
        public const double BaseDecorationFeePerPerson = 7.50;    // Kleine Dekorationsgebühr pro Person
        public const double IncreasedDecorationFeePerPerson = 15; // Große Dekorationsgebühr pro Person
        public const double BaseDecorationFee = 30.0;             // Kleine Dekorationspauschale
        public const double IncreasedDecorationFee = 50.0;        // Große Dekorationspauschale

       
    }
}
