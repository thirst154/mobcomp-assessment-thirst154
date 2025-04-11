using assignment_2425.Model;
using assignment_2425.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace assignment_2425.ViewModel;

public class HomeViewModel { 

    public ObservableCollection<Recipe> Recipes { get; set; }
    private IngredientRepo IngredientRepo { get; set; } = new IngredientRepo();
    private MealRepo MealRepo { get; set; } = new MealRepo();

    public ICommand AddCardCommand { get; }

    public HomeViewModel()
    {
        Recipes = new ObservableCollection<Recipe> {

            new Recipe { Name="Test", ImageUrl="Resources/Images/food1.jpg", Ingredients = new List<Ingredient>{ new Ingredient { Name="Ingredient1"} } },
            new Recipe { Name="Test1 With Description", Description="A description", ImageUrl="Resources/Images/food2.jpg"},
            new Recipe { Name="Test2 With Description", Description="A description", ImageUrl="Resources/Images/food1.jpg"},
        };

        AddCardCommand = new Command<Recipe>(AddCardAsync);
    }

    private async void AddCardAsync(Recipe recipe)
    {
        

        bool confirmAdd = await Application.Current.MainPage.DisplayAlert("Confirm Add", "Are you sure you want to add this item?", "Yes", "No");
        if (confirmAdd)
        {
            MealRepo.Add(new Meal { Name = recipe.Name, Description = recipe.Description });
            foreach (var ingredient in recipe.Ingredients)
            {
                IngredientRepo.Add(new Ingredient { Name = ingredient.Name, Description = ingredient.Description });
            }
        }
    }



}