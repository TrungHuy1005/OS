using AutoMapper;
using OS.Application.ViewModels;
using OS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.Application.Automapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
               .ForMember(t => t.Id, tt => tt.MapFrom(h => h.Id))
               .ForMember(t => t.Name, tt => tt.MapFrom(h => h.Name))
               .ForMember(t => t.Image, tt => tt.MapFrom(h => h.Image))
               .ForMember(t => t.Price, tt => tt.MapFrom(h => h.Price))
               .ForMember(t => t.CategoryId, tt => tt.MapFrom(h => h.CategoryId));
            CreateMap<Bill, InvoiceDetailViewModel>()
               .ForMember(t => t.Id, tt => tt.MapFrom(h => h.Id))
               .ForMember(t => t.TotalPrice, tt => tt.MapFrom(h => h.Total))
               .ForMember(t => t.Products, tt => tt.MapFrom(h => h.Products));
            CreateMap<Customer, InformationCustomerViewModel>()
             .ForMember(t => t.Id, tt => tt.MapFrom(h => h.Id))
             .ForMember(t => t.Name, tt => tt.MapFrom(h => h.Name))
             .ForMember(t => t.Email, tt => tt.MapFrom(h => h.Email))
             .ForMember(t => t.PhoneNumber, tt => tt.MapFrom(h => h.PhoneNumber));
            CreateMap<Product, CreateProductViewModel>();
            CreateMap<Category, CategoryViewModel>()
             .ForMember(t => t.Id, tt => tt.MapFrom(h => h.Id))
             .ForMember(t => t.Type, tt => tt.MapFrom(h => h.Type));
            CreateMap<CartProduct, CartProductViewModel>()
              .ForMember(t => t.Id, tt => tt.MapFrom(h => h.Id))
              .ForMember(t => t.ProductId, tt => tt.MapFrom(h => h.ProductId))
              .ForMember(t => t.Quantity, tt => tt.MapFrom(h => h.Quantity))
             .ForMember(t => t.BillId, tt => tt.MapFrom(h => h.BillId));
        }
    }
}
