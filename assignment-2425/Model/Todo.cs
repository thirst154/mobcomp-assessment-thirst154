using System.ComponentModel;

namespace assignment_2425.Model;

public class Todo : INotifyPropertyChanged
{
    private bool isCompleted;
    public string Text { get; set; }

    public bool IsCompleted {
        get => isCompleted;
        set {
            if (isCompleted != value) { 
                isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
