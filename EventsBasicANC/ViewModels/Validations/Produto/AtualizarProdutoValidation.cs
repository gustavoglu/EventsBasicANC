namespace EventsBasicANC.ViewModels.Validations.Produto
{
    public class AtualizarProdutoValidation : ProdutoValidation
    {
        public AtualizarProdutoValidation()
        {
            ValidaId();
            ValidaDescricao();
            ValidaPreco();
            ValidaLoja();
            ValidaTipo();
        }
    }
}
