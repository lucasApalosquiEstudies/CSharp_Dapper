
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

const string CONNECTION_STRING = "Server=DESKTOP-BVKU5HC;Database=Blog;Trusted_Connection=True;TrustServerCertificate=True";
var connection = new SqlConnection(CONNECTION_STRING);
connection.Open();

connection.Close();




