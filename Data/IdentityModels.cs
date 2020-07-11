using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Background> Backgrounds { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterClass> CharacterClasses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<Subclass> Subclasses { get; set; }
        public DbSet<Subrace> Subraces { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Monster>()
                .Property(b => b._SavingThrows).HasColumnName("SavingThrows");
            modelBuilder.Entity<Monster>()
                .Property(b => b._Skills).HasColumnName("Skills");
            modelBuilder.Entity<Monster>()
                .Property(b => b._Traits).HasColumnName("Traits");
            modelBuilder.Entity<Monster>()
                .Property(b => b._Actions).HasColumnName("Actions");
            modelBuilder.Entity<Monster>()
                .Property(b => b._Reactions).HasColumnName("Reactions");
            modelBuilder.Entity<Monster>()
                .Property(b => b._LegendaryActions).HasColumnName("LegendaryActions");
            modelBuilder.Entity<Monster>()
                .Property(b => b._LairActions).HasColumnName("LairActions");
            modelBuilder.Entity<Subrace>()
                .Property(b => b._AbilityScoreIncrease).HasColumnName("AbilityScoreIncrease");
            modelBuilder.Entity<Subrace>()
                .Property(b => b._Traits).HasColumnName("Traits");
            modelBuilder.Entity<Background>()
                .Property(b => b._SkillProficiencies).HasColumnName("SkillProficiencies");
            modelBuilder.Entity<Character>()
                .Property(b => b._SavingThrows).HasColumnName("SavingThrows");
            modelBuilder.Entity<Character>()
                .Property(b => b._Skills).HasColumnName("Skills");
            modelBuilder.Entity<CharacterClass>()
                .Property(b => b._Features).HasColumnName("Features");
            modelBuilder.Entity<CharacterClass>()
                .Property(b => b._SavingThrows).HasColumnName("SavingThrows");
            modelBuilder.Entity<CharacterClass>()
                .Property(b => b._SkillChoices).HasColumnName("SkillChoices");
            modelBuilder.Entity<Race>()
                .Property(b => b._AbilityScoreIncrease).HasColumnName("AbilityScoreIncrease");
            modelBuilder.Entity<Race>()
                .Property(b => b._Traits).HasColumnName("Traits");
            modelBuilder.Entity<Spell>()
                .Property(b => b._ClassIds).HasColumnName("ClassIds");
            modelBuilder.Entity<Spell>()
                .Property(b => b._Components).HasColumnName("Components");
            modelBuilder.Entity<Subclass>()
                .Property(b => b._Features).HasColumnName("Features");
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();
            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());
        }
    }
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}