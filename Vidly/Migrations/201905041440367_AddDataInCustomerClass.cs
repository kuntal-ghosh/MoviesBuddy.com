namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataInCustomerClass : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers(Name,IsSubscribedToNewsletter,MembershipTypeId,Birthdate) VALUES('ARNOB','TRUE',1,27/22/1994)");
            Sql("INSERT INTO Customers(Name,IsSubscribedToNewsletter,MembershipTypeId,Birthdate) VALUES('ARYAN','TRUE',1,27/22/1994)");
            Sql("INSERT INTO Customers(Name,IsSubscribedToNewsletter,MembershipTypeId,Birthdate) VALUES('KUNTAL','TRUE',1,27/22/1994)");

        }

        public override void Down()
        {
        }
    }
}
