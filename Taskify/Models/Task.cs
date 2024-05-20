using System.ComponentModel.DataAnnotations;

namespace Taskify.Models;

public class Task
{
    [Key]
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O titulo da tarefa é obrigatório")]
    public string Titulo { get; set; }
    
    [Required(ErrorMessage = "A descrição da tarefa é obrigatório")]
    [StringLength(300, ErrorMessage = "O tamanho da descrição não pode exceder cerca de 300 caracteres")]
    public string Descricao { get; set; }
    
    [Required(ErrorMessage = "A data de vencimento da tarefa é obrigatório")]
    public DateTime DataVencimento { get; init; }
    
    [Required(ErrorMessage = "A prioridade da tarefa é obrigatório")]
    public Prioridades Prioridade { get; set; }

    public bool Concluido { get; set; }
}

public enum Prioridades
{
    Baixo,
    Medio,
    Alto,
    Critico
}