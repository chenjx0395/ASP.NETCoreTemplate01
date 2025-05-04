using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.model.config
{
    public class UserInfoConfig : IEntityTypeConfiguration<UserInfo>

    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable("UserInfos");
            builder.Property(a => a.Username).HasMaxLength(20).IsRequired();
            builder.Property(a => a.PasswordHash).HasMaxLength(20).IsRequired();
            builder.Property(a => a.UserEmail).HasMaxLength(100).IsRequired();
            builder.Property(a => a.UserPhone).HasMaxLength(16);
            builder.Property(a => a.Age);
            builder.Property(a => a.Gender).HasDefaultValue(0);
            builder.Property(a => a.AvatarUrl).HasMaxLength(100).HasDefaultValue("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR615GBUSZb8GeFZXD70nTOYodrPGHwmu19IA&s");
        }
    }
}
