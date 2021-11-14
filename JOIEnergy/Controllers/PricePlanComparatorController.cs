using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JOIEnergy.Controllers
{
    [Route("price-plans")]
    public class PricePlanComparatorController : Controller
    {
        private readonly IPricePlanService _pricePlanService;
        private readonly IAccountService _accountService;

        public PricePlanComparatorController(IPricePlanService pricePlanService, IAccountService accountService)
        {
            this._pricePlanService = pricePlanService;
            this._accountService = accountService;
        }
        //prob: objectresult.   objectResult.Value是 非强类型的 object类型. 业务目的不明晰
        [HttpGet("compare-all/{smartMeterId}")]
        public ObjectResult CalculatedCostForEachPricePlan(string smartMeterId)
        {
            //prob: coding:无效代码
            var pricePlanId = _accountService.GetPricePlanIdForSmartMeterId(smartMeterId);
            var costPerPricePlan = _pricePlanService.GetConsumptionCostOfElectricityReadingsForEachPricePlan(smartMeterId);
            if (!costPerPricePlan.Any())
            {
                return new NotFoundObjectResult(string.Format("Smart Meter ID ({0}) not found", smartMeterId));
            }

            dynamic response = JObject.FromObject(costPerPricePlan);

            return
                costPerPricePlan.Any() ? 
                new ObjectResult(response) : 
                new NotFoundObjectResult(string.Format("Smart Meter ID ({0}) not found", smartMeterId));
        }

        [HttpGet("recommend/{smartMeterId}")]
        public ObjectResult RecommendCheapestPricePlans(string smartMeterId, int? limit = null) {
            var consumptionForPricePlans = _pricePlanService.GetConsumptionCostOfElectricityReadingsForEachPricePlan(smartMeterId);
            //prob: coding 重复的代码. 和上面的逻辑重复. 
          
            if (!consumptionForPricePlans.Any()) {
                return new NotFoundObjectResult(string.Format("Smart Meter ID ({0}) not found", smartMeterId));
            }

            var recommendations = consumptionForPricePlans.OrderBy(pricePlanComparison => pricePlanComparison.Value);
            //prob: 领域逻辑外泄.应该在领域内实现.
            if (limit.HasValue && limit.Value < recommendations.Count())
            {
                return new ObjectResult(recommendations.Take(limit.Value));
            }

            return new ObjectResult(recommendations);
        }
    }
}
