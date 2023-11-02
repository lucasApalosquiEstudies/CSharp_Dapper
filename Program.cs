﻿
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=DESKTOP-BVKU5HC;Database=Blog;Trusted_Connection=True;TrustServerCertificate=True";

ReadUsers();
//ReadUser();
//CreateUser();

static void ReadUsers()
{
    using (var connection = new SqlConnection(CONNECTION_STRING))
    {
        var users = connection.GetAll<User>();
        foreach (var user in users)
        {
            Console.WriteLine(user.Name);
        }
    }
}

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
