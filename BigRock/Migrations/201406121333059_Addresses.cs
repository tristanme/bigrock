namespace BigRock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addresses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Block = c.String(),
                        City = c.String(),
                        ZipCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.People", "Address_ID", c => c.Int());
            CreateIndex("dbo.People", "Address_ID");
            AddForeignKey("dbo.People", "Address_ID", "dbo.Addresses", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Address_ID", "dbo.Addresses");
            DropIndex("dbo.People", new[] { "Address_ID" });
            DropColumn("dbo.People", "Address_ID");
            DropTable("dbo.Addresses");
        }
    }
}
