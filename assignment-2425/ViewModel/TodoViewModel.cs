namespace assignment_2425.ViewModel;

using assignment_2425.Model;
using System.Collections.ObjectModel;

public class TodoViewModel
{
    public ObservableCollection<Todo> Todos { get; set; }

    public TodoViewModel()
    {
        Todos = new ObservableCollection<Todo>
        {
            new Todo { Text = "Buy milk" },
            new Todo { Text = "Walk dog" },
            new Todo { Text = "Do laundry" }
        };
    }
}
