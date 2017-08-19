using System.ComponentModel.DataAnnotations;

namespace EventsBasicANC.ViewModels
{
    public class UsuarioRegistroViewModel
    {
        [Display(Name = "E-mail"), DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name ="Senha"),DataType(DataType.Password)]
        public string senha { get; set; }

        [Display(Name = "´Confirmacao da Senha"), DataType(DataType.Password), Compare("senha")]
        public string confirmacaoSenha { get; set; }

    }
}
