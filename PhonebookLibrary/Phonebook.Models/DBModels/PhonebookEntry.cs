namespace Phonebook.Models.DBModels
{
    using System.ComponentModel.DataAnnotations;

    public class PhonebookEntry
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