using System.Runtime.Serialization;

namespace AnnouncementsAPI.Enums
{
    public enum ComputerSubCategoryEmun
    {
        [EnumMember(Value = "ПК")]
        PCs,
        [EnumMember(Value = "Ноутбуки")]
        Laptops,
        [EnumMember(Value = "Монітори")]
        Monitors,
        [EnumMember(Value = "Принтери")]
        Printers,
        [EnumMember(Value = "Сканери")]
        Scanners
    }
}
