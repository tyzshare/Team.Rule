using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Rule.Dto;

namespace Team.Rule.Business
{
    //注释：不建议使用缓存，除非特殊情况
    public static class UserCache
    {
        private static IExpireCache<long, UserInfoDto> _userCache;

        static UserCache()
        {
            _userCache = CacheFactory.Instance.CreateExpireMemoryCache<long, UserInfoDto>(new TimeSpan(1, 0, 0));
        }

        public static UserInfoDto GetUserInfo(long id)
        {
            if (id <= 0)
            {
                return null;
            }
            var user = _userCache.Get(id, delegate
            {
                return ThreadCache.dbContext_Test_Rule.UserInfo.Where(o => o.Id == id).Select(o => new UserInfoDto()
                {
                    Id = id,
                    LoginEmail = o.LoginEmail,
                    LoginPwd = o.LoginPwd
                }).FirstOrDefault();
            });
            return user;
        }
    }
}
