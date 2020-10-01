using PartyService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestPartyService
{
    
    
    /// <summary>
    ///This is a test class for PartyTest and is intended
    ///to contain all PartyTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PartyTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for CalculateCleaningCosts
        ///</summary>
        [TestMethod()]
        public void T01_Constructor()
        {
            Assert.IsTrue(typeof(Party).IsAbstract,"Klasse Party sollte abstract sein!");
            DinnerParty d1 = new DinnerParty(10, false);
            BirthdayParty b1 = new BirthdayParty(20, true, "Hello");
            Assert.AreEqual(10, d1.NumberOfPeople, "10 Personen sollten auf der Dinnerparty sein!");
            Assert.AreEqual(20,b1.NumberOfPeople, "20 Personen sollten auf der Geburtstagsparty sein!");
            Assert.AreEqual(false,d1.FancyDecorations,  "Dinnerparty sollte keine ausgefallene Deco haben!");
            Assert.AreEqual(true, b1.FancyDecorations,  "Geburtstagsparty sollte ausgefallene Deco haben!");
        }


        /// <summary>
        ///A test for CalculateDecorationCosts
        ///</summary>
        [TestMethod()]
        public void T02_CalculateDecorationCostsTest()
        {
            DinnerParty d1 = new DinnerParty(10, false);
            Assert.AreEqual(30 + 7.5 * 10, d1.CalculateDecorationCosts(),0.1, "Falsche Decokosten bei DinnerParty!");
            BirthdayParty b1 = new BirthdayParty(20, true, "Hello");
            Assert.AreEqual(50 + 15 * 20, b1.CalculateDecorationCosts(),0.1, "Falsche Decokosten bei Geburtstagsparty!");
        }

        /// <summary>
        ///A test for CalculateCleaningCosts
        ///</summary>
        [TestMethod()]
        public void T03_CalculateCleaningCostsTest()
        {
            DinnerParty d1 = new DinnerParty(10, false);
            Assert.AreEqual(105*0.10, d1.CalculateCleaningCosts(), 0.1, "Falsche Reinigungskosten bei DinnerParty!");
            BirthdayParty b1 = new BirthdayParty(20, true, "Hello");
            Assert.AreEqual(350 * 0.15, b1.CalculateCleaningCosts(), 0.1, "Falsche Reinigungskosten bei Geburtstagsparty!");
        }
        
        
        /// <summary>
        ///A test for CalculateCosts
        ///</summary>
        [TestMethod()]
        public void T04_CalculateCostsOfDinnerPartyTest()
        {
            DinnerParty d1 = new DinnerParty(10, false);
            Assert.AreEqual(105 + 10.5 + 10 * 25, d1.CalculateCosts(), 0.1, "Dinnerparty mit normaler Deco liefert falsche Kosten!");
            d1 = new DinnerParty(100, true);
            Assert.AreEqual(1550 + 1550*0.10 + 100 * 25, d1.CalculateCosts(), 0.1, "Dinnerparty mit spezieller Deco liefert falsche Kosten!");
        }

        /// <summary>
        ///A test for CalculateCosts
        ///</summary>
        [TestMethod()]
        public void T05_CalculateCostsOfBirthdayPartyTest()
        {
            BirthdayParty b1 = new BirthdayParty(20, true, "");
            Assert.AreEqual(350 + 350*0.15 + 20 * 25+75, b1.CalculateCosts(), 0.1, "Birthdayparty mit normaler Deco und unbeschrifteten Kuchen liefert falsche Kosten!");

            b1 = new BirthdayParty(20, true, "Hallo");
            Assert.AreEqual(350 + 350 * 0.15 + 20 * 25 + 75+0.25*5, b1.CalculateCosts(), 0.1, "Birthdayparty mit normaler Deco und beschrifteten Kuchen (5 Zeichen) liefert falsche Kosten!");

            b1 = new BirthdayParty(1, true, "");
            Assert.AreEqual(65 + 65 * 0.15 + 1 * 25 + 40 , b1.CalculateCosts(), 0.1, "Birthdayparty mit normaler Deco und unbeschr. kleinen Kuchen liefert falsche Kosten!");

            b1 = new BirthdayParty(1, true, "Dies sind sicherlich zuviele Zeichen für einen kleinen Kuchen");
            Assert.AreEqual(65 + 65 * 0.15 + 1 * 25 + 40+0.25*16, b1.CalculateCosts(), 0.1, "Birthdayparty mit normaler Deco und beschrifteten kleinen Kuchen (max. Zeichenzahl) liefert falsche Kosten!");

        }

        /// <summary>
        ///A test for CalculateCosts
        ///</summary>
        [TestMethod()]
        public void T06_PropertyCakeWritingTest()
        {
            BirthdayParty b1 = new BirthdayParty(1, true, "Dies sind sicherlich zuviele Zeichen für einen kleinen Kuchen");
            Assert.AreEqual("Dies sind sicher", b1.CakeWriting,  "Property CakeWriting liefert den Text nicht in der tatsächlich möglichen Länge!");
            b1 = new BirthdayParty(1000, true, "Dies sind sicherlich zuviele Zeichen für einen kleinen Kuchen");
            Assert.AreEqual(40, b1.CakeWriting.Length, "Property CakeWriting liefert den Text, bei einem großen Kuchen, nicht in der tatsächlich möglichen Länge!");
        }

        



    }
}
