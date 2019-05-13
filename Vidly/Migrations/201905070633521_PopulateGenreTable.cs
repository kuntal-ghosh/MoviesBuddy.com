namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id,Name) VALUES(1,'Action') ");
            Sql("INSERT INTO Genres(Id,Name) VALUES(2,'Romantic') ");
            Sql("INSERT INTO Genres(Id,Name) VALUES(3,'Comedy') ");
            Sql("INSERT INTO Genres(Id,Name) VALUES(4,'Thriller') ");

        }

        public override void Down()
        {
        }
    }
}
