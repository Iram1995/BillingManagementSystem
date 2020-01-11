namespace BillingManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        payment_Id = c.Int(nullable: false, identity: true),
                        year = c.Int(nullable: false),
                        month = c.Int(nullable: false),
                        paid_By = c.String(nullable: false),
                        employee_Name = c.String(nullable: false),
                        payment_Date = c.DateTime(nullable: false),
                        cust_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.payment_Id)
                .ForeignKey("dbo.Customers", t => t.cust_Id, cascadeDelete: true)
                .Index(t => t.cust_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "cust_Id", "dbo.Customers");
            DropIndex("dbo.Payments", new[] { "cust_Id" });
            DropTable("dbo.Payments");
        }
    }
}
