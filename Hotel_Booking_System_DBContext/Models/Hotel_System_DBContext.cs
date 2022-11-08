namespace Hotel_Booking_System_DBContext.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Hotel_System_DBContext : DbContext
    {
        public Hotel_System_DBContext()
            : base("name=Hotel_System_DBContext")
        {
        }

        public virtual DbSet<Booking_log> Booking_log { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Hotel_Categories> Hotel_Categories { get; set; }
        public virtual DbSet<Hotel_Info> Hotel_Info { get; set; }
        public virtual DbSet<Room_Types> Room_Types { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking_log>()
                .Property(e => e.amount)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Booking_log)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.client_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Floor>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Floor)
                .HasForeignKey(e => e.floor_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotel_Categories>()
                .HasMany(e => e.Booking_log)
                .WithOptional(e => e.Hotel_Categories)
                .HasForeignKey(e => e.hotel_category_id);

            modelBuilder.Entity<Hotel_Categories>()
                .HasMany(e => e.Floors)
                .WithOptional(e => e.Hotel_Categories)
                .HasForeignKey(e => e.hotel_category_id);

            modelBuilder.Entity<Hotel_Info>()
                .HasMany(e => e.Hotel_Categories)
                .WithRequired(e => e.Hotel_Info)
                .HasForeignKey(e => e.hotel_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room_Types>()
                .HasMany(e => e.Rooms)
                .WithRequired(e => e.Room_Types)
                .HasForeignKey(e => e.room_type_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.day_price)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Booking_log)
                .WithOptional(e => e.Room)
                .HasForeignKey(e => e.room_id);
        }
    }
}
