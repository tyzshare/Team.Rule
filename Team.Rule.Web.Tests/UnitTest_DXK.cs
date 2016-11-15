using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Team.Rule.Dto;
using System.ComponentModel.DataAnnotations;
using Team.Rule.Business;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Team.Rule.Web.Tests
{
    [TestClass]
    public class UnitTest_DXK
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserInfoDto dto = new UserInfoDto()
            {
                LoginEmail = "asda",
                 //LoginPwd="12345"
            };


            ////校验

            //var properties = dto.GetType().GetProperties();


            //foreach (var property in properties)
            //{

            //    var atts = property.GetCustomAttributes<ValidationAttribute>();

            //    foreach (var att in atts)
            //    {
            //        var b = att.IsValid(property.GetValue(dto));

            //        if (!b)
            //        {

            //        }
            //    }

            //}


            //插数据库了

            try
            {
                dto.Validate();
            }
            catch (ValidationException ex)
            {

                throw;
            }

        }

        [TestMethod]
        public void TestMethod2()
        {
            var service = new UserInfoService();

            var result = service.QueryUserInfoList(1);
            string value = "";
        }

        [TestMethod]
        public void TestMethod3()
        {




            Expression expression = Expression.New(typeof(UserInfoDto));

            var action = Expression.Lambda<Func<UserInfoDto>>(expression).Compile();

            var service = action();

            service = new UserInfoDto();

        }

        [TestMethod]
        public void TestMethod4()
        {

            UserInfoDto user = new UserInfoDto()
            {
                Id = 10
            };


            var sourceInstance = Expression.Parameter(typeof(UserInfoDto), "sourceInstance");


            var propertyExpression = Expression.Property(sourceInstance, typeof(UserInfoDto).GetProperty("Id").GetMethod);


            var action=  Expression.Lambda<Func<UserInfoDto, long>>(propertyExpression, sourceInstance).Compile();


            var id = action(user);

        }


        [TestMethod]
        public void TestMethod5()
        {

            UserInfoDto user = new UserInfoDto()
            {
                Id = 10
            };


            var sourceInstance = Expression.Parameter(typeof(UserInfoDto), "sourceInstance");

            var parameterExpression = Expression.Parameter(typeof(object),"value");

            var method=typeof(UserInfoDto).GetMethod("Test",new Type[]{typeof(object)});

            var methodExpression = Expression.Call(sourceInstance, method, parameterExpression);


            var action = Expression.Lambda<Func<UserInfoDto, object, object>>(methodExpression, sourceInstance, parameterExpression).Compile();


            var value = action(user,9);

        }


        class TestClass
        { 
        
        }

        class TestClass1 : TestClass
        {

        }

        interface TestFClass<out T> 
        { 
          
        }

        [TestMethod]
        public void TestMethod6()
        {

           List<TestClass1> list = new List<TestClass1>();

           IEnumerable<TestClass> list2 = list;

           TestClass1 dd = new TestClass1();

           TestClass ddd = dd;

           IEnumerable<object> list1 = list;


        }
    }
}
