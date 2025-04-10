using assignment_2425.Repositories;
using assignment_2425.ViewModel;

namespace assignment_2425.View;

public partial class Shopping : ContentPage
{
	public Shopping()
	{
		InitializeComponent();
	}

    private IngredientRepo ingredientRepo = new IngredientRepo();

    private void CheckBox_CheckChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkbox && checkbox.BindingContext is Model.Ingredient ingredient)
        {
            ingredient.IsCompleted = e.Value;
            ingredientRepo.AddOrUpdate(ingredient);
        }
    }

    private void OnPickerFocused(object sender, FocusEventArgs e)
    {
        var viewModel = BindingContext as ShoppingViewModel;
        viewModel?.RefreshPickerOptions();
        (sender as Picker).ItemsSource = viewModel?.Options;
    }


}