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
        public bool CreateUserInfo(CreateUserInfoDto dto)
        {

            throw new Exception("abc");
            //dto.Validate();
            int a = 1, b = 0;
            var result = a / b;

            //业务：创建新用户的登陆邮箱不能重复
            if (dbContent.UserInfo.Any(o => o.LoginEmail == dto.LoginEmail))
            {
                Throw("登陆邮箱不能重复！");
            }
            var user = AutoMapperHelper.MapTo<UserInfo>(dto);
            user.CreateTime = DateTime.Now;
            dbContent.UserInfo.Add(user);
            return dbContent.SaveChanges() > 0;
        }
        #endregion

        #region 获取用户列表

        public IPageResult<UserInfoDto> QueryUserInfoList(int pageIndex = 1, int pageSize = Config.PageSize)
        {

            var result = dbContent.UserInfo.OrderByDescending(o => o.CreateTime).Select(o =>
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
            dbContent.Database.ExecuteSqlCommand("delete from userinfo where id=@p0", id);
        }
        #endregion
    }
}
