﻿using AutoMapper;
using BarberShop.Dto;
using BarberShop.Models;

namespace BarberShop.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Barber,BarberGetDto>();
            CreateMap<BarberGetDto,Barber>();
            CreateMap<BarberCreateDto,Barber>();
            CreateMap<Barber,BarberCreateDto>();
            CreateMap<CustomerGetDto, Customer>();
            CreateMap<Customer,CustomerGetDto>();
            CreateMap<CustomerCreateDto, Customer>();
            CreateMap<Customer,CustomerGetDto>();
            CreateMap<BarberEmployeeCreateDto, BarberEmployee>();
            CreateMap<BarberEmployee,BarberEmployeeCreateDto>();
        }
    }
}
