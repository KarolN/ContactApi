namespace ContactsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.String(),
                        OrganizationId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonAddresses",
                c => new
                    {
                        Person_Id = c.Long(nullable: false),
                        Address_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Address_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Address_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.PersonAddresses", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.PersonAddresses", "Person_Id", "dbo.People");
            DropIndex("dbo.PersonAddresses", new[] { "Address_Id" });
            DropIndex("dbo.PersonAddresses", new[] { "Person_Id" });
            DropIndex("dbo.People", new[] { "OrganizationId" });
            DropTable("dbo.PersonAddresses");
            DropTable("dbo.Organizations");
            DropTable("dbo.People");
            DropTable("dbo.Addresses");
        }
    }
}
