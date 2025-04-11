using SQLite;

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
