using System.Runtime.Serialization;

namespace BlazorApp1.Enums
{
    public enum HouseholdSubCategoryEnum
    {
        [EnumMember(Value = "Холодильники")]
        Refrigerators,
        [EnumMember(Value = "Пральні машини")]
        WashingMachines,
        [EnumMember(Value = "Бойлери")]
        Boilers,
        [EnumMember(Value = "Печі")]
        Stoves,
        [EnumMember(Value = "Витяжки")]
        Hoods,
        [EnumMember(Value = "Мікрохвильові печі")]
        Microwaves
    }
}
