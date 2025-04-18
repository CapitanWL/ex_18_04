using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WpfApp1
{
    public partial class PizzaDbSharapovaContext : DbContext
    {
        public PizzaDbSharapovaContext()
        {
        }

        public PizzaDbSharapovaContext(DbContextOptions<PizzaDbSharapovaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addre> Addres { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientAddre> ClientAddres { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<PizzaAssortiment> PizzaAssortiments { get; set; }
        public virtual DbSet<PizzaIngredient> PizzaIngredients { get; set; }
        public virtual DbSet<PizzaOrder> PizzaOrders { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=hqvla3302s01\\KITP;Initial Catalog=PizzaDbSharapova;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Addre>(entity =>
            {
                entity.HasKey(e => e.AddresId);

                entity.Property(e => e.AddresId)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn()
                    .HasColumnName("AddresID")
                    ;

                entity.Property(e => e.FlatNumber)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.HomeNumber)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientId)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn()
                    .HasColumnName("ClientID");

                entity.Property(e => e.ClientFname)
                    .IsRequired()
                    .HasMaxLength(120)
                    .HasColumnName("ClientFName");

                entity.Property(e => e.ClientLname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ClientLName");

                entity.Property(e => e.ClientPatronumic).HasMaxLength(120);

                entity.Property(e => e.ClientPhone)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ClientAddre>(entity =>
            {
                entity.HasKey(e => e.ClientAddresId);

                entity.Property(e => e.ClientAddresId)
                .ValueGeneratedOnAdd()
                    .UseIdentityColumn()
                    .HasColumnName("ClientAddresID");

                entity.Property(e => e.AddresId).HasColumnName("AddresID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.HasOne(d => d.Addres)
                    .WithMany(p => p.ClientAddres)
                    .HasForeignKey(d => d.AddresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientAddres_Addres");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientAddres)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientAddres_Client");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredient");

                entity.Property(e => e.IngredientId)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn()
                    .HasColumnName("IngredientID");

                entity.Property(e => e.IngredientName)
                    .IsRequired()
                    .HasMaxLength(180);
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.ToTable("Pizza");

                entity.Property(e => e.PizzaId)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn()
                    .HasColumnName("PizzaID");

                entity.Property(e => e.PizzaName)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<PizzaAssortiment>(entity =>
            {
                entity.ToTable("PizzaAssortiment");

                entity.Property(e => e.PizzaAssortimentId)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn()
                    .HasColumnName("PizzaAssortimentID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.Property(e => e.PizzaSizeId).HasColumnName("PizzaSizeID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaAssortiments)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaAssortiment_Pizza");

                entity.HasOne(d => d.PizzaSize)
                    .WithMany(p => p.PizzaAssortiments)
                    .HasForeignKey(d => d.PizzaSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaAssortiment_Size");
            });

            modelBuilder.Entity<PizzaIngredient>(entity =>
            {
                entity.ToTable("PizzaIngredient");

                entity.Property(e => e.PizzaIngredientId)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn()
                    .HasColumnName("PizzaIngredientID");

                entity.Property(e => e.IngredientId).HasColumnName("IngredientID");

                entity.Property(e => e.PizzaId).HasColumnName("PizzaID");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.PizzaIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaIngredient_Ingredient");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaIngredients)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaIngredient_Pizza");
            });

            modelBuilder.Entity<PizzaOrder>(entity =>
            {
                entity.ToTable("PizzaOrder");

                entity.Property(e => e.PizzaOrderId)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn()
                    .HasColumnName("PizzaOrderID");

                entity.Property(e => e.ClientAddresId).HasColumnName("ClientAddresID");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.PizzaAssortimentId).HasColumnName("PizzaAssortimentID");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.HasOne(d => d.ClientAddres)
                    .WithMany(p => p.PizzaOrders)
                    .HasForeignKey(d => d.ClientAddresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaOrder_ClientAddres");

                entity.HasOne(d => d.PizzaAssortiment)
                    .WithMany(p => p.PizzaOrders)
                    .HasForeignKey(d => d.PizzaAssortimentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaOrder_PizzaAssortiment");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size");

                entity.Property(e => e.SizeId)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn()
                    .HasColumnName("SizeID");

                entity.Property(e => e.SizeName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
