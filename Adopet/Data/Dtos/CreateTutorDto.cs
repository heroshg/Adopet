using System.ComponentModel.DataAnnotations;

namespace Adopet.Data.Dtos;

public class CreateTutorDto
{
    public String? FotoPerfil { get; set; } = "https://cdn.discordapp.com/attachments/769762272838156298/1216437914804682824/Usuario.png?ex=66006317&is=65edee17&hm=6cbf9ea9eb8946f73999382463984a651c53be68f8cf578f6e9d38075e4c9c55&";
    
    [Required(ErrorMessage = "Nome é obrigatório!")]
    [MaxLength(50, ErrorMessage = "Por favor insira o nome do tutor!")]
    [MinLength(2, ErrorMessage = "Nome deve conter mais de 2 caracteres!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Telefone é obrigatório")]
    [RegularExpression(@"^\+55\s\d{2}\s\d{5}\-\d{4}$", ErrorMessage = "Por favor, insira um número de telefone válido no formato +55 11 XXXXX-XXXX")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Cidade é obrigatória")]
    [MinLength(2, ErrorMessage = "Cidade deve conter no mínimo 2 caracteres!")]
    [MaxLength(30, ErrorMessage = "Cidade deve conter no máximo 30 caracteres!")]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "Sobre é obrigatório!")]
    [MaxLength(500, ErrorMessage = "Sobre não pode exceder 500 caracteres!")]
    [MinLength(3, ErrorMessage = "Sobre deve conter no mínimo 3 caracteres!")]
    public string Sobre { get; set; }
}
