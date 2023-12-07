﻿using System.ComponentModel;

namespace Models
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public DateTime ExpirationDate { get; set; }

        public bool Priority { get; set; }

        public string Summary => $"{Name}; {Price} zł";

    }
}
