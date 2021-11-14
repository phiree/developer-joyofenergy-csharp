using System;
using System.Collections.Generic;

namespace JOIEnergy.Domain
{
    /// <summary>
    /// 电表读数
    /// </summary>
    public class MeterReadings
    {
        public string SmartMeterId { get; set; }
        public List<ElectricityReading> ElectricityReadings { get; set; }
        //refact:
        public bool IsValid()
        { 
        
        }
    }
}
