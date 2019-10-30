namespace ContactBook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addresses2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Contact_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id)
                .Index(t => t.Contact_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emails", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Companies", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.Addresses", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.Emails", new[] { "Contact_Id" });
            DropIndex("dbo.Companies", new[] { "Contact_Id" });
            DropIndex("dbo.Addresses", new[] { "Contact_Id" });
            DropTable("dbo.Emails");
            DropTable("dbo.Companies");
            DropTable("dbo.Addresses");
        }
    }
}
