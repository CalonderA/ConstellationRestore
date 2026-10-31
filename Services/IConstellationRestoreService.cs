using ConstellationRestore.DTOs;

namespace ConstellationRestore.Services;

public interface IConstellationRestoreService
{
    /// <summary>Проверяет входные данные. Возвращает текст ошибки или null, если всё корректно.</summary>
    string? Validate(string reference, string damaged);

    
    ConstellationRestoreResponse Restore(string reference, string damaged);
}
