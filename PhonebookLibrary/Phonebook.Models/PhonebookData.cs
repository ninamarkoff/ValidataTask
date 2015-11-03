namespace Phonebook.Models
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using DBModels;

    using System.Data.Entity;

    public class PhonebookData : IPhonebookData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public PhonebookData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<PhonebookEntry> PhonebookEntries
        {
            get
            {
                return this.GetRepository<PhonebookEntry>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}