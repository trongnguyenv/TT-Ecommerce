namespace TTEcommerce.Core.Reflection;

public static class TypeGetter
{
    public static Type? GetTypeFromCurrentDomainAssembly(string typeName)
    {
        return AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t => !t.IsAbstract && t.Name == typeName);
    }
}
