namespace BillingManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTableUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "payment_Amount", c => c.Double(nullable: false,defaultValue:0.0));
            AddColumn("dbo.Payments", "payment_For", c => c.DateTime(nullable: false));
            DropColumn("dbo.Payments", "year");
            DropColumn("dbo.Payments", "month");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "month", c => c.Int(nullable: false));
            AddColumn("dbo.Payments", "year", c => c.Int(nullable: false));
            DropColumn("dbo.Payments", "payment_For");
            DropColumn("dbo.Payments", "payment_Amount");
        }
    }
}
