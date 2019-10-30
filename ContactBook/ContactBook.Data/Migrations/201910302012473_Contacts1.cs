namespace ContactBook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contacts1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Company", c => c.String());
            AddColumn("dbo.Contacts", "Note", c => c.String());
            AddColumn("dbo.Contacts", "Birthday", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Birthday");
            DropColumn("dbo.Contacts", "Note");
            DropColumn("dbo.Contacts", "Company");
        }
    }
}
