namespace ContactsApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "MyProperty", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "MyProperty");
        }
    }
}
