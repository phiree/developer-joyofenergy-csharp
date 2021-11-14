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
        //prob:domain  单价的单位? 只能通过代码看到 单位是小时. 应该明示.
        public IList<PeakTimeMultiplier> PeakTimeMultiplier { get; set;}

        //prob: oo design 违反依赖最小化原则(迪米特原则). 该规则只需要知道 星期几 即可, 不需要知道具体时间)
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
    /// 峰/谷价格设定
    /// 
    /// </summary>
    public class PeakTimeMultiplier
    {
        public DayOfWeek DayOfWeek { get; set; }
        /// <summary>
        /// prob: coding 缺少必要的注释. 峰谷/顶 倍率
        /// </summary>
       
        public decimal Multiplier { get; set; }
    }
}
