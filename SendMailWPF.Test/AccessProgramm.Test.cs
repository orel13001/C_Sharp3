using NUnit.Framework;
using SendMailWPF.Logic;

namespace SendMailWPF.Test
{
    internal class AccessProgrammTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsAccessProgrammTrueTest()
        {
            string passIn = "qwerty";
            string loginIn = "admin";

            passIn = "admin";
            loginIn = "admin";
            bool Actual = AccessProgramm.IsAccessProgramm(loginIn, passIn.GetHashCode().ToString());
            Assert.True(Actual);

        }

        [Test]
        public void IsAccessProgrammIsFalseTest()
        {
            string passIn = "qwerty";
            string loginIn = "admin";

            bool Actual = AccessProgramm.IsAccessProgramm(loginIn, passIn.GetHashCode().ToString());
            Assert.IsFalse(Actual);

        }
    }
}
