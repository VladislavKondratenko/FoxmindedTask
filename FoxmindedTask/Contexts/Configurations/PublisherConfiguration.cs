using FoxmindedTask.Contexts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoxmindedTask.Contexts.Configurations;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
	public void Configure(EntityTypeBuilder<Publisher> builder)
	{
		builder.ToTable("publishers", "library");
		
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Name).IsRequired();
	}
}