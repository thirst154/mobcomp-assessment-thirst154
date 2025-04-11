using SQLite;
using System.Text.Json.Serialization;

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