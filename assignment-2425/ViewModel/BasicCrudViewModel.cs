using assignment_2425.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace assignment_2425.ViewModel;

public abstract partial class BaseCrudViewModel<T> : ObservableObject where T : class, new()
{
    protected readonly BaseRepository<T> repo;

    public ObservableCollection<T> Items { get; set; }

    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }

    public BaseCrudViewModel(BaseRepository<T> repository)
    {
        repo = repository;
        Items = new ObservableCollection<T>(repo.GetAll());

        AddCommand = new Command(AddItem);
        DeleteCommand = new Command<T>(DeleteItem);
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




    protected virtual async void DeleteItem(T item)
    {
        var idProp = item?.GetType().GetProperty("Id");
        if (idProp != null && item != null)
        {
            bool confirmDelete = await Application.Current.MainPage.DisplayAlert("Confirm Delete", "Are you sure you want to delete this item?", "Yes", "No");
            if (confirmDelete)
            {
                //int id = (int)idProp.GetValue(item);
                repo.Delete(item);
                Refresh();
            }
        }
    }




    public void Refresh()
    {
        Items.Clear();
        foreach (var item in repo.GetAll())
            Items.Add(item);
    }
}