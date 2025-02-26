using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZwalks.Api.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var ReaderId = "2c095b72-07f6-4b46-8a85-081f09fca629";
            var WriterRoleId = "a67fe12b-2dca-4ae7-8cc4-45a44021352a";
            var Role = new List<IdentityRole> {
                new IdentityRole()
                {
                Id = WriterRoleId,
                ConcurrencyStamp = WriterRoleId,
                Name = "Writer",
                NormalizedName = "Writer".ToUpper()
                },
            new IdentityRole()
            {
                Id = ReaderId,
                ConcurrencyStamp = ReaderId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()
            }};
                

        builder.Entity<IdentityRole>().HasData(Role);
        }
    }
}    

