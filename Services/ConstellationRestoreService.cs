using ConstellationRestore.DTOs;

namespace ConstellationRestore.Services;

public sealed class ConstellationRestoreService : IConstellationRestoreService
{
    public string? Validate(string reference, string damaged)
    {
        if (reference is null || reference.Length == 0)
            return "Поле 'reference' не может быть пустым.";

        if (damaged is null)
            return "Поле 'damaged' не может быть null.";

        for (int i = 0; i < reference.Length; i++)
        {
            if (!IsLatinUpper(reference[i]))
                return "Поле 'reference' может содержать только заглавные латинские буквы A-Z.";

            for (int j = i + 1; j < reference.Length; j++)
            {
                if (reference[i] == reference[j])
                    return "Поле 'reference' не должно содержать повторяющихся символов.";
            }
        }

        for (int i = 0; i < damaged.Length; i++)
        {
            if (!IsLatinUpper(damaged[i]))
                return "Поле 'damaged' может содержать только заглавные латинские буквы A-Z.";

            if (!SymbolExists(reference, damaged[i]))
                return $"Символ '{damaged[i]}' отсутствует в эталонном коде.";
        }

        return null;
    }

    public ConstellationRestoreResponse Restore(string reference, string damaged)
    {
        var missing = new List<char>();

        for (int i = 0; i < reference.Length; i++)
        {
            if (!SymbolExists(damaged, reference[i]))
                missing.Add(reference[i]);
        }

        missing.Sort();

        return new ConstellationRestoreResponse
        {
            MissingSymbols = new string(missing.ToArray()),
            IsComplete = missing.Count == 0
        };
    }

    private static bool SymbolExists(string source, char symbol)
    {
        for (int i = 0; i < source.Length; i++)
        {
            if (source[i] == symbol)
                return true;
        }

        return false;
    }

    private static bool IsLatinUpper(char c) => c >= 'A' && c <= 'Z';
}
