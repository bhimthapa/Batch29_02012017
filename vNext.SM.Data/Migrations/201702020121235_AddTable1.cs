namespace vNext.SM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTable1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SMUser", newName: "SMUsers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SMUsers", newName: "SMUser");
        }
    }
}
