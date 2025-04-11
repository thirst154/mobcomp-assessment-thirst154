using assignment_2425.Model;
using assignment_2425.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace assignment_2425.ViewModel;

public partial class MealsViewModel : BaseCrudViewModel<Meal>
{
    private string newMealText;
    private string newMealDesc;

    public string NewMealText
    {
        get => newMealText;
        set => SetProperty(ref newMealText, value);
    }

    public string NewMealDesc
    {
        get => newMealDesc;
        set => SetProperty(ref newMealDesc, value);
    }

    

    public ICommand EditCommand { get; }
    public MealsViewModel() : base(new MealRepo()) {

        EditCommand = new Command<Meal>(EditItem);
    }

    protected override Meal CreateNewItem()
    {
        if (string.IsNullOrWhiteSpace(NewMealText)) return null;

        var meal = new Meal
        {
            Name = NewMealText,
            Description = NewMealDesc,
            IsCompleted = false
        };

        NewMealDesc = string.Empty;
        NewMealText = string.Empty;
        return meal;

    }

    private async void EditItem(Meal item)
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
            Refresh();
        });
    }




}