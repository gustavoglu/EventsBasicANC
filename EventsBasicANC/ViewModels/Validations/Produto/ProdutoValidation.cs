using FluentValidation;

namespace EventsBasicANC.ViewModels.Validations.Produto
{
    public class ProdutoValidation : AbstractValidator<ProdutoViewModel>
    {

        protected void ValidaDescricao()
        {
            RuleFor(p => p.Descricao)
                .NotEmpty()
                .NotNull()
                .WithMessage("Necessário informar a Descrição do Produto");
        }

        protected void ValidaTipo()
        {
            RuleFor(p => p.Tipo)
                .NotEmpty()
                .NotNull()
                .WithMessage("Necessário informar o Tipo do Produto");
        }

        protected void ValidaPreco()
        {
            RuleFor(p => p.Preco)
            .NotEmpty()
            .NotNull()
            .WithMessage("Necessário informar o Valor do Produto");
        }

        protected void ValidaLoja()
        {
            RuleFor(p => p.Id_loja)
            .NotEmpty()
            .NotNull()
            .WithMessage("Necessário informar a Loja que pertence ao Produto (id_loja)");
        }

        protected void ValidaId()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .WithMessage("Id do Produto não informado");
        }
    }
}
