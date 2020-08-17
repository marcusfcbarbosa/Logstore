using FluentValidator;
using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.LogStoreContext.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Logstore.Infra.Context
{
    public class LogStoreContext : DbContext
    {

        public LogStoreContext(DbContextOptions<LogStoreContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notifiable>();
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Email>();


            base.OnModelCreating(modelBuilder);

        }

        private void EntityMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
                       {
                           entity.ToTable("Cliente")
                           .HasKey(e => e.Id);

                           entity.Property(e => e.identifyer).HasDefaultValueSql("lower(hex(randomblob(16)))");
                           entity.Property(e => e.Nome)
                               .HasMaxLength(100);

                           entity.Property(e => e.Email)
                               .IsRequired()
                               .HasMaxLength(50).
                               HasColumnName("Email");
                       });
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("Produto")
                .HasKey(e => e.Id);

                entity.Property(e => e.identifyer).HasDefaultValueSql("lower(hex(randomblob(16)))");
                entity.Property(e => e.Descricao)
                    .HasMaxLength(100);

                entity.Property(e => e.Valor)
                    .IsRequired().
                    HasColumnName("Valor");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedido")
                .HasKey(e => e.Id);

                entity.Property(e => e.identifyer).HasDefaultValueSql("lower(hex(randomblob(16)))");


            });

        }

    }
}