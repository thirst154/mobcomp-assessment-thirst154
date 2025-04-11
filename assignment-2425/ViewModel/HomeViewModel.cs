using assignment_2425.Model;
using assignment_2425.Repositories;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Windows.Input;

namespace assignment_2425.ViewModel;

public class HomeViewModel : BaseCrudViewModel<Recipe>
{

    public ObservableCollection<Recipe> Recipes { get; set; }
    private IngredientRepo IngredientRepo { get; set; } = new IngredientRepo();
    private MealRepo MealRepo { get; set; } = new MealRepo();

    private string newRecText;
    private string newRecDesc;

    public string NewRecText
    {
        get => newRecText;
        set => SetProperty(ref newRecText, value);
    }

    public string NewRecDesc
    {
        get => newRecDesc;
        set => SetProperty(ref newRecDesc, value);
    }

    public ICommand AddCardCommand { get; }

    public HomeViewModel() : base(new RecipeRepo())
    {
        Items.Add(new Recipe
        {
            Name = "Pizza",
            Description = "Margherita Pizza Prep: 25mins",
            ImageUrl = "Resources/Images/pizza.jpg",
            Ingredients = new List<Ingredient>                 {
                    new Ingredient { Name="Flour", Description="2 cups" },
                    new Ingredient { Name="Tomato Sauce", Description="1 cup" },
                    new Ingredient { Name="Mozzarella Cheese", Description="1 cup" },
                    new Ingredient { Name="Basil", Description="Fresh leaves" }
                }
        });

        Items.Add(new Recipe
        {
            Name = "Pasta",
            Description = "Margherita Pizza Prep: 25mins",
            ImageUrl = "Resources/Images/pasta.jpg",
            Ingredients = new List<Ingredient>                 {
                    new Ingredient { Name="Onion", Description="1" },
                    new Ingredient { Name="Tomato Sauce", Description="1 cup" },
                    new Ingredient { Name="Pasta", Description="1 cup" },
                    new Ingredient { Name="Basil", Description="Fresh leaves" }
                }
        });
        Items.Add(new Recipe
        {
            Name = "Salad",
            Description = "Margherita Pizza Prep: 25mins",
            ImageUrl = "Resources/Images/food1.jpg",
            Ingredients = new List<Ingredient>                 {
                    new Ingredient { Name="Lettuce", Description="1 head" },
                    new Ingredient { Name="Tomato", Description="1" },
                    new Ingredient { Name="Cucumber", Description="1" },
                    new Ingredient { Name="Olive Oil", Description="2 tbsp" }
                }
        });


        AddCardCommand = new Command<Recipe>(AddCardAsync);
    }

    protected override Recipe CreateNewItem()
    {
        if (string.IsNullOrWhiteSpace(NewRecText)) return null;

        var recipe = new Recipe
        {
            Name = NewRecText,
            Description = NewRecDesc,
        };

        NewRecDesc = string.Empty;
        NewRecText = string.Empty;
        return recipe;

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

    public async Task LoadRecipesAsync()
    {
        try
        {
            using var client = new HttpClient();
            var url = Constants.RecipeURL;

            var response = await client.GetStringAsync(url);

            var recipeList = await client.GetFromJsonAsync<List<Recipe>>(url);


        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error fetching recipes: {ex.Message}");
            Shell.Current.DisplayAlert("Error", "Failed to load recipes \n Error:" + ex.Message, "OK");
        }
    }



}