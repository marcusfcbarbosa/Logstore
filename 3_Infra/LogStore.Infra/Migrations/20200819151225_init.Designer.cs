﻿// <auto-generated />
using System;
using Logstore.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Logstore.Infra.Migrations
{
    [DbContext(typeof(LogStoreContext))]
    [Migration("20200819151225_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Logstore.Domain.LogStoreContext.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .HasColumnName("Nome")
                        .HasMaxLength(100);

                    b.Property<string>("identifyer")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("lower(hex(randomblob(16)))");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Logstore.Domain.LogStoreContext.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("FreteGratis");

                    b.Property<decimal>("ValorPedido");

                    b.Property<string>("identifyer")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("lower(hex(randomblob(16)))");

                    b.Property<byte>("status");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Logstore.Domain.LogStoreContext.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Descricao")
                        .HasMaxLength(100);

                    b.Property<decimal>("Valor")
                        .HasColumnName("Valor");

                    b.Property<string>("identifyer")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("lower(hex(randomblob(16)))");

                    b.HasKey("Id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Logstore.Domain.LogStoreContext.Entities.ProdutoPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("PedidoId");

                    b.Property<int>("ProdutoId");

                    b.Property<int>("QuantidadeProduto")
                        .HasColumnName("QuantidadeProduto");

                    b.Property<string>("identifyer")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("lower(hex(randomblob(16)))");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutoPedido");
                });

            modelBuilder.Entity("Logstore.Domain.LogStoreContext.Entities.Pedido", b =>
                {
                    b.HasOne("Logstore.Domain.LogStoreContext.Entities.Cliente", "cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Logstore.Domain.LogStoreContext.Entities.ProdutoPedido", b =>
                {
                    b.HasOne("Logstore.Domain.LogStoreContext.Entities.Pedido", "pedido")
                        .WithMany("ProdutoPedidos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Logstore.Domain.LogStoreContext.Entities.Produto", "produto")
                        .WithMany("ProdutoPedidos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
