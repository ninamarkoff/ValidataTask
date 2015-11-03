using System.Collections;
using System.Collections.Generic;

namespace Phonebook.WebAPI
{
    using Models.DBModels;
    using ViewModels;

    using AutoMapper;

    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<PhonebookEntry, PhonebookEntryViewModel>().ReverseMap();

            Mapper.CreateMap<ICollection<PhonebookEntry>, ICollection<PhonebookEntryViewModel>>().ReverseMap();
        }
    }
}