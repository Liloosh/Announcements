using System.Runtime.Serialization;

namespace AnnouncementsAPI.Enums
{
    public enum CategoryEnum
    {
        [EnumMember(Value = "Побутова техніка")]
        HouseholdAppliances,
        [EnumMember(Value = "Комп'ютерна техніка")]
        ComputerEquipment,
        [EnumMember(Value = "Смартфони")]
        Smartphones,
        [EnumMember(Value = "Інше")]
        Other
    }
}
