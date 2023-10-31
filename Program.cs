using BaltaDataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;

const string connectionString = "Server=DESKTOP-BVKU5HC;Database=balta;Trusted_Connection=True;TrustServerCertificate=True";





using (var connection = new SqlConnection(connectionString))
{
    //UpdateCategory(connection);
    //DeleteCategory(connection);
    //CreateManyCategory(connection);
    //ListCategories(connection);
    //GetCategory(connection, "06d73e6b-315f-4cfc-b462-f643e1a50e97");
    //ExecuteProcedure(connection);
    ExecuteReadProcedure(connection);

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

static void GetCategory(SqlConnection connection, string stringId)
{
    try
    {
        Category categorySelect = new Category(new Guid(stringId));
        Category category = connection.QueryFirst<Category>("SELECT [Id], [Title], [Url], [Summary] FROM [Category] WHERE [Id]=@Id", new { categorySelect.Id });


        Console.WriteLine($"{category.Id}, {category.Title}, {category.Url}, {category.Summary}");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Category not found");
    }



}

static void ExecuteProcedure(SqlConnection connection)
{
    var sql = "spDeleteStudent";
    var param = new { StudentId = "6719CA6F-645B-4AA4-B92C-063264F1F6C6" };
    var rows = connection.Execute(sql, param, commandType: System.Data.CommandType.StoredProcedure);
    Console.WriteLine($"{rows} Rows Deleted");

}

static void ExecuteReadProcedure(SqlConnection connection)
{
    var sql = "spGetCoursesByCategory";
    var param = new { CategoryId = "AF3407AA-11AE-4621-A2EF-2028B85507C4" };
    var courses = connection.Query(sql, param, commandType: System.Data.CommandType.StoredProcedure);
    foreach(var item in courses)
    {
        Console.WriteLine($"{item.Id}, {item.Title}, {item.Summary}, {item.Tag}");
    }
}



