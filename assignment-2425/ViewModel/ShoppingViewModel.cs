using assignment_2425.Model;
using assignment_2425.Repositories;
using System.Windows.Input;

namespace assignment_2425.ViewModel;

public partial class ShoppingViewModel : BaseCrudViewModel<Ingredient>
{
    private string newIngText;
    private string newIngDesc;
    private string newMeal;

    public string NewIngText
    {
        get => newIngText;
        set => SetProperty(ref newIngText, value);
    }

    public string NewIngDesc
    {
        get => newIngDesc;
        set => SetProperty(ref newIngDesc, value);
    }

    public string NewMeal
    {
        get => newMeal;
        set => SetProperty(ref newMeal, value);
    }

    public List<String> Options { get; set; }

    public ICommand EditCommand { get; }

    public ShoppingViewModel() : base(new IngredientRepo())
    {

        Options = new List<String>();
        RefreshPickerOptions();
        EditCommand = new Command<Ingredient>(EditItem);
    }

    protected override Ingredient CreateNewItem()
    {
        if (string.IsNullOrWhiteSpace(NewIngText)) return null;

        var item = new Ingredient
        {
            Name = NewIngText,
            Description = NewIngDesc,
            IsCompleted = false,
        };

        NewIngText = string.Empty;
        NewIngDesc = string.Empty;
        return item;
    }

    public async void EditItem(Ingredient item)
    {
        var newName = await Application.Current.MainPage.DisplayPromptAsync("Edit Name", "Enter new name:", initialValue: item.Name);
        var newDesc = await Application.Current.MainPage.DisplayPromptAsync("Edit Desciption", "Enter new description:", initialValue: item.Description);

        if (!string.IsNullOrWhiteSpace(newName))
        {
            item.Name = newName;
            item.Description = newDesc;

            repo.AddOrUpdate(item);
            Refresh();
        }
    }

    public void RefreshPickerOptions()
    {

        MealRepo mealRepo = new MealRepo();

        Options.Clear();
        foreach (var item in mealRepo.GetAll())
        {
            Options.Add(item.Name);
        }
    }

    public void StartListeningToShakes()
    {
        if (!Accelerometer.IsMonitoring)
        {
            Accelerometer.ShakeDetected += OnShakeDetected;
            Accelerometer.Start(SensorSpeed.Game);
        }
    }

    public void StopListeningToShakes()
    {
        if (Accelerometer.IsMonitoring)
        {
            Accelerometer.ShakeDetected -= OnShakeDetected;
            Accelerometer.Stop();
        }
    }

    private void OnShakeDetected(object? sender, EventArgs e)
    {
        Accelerometer.Stop();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            foreach (var meal in repo.GetAll())
            {
                if (!meal.IsCompleted)
                {
                    meal.IsCompleted = true;
                    repo.AddOrUpdate(meal);
                }
            }
            Shell.Current.DisplayAlert("Meals Completed", "All meals marked as done!", "OK");
            Accelerometer.Start(SensorSpeed.Game);
            Refresh();
        });
    }
}