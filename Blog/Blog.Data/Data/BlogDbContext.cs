using Blog.Data.Data.Configurations;
using Blog.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<PostCategory> PostCategories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder?.ApplyConfiguration(new CommentConfigurations());
            modelBuilder.ApplyConfiguration(new PostCategoryConfigurations());
        }

        public void UseSeedData()
        {
            if (!Posts.Any() && !Categories.Any())
            {
                // Seed posts 
                var posts = SeedData.GetPosts();
                var categories = SeedData.GetCategories();
                var postCategories = SeedData.GetPostCategories();
                Posts.AddRange(posts);
                Categories.AddRange(categories);
                PostCategories.AddRange(postCategories);
                SaveChanges();
            }

            if (!ApplicationUsers.Any())
            {
                // Add Admin user
                ApplicationUsers.Add(SeedData.GetAdminUser());
                SaveChanges();
            }
        }
    }
}
