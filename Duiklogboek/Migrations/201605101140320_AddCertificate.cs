namespace Duiklogboek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCertificate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        CertificateId = c.Int(nullable: false, identity: true),
                        DivingOrganisation = c.String(),
                    })
                .PrimaryKey(t => t.CertificateId);
            
            AddColumn("dbo.AspNetUsers", "Certificate_CertificateId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Certificate_CertificateId");
            AddForeignKey("dbo.AspNetUsers", "Certificate_CertificateId", "dbo.Certificates", "CertificateId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Certificate_CertificateId", "dbo.Certificates");
            DropIndex("dbo.AspNetUsers", new[] { "Certificate_CertificateId" });
            DropColumn("dbo.AspNetUsers", "Certificate_CertificateId");
            DropTable("dbo.Certificates");
        }
    }
}
