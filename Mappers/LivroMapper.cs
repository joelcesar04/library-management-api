using library_jc_API.Dtos.Autor;
using library_jc_API.Dtos.Categoria;
using library_jc_API.Dtos.Livro;
using library_jc_API.Models;

namespace library_jc_API.Mappers
{
    public static class LivroMapper
    {
        public static LivroDto ToLivroDto(this Livro livro)
        {
            return new LivroDto
            {
                LivroId = livro.LivroId,
                Titulo = livro.Titulo,
                Paginas = livro.Paginas,
                ISBN = livro.ISBN,
                Idioma = livro.Idioma,
                Editora = livro.Editora,
                Edicao = livro.Edicao,
                Disponivel = livro.Disponivel,
                Descricao = livro.Descricao,
                DataPublicacao = livro.DataPublicacao,
                Categoria = livro.Categoria!.ToCategoriaDto(),
                Autor = livro.Autor!.ToAutorDto(),
            };
        }

        public static LivroDto ToLivroDtoPartial(this Livro livro)
        {
            return new LivroDto
            {
                LivroId = livro.LivroId,
                Titulo = livro.Titulo,
                Paginas = livro.Paginas,
                ISBN = livro.ISBN,
                Idioma = livro.Idioma,
                Editora = livro.Editora,
                Edicao = livro.Edicao,
                Disponivel = livro.Disponivel,
                Descricao = livro.Descricao,
                DataPublicacao = livro.DataPublicacao,
                Categoria = new CategoriaDto { CategoriaId = livro.CategoriaId },
                Autor = new AutorDto { AutorId = livro.AutorId },
            };
        }

        public static Livro ToCreateLivroDto(this CreateLivroDto livroDto)
        {
            return new Livro
            {
                Titulo = livroDto.Titulo,
                Paginas = livroDto.Paginas,
                ISBN = livroDto.ISBN,
                Idioma = livroDto.Idioma,
                Editora = livroDto.Editora,
                Edicao = livroDto.Edicao,
                Disponivel = livroDto.Disponivel,
                Descricao = livroDto.Descricao,
                DataPublicacao = livroDto.DataPublicacao,
                CategoriaId = livroDto.CategoriaId,
                AutorId = livroDto.AutorId,
            };
        }

        public static Livro ToUpdateLivroDto(this UpdateLivroDto livroDto, int id)
        {
            return new Livro
            {
                LivroId = id,
                Titulo = livroDto.Titulo,
                Paginas = livroDto.Paginas,
                ISBN = livroDto.ISBN,
                Idioma = livroDto.Idioma,
                Editora = livroDto.Editora,
                Edicao = livroDto.Edicao,
                Disponivel = livroDto.Disponivel,
                Descricao = livroDto.Descricao,
                DataPublicacao = livroDto.DataPublicacao,
                CategoriaId = livroDto.CategoriaId,
                AutorId = livroDto.AutorId,
            };
        }
    }
}
