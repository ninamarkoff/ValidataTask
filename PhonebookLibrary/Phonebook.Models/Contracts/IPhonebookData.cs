namespace Phonebook.Models.Contracts
{
    using DBModels;
   public interface IPhonebookData
    {
        IRepository<PhonebookEntry> PhonebookEntries { get; }

        int SaveChanges();
    }
}