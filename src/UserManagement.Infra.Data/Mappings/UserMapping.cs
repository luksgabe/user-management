using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.Entities;

namespace UserManagement.Infra.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("Id").IsRequired().ValueGeneratedOnAdd();

            builder.Property(u => u.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Cpf)
                .HasColumnType("varchar(20)")
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Genre)
                .HasColumnType("int");

            builder.Property(c => c.BirthDate)
                .HasColumnType("datetime2(7)");

            builder.Property(c => c.InclusionDate)
                .HasColumnType("datetime2(7)");

            builder.HasIndex(u => u.Email);

            builder.Property(u => u.Active).HasColumnType("smallint");
        }
    }
}
