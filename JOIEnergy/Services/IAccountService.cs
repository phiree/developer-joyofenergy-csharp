using JOIEnergy.Enums;

namespace JOIEnergy.Services
{
    public interface IAccountService
    {
        //prob:  coding naming 命名问题: 返回值(Supplier) 和 方法名称(PricePlanId)不一致.
        Supplier GetPricePlanIdForSmartMeterId(string smartMeterId);
    }
}