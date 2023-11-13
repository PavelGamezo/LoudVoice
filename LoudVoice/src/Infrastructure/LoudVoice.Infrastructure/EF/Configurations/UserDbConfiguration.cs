using LoudVoice.Domain.Users.Entity;
using LoudVoice.Domain.Users.ValueObjects;
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
    public class UserDbConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(users => users.Id);

            var loginConverter = new ValueConverter<Login, string>(login => login.Value, 
                login => Login.Create(login).Value);

            var emailConverter = new ValueConverter<Email, string>(email => email.Value,
                email => Email.Create(email).Value);

            var passwordConverter = new ValueConverter<Password, string>(password => password.Value,
                password => Password.Create(password).Value);

            builder.Property(user => user.Login)
                   .HasConversion(loginConverter);

            builder.Property(user => user.Email)
                   .HasConversion(emailConverter);

            builder.Property(user => user.Password)
                   .HasConversion(passwordConverter);
        }
    }
}
