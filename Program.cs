
using Blog;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=DESKTOP-BVKU5HC;Database=Blog;Trusted_Connection=True;TrustServerCertificate=True";
Database.connection = new SqlConnection(CONNECTION_STRING);
Database.connection.Open();

Load("");

Console.ReadKey();
Database.connection.Close();

static void Load(string message)
{
    Console.Clear();
    
    Console.WriteLine("Meu Blog");
    Console.WriteLine("----------------");
    Console.WriteLine("O que deseja Fazer?");
    Console.WriteLine();
    Console.WriteLine("1 - Gestão de Usuário");
    Console.WriteLine("2 - Gestão de Perfil");
    Console.WriteLine("3 - Gestão de Categoria");
    Console.WriteLine("4 - Gestão de Tag");
    Console.WriteLine("5 - Vincular Perfil/Usuário");
    Console.WriteLine("6 - Vincular Post/Tag");
    Console.WriteLine("7 - relatórios");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine(message);
    try
    {
        var option = short.Parse(Console.ReadLine()!);
        switch (option)
        {
            case 4:
                MenuTagScreen.Load();
                break;

            default:

                Load("Opção inválida, tente novamente!");
                break;

        }
    }
    catch (Exception ex)
    {

        Load("Por favor digite uma das opções");
    }



}



