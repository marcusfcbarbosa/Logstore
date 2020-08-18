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
        public DbSet<ProdutoPedido> ProdutoPedidos { get; set; }
        

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

                entity.HasOne(p => p.cliente)
                               .WithMany(p => p.Pedidos)
                               .HasForeignKey(bc => bc.ClienteId);
            });

            modelBuilder.Entity<ProdutoPedido>(entity =>
            {
                entity.ToTable("ProdutoPedido")
                .HasKey(e => e.Id);

                entity.Property(e => e.identifyer).HasDefaultValueSql("lower(hex(randomblob(16)))");

                entity.HasOne(p => p.pedido)
                               .WithMany(p => p.ProdutoPedidos)
                               .HasForeignKey(bc => bc.PedidoId);

                entity.HasOne(p => p.produto)
                               .WithMany(p => p.ProdutoPedidos)
                               .HasForeignKey(bc => bc.ProdutoId);
                
                entity.Property(e => e.QuantidadeProduto)
                    .IsRequired().
                    HasColumnName("QuantidadeProduto");
            });
        }
    }
}