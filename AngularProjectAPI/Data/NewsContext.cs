using AngularProjectAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProjectAPI.Data
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<ArticleStatus> ArticleStatuses { get; set; }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<ArticleStatus>().ToTable("ArticleStatus");
            modelBuilder.Entity<Article>().ToTable("Article");
            modelBuilder.Entity<Image>().ToTable("Image");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Like>().ToTable("Like");

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Image)
                .WithOne(i => i.Article)
                .HasForeignKey<Image>(i => i.ArticleID);
            
        }
    }
}
