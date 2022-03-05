using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CountryStateApplication.Authorization.Roles;
using CountryStateApplication.Authorization.Users;
using CountryStateApplication.MultiTenancy;
using CountryStateApplication.Countries;
using CountryStateApplication.States;

namespace CountryStateApplication.EntityFrameworkCore
{
    public class CountryStateApplicationDbContext : AbpZeroDbContext<Tenant, Role, User, CountryStateApplicationDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public CountryStateApplicationDbContext(DbContextOptions<CountryStateApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<State> State { get; set; }
    }
}
