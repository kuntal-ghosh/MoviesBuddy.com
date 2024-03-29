namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieTableUpdated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Byte());
            AlterColumn("dbo.Movies", "NumberAvailable", c => c.Byte());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
