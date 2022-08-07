namespace WebApi.Helpers;

using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Entities.Events;
using WebApi.Entities.Misc;
using WebApi.Entities.Venues;
using WebApi.Entities.Users;
using WebApi.Entities.DbFlags;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
    }

    #region Users

    public DbSet<User> Users { get; set; }

    #endregion

    #region Users

    public DbSet<Event> Events { get; set; }

    #endregion

    #region Misc

    public DbSet<Address> Address { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivityType> ActivityTypes { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryType> InventoryTypes { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Tag> Tags { get; set; }

    #endregion

    #region Venues

    public DbSet<Venue> Venues { get; set; }
    public DbSet<VenueType> VenueTypes { get; set; }

    #endregion


    #region DbConfig

    public DbSet<DbFlags> DbFlags { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Write Fluent API configurations here

        // var newVenueType1 = new VenueType { Id = 1, Name = "Igralista" };
        // var newVenueType2 = new VenueType { Id = 2, Name = "Dvorana" };
        // var newVenueType3 = new VenueType { Id = 3, Name = "Kino" };
        // var newVenueType4 = new VenueType { Id = 4, Name = "Kafic" };

        // // Property Configurations
        // modelBuilder.Entity<VenueType>().HasData(newVenueType1, newVenueType2, newVenueType3, newVenueType4);

        // var newAddress1 = new Address { Id = 1, Country = "Hrvatska", City = "Osijek", PostalCode = "31000", Street = "Suncana", StreetNumber = "9" };
        // var newAddress2 = new Address { Id = 2, Country = "Hrvatska", City = "Osijek", PostalCode = "31000", Street = "Svaciceva", StreetNumber = "3" };
        // var newAddress3 = new Address { Id = 3, Country = "Hrvatska", City = "Osijek", PostalCode = "31000", Street = "Crkvena", StreetNumber = "12" };
        // var newAddress4 = new Address { Id = 4, Country = "Hrvatska", City = "Osijek", PostalCode = "31000", Street = "Ilirska", StreetNumber = "54" };

        // modelBuilder.Entity<Address>().HasData(newAddress1, newAddress2, newAddress3, newAddress4);

        // var newVenue1 = new Venue { Id = 1, Name = "Nogos na srednjici", VenueType = newVenueType1 };
        // var newVenue2 = new Venue { Id = 2, Name = "Nogos u truhleci", VenueType = newVenueType2 };
        // var newVenue3 = new Venue { Id = 3, Name = "Basket na srednjici", VenueType = newVenueType3 };
        // var newVenue4 = new Venue { Id = 4, Name = "Basket u truhleci ", VenueType = newVenueType4 };
        modelBuilder.Entity<Venue>()
               .HasOne(c => c.Address)
               .WithMany(e => e.Venues);

        modelBuilder.Entity<Venue>()
               .HasOne(c => c.VenueType)
               .WithMany(e => e.Venues);

        // modelBuilder.Entity<Address>(a =>
        //     {
        //         a.HasData(new
        //         {
        //             Id = 1,
        //             Country = "Hrvatska",
        //             City = "Osijek",
        //             PostalCode = "31000",
        //             Street = "Suncana",
        //             StreetNumber = "9"
        //         });

        //         a.OwnsMany(e => e.Venues).HasData(new
        //         {
        //             Id = 1,
        //             Name = "Nogos na srednjici",
        //         },
        //         new {
        //             Id =2,
        //             Name = "Nogos na srednjici",
        //         },
        //         new {
        //             Id = 3,
        //             Name = "Nogos na srednjici",
        //         });
        //     });



        // modelBuilder.Entity<Venue>().HasData(newVenue1, newVenue2, newVenue3, newVenue4);

        // modelBuilder.Entity<VenueType>().HasData(
        //                 new Event { Id = 1, EventName = "Igralista" },
        //                 new Event { Id = 2, EventName = "Dvorana" },
        //                 new Event { Id = 3, EventName = "Kino" },
        //                 new Event { Id = 4, EventName = "Kafic" });

        // modelBuilder.Entity<VenueType>().HasData(
        //                 new Event { Id = 1, EventName = "Igralista" },
        //                 new Event { Id = 2, EventName = "Dvorana" },
        //                 new Event { Id = 3, EventName = "Kino" },
        //                 new Event { Id = 4, EventName = "Kafic" });

        // modelBuilder.Entity<Event>().HasData(
        //         new Event { EventName = "Nogos na srednjici", PostId = 1, Title = "First post", Content = "Test 1" });
    }
}