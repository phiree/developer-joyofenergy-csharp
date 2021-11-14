using System;
using System.Collections.Generic;
using System.Linq;
using JOIEnergy.Enums;

namespace JOIEnergy.Domain
{
    /// <summary>
    /// 供电方价格计划: 
    /// 一周每一天的价格比率不同. 
    /// </summary>
    public class PricePlan
    {
        public Supplier EnergySupplier { get; set; }
        public decimal UnitRate { get; set; }
        
        public IList<PeakTimeMultiplier> PeakTimeMultiplier { get; set;}

        //prob: 违反依赖最小化原则(迪米特原则). 该规则只需要知道 星期几 即可, 不需要知道具体时间)
        public decimal GetPrice(DateTime datetime) {
            var multiplier = PeakTimeMultiplier.FirstOrDefault(m => m.DayOfWeek == datetime.DayOfWeek);

            if (multiplier?.Multiplier != null) {
                return multiplier.Multiplier * UnitRate;
            } else {
                return UnitRate;
            }
        }
    }
    /// <summary>
    /// 高峰期规则
    /// </summary>
    public class PeakTimeMultiplier
    {
        public DayOfWeek DayOfWeek { get; set; }
        public decimal Multiplier { get; set; }
    }
}
