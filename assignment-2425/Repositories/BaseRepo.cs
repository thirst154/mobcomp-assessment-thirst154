using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace assignment_2425.Repositories;

public abstract class BaseRepository<T> where T : new()
{
    protected SQLiteConnection connection;
    public string StatusMessage { get; protected set; }

    public BaseRepository()
    {
        connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        connection.CreateTable<T>();
    }

    public void Add(T item)
    {
        try
        {
            int result = connection.Insert(item);
            StatusMessage = $"{result} row(s) added";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public List<T> GetAll()
    {
        try
        {
            return connection.Table<T>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }

        return null;
    }

    public T Get(int id)
    {
        try
        {
            return connection.Table<T>().FirstOrDefault(x => (int)x.GetType().GetProperty("Id").GetValue(x) == id);
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }

        return default;
    }

    public T Get(string name)
    {
        try
        {

            return connection.Table<T>().FirstOrDefault(x => (string)x.GetType().GetProperty("Name").GetValue(x) == name);
        }
        catch (Exception ex) {
            StatusMessage = $"Error: {ex.Message}";
        }

        return default;
    
    }

    public void AddOrUpdate(T item)
    {
        try
        {
            var idProp = item.GetType().GetProperty("Id");
            int id = (int)(idProp?.GetValue(item) ?? 0);
            int result = id != 0 ? connection.Update(item) : connection.Insert(item);
            StatusMessage = $"{result} row(s) {(id != 0 ? "updated" : "inserted")}";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public void Delete(int id)
    {
        try
        {
            var item = Get(id);
            connection.Delete(item);
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public void Delete(T item)
    {
        try
        {
            connection.Delete(item);
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }
}
