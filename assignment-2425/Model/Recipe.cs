using System.Text.Json.Serialization;

namespace assignment_2425.Model;

public class Recipe
{
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    public string? Description { get; set; }
    public string ImageUrl { get; set; }
    [JsonPropertyName("ingredients")]
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

}