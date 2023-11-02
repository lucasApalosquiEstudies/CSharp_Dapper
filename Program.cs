
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=DESKTOP-BVKU5HC;Database=Blog;Trusted_Connection=True;TrustServerCertificate=True";

//ReadUsers();
//ReadUser();
//CreateUser();
//UpdateUser();
//DeleteUser(2);

static void ReadUser()
{
    using (var connection = new SqlConnection(CONNECTION_STRING))
    {
        var user = connection.Get<User>(1);
        Console.WriteLine($"{user.Name}");

    }
}

static void CreateUser()
{
    var user = new User();
    user.Name = "Rodrigo Faro";
    user.Email = "rodrigo.faro@email.com";
    user.Passwordhash = "HASH";
    user.Bio = "Apenas um apresentador";
    user.Image = "Http://";
    user.Slug = "rodrigo-faro";

    using (var connection = new SqlConnection(CONNECTION_STRING))
    {
        connection.Insert(user);
        Console.WriteLine("Cadastro Realizado com Sucesso!");
    }
}

static void UpdateUser()
{
    var user = new User();
    user.Id = 2;
    user.Name = "Rodrigo Faro Almeida";
    user.Email = "rodrigo.faro@email.com";
    user.Passwordhash = "HASH";
    user.Bio = "Apenas um apresentador";
    user.Image = "Http://";
    user.Slug = "rodrigo-faro";

    using (var connection = new SqlConnection(CONNECTION_STRING))
    {
        connection.Update(user);
        Console.WriteLine("Cadastro Alterado com Sucesso!");
    }
}

static void DeleteUser(int id)
{
    var user = new User();
    user.Id = id;

    using (var connection = new SqlConnection(CONNECTION_STRING))
    {
        connection.Delete(user);
        Console.WriteLine("Cadastro Excluido com Sucesso!");
    }
}


