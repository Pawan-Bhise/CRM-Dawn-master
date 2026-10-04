namespace CallCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryMasters",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.KnowledgeCenters",
                c => new
                    {
                        KnowledgeId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                        SubSubCategoryId = c.Int(nullable: false),
                        Description = c.String(),
                        FileURL = c.String(),
                    })
                .PrimaryKey(t => t.KnowledgeId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.SRManagements",
                c => new
                    {
                        SRId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        PhoneNo = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        AgentName = c.String(nullable: false),
                        RequestComplaintDetails = c.String(),
                        Category = c.String(),
                        SubCategory = c.String(),
                        SubSubCategory = c.String(),
                        Remark = c.String(),
                        TicketOpenDate = c.DateTime(),
                        TicketCloseDate = c.DateTime(),
                        TicketOpenAgentName = c.String(),
                        TicketCloseAgentName = c.String(),
                        Status = c.String(),
                        TypeOfCaller = c.String(),
                        CustomerSegment = c.String(),
                        TypeOfCall = c.String(),
                        ResoluctionFeedback = c.String(),
                    })
                .PrimaryKey(t => t.SRId);
            
            CreateTable(
                "dbo.SubCategoryMasters",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        SubCategoryName = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.SubSubCategoryMasters",
                c => new
                    {
                        SubSubCategoryId = c.Int(nullable: false, identity: true),
                        SubSubCategoryName = c.String(),
                        SubCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubSubCategoryId);
            
            CreateTable(
                "dbo.TicketManagements",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CallingNumber = c.String(),
                        TypeOfCaller = c.String(),
                        CustomerSegment = c.String(),
                        TypeOfCall = c.String(),
                        Category = c.String(),
                        SubCategory = c.String(),
                        SubSubCategory = c.String(),
                        Remark = c.String(),
                        TicketOpenDate = c.DateTime(),
                        TicketCloseDate = c.DateTime(),
                        TicketOpenAgentName = c.String(),
                        TicketCloseAgentName = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.TicketId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Role_RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Role_RoleId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_RoleId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Role_RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "User_UserId", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "Role_RoleId" });
            DropIndex("dbo.UserRoles", new[] { "User_UserId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.TicketManagements");
            DropTable("dbo.SubSubCategoryMasters");
            DropTable("dbo.SubCategoryMasters");
            DropTable("dbo.SRManagements");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.KnowledgeCenters");
            DropTable("dbo.CategoryMasters");
        }
    }
}
