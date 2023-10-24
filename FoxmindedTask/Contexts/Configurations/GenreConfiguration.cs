using FoxmindedTask.Contexts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoxmindedTask.Contexts.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
	public void Configure(EntityTypeBuilder<Genre> builder)
	{
		builder.ToTable("genres", "library");
		
		builder.HasKey(x => x.Id);
		
		builder.Property(e => e.Id).ValueGeneratedNever();
		builder.Property(x => x.Name).IsRequired();
	}
}