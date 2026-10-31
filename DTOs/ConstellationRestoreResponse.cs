namespace ConstellationRestore.DTOs;

/// <summary>Результат восстановления кода.</summary>
public sealed class ConstellationRestoreResponse
{
    /// <summary>Отсутствующие символы, отсортированные по алфавиту.</summary>
    public string MissingSymbols { get; init; } = string.Empty;

    public bool IsComplete { get; init; }
}
