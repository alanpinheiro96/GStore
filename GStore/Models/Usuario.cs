using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;
namespace GStore.Models;

[Table("Usuario")]
public class Usuario : IdentityUser
{
    [Required(ErrorMessage = "Por favor, informe seu nome")]
    [StringLength(60, ErrorMessage = "O nome deve possuir no máximo 60 caracteres")]
    public string Name { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data de nascimento")]
    public DateTime DataNascimento { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }

}