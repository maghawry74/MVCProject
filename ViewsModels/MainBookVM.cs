﻿using Kotabko.Models;

namespace Kotabko.ViewsModels
{
    public class MainBookVM
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public float Rate { get; set; }
       
        public virtual Author? Author { get; set; }
    }
}
