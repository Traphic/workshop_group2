using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Blog.Data.Models;

namespace Blog.Data.Data.Configurations
{
    public class PostCategoryConfigurations : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder?.HasKey(am => new { am.PostId, am.CategoryId });

            builder.HasOne(am => am.Post)
                .WithMany(a => a.PostCategories)
                .HasForeignKey(am => am.PostId);

            builder.HasOne(am => am.Category)
                .WithMany(m => m.PostCategories)
                .HasForeignKey(am => am.CategoryId);
        }
    }
}
