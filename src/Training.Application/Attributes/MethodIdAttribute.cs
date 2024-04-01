namespace Training.Application.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class MethodIdAttribute(string MethodId) : Attribute
{
    public readonly string MethodId = MethodId;
}
