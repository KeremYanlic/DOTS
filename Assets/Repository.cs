using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repository<T> : IRepository<T> where T: class
{
    private readonly List<T> _context = new List<T>();

    public void Add(T entity)
    {
        _context.Add(entity);
    }

    public IEnumerable<T> GetAll()
    {
        return _context;
    }

    public T GetByID(int id)
    {
        return _context[id];
    }

    public void Remove(T entity)
    {
        _context.Remove(entity);
    }
}

public class RepositoryForECommerce
{

}

public class RepositoryManager
{
    public RepositoryForECommerce repositoryForE = new RepositoryForECommerce();
    public Repository<RepositoryForECommerce> repositoryForECommerce = new Repository<RepositoryForECommerce>();

    public void Add()
    {
        repositoryForECommerce.Add(repositoryForE);
    }
}