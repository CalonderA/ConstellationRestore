using System.ComponentModel.DataAnnotations;

namespace ConstellationRestore.DTOs;

/// <summary>Запрос на восстановление кода созвездия.</summary>
public sealed class ConstellationRestoreRequest
{
    /// <summary>Эталонный код: уникальные заглавные латинские буквы A-Z.</summary>
    [Required(ErrorMessage = "Поле 'reference' обязательно.")]
    public string? Reference { get; set; }
    
    [Required(AllowEmptyStrings = true, ErrorMessage = "Поле 'damaged' обязательно.")]
    public string? Damaged { get; set; }
}
