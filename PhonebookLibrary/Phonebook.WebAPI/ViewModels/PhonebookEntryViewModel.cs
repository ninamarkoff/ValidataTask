namespace Phonebook.WebAPI.ViewModels
{
    using System.ComponentModel.DataAnnotations;
   
    using Models.DBModels;

    public class PhonebookEntryViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public PhonebookEntryType Type { get; set; }

        [Key]
        public string Number { get; set; }
    }
}