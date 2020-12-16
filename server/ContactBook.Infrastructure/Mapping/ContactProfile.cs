using AutoMapper;
using AddressBook.Domain.Entities;
using AddressBook.Domain.Dtos;

namespace AddressBook.Infrastructure.Mapping
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactDto, Contact>()
                .ReverseMap();
        }
    }
}
