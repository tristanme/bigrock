namespace BigRock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        FamilyCode = c.String(nullable: false, maxLength: 4),
                        SecurityCard = c.String(),
                        TypeCode = c.Int(nullable: false),
                        TypeCodeOther = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
