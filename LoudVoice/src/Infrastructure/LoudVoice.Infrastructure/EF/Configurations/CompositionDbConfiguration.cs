using LoudVoice.Domain.Compositions.ValueObjects;
using LoudVoice.Domain.Performers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoudVoice.Infrastructure.EF.Configurations
{
    public class CompositionDbConfiguration : IEntityTypeConfiguration<Composition>
    {
        public void Configure(EntityTypeBuilder<Composition> builder)
        {
            builder.HasKey(composition => composition.Id);

            var compositionUrlConverter = new ValueConverter<CompositionUrl, string>(url => url.Value,
                url => CompositionUrl.Create(url).Value);

            var nameConverter = new ValueConverter<CompositionName, string>(name => name.Value,
                name => CompositionName.Create(name).Value);

            var listensCountConverter = new ValueConverter<CompositionListensCount, uint>(listensCount => listensCount.Value,
                listensCount => CompositionListensCount.Create(listensCount).Value);

            builder.Property(composition => composition.Name)
                   .HasConversion(nameConverter);

            builder.Property(composition => composition.Url)
                   .HasConversion(compositionUrlConverter);

            builder.Property(composition => composition.ListensCount)
                   .HasColumnName("ListensCount")
                   .HasConversion(listensCountConverter);

            builder.HasOne(composition => composition.Performer)
                   .WithMany(performer => performer.Compositions);
        }
    }
}
