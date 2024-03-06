﻿using System;
using System.Collections.Generic;
using AnotherTest.Models;
using Microsoft.EntityFrameworkCore;

namespace AnotherTest.Database;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ArticleTag1> ArticleTags1 { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<YourEntity> YourEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FlatDanTestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Articles_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.Articles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(d => d.TagsTags).WithMany(p => p.ArticlesArticles)
                .UsingEntity<Dictionary<string, object>>(
                    "ArticleTag",
                    r => r.HasOne<Tag>().WithMany().HasForeignKey("TagsTagId"),
                    l => l.HasOne<Article>().WithMany().HasForeignKey("ArticlesArticleId"),
                    j =>
                    {
                        j.HasKey("ArticlesArticleId", "TagsTagId");
                        j.ToTable("ArticleTag");
                        j.HasIndex(new[] { "TagsTagId" }, "IX_ArticleTag_TagsTagId");
                    });
        });

        modelBuilder.Entity<ArticleTag1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ArticleTags");

            entity.HasIndex(e => e.ArticleId, "IX_ArticleTags_ArticleId");

            entity.HasIndex(e => e.TagId, "IX_ArticleTags_TagId");

            entity.HasOne(d => d.Article).WithMany().HasForeignKey(d => d.ArticleId);

            entity.HasOne(d => d.Tag).WithMany().HasForeignKey(d => d.TagId);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasIndex(e => e.ArticleId, "IX_Comments_ArticleId");

            entity.HasIndex(e => e.UserId, "IX_Comments_UserId");

            entity.HasOne(d => d.Article).WithMany(p => p.Comments).HasForeignKey(d => d.ArticleId);

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
