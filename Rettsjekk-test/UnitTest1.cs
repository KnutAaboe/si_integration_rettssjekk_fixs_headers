using NUnit.Framework;
using Rettsjekk_Register;
using Rettsjekk_Register.Controllers;
using Rettsjekk_Register.Data;

namespace Rettsjekk_test
{
    [TestFixture]
    public class Tests
    {
        private readonly CourtCheck data = new();

        [Test]
        public void NoTrials()
        {
            //Vatnum 1
            string vatnum = "1";
            string chosenDate = "";
            Assert.IsNull(data.TrialsSearch(vatnum, chosenDate));
        }

        [Test]
        public void CaseOfBankruptcy()
        {
            string vatnum = "822393462";
            Assert.IsNotNull(data.BankruptcySearch(vatnum));
        }

        [Test]
        public void CaseOfSolvent()
        {
            string vatnum = "922704872";
            Assert.IsNotNull(data.SolventSearch(vatnum));
        }

        [Test]
        public void OneOrMoreTrials()
        {
            string vatnum = "822393462";
            string chosenDate = "";
            Assert.IsNotNull(data.TrialsSearch(vatnum, chosenDate));
        }

        [Test]
        public void OneOrMoreTrialsWithDate()
        {
            string vatnum = "835302202";
            string chosenDate = "2021-05-28 00:00:00";
            string chosenDate2 = "2021-00-00 00:00:00";
            Assert.IsNotNull(data.TrialsSearch(vatnum, chosenDate));
            Assert.IsNotNull(data.TrialsSearch(vatnum, chosenDate2));
        }
    }
}