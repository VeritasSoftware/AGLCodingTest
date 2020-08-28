using System;
using System.Collections.Generic;
using System.Text;
using AGL.Entities;
using AGL.Models;
using AutoMapper;

namespace AGL.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PetsByPersonGenderCollection, PetsByPersonGenderCollectionModel>();

            CreateMap<PetsByPersonGender, PetsByPersonGenderModel>();

            CreateMap<Pet, PetModel>();
        }
    }
}
