using System;
using System.Collections.Generic;
using JOIEnergy.Enums;

namespace JOIEnergy.Services
{
    public class AccountService : Dictionary<string, Supplier>, IAccountService
    { 
        //电表对应的供应商.
        private Dictionary<string, Supplier> _smartMeterToPricePlanAccounts;

        public AccountService(Dictionary<string, Supplier> smartMeterToPricePlanAccounts) {
            _smartMeterToPricePlanAccounts = smartMeterToPricePlanAccounts;
        }
        /// <summary>
        /// 获取智能表当前的供应商
        /// </summary>
        /// <param name="smartMeterId"></param>
        /// <returns></returns>
        public Supplier GetPricePlanIdForSmartMeterId(string smartMeterId) {
            if (!_smartMeterToPricePlanAccounts.ContainsKey(smartMeterId))
            {
                return Supplier.NullSupplier;
            }
            return _smartMeterToPricePlanAccounts[smartMeterId];
        }
    }
}
