using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AquitoApi.Entities {
    public partial class d2bc1ckqeusvkjContext : IdentityDbContext<Useraquito, Roleaquito, int> {
        public d2bc1ckqeusvkjContext() { }

        public d2bc1ckqeusvkjContext(DbContextOptions<d2bc1ckqeusvkjContext> options) : base(options) { }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Typevehicle> Typevehicles { get; set; }
        public virtual DbSet<Useraquito> Useraquitos { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Factura606> Factura606s { get; set; }
        public virtual DbSet<Factura607> Factura607s { get; set; }
        public virtual DbSet<FacturaDetalle606> FacturaDetalles606s { get; set; }
        public virtual DbSet<FacturaDetalle607> FacturaDetalles607s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Client>(entity => {
                entity.ToTable("client");

                entity.Property(e => e.Id)
                    .HasColumnName("clientid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .HasColumnName("cedula");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(80)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(80)
                    .HasColumnName("lastname");

                entity.Property(e => e.Licence)
                    .HasMaxLength(25)
                    .HasColumnName("licence");

                entity.Property(e => e.Licencepic)
                    .HasMaxLength(650)
                    .HasColumnName("licencepic");

                entity.Property(e => e.Nacionality)
                    .HasMaxLength(80)
                    .HasColumnName("nacionality");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Typeblood)
                    .HasMaxLength(10)
                    .HasColumnName("typeblood");

                entity.Property(e => e.Useraquitoid).HasColumnName("useraquitoid");

                entity.Property(e => e.Userpic)
                    .HasMaxLength(650)
                    .HasColumnName("userpic");

                entity.HasOne(d => d.Useraquito)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.Useraquitoid)
                    .HasConstraintName("fk_useraquito_client");
            });

            modelBuilder.Entity<Reservation>(entity => {
                entity.ToTable("reservation");

                entity.Property(e => e.Id)
                    .HasColumnName("reservationid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Enddate)
                    .HasColumnType("date")
                    .HasColumnName("enddate");

                entity.Property(e => e.Startdate)
                    .HasColumnType("date")
                    .HasColumnName("startdate");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Totalpay).HasColumnName("totalpay");

                entity.Property(e => e.Useraquitoid).HasColumnName("useraquitoid");

                entity.Property(e => e.Vehicleid).HasColumnName("vehicleid");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Clientid)
                    .HasConstraintName("fk_client_reservation");

                entity.HasOne(d => d.Useraquito)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Useraquitoid)
                    .HasConstraintName("fk_useraquito_reservation");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.Vehicleid)
                    .HasConstraintName("fk_vehicle_reservation");
            });

            modelBuilder.Entity<Typevehicle>(entity => {
                entity.ToTable("typevehicle");

                entity.Property(e => e.Id)
                    .HasColumnName("typevehicleid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Namevehicle)
                    .HasMaxLength(150)
                    .HasColumnName("namevehicle");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Useraquito>(entity => {
                entity.ToTable("useraquito");


                entity.Property(e => e.Firstname)
                    .HasMaxLength(80)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(80)
                    .HasColumnName("lastname");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Vehicle>(entity => {
                entity.ToTable("vehicle");

                entity.Property(e => e.Id)
                    .HasColumnName("vehicleid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Brand)
                    .HasMaxLength(150)
                    .HasColumnName("brand");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(25)
                    .HasColumnName("matricula");

                entity.Property(e => e.Model)
                    .HasMaxLength(150)
                    .HasColumnName("model");

                entity.Property(e => e.Passengers).HasColumnName("passengers");

                entity.Property(e => e.Priceday).HasColumnName("priceday");

                entity.Property(e => e.Securitynum)
                    .HasMaxLength(25)
                    .HasColumnName("securitynum");

                entity.Property(e => e.Color)
                    .HasMaxLength(25)
                    .HasColumnName("color");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Typevehicleid).HasColumnName("typevehicleid");

                entity.Property(e => e.Useraquitoid).HasColumnName("useraquitoid");

                entity.Property(e => e.Vehiclepic)
                    .HasMaxLength(650)
                    .HasColumnName("vehiclepic");

                entity.Property(e => e.Weightcapacity).HasColumnName("weightcapacity");

                entity.HasOne(d => d.Typevehicle)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.Typevehicleid)
                    .HasConstraintName("fk_typevehicle_vehicle");

                entity.HasOne(d => d.Useraquito)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.Useraquitoid)
                    .HasConstraintName("fk_useraquito_vehicle");
            });


            modelBuilder.Entity<Factura606>(entity => {
                entity.ToTable("factura606");

                entity.Property(e => e.Id)
                    .HasColumnName("factura606id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Mes).HasColumnName("mes");

                entity.Property(e => e.Identification).HasColumnName("identification");

                entity.Property(e => e.EmisionDate)
                    .HasColumnType("date")
                    .HasColumnName("emisiondate");

                entity.Property(e => e.Status).HasColumnName("status");
            
            });

            modelBuilder.Entity<Factura607>(entity => {
                entity.ToTable("factura607");

                entity.Property(e => e.Id)
                    .HasColumnName("factura607id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Mes).HasColumnName("mes");

                entity.Property(e => e.Identification).HasColumnName("identification");

                entity.Property(e => e.EmisionDate)
                    .HasColumnType("date")
                    .HasColumnName("emisiondate");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<FacturaDetalle606>(entity => {
                entity.ToTable("detallefactura606");

                entity.Property(e => e.Id)
                    .HasColumnName("detallefactura606id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Comprobante).HasColumnName("comprobantefiscal");

                entity.Property(e => e.ComprobanteDate)
                    .HasColumnType("date")
                    .HasColumnName("datecomprobante");

                entity.Property(e => e.TypeVenta)
                    .HasMaxLength(300)
                    .HasColumnName("tipoventa");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Itbis).HasColumnName("itbis");

                entity.Property(e => e.FormaPago)
                   .HasMaxLength(300)
                   .HasColumnName("formapago");

                entity.Property(e => e.FechaPago)
                   .HasColumnType("date")
                   .HasColumnName("fechapago");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Factura606)
                    .WithMany(p => p.FacturasDetalle606)
                    .HasForeignKey(d => d.Factura606id)
                    .HasConstraintName("fk_factura606_detallefactura606");
            });

            modelBuilder.Entity<FacturaDetalle607>(entity => {
                entity.ToTable("detallefactura607");

                entity.Property(e => e.Id)
                    .HasColumnName("detallefactura607id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Comprobante).HasColumnName("comprobantefiscal");

                entity.Property(e => e.ComprobanteDate)
                    .HasColumnType("date")
                    .HasColumnName("datecomprobante");

                entity.Property(e => e.TypeIncome)
                    .HasMaxLength(300)
                    .HasColumnName("tipoingreso");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Itbis).HasColumnName("itbis");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Factura607)
                    .WithMany(p => p.FacturasDetalle607)
                    .HasForeignKey(d => d.Factura607id)
                    .HasConstraintName("fk_factura607_detallefactura607");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
