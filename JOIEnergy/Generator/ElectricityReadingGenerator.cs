using System;
using System.Collections.Generic;
using JOIEnergy.Domain;

namespace JOIEnergy.Generator
{
    public class ElectricityReadingGenerator
    {
        public ElectricityReadingGenerator()
        {

        }
        //prob: domain 模拟读数只有 200秒, 没有跨天. 但是 价格规则是以天为单位进行计算的?
        /// <summary>
        /// 模拟读数 
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<ElectricityReading> Generate(int number)
        {
            var readings = new List<ElectricityReading>();
            var random = new Random();
            for (int i = 0; i < number; i++)
            {
                var reading = (decimal)random.NextDouble();
                var electricityReading = new ElectricityReading
                {
                    Reading = reading,
                    Time = DateTime.Now.AddSeconds(-i * 10)
                };
                readings.Add(electricityReading);
            }
            readings.Sort((reading1, reading2) => reading1.Time.CompareTo(reading2.Time));
            return readings;
        }
    }
}
