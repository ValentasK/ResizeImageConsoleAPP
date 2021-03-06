﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ResizeImageConsoleAPP.Models
{
    public partial class SaveImageToFolderContext : DbContext
    {
        public SaveImageToFolderContext()
        {
        }

        public SaveImageToFolderContext(DbContextOptions<SaveImageToFolderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ImageDetails> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SaveImageToFolder;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ImageDetails>(entity =>
            {
                entity.ToTable("ImageDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
