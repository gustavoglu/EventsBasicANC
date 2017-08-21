using EventsBasicANC.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EventsBasicANC.ViewModels
{
    public class UsuarioRegistroViewModel
    {
        [Display(Name = "E-mail"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Senha"),DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "´Confirmacao da Senha"), DataType(DataType.Password), Compare("Senha")]
        public string ConfirmacaoSenha { get; set; }

        [Required(ErrorMessage = "Ncessário informar Tipo da Conta")]
        public ContaTipo ContaTipo { get; set; }
    }
}
