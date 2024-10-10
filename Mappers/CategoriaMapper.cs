using library_jc_API.Dtos.Categoria;
using library_jc_API.Models;

namespace library_jc_API.Mappers
{
    public static class CategoriaMapper
    {
        public static CategoriaDto ToCategoriaDto(this Categoria categoria)
        {
            return new CategoriaDto
            {
                CategoriaId = categoria.CategoriaId,
                Descricao = categoria.Descricao,
                Nome = categoria.Nome,
            };
        }

        public static Categoria ToCreateCategoriaDto(this CreateCategoriaDto categoriaDto)
        {
            return new Categoria
            {
                Nome = categoriaDto.Nome,
                Descricao = categoriaDto.Descricao,
            };
        }

        public static Categoria ToUpdateCategoriaDto(this UpdateCategoriaDto categoriaDto, int id)
        {
            return new Categoria
            {
                CategoriaId = id,
                Descricao = categoriaDto.Descricao,
                Nome = categoriaDto.Nome
            };
        }
    }
}
