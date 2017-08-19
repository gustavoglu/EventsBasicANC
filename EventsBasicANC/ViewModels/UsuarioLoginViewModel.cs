using System.ComponentModel.DataAnnotations;

namespace EventsBasicANC.ViewModels
{
    public class UsuarioLoginViewModel
    {
        [Display(Name = "E-mail"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Senha"), DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
