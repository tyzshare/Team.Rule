using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Team.Rule.Business;
using System.Web.Caching;

namespace Team.Rule.Web.Tests
{
    [TestClass]
    public class UnitTest_JP
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var user = UserCache.GetUserInfo(75);

            string result = PaymentService.Payment(9033294, "ddddd", "ssss", 9033294, 10, XYY.PaymentSystem.DTO.MoneyType.Point);
        }
    }
}
