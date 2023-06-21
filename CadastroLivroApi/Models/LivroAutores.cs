namespace CadastroLivroApi.Models
{
    public class LivroAutores : BaseModel
    {
        public LivroAutores() { }

        public LivroAutores(Livro livro) 
        {
            this.livro = livro;
        }

        public string? IdLivro
        {
            get => livro == null ? idLivro : livro.Id;
            set => idLivro = value;
        }

        public string Nome { get; set; } = "";

        public string Sobrenome { get; set; } = "";

        private string? idLivro = null;
        private Livro? livro;
    }
}
