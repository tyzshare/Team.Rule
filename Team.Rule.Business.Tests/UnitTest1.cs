using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Team.Rule.Business.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                new UserInfoService().CreateUserInfo(new CreateUserInfoDto() { LoginEmail = "jinpeng19@163.com", LoginPwd = "sdfdfsdfsf" });
            }
            catch (Exception ex)
            {

            }

        }
    }
}
