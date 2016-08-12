using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TouchCloudBackEnd.Entities.Administrations;

namespace TouchCloudBackEnd.Entities
{
    public class TouchcloudDbContext : DbContext
    {
        public TouchcloudDbContext(DbContextOptions<TouchcloudDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }

        //methode fluent API 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //When a Role is deleted, the UserRole is set to NULL
            //user and role
            modelBuilder.Entity<User>()
                .HasOne(key => key.RoleUser)
                .WithMany(foreign => foreign.Users)
                .HasForeignKey(foreignKey => foreignKey.RoleUser_Id)
                .OnDelete(DeleteBehavior.SetNull);


            //relation many-to-many 
            // User, Group and UserGroup
            modelBuilder.Entity<User_Group>().HasKey(primary => new { primary.IdUser, primary.IdGroup });

            modelBuilder.Entity<User_Group>()
                .HasOne(e_g => e_g.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(e_g => e_g.IdUser)
                .OnDelete(DeleteBehavior.Restrict);  

            modelBuilder.Entity<User_Group>()
                .HasOne(e_g => e_g.Group)
                .WithMany(g=> g.UserGroups)
                .HasForeignKey(e_g=> e_g.IdGroup)
                .OnDelete(DeleteBehavior.Cascade);    //for one-to-many relationships, onDeleteCascade is set by default




           // action, group and actionGroup
            modelBuilder.Entity<ActionGroup>().HasKey(primary => new { primary.IdAction, primary.IdGroup });

            modelBuilder.Entity<ActionGroup>()
                .HasOne(key => key.Action)
                .WithMany(foreign => foreign.ActionGroups)
                .HasForeignKey(foreignKey => foreignKey.IdAction);

            modelBuilder.Entity<ActionGroup>()
                .HasOne(key => key.Group)
                .WithMany(foreign => foreign.ActionGroups)
                .HasForeignKey(foreignKey => foreignKey.IdGroup);
        }
    }



}
