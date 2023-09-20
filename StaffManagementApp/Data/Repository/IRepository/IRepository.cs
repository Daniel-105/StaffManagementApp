﻿using System.Linq.Expressions;

namespace StaffManagementApp.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // T - Category Type
        IEnumerable<T> GetAll(string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}