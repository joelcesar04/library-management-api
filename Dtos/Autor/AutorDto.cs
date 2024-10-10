using library_jc_API.Models;

namespace library_jc_API.Dtos.Autor
{
    public class AutorDto
    {
        public int AutorId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string PaisOrigem { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Biografia { get; set; } = string.Empty;
    }
}
