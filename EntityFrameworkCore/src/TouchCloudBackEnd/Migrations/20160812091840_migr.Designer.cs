using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TouchCloudBackEnd.Entities;

namespace TouchCloudBackEnd.Migrations
{
    [DbContext(typeof(TouchcloudDbContext))]
    [Migration("20160812091840_migr")]
    partial class migr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TouchCloudBackEnd.Entities.Administrations.Action", b =>
                {
                    b.Property<int?>("IdAction")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("NameAction");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("IdAction");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("TouchCloudBackEnd.Entities.Administrations.ActionGroup", b =>
                {
                    b.Property<int?>("IdAction");

                    b.Property<int?>("IdGroup");

                    b.HasKey("IdAction", "IdGroup");

                    b.HasIndex("IdAction");

                    b.HasIndex("IdGroup");

                    b.ToTable("ActionGroup");
                });

            modelBuilder.Entity("TouchCloudBackEnd.Entities.Administrations.Group", b =>
                {
                    b.Property<int?>("IdGroup")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("DescriptionGroup");

                    b.Property<string>("NameGroup");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("IdGroup");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("TouchCloudBackEnd.Entities.Administrations.RoleUser", b =>
                {
                    b.Property<int?>("IdRoleUser")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("NameRoleUser");

                    b.Property<int>("NumberRoleUser");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("IdRoleUser");

                    b.ToTable("RoleUsers");
                });

            modelBuilder.Entity("TouchCloudBackEnd.Entities.Administrations.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BirthdateUser");

                    b.Property<DateTime?>("CreatedAt");

                    b.Property<string>("EmailUser");

                    b.Property<string>("HiddenInfos");

                    b.Property<string>("PasswordUser")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("PseudoUser")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int?>("RoleUser_Id");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("IdUser");

                    b.HasIndex("RoleUser_Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TouchCloudBackEnd.Entities.Administrations.User_Group", b =>
                {
                    b.Property<int?>("IdUser");

                    b.Property<int?>("IdGroup");

                    b.HasKey("IdUser", "IdGroup");

                    b.HasIndex("IdGroup");

                    b.HasIndex("IdUser");

                    b.ToTable("User_Group");
                });

            modelBuilder.Entity("TouchCloudBackEnd.Entities.Administrations.ActionGroup", b =>
                {
                    b.HasOne("TouchCloudBackEnd.Entities.Administrations.Action", "Action")
                        .WithMany("ActionGroups")
                        .HasForeignKey("IdAction")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TouchCloudBackEnd.Entities.Administrations.Group", "Group")
                        .WithMany("ActionGroups")
                        .HasForeignKey("IdGroup")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TouchCloudBackEnd.Entities.Administrations.User", b =>
                {
                    b.HasOne("TouchCloudBackEnd.Entities.Administrations.RoleUser", "RoleUser")
                        .WithMany("Users")
                        .HasForeignKey("RoleUser_Id")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("TouchCloudBackEnd.Entities.Administrations.User_Group", b =>
                {
                    b.HasOne("TouchCloudBackEnd.Entities.Administrations.Group", "Group")
                        .WithMany("UserGroups")
                        .HasForeignKey("IdGroup")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TouchCloudBackEnd.Entities.Administrations.User", "User")
                        .WithMany("UserGroups")
                        .HasForeignKey("IdUser");
                });
        }
    }
}
