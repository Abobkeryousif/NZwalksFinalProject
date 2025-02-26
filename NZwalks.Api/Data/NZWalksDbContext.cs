using Microsoft.EntityFrameworkCore;
using NZwalks.Api.Models.Domain;

namespace NZwalks.Api.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        public DbSet<Image> Images { get;  set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data to difficulty domain model
            var difficulty = new List<Difficulty>()
            {
                new Difficulty()
                {
                Id = Guid.Parse("d4f00cd7-864b-49f5-9857-d7e0ca759914"),
                Name = "Easy"

                },
                new Difficulty()
                {
                Id = Guid.Parse("0d2efca6-b9df-4d34-bfda-e28a506114e5"),
                Name = "Meduim"

                },
                new Difficulty()
                {
                Id = Guid.Parse("a24285ea-a684-41bd-a47c-d299fc06502f"),
                Name = "Hard"

                }

            };

            modelBuilder.Entity<Difficulty>().HasData(difficulty);

            //seed data to Region domain model

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("840061b2-ad14-4f02-ac93-9d28fdb878f7"),
                    Name = "Akuland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"

                },

                   new Region
                {
                    Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);



        

        }

    }


    
}


