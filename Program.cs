using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=DESKTOP-BVKU5HC;Database=balta;Trusted_Connection=True;TrustServerCertificate=True";





using (var connection = new SqlConnection(connectionString))
{
    //UpdateCategory(connection);
    //DeleteCategory(connection);
    CreateManyCategory(connection);
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

static void UpdateCategory(SqlConnection connection)
{
    Category category = new Category(new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"), "FrontEnd 2021");
    var UpdateQuery = "UPDATE [Category] SET [Title]=@Title WHERE [Id]=@Id";
    var rows = connection.Execute(UpdateQuery, new
    {
        category.Id,
        category.Title
    });
    Console.WriteLine($"{rows} linhas Atualizadas;");
}

static void DeleteCategory(SqlConnection connection)
{
    Category category = new Category(new Guid("25d510c8-3108-44c2-86c5-924d9832aa8c"));
    var DeleteQuery = "DELETE [Category] WHERE [Id]=@Id";
    var rows = connection.Execute(DeleteQuery, new
    {
        category.Id
    });
    Console.WriteLine($"{rows} linhas Deletadas;");
}

static void CreateManyCategory(SqlConnection connection)
{
    Category category = new Category("Azure", "Azure", "Categoria destinada a serviços Azure", 5, "Azure", false);
    Category category2 = new Category("Categoria nova", "Categoria nova", "Categoria Nova", 3, "Nova", true);

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

    var rows = connection.Execute(insertSql, new[]{
        new 
        {   
            category.Id,
            category.Title,
            category.Url,
            category.Summary,
            category.Order,
            category.Description,
            category.Featured
            },
        new
        {
            category2.Id,
            category2.Title,
            category2.Url,
            category2.Summary,
            category2.Order,
            category2.Description,
            category2.Featured
        }
    });

    Console.WriteLine($"{rows} linhas inseridas;");
}



