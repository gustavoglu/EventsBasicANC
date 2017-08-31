using System.Collections.Generic;

namespace EventsBasicANC.ViewModels
{
    public class LojaContainerViewModel
    {
        public string Login { get; set; } = null;

        public string Senha { get; set; } = null;

        public string RazaoSocial { get; set; } = null;

        public string NomeFantasia { get; set; } = null;

        public EnderecoContainerViewModel Endereco { get; set; } = null;

        public ContatoContainerViewModel Contato { get; set; } = null;

        public ICollection<ProdutoContainerViewModel> Produtos { get; set; }

        public ICollection<ContaBasicaContainerViewModel> Funcionarios { get; set; }
    }
}
