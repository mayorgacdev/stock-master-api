namespace Training.Application.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ErrorCodePrefixAttribute(string Prefix) : Attribute
{
    public readonly string Prefix = Prefix;
}