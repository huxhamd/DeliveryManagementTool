﻿// <auto-generated />
using System;
using DMT.GeneratingOrderBooks.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DMT.GeneratingOrderbooks.Data.Migrations
{
    [DbContext(typeof(GeneratingOrderbooksContext))]
    [Migration("20191105114120_BackendChangesForGettingOrderbookWeeks")]
    partial class BackendChangesForGettingOrderbookWeeks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DMT.GeneratingOrderBooks.Domain.Entities.Order", b =>
                {
                    b.Property<string>("PandOId")
                        .HasMaxLength(23);

                    b.Property<decimal>("OrderbookId")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.HasKey("PandOId", "OrderbookId");

                    b.HasIndex("OrderbookId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DMT.GeneratingOrderBooks.Domain.Entities.Orderbook", b =>
                {
                    b.Property<decimal>("Id")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<int>("SupplierId");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Orderbooks");
                });

            modelBuilder.Entity("DMT.GeneratingOrderBooks.Domain.Entities.PlannedAndOverdueOrder", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(23);

                    b.Property<DateTime>("DatePulled")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("ItemDeliveryDate")
                        .HasColumnType("date");

                    b.Property<int>("OpenPOQty");

                    b.Property<int>("POLineItem");

                    b.Property<int>("POSchedLine");

                    b.Property<string>("PartDescription")
                        .HasMaxLength(100);

                    b.Property<string>("PartNumber")
                        .HasMaxLength(80);

                    b.Property<string>("PurchaseOrder")
                        .HasMaxLength(8);

                    b.Property<DateTime>("StatDeliverySchedule")
                        .HasColumnType("date");

                    b.Property<int>("SupplierId");

                    b.Property<string>("SupplierName")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("PlannedAndOverdueOrders");
                });

            modelBuilder.Entity("DMT.GeneratingOrderBooks.Domain.Entities.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .IsFixedLength(true)
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("DMT.GeneratingOrderBooks.Domain.Entities.Order", b =>
                {
                    b.HasOne("DMT.GeneratingOrderBooks.Domain.Entities.Orderbook")
                        .WithMany("Orders")
                        .HasForeignKey("OrderbookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("DMT.GeneratingOrderBooks.Domain.ValueObjects.Order_VO", "Details", b1 =>
                        {
                            b1.Property<string>("OrderPandOId");

                            b1.Property<decimal>("OrderbookId")
                                .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                            b1.Property<DateTime>("ItemDeliveryDate")
                                .HasColumnType("date");

                            b1.Property<int>("OpenPOQty");

                            b1.Property<int>("POLineItem");

                            b1.Property<int>("POSchedLine");

                            b1.Property<string>("PurchaseOrder")
                                .HasMaxLength(8);

                            b1.Property<DateTime>("StatDeliverySchedule")
                                .HasColumnType("date");

                            b1.HasKey("OrderPandOId", "OrderbookId");

                            b1.ToTable("Orders");

                            b1.HasOne("DMT.GeneratingOrderBooks.Domain.Entities.Order")
                                .WithOne("Details")
                                .HasForeignKey("DMT.GeneratingOrderBooks.Domain.ValueObjects.Order_VO", "OrderPandOId", "OrderbookId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("DMT.GeneratingOrderBooks.Domain.ValueObjects.Part_VO", "Part", b1 =>
                        {
                            b1.Property<string>("OrderPandOId");

                            b1.Property<decimal>("OrderbookId")
                                .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                            b1.Property<string>("Description")
                                .HasMaxLength(100);

                            b1.Property<string>("Number")
                                .HasMaxLength(80);

                            b1.HasKey("OrderPandOId", "OrderbookId");

                            b1.ToTable("Orders");

                            b1.HasOne("DMT.GeneratingOrderBooks.Domain.Entities.Order")
                                .WithOne("Part")
                                .HasForeignKey("DMT.GeneratingOrderBooks.Domain.ValueObjects.Part_VO", "OrderPandOId", "OrderbookId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("DMT.GeneratingOrderBooks.Domain.Entities.Orderbook", b =>
                {
                    b.HasOne("DMT.GeneratingOrderBooks.Domain.Entities.Supplier")
                        .WithMany("Orderbooks")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("DMT.GeneratingOrderBooks.Domain.ValueObjects.DateStamp_VO", "DateStamp", b1 =>
                        {
                            b1.Property<decimal>("OrderbookId")
                                .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                            b1.Property<DateTime>("DateCreated");

                            b1.Property<DateTime>("DatePulled")
                                .HasColumnType("smalldatetime");

                            b1.Property<string>("OrderbookWeek")
                                .HasMaxLength(7);

                            b1.HasKey("OrderbookId");

                            b1.ToTable("Orderbooks");

                            b1.HasOne("DMT.GeneratingOrderBooks.Domain.Entities.Orderbook")
                                .WithOne("DateStamp")
                                .HasForeignKey("DMT.GeneratingOrderBooks.Domain.ValueObjects.DateStamp_VO", "OrderbookId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("DMT.GeneratingOrderBooks.Domain.Entities.Supplier", b =>
                {
                    b.OwnsOne("DMT.GeneratingOrderBooks.Domain.ValueObjects.Supplier_VO", "Details", b1 =>
                        {
                            b1.Property<int>("SupplierId");

                            b1.Property<string>("Name")
                                .HasMaxLength(80);

                            b1.HasKey("SupplierId");

                            b1.ToTable("Supplier");

                            b1.HasOne("DMT.GeneratingOrderBooks.Domain.Entities.Supplier")
                                .WithOne("Details")
                                .HasForeignKey("DMT.GeneratingOrderBooks.Domain.ValueObjects.Supplier_VO", "SupplierId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
