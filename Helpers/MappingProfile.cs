﻿using AutoMapper;
using Kotabko.Models;
using Kotabko.ViewsModels;

namespace Kotabko.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
           CreateMap<AuthorVM, Author>().ReverseMap();
        }
    }
}