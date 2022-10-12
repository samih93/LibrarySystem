﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string color { get; set; }

        public int categoryId { get; set; }
        public Category category { get; set; }
    }
}