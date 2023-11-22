using LoudVoice.Domain.Compositions.Entity;
using LoudVoice.Domain.Compositions.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoudVoice.Infrastructure.EF.Configurations
{
    public class CompositionDbConfiguration : IEntityTypeConfiguration<Composition>
    {
        public void Configure(EntityTypeBuilder<Composition> builder)
        {
            builder.HasKey(composition => composition.Id);

            var compositionUrlConverter = new ValueConverter<CompositionUrl, string>(url => url.Value,
                url => CompositionUrl.Create(url).Value);

            var nameConverter = new ValueConverter<Name, string>(name => name.Value,
                name => Name.Create(name).Value);

            var listensCountConverter = new ValueConverter<ListensCount, uint>(listensCount => listensCount.Value,
                listensCount => ListensCount.Create(listensCount).Value);

            builder.Property(composition => composition.Name)
                   .HasConversion(nameConverter);

            builder.Property(composition => composition.Url)
                   .HasConversion(compositionUrlConverter);

            builder.Property(composition => composition.ListensCount)
                   .HasConversion(listensCountConverter);

            builder.HasOne(composition => composition.Performer)
                   .WithMany(performer => performer.Compositions);
        }
    }
}
