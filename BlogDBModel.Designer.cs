// T4 code generation is enabled for model 'D:\DHproject\BTLBlog\BlogDBModel.edmx'. 
// To enable legacy code generation, change the value of the 'Code Generation Strategy' designer
// property to 'Legacy ObjectContext'. This property is available in the Properties Window when the model
// is open in the designer.

// If no context and entity classes have been generated, it may be because you created an empty model but
// have not yet chosen which version of Entity Framework to use. To generate a context class and entity
// classes for your model, open the model in the designer, right-click on the designer surface, and
// select 'Update Model from Database...', 'Generate Database from Model...', or 'Add Code Generation
// Item...'.

using BTLBlog;
using System.Data.Entity;

public partial class BlogDBEntities : DbContext
{
    public BlogDBEntities()
        : base("name=data_blogEntities")
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Blog> Blogs { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<Friend> Friends { get; set; }
    public virtual DbSet<Preference> Preferences { get; set; }
    public virtual DbSet<Danhmuc> Danhmucs { get; set; }
    public virtual DbSet<LoaiDanhmuc> LoaiDanhmucs { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Tùy chỉnh ánh xạ bảng nếu cần
    }
}