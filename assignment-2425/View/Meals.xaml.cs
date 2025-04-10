using assignment_2425.Repositories;

namespace assignment_2425.View;

public partial class Meals : ContentPage
{
	public Meals()
	{
		InitializeComponent();
	}

	private MealRepo mealRepo = new MealRepo();

	private void CheckBox_CheckChanged(object sender, CheckedChangedEventArgs e)
	{
		if (sender is CheckBox checkbox && checkbox.BindingContext is Model.Meal meal)
		{
			meal.IsCompleted = e.Value;
			mealRepo.AddOrUpdate(meal);
		}
	}
}