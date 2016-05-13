namespace Duiklogboek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDiveModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Certificate_CertificateId", "dbo.Certificates");
            DropIndex("dbo.AspNetUsers", new[] { "Certificate_CertificateId" });
            CreateTable(
                "dbo.Divers",
                c => new
                    {
                        DiverId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        UserAccount_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DiverId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAccount_Id)
                .Index(t => t.UserAccount_Id);
            
            CreateTable(
                "dbo.Dives",
                c => new
                    {
                        DiveId = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false),
                        DiveSite = c.String(),
                        Date = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Weather = c.String(),
                        Visibility = c.String(),
                        Notes = c.String(),
                        Buddy_DiverId = c.Int(),
                    })
                .PrimaryKey(t => t.DiveId)
                .ForeignKey("dbo.Divers", t => t.Buddy_DiverId)
                .Index(t => t.Buddy_DiverId);
            
            AddColumn("dbo.Certificates", "Diver_DiverId", c => c.Int());
            CreateIndex("dbo.Certificates", "Diver_DiverId");
            AddForeignKey("dbo.Certificates", "Diver_DiverId", "dbo.Divers", "DiverId");
            DropColumn("dbo.AspNetUsers", "Certificate_CertificateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Certificate_CertificateId", c => c.Int());
            DropForeignKey("dbo.Divers", "UserAccount_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Dives", "Buddy_DiverId", "dbo.Divers");
            DropForeignKey("dbo.Certificates", "Diver_DiverId", "dbo.Divers");
            DropIndex("dbo.Dives", new[] { "Buddy_DiverId" });
            DropIndex("dbo.Divers", new[] { "UserAccount_Id" });
            DropIndex("dbo.Certificates", new[] { "Diver_DiverId" });
            DropColumn("dbo.Certificates", "Diver_DiverId");
            DropTable("dbo.Dives");
            DropTable("dbo.Divers");
            CreateIndex("dbo.AspNetUsers", "Certificate_CertificateId");
            AddForeignKey("dbo.AspNetUsers", "Certificate_CertificateId", "dbo.Certificates", "CertificateId");
        }
    }
}
