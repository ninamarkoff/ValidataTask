using System;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Phonebook.Models.DBModels;
using Phonebook.WebAPI.ViewModels;

namespace Phonebook.WebAPI.Controllers
{
    using System.Web.Http;

    using Models.Contracts;
    using Services;

    public class PhonebookEntryController : BaseController
    {
        private PhonebookEntryServices services;

        public PhonebookEntryController(IPhonebookData data, PhonebookEntryServices services)
            : base(data)
        {
            this.services = services;
        }

        [HttpGet]
        public IHttpActionResult ByFirstName(string firstName)
        {
            var dbPhonebookEntries = services.GetEntriesByFirstNameAlphabetically(firstName);
            if (dbPhonebookEntries.Count == 0)
            {
                return NotFound();
            }
            return Ok(dbPhonebookEntries);
        }

        [HttpGet]
        public IHttpActionResult ByLastName(string lastName)
        {
            var dbPhonebookEntries = services.GetEntriesByLastNameAlphabetically(lastName);
            if (dbPhonebookEntries.Count == 0)
            {
                return NotFound();
            }
            return Ok(dbPhonebookEntries);
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var dbPhonebookEntries = services.GetAllEntriesAlphabetically();
            return Ok(dbPhonebookEntries);
        }


        [HttpPost]
        public IHttpActionResult Create(PhonebookEntryViewModel entryViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var entry = Mapper.Map<PhonebookEntry>(entryViewModel);
            services.CreateDBEntry(entry);
            return Ok(entryViewModel);
        }

        [HttpDelete]
        public IHttpActionResult Delete(PhonebookEntryViewModel entryViewModel)
        {
            var entry = this.data.PhonebookEntries.All().FirstOrDefault(p => p.Number == entryViewModel.Number);            

            if (entry == null)
            {
                return BadRequest("No such entry found!");
            }
            services.DeleteDBEntry(entry);

            return Ok("Entry deleted!");
        }

        [HttpPut]
        public IHttpActionResult Update(string number, PhonebookEntryViewModel entryViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var entry = this.data.PhonebookEntries.All().FirstOrDefault(p => p.Number == number);

            if (entry == null)
            {
                return BadRequest("No such entry found!");
            }

            services.UpdateDBEntry(entry, entryViewModel);

            return Ok("Entry updated!");
        }

    }
}