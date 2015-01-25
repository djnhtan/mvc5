namespace BasicWebsite.BasicWebDbContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCompanyTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CompanyModels", "CreatedBy");
            DropColumn("dbo.CompanyModels", "Created");
            DropColumn("dbo.CompanyModels", "ModifiedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompanyModels", "ModifiedBy", c => c.String(maxLength: 255));
            AddColumn("dbo.CompanyModels", "Created", c => c.DateTime());
            AddColumn("dbo.CompanyModels", "CreatedBy", c => c.String(maxLength: 255));
        }
    }
}
