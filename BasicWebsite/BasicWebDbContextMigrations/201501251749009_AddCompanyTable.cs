namespace BasicWebsite.BasicWebDbContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        StockId = c.String(maxLength: 255),
                        Founded = c.DateTime(),
                        Director = c.String(maxLength: 255),
                        Country = c.String(maxLength: 255),
                        Headquarters = c.String(maxLength: 255),
                        Description = c.String(),
                        Tags = c.String(maxLength: 255),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 255),
                        Created = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Name, unique: true, name: "NameIndex");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CompanyModels", "NameIndex");
            DropTable("dbo.CompanyModels");
        }
    }
}
