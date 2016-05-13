namespace Duiklogboek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Moved_Diver_model_into_ID_model : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Certificates", "Diver_DiverId", "dbo.Divers");
            DropForeignKey("dbo.Dives", "Buddy_DiverId", "dbo.Divers");
            DropForeignKey("dbo.Divers", "UserAccount_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Certificates", new[] { "Diver_DiverId" });
            DropIndex("dbo.Divers", new[] { "UserAccount_Id" });
            DropIndex("dbo.Dives", new[] { "Buddy_DiverId" });
            AddColumn("dbo.Certificates", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Dives", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Firstname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Lastname", c => c.String());
            CreateIndex("dbo.Certificates", "ApplicationUser_Id");
            CreateIndex("dbo.Dives", "ApplicationUser_Id");
            AddForeignKey("dbo.Certificates", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Dives", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Certificates", "Diver_DiverId");
            DropColumn("dbo.Dives", "Buddy_DiverId");
            DropTable("dbo.Divers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Divers",
                c => new
                    {
                        DiverId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        UserAccount_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DiverId);
            
            AddColumn("dbo.Dives", "Buddy_DiverId", c => c.Int());
            AddColumn("dbo.Certificates", "Diver_DiverId", c => c.Int());
            DropForeignKey("dbo.Dives", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Certificates", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Dives", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Certificates", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Lastname");
            DropColumn("dbo.AspNetUsers", "Firstname");
            DropColumn("dbo.Dives", "ApplicationUser_Id");
            DropColumn("dbo.Certificates", "ApplicationUser_Id");
            CreateIndex("dbo.Dives", "Buddy_DiverId");
            CreateIndex("dbo.Divers", "UserAccount_Id");
            CreateIndex("dbo.Certificates", "Diver_DiverId");
            AddForeignKey("dbo.Divers", "UserAccount_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Dives", "Buddy_DiverId", "dbo.Divers", "DiverId");
            AddForeignKey("dbo.Certificates", "Diver_DiverId", "dbo.Divers", "DiverId");
        }
    }
}
