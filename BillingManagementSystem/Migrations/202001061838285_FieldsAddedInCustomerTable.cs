namespace BillingManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FieldsAddedInCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "cardNumber", c => c.String());
            AddColumn("dbo.Customers", "cnic", c => c.String());
            AlterColumn("dbo.Customers", "address", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "address", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "cnic");
            DropColumn("dbo.Customers", "cardNumber");
        }
    }
}
