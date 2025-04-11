using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2425;

internal class Constants {
    private const string DBFileName = "SQLite.db3";

    public const SQLiteOpenFlags Flags = 
        SQLiteOpenFlags.ReadWrite | 
        SQLiteOpenFlags.Create | 
        SQLiteOpenFlags.SharedCache;

    public static string DatabasePath
    {
        get
        {
            return Path.Combine(FileSystem.AppDataDirectory, DBFileName);
        }
    }

    public const string RecipeURL = "https://localhost:8080/recipes";
}
