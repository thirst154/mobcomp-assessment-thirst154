using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace assignment_2425.Model;

[Table("Ingredients")]
public class Ingredient : Todo
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Column("name"), Indexed, NotNull, JsonPropertyName("name")]
    public string Name { get; set; }
    [MaxLength(200), JsonPropertyName("description")]
    public string? Description { get; set; }
    [Column("MealId")]
    public int MealId { get; set; }

}