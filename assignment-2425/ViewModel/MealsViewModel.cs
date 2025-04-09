using assignment_2425.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace assignment_2425.ViewModel;

public class MealsViewModel : ObservableObject
{
    public ObservableCollection<Meal> Meals { get; set; }

    private string _newMealText;
    public string NewMealText
    {
        get => _newMealText;
        set => SetProperty(ref _newMealText, value);
    }

    private string _newMealDesc;
    public string NewMealDesc
    {
        get => _newMealDesc;
        set => SetProperty(ref _newMealDesc, value);
    }

    public ICommand AddMealCommand { get; }
    public ICommand DeleteMealCommand { get; }
    public ICommand EditMealCommand { get; }

    public MealsViewModel()
    {
        Meals = new ObservableCollection<Meal>
        {
            new Meal { Name = "Chicken Wraps", Description = "Chicken in a wrap", IsCompleted = false },
            new Meal { Name = "Curry", Description = "Chicken in a curry", IsCompleted = false  },
            new Meal { Name = "Pasta", Description = "Chicken in a pasta", IsCompleted = false  }
        };

        AddMealCommand = new Command(AddMeal);
        DeleteMealCommand = new Command<Meal>(DeleteMeal);
        EditMealCommand = new Command<Meal>(EditMeal);


    }

    private void AddMeal() {
        if (!string.IsNullOrWhiteSpace(NewMealText))
        {
            Console.WriteLine($"Adding: {NewMealText}");
            Meals.Add(new Meal { Name = NewMealText, Description = NewMealDesc, IsCompleted = false });
            NewMealText = string.Empty;
            NewMealDesc = string.Empty;
        }

    }
    private void DeleteMeal(Meal Item) {
        if (Meals.Contains(Item))
        {
            Meals.Remove(Item);
        }
    }
    private void EditMeal(Meal Item) { }
}
