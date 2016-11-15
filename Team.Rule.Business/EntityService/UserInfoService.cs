using Abp.Application.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Rule.Dto;
using Team.Rule.Entity.Team_Rule;
using System.Data.Entity;

namespace Team.Rule.Business
{
    public class UserInfoService : BaseService
    {
        #region 创建用户信息
        public void CreateUserInfo(UserInfoDto dto)
        {
            dto.Validate();
            var user = AutoMapperHelper.MapTo<UserInfo>(dto);
            user.CreateTime = DateTime.Now;
            ThreadCache.dbContext_Test_Rule.UserInfo.Add(user);
            ThreadCache.dbContext_Test_Rule.SaveChanges();
        }
        #endregion

        #region 获取用户列表

        public IPageResult<UserInfoDto> QueryUserInfoList(int pageIndex = 1, int pageSize = Config.PageSize)
        {

            var result = ThreadCache.dbContext_Test_Rule.UserInfo.OrderByDescending(o => o.CreateTime).Select(o =>
                new UserInfoDto()
                {
                    Id = o.Id,
                    LoginEmail = o.LoginEmail,
                    LoginPwd = o.LoginPwd
                }).ToPage(pageIndex, pageSize);

            return result;
        }
        #endregion

        #region 删除用户
        public void DeleteUserInfo(long id)
        {
            if (id <= 0)
            {
                Throw();
            }
            ThreadCache.dbContext_Test_Rule.Database.ExecuteSqlCommand("delete from userinfo where id=@p0", id);
        }
        #endregion
    }
}
