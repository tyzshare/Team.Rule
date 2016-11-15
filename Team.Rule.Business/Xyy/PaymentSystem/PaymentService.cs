using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYY.PaymentSystem;
using XYY.PaymentSystem.DTO;

namespace Team.Rule.Business
{
    //多线程 ，单例模式
    //public class PaymentService
    //{
    //    private static SystemRewardManage _paymentApi;
    //    private static object _lock = new object();

    //    private object _lo1ck = new object();

    //    private PaymentService()
    //    {

    //    }

    //    public static SystemRewardManage GetInstance()
    //    {
    //        if (_paymentApi == null)
    //        {
    //            lock (_lock)
    //            {
    //                if (_paymentApi == null)
    //                {
    //                    _paymentApi = new SystemRewardManage();
    //                }
    //            }
    //        }
    //        return _paymentApi;
    //    }

    //    /// <summary>
    //    /// 提交奖励申请
    //    /// </summary>
    //    /// <param name="applicantId">申请人</param>
    //    /// <param name="detail">详情</param>
    //    /// <param name="rewardReason">理由</param>
    //    /// <param name="toUserId">发放对象</param>
    //    /// <param name="fee">金额</param>
    //    /// <param name="moneyType">类型</param>
    //    /// <returns></returns>
    //    public static string Payment(int applicantId, string detail, string rewardReason, int toUserId, decimal fee, MoneyType moneyType)
    //    {
    //        string applicantName = string.Empty;
    //        return _paymentApi.CreateAward(applicantName, detail, rewardReason, toUserId, fee, moneyType);
    //    }
    //}



    public static class PaymentService
    {
        static readonly SystemRewardManage _paymentApi = new SystemRewardManage();

        /// <summary>
        /// 提交奖励申请
        /// </summary>
        /// <param name="applicantId">申请人</param>
        /// <param name="detail">详情</param>
        /// <param name="rewardReason">理由</param>
        /// <param name="toUserId">发放对象</param>
        /// <param name="fee">金额</param>
        /// <param name="moneyType">类型</param>
        /// <returns></returns>
        public static string Payment(int applicantId, string detail, string rewardReason, int toUserId, decimal fee, MoneyType moneyType)
        {
            string applicantName = string.Empty;
            return _paymentApi.CreateAward(applicantName, detail, rewardReason, toUserId, fee, moneyType);
        }
    }
}
