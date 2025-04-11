using Microsoft.VisualBasic;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2425.Model;

[Table("Meals")]
public class Meal : Todo
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Column("name"), Indexed, NotNull]
    public string Name { get; set; }
    [MaxLength(200)]
    public string? Description { get; set; }

}
