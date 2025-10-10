namespace YangWei.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleName = c.String(nullable: false, maxLength: 50),
                        ParentId = c.Int(),
                        Level = c.Int(),
                        Icon = c.Binary(),
                        Permission = c.String(maxLength: 200),
                        IsShow = c.Int(),
                        ReMark = c.String(maxLength: 500),
                        Status = c.Int(),
                        CreatTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        CreateUser = c.String(nullable: false),
                        UpdateUser = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NikeName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        State = c.Int(),
                        CreatTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        CreateUser = c.String(nullable: false),
                        UpdateUser = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Menus");
        }
    }
}
