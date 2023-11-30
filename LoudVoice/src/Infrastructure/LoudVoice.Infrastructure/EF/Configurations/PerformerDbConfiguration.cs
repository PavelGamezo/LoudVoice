using LoudVoice.Domain.Performers;
using LoudVoice.Domain.Performers.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoudVoice.Infrastructure.EF.Configurations
{
    public class PerformerDbConfiguration : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> builder)
        {
            builder.HasKey(performer => performer.Id);

            var descriptionConverter = new ValueConverter<Description,  string>(description => description.Value, 
                description => Description.Create(description).Value);

            var nicknameConverter = new ValueConverter<Nickname, string>(nickname => nickname.Value,
                nickname => Nickname.Create(nickname).Value);

            builder.Property(performer => performer.Nickname)
                   .HasConversion(nicknameConverter);

            builder.Property(performer => performer.Description)
                   .HasConversion(descriptionConverter);
        }
    }
}
