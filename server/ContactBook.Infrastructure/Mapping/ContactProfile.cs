using AutoMapper;
using AddressBook.Infrastructure.ViewModel;
using AddressBook.Domain.Entities;

namespace AddressBook.Infrastructure.Mapping
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactModel, Contact>()
                .ReverseMap();
        }
    }
}
