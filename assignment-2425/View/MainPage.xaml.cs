using assignment_2425.Model;
using assignment_2425.ViewModel;
using System.Collections.ObjectModel;

namespace assignment_2425.View
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as HomeViewModel)?.LoadRecipesAsync();
        }

    }

}
