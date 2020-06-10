using AutoMapper;
using Exam.Entity;
using Exam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Mapping
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
