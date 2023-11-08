using Blog.Models;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.TagScreens
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criar uma Tag");
            Console.WriteLine("Digite o nome da Tag:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o Slug da Tag:");
            string slug = Console.ReadLine();

            try
            {
                Create(nome, slug);
                Console.WriteLine("Tag Cadastrada com sucesso!");
                Console.ReadKey();
                MenuTagScreen.Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro nas informações de cadastro, tente novamente");
                Console.ReadKey();
                CreateTagScreen.Load();
            }




        }

        public static void Create(string name, string slug)
        {
            try
            {
                Tag tag = new Tag { Name = name, Slug = slug };
                var repository = new Repository<Tag>();
                repository.Create(tag);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel Cadastrar a Tag");
            }
        }
    }
}
