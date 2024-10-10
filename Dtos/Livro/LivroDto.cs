using library_jc_API.Dtos.Autor;
using library_jc_API.Dtos.Categoria;

namespace library_jc_API.Dtos.Livro
{
    public class LivroDto
    {
        public int LivroId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Editora { get; set; } = string.Empty;
        public string Edicao { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int Paginas { get; set; }
        public string Idioma { get; set; } = string.Empty;
        public DateTime DataPublicacao { get; set; }
        public bool Disponivel { get; set; }
        public AutorDto? Autor { get; set; }
        public CategoriaDto? Categoria { get; set; }
    }
}
