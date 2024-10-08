using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RealEstateManagement.DAO.Configurations;
using RealEstateManagement.Domain.AgentModule;
using RealEstateManagement.Domain.ClientModule;
using RealEstateManagement.Web;

namespace RealEstateManagement.DAO.Repositories.EF;
// Having access privileges here would be good
public partial class RealEstateDbContext : DbContext
{
    private string ConnectionString { get; set; }
    public RealEstateDbContext(IOptions<ConnectionStrings> options)
    {
        ConnectionStrings connections = options.Value;
        ConnectionString = connections.Master;
    }

    public RealEstateDbContext(IOptions<ConnectionStrings> optionsObject, DbContextOptions<RealEstateDbContext> options)
     : base(options)
    {
        ConnectionStrings connections = optionsObject.Value;
        ConnectionString = connections.Master;
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ContactMessage> ContactMessages { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.AgentId).HasName("PK__Agents__9AC3BFF199A0DCC1");

            entity.HasIndex(e => e.Cpf, "UQ__Agents__C1F89731D3425FCB").IsUnique();

            entity.HasIndex(e => e.Creci, "UQ__Agents__C46674091B88D165").IsUnique();

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .HasColumnName("CPF");
            entity.Property(e => e.Creci)
                .HasMaxLength(20)
                .HasColumnName("CRECI");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__E67E1A244A636809");

            entity.HasIndex(e => e.Cpf, "UQ__Clients__C1F89731C06855D6").IsUnique();

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .HasColumnName("CPF");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<ContactMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__ContactM__C87C0C9C22F1EFD6");

            entity.Property(e => e.DateSent)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Agent).WithMany(p => p.ContactMessages)
                .HasForeignKey(d => d.AgentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContactMe__Agent__4CA06362");

            entity.HasOne(d => d.Client).WithMany(p => p.ContactMessages)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContactMe__Clien__4BAC3F29");

            entity.HasOne(d => d.Property).WithMany(p => p.ContactMessages)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContactMe__Prope__4AB81AF0");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.FavoriteId).HasName("PK__Favorite__CE74FAD588E42CEB");

            entity.HasOne(d => d.Client).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorites__Clien__45F365D3");

            entity.HasOne(d => d.Property).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favorites__Prope__46E78A0C");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("PK__Properti__70C9A7354FF4220C");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Area).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Available).HasDefaultValue(true);
            entity.Property(e => e.TransactionType).HasDefaultValue(1);
            entity.Property(e => e.Type).HasDefaultValue(1);
            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.AgentManager).WithMany(p => p.PropertyAgentManagers)
                .HasForeignKey(d => d.AgentManagerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Propertie__Agent__412EB0B6");

            entity.HasOne(d => d.AgentTransaction).WithMany(p => p.PropertyAgentTransactions)
                .HasForeignKey(d => d.AgentTransactionId)
                .HasConstraintName("FK__Propertie__Agent__4222D4EF");

            entity.HasOne(d => d.OwnerClient).WithMany(p => p.Properties)
                .HasForeignKey(d => d.OwnerClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Propertie__Owner__4316F928");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public void Seed()
    {
        Database.EnsureCreated();
    }
}
