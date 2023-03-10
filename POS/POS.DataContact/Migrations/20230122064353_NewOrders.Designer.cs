// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS.Repository;

#nullable disable

namespace POS.Repository.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230122064353_NewOrders")]
    partial class NewOrders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("POS.Repository.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("category_name");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("category_desc");

                    b.HasKey("Id");

                    b.ToTable("tbl_category");
                });

            modelBuilder.Entity("POS.Repository.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("city");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("company_name");

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("contact_title");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("country");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<int>("Fax")
                        .HasColumnType("int")
                        .HasColumnName("fax");

                    b.Property<int>("Phone")
                        .HasColumnType("int")
                        .HasColumnName("phone");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("postalcode");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("region");

                    b.HasKey("Id");

                    b.ToTable("tbl_customer");
                });

            modelBuilder.Entity("POS.Repository.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("address");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("birth_date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("country");

                    b.Property<int>("Extension")
                        .HasColumnType("int")
                        .HasColumnName("extension");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("first_name");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("hire_date");

                    b.Property<int>("HomePhone")
                        .HasColumnType("int")
                        .HasColumnName("home_phone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("last_name");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("notes");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int")
                        .HasColumnName("postal_code");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("region");

                    b.Property<string>("ReportTo")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("report_to");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("tittle");

                    b.Property<string>("TittleOfCourtesy")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("tittle_of_courtesy");

                    b.HasKey("Id");

                    b.ToTable("tbl_employees");
                });

            modelBuilder.Entity("POS.Repository.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<double>("Discount")
                        .HasColumnType("double")
                        .HasColumnName("discount");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int")
                        .HasColumnName("unit_price");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("tbl_order_details");
                });

            modelBuilder.Entity("POS.Repository.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("orders_ship_country");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("orders_customerid");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("orders_employeeid");

                    b.Property<int>("Freight")
                        .HasColumnType("int")
                        .HasColumnName("orders_freight");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("orders_date");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("orders_required_date");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("orders_ship_address");

                    b.Property<string>("ShipCity")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("orders_ship_city");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("orders_ship_name");

                    b.Property<int>("ShipPostalCode")
                        .HasColumnType("int")
                        .HasColumnName("orders_ship_postalcode");

                    b.Property<string>("ShipRegion")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("orders_ship_region");

                    b.Property<int>("ShipVia")
                        .HasColumnType("int")
                        .HasColumnName("orders_ship_via");

                    b.Property<DateTime>("ShippedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("orders_shipped_date");

                    b.Property<int>("ShipperId")
                        .HasColumnType("int")
                        .HasColumnName("orders_shipperid");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ShipperId");

                    b.ToTable("tbl_orders");
                });

            modelBuilder.Entity("POS.Repository.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<bool>("Discontinued")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("products_discontinued");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("products_name");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("products_quantity");

                    b.Property<int>("Reorder")
                        .HasColumnType("int")
                        .HasColumnName("products_reorder");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int")
                        .HasColumnName("supplier_id");

                    b.Property<int>("UnitOrder")
                        .HasColumnType("int")
                        .HasColumnName("products_unit_order");

                    b.Property<int>("UnitPrice")
                        .HasColumnType("int")
                        .HasColumnName("products_unit_price");

                    b.Property<int>("UnitStock")
                        .HasColumnType("int")
                        .HasColumnName("products_unit_stock");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("tbl_products");
                });

            modelBuilder.Entity("POS.Repository.Shippers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("company_name");

                    b.Property<int>("Phone")
                        .HasColumnType("int")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("tbl_shipper");
                });

            modelBuilder.Entity("POS.Repository.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("supplier_address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("supplier_city");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("supplier_company_name");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("supplier_contact_name");

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("supplier_contact_title");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("supplier_country");

                    b.Property<int>("Fax")
                        .HasColumnType("int")
                        .HasColumnName("supplier_fax");

                    b.Property<string>("HomePage")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("supplier_homepage");

                    b.Property<int>("Phone")
                        .HasColumnType("int")
                        .HasColumnName("supplier_phone");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("supplier_postalcode");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("supplier_region");

                    b.HasKey("Id");

                    b.ToTable("tbl_supplier");
                });

            modelBuilder.Entity("POS.Repository.OrderDetails", b =>
                {
                    b.HasOne("POS.Repository.Orders", "Order")
                        .WithMany("OrderDetail")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Repository.Products", "Product")
                        .WithMany("OrderDetail")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("POS.Repository.Orders", b =>
                {
                    b.HasOne("POS.Repository.Customers", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Repository.Employees", "Employee")
                        .WithMany("Order")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Repository.Shippers", "Shipper")
                        .WithMany()
                        .HasForeignKey("ShipperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("POS.Repository.Products", b =>
                {
                    b.HasOne("POS.Repository.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Repository.Supplier", "Supplier")
                        .WithMany("Product")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("POS.Repository.Category", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("POS.Repository.Customers", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("POS.Repository.Employees", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("POS.Repository.Orders", b =>
                {
                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("POS.Repository.Products", b =>
                {
                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("POS.Repository.Supplier", b =>
                {
                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
