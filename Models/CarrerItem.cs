﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaDataAccess.Models
{
    public class CarrerItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Course Course { get; set; }
    }
}
