using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EagleStore.Models;

[Table("Categoria")]
public class Categoria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, informe o nome")]
    [StringLenght(30, ErrorMessage = "O nome deve possuir no máximo 30 caracteres")]
    public string Nome { get; set; }

    [StringLenght(300)]
    public string Foto { get; set; }


}
