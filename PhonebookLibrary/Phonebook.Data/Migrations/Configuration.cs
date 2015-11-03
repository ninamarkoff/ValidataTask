namespace Phonebook.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models.DBModels;

    internal sealed class Configuration : DbMigrationsConfiguration<PhonebookDBModel>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhonebookDBModel context)
        {
            SeedPhonebookEntries(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private void SeedPhonebookEntries(PhonebookDBModel context)
        {
            for (int i = 0; i < 3; i++)
            {
                context.PhonebookEntries.AddOrUpdate(new PhonebookEntry
                {
                    FirstName = "Mila",
                    LastName = "Nenova",
                    Number = "087" + i,
                    Type = PhonebookEntryType.Cellphone
                });

                context.PhonebookEntries.AddOrUpdate(new PhonebookEntry
                {
                    FirstName = "Pesho" + i,
                    LastName = "Goshev" + i,
                    Number = "088" + i,
                    Type = PhonebookEntryType.Work
                });

                context.PhonebookEntries.AddOrUpdate(new PhonebookEntry
                {
                    FirstName = "Pesho" + i,
                    LastName = "Goshev" + i,
                    Number = "089" + i,
                    Type = PhonebookEntryType.Home
                });
                
            }
            context.SaveChanges();
        }
    }
}