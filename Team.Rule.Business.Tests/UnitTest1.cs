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
            //var result = new UserService().CreateUser(new CreateUserInputDto() { LoginEmail = "jinpeng19@163.com", LoginPwd = "12345678" });

            var result = new UserService().QueryUsers(new QueryUsersInputDto() { PageIndex = 1, PageSize = 10 });
        }
    }
}
