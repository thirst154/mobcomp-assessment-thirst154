using assignment_2425.Model;
using assignment_2425.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2425.ViewModel;

public partial class ShoppingViewModel : BaseCrudViewModel<Ingredient>
{
    private string newIngText;
    private string newIngDesc;

    public string NewIngText
    {
        get => newIngText;
        set => SetProperty(ref newIngText, value);
    }

    public string NewIngDesc
    {
        get => newIngDesc;
        set => SetProperty(ref newIngDesc, value);
    }

    public ShoppingViewModel() : base(new IngredientRepo()) { }

    protected override Ingredient CreateNewItem()
    {
        if (string.IsNullOrWhiteSpace(NewIngText)) return null;

        var item = new Ingredient
        {
            Name = NewIngText,
            Description = NewIngDesc,
            IsCompleted = false,
        };

        NewIngText = string.Empty;
        NewIngDesc = string.Empty;
        return item;
    }
}