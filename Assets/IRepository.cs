using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRepository<T>
{
    void Add(T entity);
    T GetByID(int id);
    IEnumerable<T> GetAll();
    void Remove(T entity);
}
