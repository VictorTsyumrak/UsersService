namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCreatedOn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "CreatedOn");
        }
    }
}
