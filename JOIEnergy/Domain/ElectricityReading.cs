using System;
namespace JOIEnergy.Domain
{
    /// <summary>
    /// 电表读数
    /// </summary>
    //prob: 需要添加 能源类型
    public class ElectricityReading
    {
        public DateTime Time { get; set; }
        public Decimal Reading { get; set; }
    }
}
