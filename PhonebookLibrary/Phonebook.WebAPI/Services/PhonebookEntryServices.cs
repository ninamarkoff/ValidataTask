using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using AutoMapper;
using Phonebook.Models.Contracts;
using Phonebook.Models.DBModels;
using Phonebook.WebAPI.ViewModels;

namespace Phonebook.WebAPI.Services
{
    public class PhonebookEntryServices
    {
        private IPhonebookData data;

        public PhonebookEntryServices(IPhonebookData data)

        {
            this.data = data;
        }

        public ICollection<PhonebookEntryViewModel> GetAllEntriesAlphabetically()
        {
            var entries = this.data.PhonebookEntries.All().ToList();
            var sortedEntries = entries.OrderBy(p => p.FirstName).ThenBy(p => p.LastName);
            return Mapper.Map<ICollection<PhonebookEntryViewModel>>(sortedEntries);
        }

        public ICollection<PhonebookEntryViewModel> GetEntriesByFirstNameAlphabetically(string firstName)
        {
            var entries = this.data.PhonebookEntries.All().ToList();
            var sortedEntries = entries.Where(p => p.FirstName.ToLower() == firstName.ToLower()).OrderBy(p => p.LastName);
            return Mapper.Map<ICollection<PhonebookEntryViewModel>>(sortedEntries);
        }

        public ICollection<PhonebookEntryViewModel> GetEntriesByLastNameAlphabetically(string lastName)
        {
            var entries = this.data.PhonebookEntries.All().ToList();
            var sortedEntries = entries.Where(p => p.LastName.ToLower() == lastName.ToLower()).OrderBy(p => p.FirstName);
            return Mapper.Map<ICollection<PhonebookEntryViewModel>>(sortedEntries);
        }

        public void CreateDBEntry(PhonebookEntry entry)
        {
            this.data.PhonebookEntries.Add(entry);
            this.data.SaveChanges();
        }

        public void DeleteDBEntry(PhonebookEntry entry)
        {
            this.data.PhonebookEntries.Delete(entry);
            this.data.SaveChanges();
        }

        public void UpdateDBEntry(PhonebookEntry entry, PhonebookEntryViewModel entryViewModel)
        {
            entry.FirstName = entryViewModel.FirstName;
            entry.LastName = entryViewModel.LastName;
            entry.Type = entryViewModel.Type;
            this.data.PhonebookEntries.Update(entry);
            this.data.SaveChanges();
        }
    }
}