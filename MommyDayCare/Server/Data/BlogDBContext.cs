using Microsoft.EntityFrameworkCore;
using MommyDayCare.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MommyDayCare.Server.Data
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Comments
            modelBuilder.Entity<Comment>(entity => 
            {
                entity.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
                entity.Property(c => c.Status)
                    .IsRequired()
                    .HasDefaultValue(Comment.CommentStatus.Reviewing);
                entity.Property(c => c.Body).IsRequired();
                entity.HasOne(c => c.AppUser)
                    .WithMany(au => au.Comments)
                    .HasForeignKey(c => c.AppUserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(c => c.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(c => c.PostId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            //Messages
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(m => m.Sender)
                    .WithMany(au => au.MessageFrom)
                    .HasForeignKey(m => m.SenderId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(m => m.Receiver)
                    .WithMany(au => au.MessageTo)
                    .HasForeignKey(m => m.ReceiverId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            //Posts
            modelBuilder.Entity<Post>(entity => 
            {
                entity.Property(p => p.CreatedOn).HasDefaultValueSql("GETDATE()");
                entity.HasOne(c => c.AppUser)
                    .WithMany(au => au.Posts)
                    .HasForeignKey(p => p.AppUserId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);
                /*entity.HasMany(p => p.Comments)
                    .WithOne(c => c.Post)
                    .HasForeignKey(p => p.PostId)
                    .OnDelete(DeleteBehavior.Cascade);*/
                
            });

            //Tags
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(t => t.Name).IsRequired().HasMaxLength(15);
            });

            //PostTags
            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasKey(pt => new { pt.PostId, pt.TagId });
                entity.HasOne(pt => pt.Tag)
                    .WithMany(t => t.PostTags)
                    .HasForeignKey(pt => pt.TagId);
                entity.HasOne(pt => pt.Post)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(pt => pt.PostId);
            });

            //AppUsers
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.Property(au => au.RegisteredOn)
                    .HasDefaultValueSql("GETDATE()");
                entity.Property(au => au.Password).IsRequired();
                entity.Property(au => au.Salt).IsRequired();
                entity.Property(au => au.FirstName).IsRequired();
                entity.Property(au => au.LastName).IsRequired();
                entity.Property(au => au.Email).IsRequired();
                entity.Property(au => au.Sex).IsRequired();
                entity.Property(au => au.Country).IsRequired(false);
                entity.Property(au => au.ActivationKey).IsRequired(false);
                entity.Property(au => au.Avatar).IsRequired(false);
                entity.Property(au => au.IsPrivate).IsRequired();
                entity.Property(au => au.IsActive).IsRequired();
                entity.Property(au => au.LoginAttemps).IsRequired();
                entity.Property(au => au.Biography).IsRequired(false)
                    .HasMaxLength(500);
                entity.Property(au => au.Username).IsRequired(false);
                entity.Property(au => au.LastLogin).IsRequired(false);
                entity.Property(au => au.UpdatedOn).IsRequired(false);
                entity.Property(au => au.Birthday).IsRequired(false);
            });

            //AppUserRoles
            modelBuilder.Entity<AppUserRole>(entity =>
            {
                entity.Property(ar => ar.Name).IsRequired().HasMaxLength(100);
                entity.Property(ar => ar.Description).IsRequired().HasMaxLength(500);
            });

            //AppUserGroups
            modelBuilder.Entity<AppUserGroup>(entity =>
            {
                entity.Property(ar => ar.Name).IsRequired().HasMaxLength(100);
                entity.Property(ar => ar.Description).IsRequired().HasMaxLength(500);
            });

            //AppUserFollowing
            modelBuilder.Entity<AppUserFollowing>(entity =>
            {
                entity.HasKey(af => new { af.AppUserFollowerId, af.AppUserToFolloweeId });
                entity.Property(ar => ar.CreatedOn)
                    .HasDefaultValueSql("GETDATE()");
                entity.HasOne(af => af.AppUserFollowee)
                    .WithMany(au => au.AppUserFollowees)
                    .HasForeignKey(af => af.AppUserToFolloweeId)
                    .OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(ar => ar.AppUserFollower)
                    .WithMany(au => au.AppUserFollowers)
                    .HasForeignKey(af => af.AppUserFollowerId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            //Collections
            modelBuilder.Entity<Collection>(entity =>
           {
               entity.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(20);
               entity.Property(c => c.Description)
                .IsRequired(false);
           });

            //Favourite
            modelBuilder.Entity<Favourite>(entity =>
            {
                entity.Property(f => f.ItemId).IsRequired();
                entity.Property(f => f.ItemType).IsRequired();
                entity.Property(f => f.CreatedOn).HasDefaultValueSql("GETDATE()");

            });
;        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<AppUserGroup> AppUserGroups { get; set; }
        public DbSet<AppUserFollowing> AppUserFollowing { get; set; }
    }
}
