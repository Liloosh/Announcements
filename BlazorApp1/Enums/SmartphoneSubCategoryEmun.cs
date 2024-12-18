using System.Runtime.Serialization;

namespace BlazorApp1.Enums
{
    public enum SmartphoneSubCategoryEmun
    {
        [EnumMember(Value = "Android смартфони")]
        AndroidSmartphones,
        [EnumMember(Value = "iOS/Apple смартфони")]
        iOSSmartphones
    }
}
