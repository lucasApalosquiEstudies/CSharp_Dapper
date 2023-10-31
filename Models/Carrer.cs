using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaDataAccess.Models
{
    public class Carrer
    {
        public Carrer()
        {
            CareerItems = new List<CarrerItem>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<CarrerItem> CareerItems { get; set; }
    }
}
