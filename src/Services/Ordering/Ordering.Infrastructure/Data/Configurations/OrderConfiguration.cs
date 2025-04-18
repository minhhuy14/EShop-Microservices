
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enums;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o=> o.Id);
        
        builder.Property(o => o.Id).HasConversion(
            orderId=> orderId.Value,
            dbId=>OrderId.Of(dbId));

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .IsRequired();

        builder.HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(o => o.OrderId);

        builder.ComplexProperty(
            o => o.OrderName, nameBuilder =>
            {
                nameBuilder.Property(n => n.Value)
                    .HasColumnName(nameof(Order.OrderName))
                    .HasMaxLength(100)
                    .IsRequired();
            }
        );

        builder.ComplexProperty(
            o => o.ShippingAddress, addressBuilder =>
            {
                
                addressBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();
                
                addressBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.Email)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(100)
                    .IsRequired();

                addressBuilder.Property(a => a.Country)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.State)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(5);
            }
        );
        
        builder.ComplexProperty(
            o => o.BillingAddress, addressBuilder =>
            {
                addressBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.Email)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                addressBuilder.Property(a => a.Country)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.State)
                    .HasMaxLength(50);

                addressBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(5)
                    .IsRequired();
            });

        
        builder.ComplexProperty(o=>o.Payment, paymentBuilder =>
        {
            paymentBuilder.Property(p => p.CardNumber)
                .HasMaxLength(16)
                .IsRequired();

            paymentBuilder.Property(p => p.CardName)
                .HasMaxLength(50)
                .IsRequired();

            paymentBuilder.Property(p => p.Cvv)
                .HasMaxLength(3)
                .IsRequired();

            paymentBuilder.Property(p => p.Method)
                .HasDefaultValue(PaymentMethod.InPerson)
                .HasConversion(
                    method => method.ToString(),
                    dbMethod => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), dbMethod)
                );

        });
        
        builder.Property(o=>o.Status)
            .HasDefaultValue(OrderStatus.Draft)
            .HasConversion(
                status => status.ToString(),
                dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus));

        builder.Property(o => o.TotalPrice)
            .HasPrecision(18, 2);
    }
}