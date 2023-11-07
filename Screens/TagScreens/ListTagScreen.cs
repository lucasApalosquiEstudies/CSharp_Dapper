using Blog.Models;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.TagScreens
{
    public static class ListTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Listagem de Tags");
            List();
        }

        private static void List()
        {
            var repository = new Repository<Tag>();
            var tags = repository.GetAll();
            foreach (var tag in tags)
            {
                Console.WriteLine($"{tag.Id} - {tag.Name} ({tag.Slug})");
            }
        }
    }
}
