namespace EventsBasicANC.ViewModels.Validations.Produto
{
    public class CriarProdutoValidation : ProdutoValidation
    {
        public CriarProdutoValidation()
        {
            ValidaDescricao();
            ValidaLoja();
            ValidaPreco();
            ValidaTipo();
        }
    }
}
