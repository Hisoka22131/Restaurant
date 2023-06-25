using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Core.CustomException;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core.Context;

public partial class RestaurantDbContext : DbContext
{
    private const string myComputer = "DESKTOP-467EEFG";
    private const string workComputer = ".\\SQLEXPRESS";

    private const string workDB =
        $"Server={myComputer}; Database=Restaurant; Trusted_Connection=True; MultipleActiveResultSets=True; TrustServerCertificate=True";

    public RestaurantDbContext()
    {
    }

    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<DeliveryMan> DeliveryMens { get; set; }
    public virtual DbSet<Dish> Dishes { get; set; }
    public virtual DbSet<DishesOrder> DishesOrders { get; set; }
    public virtual DbSet<District> Districts { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(workDB);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<DishesOrder>().Navigation(q => q.Order).AutoInclude();
        //modelBuilder.Entity<DishesOrder>().Navigation(q => q.Dishes).AutoInclude();
        //modelBuilder.Entity<Order>().Navigation(q => q.DeliveryMan).AutoInclude();
        //modelBuilder.Entity<Order>().Navigation(q => q.Client).AutoInclude();
        //modelBuilder.Entity<Order>().Navigation(q => q.DishesOrders).AutoInclude();
        //modelBuilder.Entity<Dish>().Navigation(q => q.DishesOrders).AutoInclude();
        //modelBuilder.Entity<DeliveryMan>().Navigation(q => q.District).AutoInclude();
        //modelBuilder.Entity<DeliveryMan>().Navigation(q => q.Orders).AutoInclude();
        //modelBuilder.Entity<Client>().Navigation(q => q.Orders).AutoInclude();

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.HasIndex(e => new { e.FirstName, e.LastName }, "NonClusteredIndex-20230221-095034");

            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Birthday).HasColumnType("date");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DeliveryMan>(entity =>
        {
            entity.ToTable("DeliveryMan");

            entity.Property(e => e.City).HasMaxLength(25);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.PassportSeries)
                .IsRequired()
                .HasMaxLength(300);

            entity.Property(e => e.PhoneNumber).HasMaxLength(100);

            entity.HasOne(d => d.District)
                .WithMany(p => p.DeliveryMens)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeliveryMan_District");
        });

        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasIndex(e => e.Name, "NonClusteredIndex-20230221-095136");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DishesOrder>(entity =>
        {
            entity.HasIndex(e => new { e.DishesId, e.OrderId }, "NonClusteredIndex-20230221-095146");

            entity.HasOne(d => d.Dishes)
                .WithMany(p => p.DishesOrders)
                .HasForeignKey(d => d.DishesId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DishesOrders_Dishes");

            entity.HasOne(d => d.Order)
                .WithMany(p => p.DishesOrders)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DishesOrders_Order");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.ToTable("District");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.HasIndex(e => e.Number, "NonClusteredIndex-20230221-095113");

            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(6, 2)");

            entity.Property(e => e.Number)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Client)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Order_Client");

            entity.HasOne(d => d.DeliveryMan)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.DeliveryManId)
                .HasConstraintName("FK_Order_DeliveryMan");
        });

        modelBuilder.Entity<DeliveryManVacation>(entity =>
        {
            entity.HasOne(d => d.DeliveryMan)
                .WithMany(d => d.DeliveryManVacations)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DeliveryManVacation_DeliveryMan");
        });

        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany()
            .UsingEntity(j => j.ToTable("UserRole"));
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public override int SaveChanges()
    {
        var dict = new Dictionary<object, List<ValidationResult>>();
        foreach (var entry in ChangeTracker.Entries()
                     .Where(t => t.State is EntityState.Modified or EntityState.Added))
        {
            if (entry.Entity is not IValidatableObject iValidatable) continue;
            var foo = iValidatable.Validate(new ValidationContext(entry.Entity)).ToList();
            if (foo.Any())
                dict.Add(entry.Entity, foo);
        }

        if (dict.Any())
        {
            throw new RestaurantValidationException(dict);
        }

        return base.SaveChanges();
    }
}