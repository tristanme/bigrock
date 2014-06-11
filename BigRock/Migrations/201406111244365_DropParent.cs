namespace BigRock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropParent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "ParentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "ParentID", c => c.Int());
        }
    }
}
