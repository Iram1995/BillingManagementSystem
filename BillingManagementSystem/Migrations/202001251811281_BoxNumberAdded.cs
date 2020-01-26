namespace BillingManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoxNumberAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "boxNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "boxNumber");
        }
    }
}
