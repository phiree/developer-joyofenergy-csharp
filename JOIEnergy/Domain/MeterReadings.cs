using System;
using System.Collections.Generic;

namespace JOIEnergy.Domain
{
    //prob : extensitive 需要添加  能源类型, 为v3版本做准备:  - Add on Gas and Dual fuel tariffs
    /// <summary>
    /// 电表读数
    /// </summary>
    public class MeterReadings
    {
        public string SmartMeterId { get; set; }
        public List<ElectricityReading> ElectricityReadings { get; set; }
        //refact: 将 controller里的 isvalid 移到此处.
        
    }
}
