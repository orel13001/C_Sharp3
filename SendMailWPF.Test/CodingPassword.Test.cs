using NUnit.Framework;
using SendMailWPF.Logic;


namespace SendMailWPF.Test
{
    public class CodingPasswordTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ToCodingPasswordTest()
        {
            string passIn = "qwerty";
            string passOut = "qwerty".GetHashCode().ToString();

            string strActual = CodingPassword.ToCodingPassword (passIn);



            Assert.AreEqual(passOut, strActual);
        }


    }
}