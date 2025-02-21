using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EagleStore.Models;

[Table("Produto")]
public class Produto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Por favor, informe a categoria")]
    public int CategoriaId { get; set; }
    [ForeignKey(nameof(CategoriaId))]
    public Categoria Categoria { get; set; }

    [Required(ErrorMessage = "Por favor, informe o nome")]
    [StringLength(60, ErrorMessage = "O nome deve possuir no máximo 60 caracteres")]
    public string Nome { get; set; }

    [Display(Name = "Descrição", prompt = "Descrição")] //Para exibir o texto escolhido para o usuário
    [StringLength(1000, ErrorMessage = "O nome deve possuir no máximo 1000 caracteres")]
    public string Descricao { get; set; }

    [Range(0, int.MaxValue)] //Range determina o minimo e máximo. int.MaxValue é usado para aumentar a qtd sem limitar um número
    public int Qtde { get; set; }

    [Range(0 , double.MaxValue)] //Utilizar double para trabalhar com medidas
    [Column(TypeName = "numeric(10,2)")] // Definir um limite de Qtd de digitos para o valor
    public decimal ValorCusto { get; set; }

    [Range(0 , double.MaxValue)]
    [Column(TypeName = "numeric(10,2)")]
    public decimal ValorVenda { get; set; }
    
}