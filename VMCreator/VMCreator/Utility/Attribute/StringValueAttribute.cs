[AttributeUsage(AttributeTargets.Field)]
public sealed class StringValueAttribute : Attribute
{
    public string StringValue { get; private set; }

    public StringValueAttribute(string value)
    {
        StringValue = value;
    }
}