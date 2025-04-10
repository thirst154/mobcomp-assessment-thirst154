using assignment_2425.Repositories;

namespace assignment_2425
{
    public partial class App : Application
    {
        public static MealRepo MealRepo { get; private set; }
        public static IngredientRepo IngredientRepo { get; private set; }
        public App(MealRepo mealRepo, IngredientRepo ingredientRepo)
        {
            InitializeComponent();
            MealRepo = mealRepo;
            IngredientRepo = ingredientRepo;

            MainPage = new AppShell();
        }
    }
}
