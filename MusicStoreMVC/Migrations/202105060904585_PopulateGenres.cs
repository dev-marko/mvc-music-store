namespace MusicStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Jazz')");
            Sql("INSERT INTO Genres (Name) VALUES ('Pop')");
            Sql("INSERT INTO Genres (Name) VALUES ('Rock')");
        }
        
        public override void Down()
        {
        }
    }
}
