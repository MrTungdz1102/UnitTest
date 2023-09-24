using ProjectTest.ApplicationCore.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest.FunctionalTests.Validations
{
    [TestFixture]
    public class DateInFutureAttributeTest
    {
        [Test]
        public void DateValidate_InputDateRange_DateValid()
        {
            DateInFutureAttribute dateInFuture = new DateInFutureAttribute(() => DateTime.Now);
            var result = dateInFuture.IsValid(DateTime.Now.AddDays(1));
            DateInFutureAttribute date = new DateInFutureAttribute();
            Assert.IsTrue(result);
            Assert.Multiple(() =>
            {
                Assert.False(date.IsValid(DateTime.Now));
                Assert.AreEqual("Date must be in the future", date.ErrorMessage);
            });
        }
    }
}
