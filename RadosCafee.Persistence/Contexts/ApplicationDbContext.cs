using Microsoft.EntityFrameworkCore;
using RadosCafee.Domain.Common;
using RadosCafee.Domain.Common.Interfaces;
using RadosCafee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RadosCafee.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option, IDomainEventDispatcher domainEventDispatcher ) : base( option )
        {
            _domainEventDispatcher= domainEventDispatcher;
        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<DishCategory> DishCategories { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MealPromotion> MealPromotions { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<DishIngredient>().HasNoKey();
            //modelBuilder.Entity<MealPromotion>().HasNoKey();

            modelBuilder.Entity<DishIngredient>().HasKey(di => new { di.IngredientId, di.DishId });
            modelBuilder.Entity<DishIngredient>().HasOne(ind => ind.Ingredient).WithMany(di=>di.DishIngredients).HasForeignKey(inde=> inde.IngredientId);
            modelBuilder.Entity<DishIngredient>().HasOne(di=>di.Dish).WithMany(din=>din.DishIngredients).HasForeignKey(di=>di.DishId);

            modelBuilder.Entity<MealPromotion>().HasKey(mp => new { mp.PromotionId, mp.MealId });
            modelBuilder.Entity<MealPromotion>().HasOne(m=>m.Meal).WithMany(mp=> mp.MealPromotion).HasForeignKey(mp=>mp.MealId);
            modelBuilder.Entity<MealPromotion>().HasOne(p=> p.Promotion).WithMany(mp=>mp.MealPromotions).HasForeignKey(mp=>mp.PromotionId);
                    
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (_domainEventDispatcher == null) return result;
            var entityWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e=> e.Entity)
                .Where(e=> e.DomainEvents.Any()).ToArray();
            await _domainEventDispatcher.DispatchAndClearEvents(entityWithEvents);
            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
