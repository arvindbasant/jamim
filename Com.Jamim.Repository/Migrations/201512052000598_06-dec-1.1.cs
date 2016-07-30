namespace Com.Jamim.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06dec11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaxRate", "CreatedBy", c => c.String());
            AlterColumn("dbo.TaxRate", "ModifiedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaxRate", "ModifiedBy", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TaxRate", "CreatedBy", c => c.DateTime(nullable: false));
        }
    }
}
