namespace vNext.SM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SMUser",
                c => new
                    {
                        SMUserId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 50),
                        UserPassport = c.String(nullable: false, maxLength: 20),
                        UserRole = c.String(maxLength: 3),
                        CreatedBy = c.String(maxLength: 50),
                        UpdatedBy = c.String(maxLength: 50),
                        UpdatedOn = c.DateTime(nullable: false),
                        CreatedOn = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.SMUserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SMUser");
        }
    }
}
