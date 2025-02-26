using assignment_2425.Model;
using System.Collections.ObjectModel;

namespace assignment_2425.View
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Todo> Todos { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Todos = new ObservableCollection<Todo>
            {
                new Todo { Title="Testing1", Status = false},
                new Todo { Title="Testing2", Status = true},
                new Todo { Title="Testing3", Status = false},
                new Todo { Title="Testing1", Status = false},
                new Todo { Title="Testing2", Status = true},
                new Todo { Title="Testing1", Status = false},
                new Todo { Title="Testing2", Status = true},
                new Todo { Title="Testing3", Status = false},
                new Todo { Title="Testing3", Status = false},
            };

            BindingContext = this;
        }

        
    }

}
