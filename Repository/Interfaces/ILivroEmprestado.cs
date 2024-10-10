using library_jc_API.Models;

namespace library_jc_API.Repository.Interfaces
{
    public interface ILivroEmprestado
    {
        Task<List<LivroEmprestado>> GetAllAsync();
    }
}
