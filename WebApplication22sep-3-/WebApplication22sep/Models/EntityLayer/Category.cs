﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication22sep.Models.EntityLayer
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public bool IsDelete { get; set; }
    }
}