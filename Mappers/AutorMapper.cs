using library_jc_API.Dtos.Autor;
using library_jc_API.Models;

namespace library_jc_API.Mappers
{
    public static class AutorMapper
    {
        public static AutorDto ToAutorDto(this Autor autorModel)
        {
            return new AutorDto
            {
                AutorId = autorModel.AutorId,
                Biografia = autorModel.Biografia,
                DataNascimento = autorModel.DataNascimento,
                Nome = autorModel.Nome,
                PaisOrigem = autorModel.PaisOrigem,
            };
        }

        public static Autor ToCreateAutorDto(this CreateAutorDto autorModel)
        {
            return new Autor
            {
                Biografia = autorModel.Biografia,
                DataNascimento = autorModel.DataNascimento,
                Nome = autorModel.Nome,
                PaisOrigem= autorModel.PaisOrigem,
            };
        }

        public static Autor ToUpdateAutorDto(this UpdateAutorDto autorModel, int id)
        {
            return new Autor
            {
                AutorId = id,
                Biografia = autorModel.Biografia,
                DataNascimento = autorModel.DataNascimento,
                Nome = autorModel.Nome,
                PaisOrigem = autorModel.PaisOrigem,
            };
        }

    }
}
