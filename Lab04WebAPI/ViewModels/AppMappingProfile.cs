using AutoMapper;
using Lab04WebAPI.Models; 
using System;

namespace Lab04WebAPI.ViewModels
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Hospitalmedicines, HospitalmedicineViewModel>().ReverseMap();
            CreateMap<Hospitaldoctors, HospitaldoctorViewModel>().ReverseMap();

        }
    }
}
