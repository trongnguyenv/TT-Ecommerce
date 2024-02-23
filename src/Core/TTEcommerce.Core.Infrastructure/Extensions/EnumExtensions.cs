using System.ComponentModel;

namespace TTEcommerce.Core.Infrastructure.Extensions;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        var enumType = value.GetType();
        var name = Enum.GetName(enumType, value);
        var field = enumType.GetField(name);
        var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

        return attribute?.Description ?? string.Empty;
    }
}
