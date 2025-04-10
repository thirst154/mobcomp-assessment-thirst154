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

    public MealsViewModel() : base(new MealRepo()) { }

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
}