using SQLite;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace assignment_2425.Model;

public class  Recipe
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    [Column("name"), Indexed, NotNull]
    public string Name { get; set; }
    [Column("description")]
    public string? Description { get; set; }
    [Column("imageurl")]
    public string ImageUrl { get; set; }
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    
}