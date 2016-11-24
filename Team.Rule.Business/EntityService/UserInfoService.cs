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
            if (string.IsNullOrEmpty(dto.LoginEmail))
            {
                Throw("登陆邮箱不能为空！");
            }
            if (string.IsNullOrEmpty(dto.LoginPwd))
            {
                Throw("登陆密码不能为空！");
            }
            //dto.Validate();
            var user = AutoMapperHelper.MapTo<UserInfo>(dto);
            user.CreateTime = DateTime.Now;
            dbContent.UserInfo.Add(user);
            dbContent.SaveChanges();
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
