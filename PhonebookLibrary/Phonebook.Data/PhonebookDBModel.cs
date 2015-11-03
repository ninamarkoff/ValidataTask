namespace Phonebook.Data
{
    using Models.DBModels;
    
    using System.Data.Entity;
   

    public class PhonebookDBModel : DbContext
    {
        // Your context has been configured to use a 'PhonebookDBModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Phonebook.Data.PhonebookDBModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PhonebookDBModel' 
        // connection string in the application configuration file.

        public const string ConnectionStringSQL = "Server=.;Database=PhonebookLibrary;Integrated Security=True;";

        public PhonebookDBModel()
            : base(ConnectionStringSQL)
        {

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual IDbSet<PhonebookEntry> PhonebookEntries { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}