namespace assignment_2425.Model;

public class Todo : ObservableObject
{
    private bool isCompleted;

    public bool IsCompleted
    {
        get => isCompleted;
        set => SetProperty(ref isCompleted, value);
    }
}
