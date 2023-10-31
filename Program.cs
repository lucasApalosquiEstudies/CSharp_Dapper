using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=DESKTOP-BVKU5HC;Database=balta;Trusted_Connection=True;TrustServerCertificate=True";





using (var connection = new SqlConnection(connectionString))
{
    ListCategories(connection);

}

static void ListCategories(SqlConnection connection)
{
    var categories = connection.Query<Category>("SELECT [Id], [Title] Title FROM [Category]");
    foreach (var item in categories)
    {
        Console.WriteLine(item.Id + ", " + item.Title);
    }
}

static void CreateCategory(SqlConnection connection)
{
    Category category = new Category("Amazon AWS", "Amazon", "Categoria destinada a serviços AWS", 8, "AWS Cloud", false);

    var insertSql = @"INSERT INTO 
    [Category] 
        VALUES(
            @Id, 
            @Title, 
            @Url, 
            @Summary, 
            @Order, 
            @Description, 
            @Featured)";

    var rows = connection.Execute(insertSql, new
    {
        category.Id,
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Featured
    });
    Console.WriteLine($"{rows} linhas inseridas;");
}



