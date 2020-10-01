using PartyService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestPartyService
{
    
    
    /// <summary>
    ///This is a test class for ControllerTest and is intended
    ///to contain all ControllerTest Unit Tesst
    ///</summary>
    [TestClass()]
    public class ControllerTest
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
        ///A test for AddParty
        ///</summary>
        [TestMethod()]
        public void T07_AddPartyTest()
        {
            Controller target = new Controller(); // TODO: Initialize to an appropriate value
            DinnerParty d1 = new DinnerParty(10, false);
            target.AddParty(d1);
            Assert.AreEqual(1, target.PartyList.Count, "Nach einer hinzugefügten Party sollte eine Party in der Collection sein!");
            BirthdayParty b1 = new BirthdayParty(20, true, "Hello");
            target.AddParty(b1);
            Assert.AreEqual(2, target.PartyList.Count, "Nach zwei hinzugefügten Party sollten zwei Party in der Collection sein!");
            
        }

        /// <summary>
        ///A test for AddParty
        ///</summary>
        [TestMethod()]
        public void T08_AddPartyOrderedTest()
        {
            Controller target = new Controller(); // TODO: Initialize to an appropriate value
            DinnerParty d1 = new DinnerParty(10, false);
            target.AddParty(d1);
            BirthdayParty b1 = new BirthdayParty(20, true, "Hello");
            target.AddParty(b1);
            Assert.AreEqual(2, target.PartyList.Count, "Nach zwei hinzugefügten Party sollten zwei Party in der Collection sein!");
            Assert.AreEqual(b1, target.PartyList[0], "Die teuerste Party sollte an erster Stelle der Liste stehen!");
            target.AddParty(new DinnerParty(100, true));
            Assert.AreEqual(b1, target.PartyList[1], "Die teuerste Party sollte an erster Stelle der Liste stehen!");
            target.AddParty(new DinnerParty(1, false));
            Assert.AreEqual(1, target.PartyList[3].NumberOfPeople, "Die günstigste Party sollte an letzter Stelle der Liste stehen!");
            target.AddParty(new DinnerParty(2, false));
            Assert.AreEqual(2, target.PartyList[3].NumberOfPeople, "Die zweitgünstigste Party sollte an vorletzter Stelle der Liste stehen!");
        }

        /// <summary>
        ///A test for CalculateTotalCosts
        ///</summary>
        [TestMethod()]
        public void T09_CalculateTotalCostsTest()
        {
            Controller target = new Controller(); // TODO: Initialize to an appropriate value
            DinnerParty d1 = new DinnerParty(10, false);
            Assert.AreEqual(105 + 10.5 + 10 * 25, d1.CalculateCosts(), 0.1, "Dinnerparty mit normaler Deco liefert falsche Kosten!");
            target.AddParty(d1);
            d1 = new DinnerParty(100, true);
            Assert.AreEqual(1550 + 1550 * 0.10 + 100 * 25, d1.CalculateCosts(), 0.1, "Dinnerparty mit spezieller Deco liefert falsche Kosten!");
            target.AddParty(d1);
            BirthdayParty b1 = new BirthdayParty(20, true, "");
            target.AddParty(b1);
            Assert.AreEqual(350 + 350 * 0.15 + 20 * 25 + 75 + 1550 + 1550 * 0.10 + 100 * 25 + 105 + 10.5 + 10 * 25, target.CalculateTotalCosts(), 0.1, "Birthdayparty mit normaler Deco und unbeschrifteten Kuchen liefert falsche Kosten!");
        
        }

        /// <summary>
        ///A test for CountBirthdayParties
        ///</summary>
        [TestMethod()]
        public void T10_CountBirthdayPartiesTest()
        {
            Controller target = new Controller(); // TODO: Initialize to an appropriate value
            DinnerParty d1 = new DinnerParty(10, false);
            target.AddParty(d1);
            Assert.AreEqual(0, target.CountBirthdayParties, "Es ist keine Geburtstagspartys in der Liste!");
            BirthdayParty b1 = new BirthdayParty(20, true, "Hello");
            target.AddParty(b1);
            target.AddParty(new DinnerParty(100, true));
            target.AddParty(new BirthdayParty(1, false,""));
            target.AddParty(new DinnerParty(2, false));
            Assert.AreEqual(2, target.CountBirthdayParties, "Es sind zwei Geburtstagspartys in der Liste!");
        }

        /// <summary>
        ///A test for CountDinnerParties
        ///</summary>
        [TestMethod()]
        public void T11_CountDinnerPartiesTest()
        {
            Controller target = new Controller(); // TODO: Initialize to an appropriate value
            DinnerParty d1 = new DinnerParty(10, false);
            target.AddParty(d1);
            Assert.AreEqual(1, target.CountDinnerParties, "Es ist eine Dinnerparty in der Liste!");
            BirthdayParty b1 = new BirthdayParty(20, true, "Hello");
            target.AddParty(b1);
            target.AddParty(new DinnerParty(100, true));
            target.AddParty(new BirthdayParty(1, false,""));
            target.AddParty(new DinnerParty(2, false));
            Assert.AreEqual(3, target.CountDinnerParties, "Es sind drei Dinnerpartys in der Liste!");
        }
    }
}
