using assignment_2425.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace assignment_2425.ViewModel;


public class TodoViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Todo> Todos { get; set; }

    private string newTodoText;
    public string NewTodoText
    {
        get => newTodoText;
        set
        {
            if (newTodoText != value) { 
                newTodoText = value;
                onPropertyChanged(nameof(NewTodoText));
            }
        }
    }

    public ICommand AddTodoCommand { get; }
    public ICommand DeleteTodoCommand { get; }

    public TodoViewModel()
    {
        Todos = new ObservableCollection<Todo>
        {
            new Todo { Text = "Buy milk" },
            new Todo { Text = "Walk dog" },
            new Todo { Text = "Do laundry" }
        };

        AddTodoCommand = new Command(AddTodo);
        DeleteTodoCommand = new Command<Todo>(DeleteTodo);
    }

    private void AddTodo()
    {
        if (!string.IsNullOrWhiteSpace(NewTodoText))
        {
            Console.WriteLine($"Adding: {NewTodoText}");
            Todos.Add(new Todo { Text = NewTodoText });
            NewTodoText = string.Empty;

        }
    }

    private void DeleteTodo(Todo Item)
    {
        if (Todos.Contains(Item)) 
        { 
            Todos.Remove(Item);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void onPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
