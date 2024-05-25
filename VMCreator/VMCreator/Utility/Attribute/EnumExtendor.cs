using System;
using System.Linq;

public static class EnumExtendor
{
    public static string StringValue(this Enum e)
    {
        var fieldInfo = e.GetType().GetField(e.ToString());
        var attribute = (StringValueAttribute)fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false).FirstOrDefault();
        return attribute == null ? null : attribute.StringValue;
    }
}