﻿using library_jc_API.Models;

namespace library_jc_API.Repository.Interfaces;

public interface ILivroRepository
{
    Task<IEnumerable<Livro>> GetAllAsync();
    Task<Livro?> GetByIdAsync(int id);
    Task<Livro?> CreateAsync(Livro livro);
    Task<Livro?> UpdateAsync(Livro livro);
    Task<Livro?> DeleteAsync(Livro livro);
    Task<Livro?> GetByTitleAsync(string titulo);
}
