using assignment_2425.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace assignment_2425.ViewModel;

public abstract partial class BaseCrudViewModel<T> : ObservableObject where T : class, new()
{
    protected readonly BaseRepository<T> repo;

    public ObservableCollection<T> Items { get; set; }

    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand EditCommand { get; }

    public BaseCrudViewModel(BaseRepository<T> repository) { 
        repo = repository;
        Items = new ObservableCollection<T>(repo.GetAll());

        AddCommand = new Command(AddItem);
        DeleteCommand = new Command<T>(DeleteItem);
        EditCommand = new Command<T>(EditItem);
    }

    protected abstract T CreateNewItem();

    protected virtual void AddItem()
    { 
        var item = CreateNewItem();
        if (item != null)
        {
            repo.Add(item);
            Refresh();
        }
    }

    protected virtual void DeleteItem(T item)
    {
        var idProp = item?.GetType().GetProperty("Id");
        if (idProp != null && item != null)
        {
            int id = (int)idProp.GetValue(item);
            repo.Delete(id);
            Refresh();
        }
    }

    protected virtual void EditItem(T item)
    {
        if (item != null)
        { 
            repo.AddOrUpdate(item);
            Refresh();
        }
    }

    protected void Refresh() {
        Items.Clear();
        foreach (var item in repo.GetAll())
            Items.Add(item);
    }
}