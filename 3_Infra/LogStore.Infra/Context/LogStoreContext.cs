using FluentValidator;
using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.LogStoreContext.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Logstore.Infra.Context
{
    public class LogStoreContext : DbContext
    {
        public LogStoreContext(){}
        public LogStoreContext(DbContextOptions<LogStoreContext> options)
            : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Data Source=LogStore.DB");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LogStoreContext).Assembly);
            modelBuilder.Ignore<Notifiable>();
            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Email>();
            modelBuilder.Ignore<Endereco>();
            base.OnModelCreating(modelBuilder);
            EntityMapping(modelBuilder);
        }

        private void EntityMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
                       {
                           entity.ToTable("Cliente")
                           .HasKey(e => e.Id);

                           entity.Property(e => e.identifyer).HasDefaultValueSql("lower(hex(randomblob(16)))");

                           entity.Property(e => e.Nome)
                               .HasMaxLength(100)
                               .HasColumnName("Nome");

                           entity.Property(e => e.Email)
                               .IsRequired()
                               .HasMaxLength(50).
                               HasColumnName("Email");


                        //    entity.Property(e => e.endereco.Cep)
                        //    .HasMaxLength(11)
                        //    .HasColumnName("Cep");

                        //    entity.Property(e => e.endereco.Cidade)
                        //    .HasMaxLength(50)
                        //    .HasColumnName("Cidade");

                        //    entity.Property(e => e.endereco.Estado)
                        //        .HasMaxLength(50)
                        //    .HasColumnName("Estado");

                        //    entity.Property(e => e.endereco.Numero)
                        //        .HasMaxLength(5)
                        //    .HasColumnName("Numero");

                        //    entity.Property(e => e.endereco.Pais)
                        //        .HasMaxLength(20)
                        //    .HasColumnName("Pais");

                        //    entity.Property(e => e.endereco.Rua)
                        //        .HasMaxLength(50)
                        //    .HasColumnName("Rua");

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

                entity.HasOne(p => p.pedido)
                               .WithMany(p => p.Produtos)
                               .HasForeignKey(bc => bc.PedidoId);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.ToTable("Pedido")
                .HasKey(e => e.Id);

                entity.Property(e => e.identifyer).HasDefaultValueSql("lower(hex(randomblob(16)))");

                entity.HasOne(p => p.cliente)
                               .WithMany(p => p.Pedidos)
                               .HasForeignKey(bc => bc.ClienteId);
            });
        }
    }
}