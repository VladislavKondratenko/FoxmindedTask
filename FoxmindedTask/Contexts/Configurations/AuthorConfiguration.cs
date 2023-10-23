using FoxmindedTask.Contexts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoxmindedTask.Contexts.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
	public void Configure(EntityTypeBuilder<Author> builder)
	{
		builder.ToTable("authors", "library");
		
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Name).IsRequired();
	}
}