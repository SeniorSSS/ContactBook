namespace ContactBook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contacts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PhoneNumbers", "Contact_Id", c => c.Int());
            CreateIndex("dbo.PhoneNumbers", "Contact_Id");
            AddForeignKey("dbo.PhoneNumbers", "Contact_Id", "dbo.Contacts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "Contact_Id", "dbo.Contacts");
            DropIndex("dbo.PhoneNumbers", new[] { "Contact_Id" });
            DropColumn("dbo.PhoneNumbers", "Contact_Id");
            DropTable("dbo.Contacts");
        }
    }
}
