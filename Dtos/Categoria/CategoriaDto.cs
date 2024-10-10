using System.ComponentModel.DataAnnotations;

namespace library_jc_API.Dtos.Categoria
{
    public class CategoriaDto
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}
