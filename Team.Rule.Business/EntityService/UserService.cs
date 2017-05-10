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
    public class UserService : BaseService
    {
        #region 创建用户信息
        /// <summary>
        /// 创建用户信息
        /// </summary>
        /// <param name="dto">创建用户信息Dto</param>
        /// <returns></returns>
        public bool CreateUser(CreateUserInputDto dto)
        {
            dto.Validate();

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
        /// <summary>
        /// 检索用户列表
        /// </summary>
        /// <param name="dto">检索用户列表Dto</param>
        /// <returns></returns>
        public IPageResult<QueryUsersOutput> QueryUsers(QueryUsersInputDto dto)
        {
            var result = dbContent.UserInfo.OrderByDescending(o => o.CreateTime).Select(o =>
                new QueryUsersOutput()
                {
                    Id = o.Id,
                    LoginEmail = o.LoginEmail,
                    CreateTime = o.CreateTime
                }).ToPage(dto.PageIndex, dto.PageSize);

            return result;
        }
        #endregion

        #region 删除用户
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="dto">删除用户Dto</param>
        /// <returns></returns>
        public bool DeleteUser(DeleteUserInputDto dto)
        {
            if (dbContent.UserInfo.Any(o => o.Id == dto.Id))
            {
                Throw("用户不存在！");
            }
            dbContent.Database.ExecuteSqlCommand("delete from userinfo where id=@p0", dto.Id);
            return true;
        }
        #endregion
    }
}
