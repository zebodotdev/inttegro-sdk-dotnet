namespace Commerce.Validation;

public static class RequestValidator
{
    public static void Require(object? value, string name)
    {
        if (value == null)
        {
            throw new ArgumentException($"'{name}' is required.", name);
        }

        if (value is string str && string.IsNullOrWhiteSpace(str))
        {
            throw new ArgumentException($"'{name}' is required.", name);
        }
    }

    public static void RequireCollection<T>(ICollection<T>? value, string name)
    {
        if (value == null || value.Count == 0)
        {
            throw new ArgumentException($"'{name}' is required.", name);
        }
    }

    public static void RequireAny((string Name, object? Value) first, (string Name, object? Value) second, string message)
    {
        var firstPresent = IsPresent(first.Value);
        var secondPresent = IsPresent(second.Value);
        if (!firstPresent && !secondPresent)
        {
            throw new ArgumentException(message);
        }
    }

    private static bool IsPresent(object? value)
    {
        if (value == null)
        {
            return false;
        }

        if (value is string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }

        return true;
    }
}
