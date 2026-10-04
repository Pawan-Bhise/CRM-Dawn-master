using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CallCenter.DataAccess
{
    public class AuthenticationDB : DbContext
    {
        public AuthenticationDB()
            : base("AuthenticationDB")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<TicketManagement>().HasKey(t => t.TicketId);
            modelBuilder.Entity<SRManagement>().HasKey(s=>s.SRId);

            modelBuilder.Entity<CategoryMaster>().HasKey(c=>c.CategoryId);
            modelBuilder.Entity<SubCategoryMaster>().HasKey(sc => sc.SubCategoryId);
            modelBuilder.Entity<SubSubCategoryMaster>().HasKey(ssc => ssc.SubSubCategoryId);
            modelBuilder.Entity<KnowledgeCenter>().HasKey(kc => kc.KnowledgeId);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TicketManagement> TicketManagements {get; set;}
        public DbSet<SRManagement> SRManagements { get; set; }
        public DbSet<CategoryMaster> CategoryMasters { get; set; }
        public DbSet<SubCategoryMaster> SubCategoryMasters{ get; set; }
        public DbSet<SubSubCategoryMaster> SubSubCategoryMasters { get; set; }
        public DbSet<KnowledgeCenter> KnowledgeCenters { get;set; }
    }
}