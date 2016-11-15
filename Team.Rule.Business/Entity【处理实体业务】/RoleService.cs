using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Rule.Dto;
using Team.Rule.Entity.Team_Rule;

namespace Team.Rule.Business
{
    public class RoleService : BaseService
    {

        #region 返回权限列表
        /// <summary>
        /// 返回权限列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IPageResult<RoleDto> QueryRoleList(int pageIndex = 1)
        {
            var result = ThreadCache.dbContext_Test_Rule.Roles.OrderByDescending(o => o.CreateTime).Select(o =>
               new RoleDto()
               {
                   Id = o.Id,
                   Name = o.Name,
                   CreateTime=o.CreateTime
               }).ToPage(pageIndex, Config.PageSize);

            return result;
        }

        #endregion

        #region 插入权限
        /// <summary>
        /// 插入权限
        /// </summary>
        /// <param name="dto"></param>
        public void CreateRole(RoleDto dto)
        {
            dto.Validate();
            var role = AutoMapperHelper.MapTo<Roles>(dto);
            role.CreateTime = DateTime.Now;
            ThreadCache.dbContext_Test_Rule.Roles.Add(role);
            ThreadCache.dbContext_Test_Rule.SaveChanges();
        }
        #endregion

        #region  删除权限
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRole(long id)
        {
            if (id <= 0)
            {
                Throw();
            }
            ThreadCache.dbContext_Test_Rule.Database.ExecuteSqlCommand("delete from roles where id=@p0", id);
        }
        #endregion
    }
}
