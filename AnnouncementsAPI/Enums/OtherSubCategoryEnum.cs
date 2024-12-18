﻿using System.Runtime.Serialization;

namespace AnnouncementsAPI.Enums
{
    public enum OtherSubCategoryEnum
    {
        [EnumMember(Value = "Одяг")]
        Clothing,
        [EnumMember(Value = "Взуття")]
        Footwear,
        [EnumMember(Value = "Аксесуари")]
        Accessories,
        [EnumMember(Value = "Спортивне обладнання")]
        SportsEquipment,
        [EnumMember(Value = "Іграшки")]
        Toys
    }
}
