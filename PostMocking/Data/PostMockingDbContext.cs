using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PostMocking.Data
{
    public partial class PostMockingDbContext : DbContext
    {
        public PostMockingDbContext()
        {
        }

        public PostMockingDbContext(DbContextOptions<PostMockingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Profesores> Profesores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=PostMocking;Uid=root;Pwd=root;");
            }
        }
    }
}
