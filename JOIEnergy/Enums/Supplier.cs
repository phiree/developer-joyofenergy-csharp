using System;
namespace JOIEnergy.Enums
{
   //prob: domain 可能的问题. 1) 是否需要考虑 能源公司的扩展性? 2) nullSupplier 是否有业务意义? 是否应该直接异常? 3) 如果有nullsupplier, 是否应该把它放在第一个,对应其特殊含义 
    public enum Supplier
    {
        DrEvilsDarkEnergy,
        TheGreenEco,
        PowerForEveryone,
        NullSupplier
    }
}
