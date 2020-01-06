namespace BillingManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        cust_Id = c.Int(nullable: false, identity: true),
                        first_Name = c.String(nullable: false),
                        last_Name = c.String(),
                        cell_Number = c.String(nullable: false),
                        address = c.String(nullable: false),
                        createdDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.cust_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
