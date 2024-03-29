﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace ART_App.Repositories
{
    //Manipulation operations
    public interface IRepositories<T> where T : class
    {
        Task Create(T obj);
        Task<T> Update(int id, T obj);
        Task<T> Delete(int id);
    }

    //Query operations
    public interface IGetRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

    }
}
