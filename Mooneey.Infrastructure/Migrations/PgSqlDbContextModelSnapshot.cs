// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mooneey.Infrastructure.Persistence.Contexts;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Mooneey.Infrastructure.Migrations
{
    [DbContext(typeof(PgSqlDbContext))]
    partial class PgSqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AccountTransaction", b =>
                {
                    b.Property<Guid>("AccountsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TransactionsId")
                        .HasColumnType("uuid");

                    b.HasKey("AccountsId", "TransactionsId");

                    b.HasIndex("TransactionsId");

                    b.ToTable("AccountTransaction");
                });

            modelBuilder.Entity("Mooneey.Domain.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte>("AccountType")
                        .HasColumnType("smallint");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CurrencyCode")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Mooneey.Domain.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Transactions", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Expense", b =>
                {
                    b.HasBaseType("Mooneey.Domain.Transaction");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.HasIndex("AccountId");

                    b.ToTable("Expenses", (string)null);
                });

            modelBuilder.Entity("Mooneey.Domain.Income", b =>
                {
                    b.HasBaseType("Mooneey.Domain.Transaction");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.HasIndex("AccountId");

                    b.ToTable("Income", (string)null);
                });

            modelBuilder.Entity("Mooneey.Domain.Transfer", b =>
                {
                    b.HasBaseType("Mooneey.Domain.Transaction");

                    b.Property<Guid?>("SourceAccountId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("SourceAmount")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("TargetAccountId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("TargetAmount")
                        .HasColumnType("numeric");

                    b.HasIndex("SourceAccountId");

                    b.HasIndex("TargetAccountId");

                    b.ToTable("Transfers", (string)null);
                });

            modelBuilder.Entity("AccountTransaction", b =>
                {
                    b.HasOne("Mooneey.Domain.Account", null)
                        .WithMany()
                        .HasForeignKey("AccountsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mooneey.Domain.Transaction", null)
                        .WithMany()
                        .HasForeignKey("TransactionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Expense", b =>
                {
                    b.HasOne("Mooneey.Domain.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mooneey.Domain.Transaction", null)
                        .WithOne()
                        .HasForeignKey("Expense", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Mooneey.Domain.Income", b =>
                {
                    b.HasOne("Mooneey.Domain.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mooneey.Domain.Transaction", null)
                        .WithOne()
                        .HasForeignKey("Mooneey.Domain.Income", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Mooneey.Domain.Transfer", b =>
                {
                    b.HasOne("Mooneey.Domain.Transaction", null)
                        .WithOne()
                        .HasForeignKey("Mooneey.Domain.Transfer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mooneey.Domain.Account", "SourceAccount")
                        .WithMany()
                        .HasForeignKey("SourceAccountId");

                    b.HasOne("Mooneey.Domain.Account", "TargetAccount")
                        .WithMany()
                        .HasForeignKey("TargetAccountId");

                    b.Navigation("SourceAccount");

                    b.Navigation("TargetAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
