using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace eStore.Repositories
{
    public partial class eVoucherContext : DbContext
    {
        public eVoucherContext()
        {
        }

        public eVoucherContext(DbContextOptions<eVoucherContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Voucher> Voucher { get; set; }
        public virtual DbSet<VoucherDetail> VoucherDetail { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_Users");

                entity.Property(e => e.Guid)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MaxGiftQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxQty).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Discount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Guid)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PK_Sale");

                entity.Property(e => e.Guid)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.BuyType).IsUnicode(false);

                entity.Property(e => e.CustomerGuid)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.PaymentType).IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CustomerGu)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.CustomerGuid)
                    .HasConstraintName("FK_Vouchers_Customer");

                entity.HasOne(d => d.PaymentTypeNavigation)
                    .WithMany(p => p.Vouchers)
                    .HasForeignKey(d => d.PaymentType)
                    .HasConstraintName("FK_Vouchers_PaymentType");
            });

            modelBuilder.Entity<VoucherDetail>(entity =>
            {
                entity.Property(e => e.Guid)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PromoCode).IsUnicode(false);

                entity.Property(e => e.PromoCodeStatus)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Qrcode).IsUnicode(false);

                entity.Property(e => e.VoucherGuid)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.HasOne(d => d.VoucherGu)
                    .WithMany(p => p.VoucherDetail)
                    .HasForeignKey(d => d.VoucherGuid)
                    .HasConstraintName("FK_VoucherDetail_Voucher");
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
