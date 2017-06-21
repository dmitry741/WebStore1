namespace WebStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyPersons",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 250),
                        LastName = c.String(nullable: false, maxLength: 250),
                        age = c.Int(nullable: false),
                        position = c.String(nullable: false, maxLength: 250),
                        hobbies = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.MyPersons");
        }
    }
}
