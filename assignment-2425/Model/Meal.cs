using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2425.Model;


public class Meal : ObservableObject
{
    private bool _isCompleted;
    private string _name;
    private string _description;
    // private DateTime _dueDate;

    public bool IsCompleted
    {
        get => _isCompleted;
        set => SetProperty(ref _isCompleted, value);
    }

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    //public DateTime DueDate
    //{
    //    get => _dueDate;
    //    set => SetProperty(ref _dueDate, value);
    //}
}
