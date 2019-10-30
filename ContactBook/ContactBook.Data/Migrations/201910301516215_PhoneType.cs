namespace ContactBook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        PhoneType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhoneTypes", t => t.PhoneType_Id)
                .Index(t => t.PhoneType_Id);
            
            CreateTable(
                "dbo.PhoneTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneNumbers", "PhoneType_Id", "dbo.PhoneTypes");
            DropIndex("dbo.PhoneNumbers", new[] { "PhoneType_Id" });
            DropTable("dbo.PhoneTypes");
            DropTable("dbo.PhoneNumbers");
        }
    }
}
