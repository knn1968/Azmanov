using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Azmanov.Data;

namespace AzmanovRC1Update1.Migrations
{
    [DbContext(typeof(AzmanovContext))]
    partial class AzmanovContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Azmanov.Entities.Autobiography", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<DateTime>("ExpireDateTime");

                    b.Property<string>("ImageUrl");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.AutobiographyDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AutobiographyId");

                    b.Property<int>("LanguageId");

                    b.Property<string>("Text");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.ContactEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Email");

                    b.Property<string>("Message");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<DateTime>("EventDate");

                    b.Property<DateTime>("ExpireDateTime");

                    b.Property<int>("Order");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.EventDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<int?>("EventId");

                    b.Property<int>("LanguageId");

                    b.Property<string>("Title");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.EventPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventId");

                    b.Property<string>("ImageUrl");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.EventPictureDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventPictureId");

                    b.Property<int>("LanguageId");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.Gallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<DateTime>("ExpireDateTime");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("Order");

                    b.Property<string>("ThumbnailUrl");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.GalleryDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GalleryId");

                    b.Property<int>("LanguageId");

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("CultureCode");

                    b.Property<bool>("Default");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ExpireDateTime");

                    b.Property<string>("LongDisplay");

                    b.Property<string>("ShortDisplay");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.LanguageDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ExpireDateTime");

                    b.Property<int>("InLanguageId");

                    b.Property<int?>("LanguageId");

                    b.Property<string>("LongDisplay");

                    b.Property<int>("Order");

                    b.Property<string>("ShortDisplay");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.MediaEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<DateTime>("EventDate");

                    b.Property<DateTime>("EventDateTime");

                    b.Property<DateTime>("ExpireDateTime");

                    b.Property<int>("Order");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.MediaEventDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<string>("Intro");

                    b.Property<int>("LanguageId");

                    b.Property<int?>("MediaEventId");

                    b.Property<string>("Title");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ExpireDateTime");

                    b.Property<string>("LongDisplay");

                    b.Property<string>("ShortDisplay");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Attribute");

                    b.Property<string>("Controller");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ExpireDateTime");

                    b.Property<string>("LongDisplay");

                    b.Property<int?>("MenuId");

                    b.Property<int>("Order");

                    b.Property<int>("ParentMenuItemId");

                    b.Property<string>("ShortDisplay");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.MenuItemDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ExpireDateTime");

                    b.Property<int>("InLanguageId");

                    b.Property<string>("LongDisplay");

                    b.Property<int?>("MenuItemId");

                    b.Property<string>("ShortDisplay");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Azmanov.Entities.AutobiographyDetail", b =>
                {
                    b.HasOne("Azmanov.Entities.Autobiography")
                        .WithMany()
                        .HasForeignKey("AutobiographyId");
                });

            modelBuilder.Entity("Azmanov.Entities.EventDetail", b =>
                {
                    b.HasOne("Azmanov.Entities.Event")
                        .WithMany()
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("Azmanov.Entities.EventPicture", b =>
                {
                    b.HasOne("Azmanov.Entities.Event")
                        .WithMany()
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("Azmanov.Entities.EventPictureDetail", b =>
                {
                    b.HasOne("Azmanov.Entities.EventPicture")
                        .WithMany()
                        .HasForeignKey("EventPictureId");
                });

            modelBuilder.Entity("Azmanov.Entities.GalleryDetail", b =>
                {
                    b.HasOne("Azmanov.Entities.Gallery")
                        .WithMany()
                        .HasForeignKey("GalleryId");
                });

            modelBuilder.Entity("Azmanov.Entities.LanguageDetail", b =>
                {
                    b.HasOne("Azmanov.Entities.Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");
                });

            modelBuilder.Entity("Azmanov.Entities.MediaEventDetail", b =>
                {
                    b.HasOne("Azmanov.Entities.MediaEvent")
                        .WithMany()
                        .HasForeignKey("MediaEventId");
                });

            modelBuilder.Entity("Azmanov.Entities.MenuItem", b =>
                {
                    b.HasOne("Azmanov.Entities.Menu")
                        .WithMany()
                        .HasForeignKey("MenuId");
                });

            modelBuilder.Entity("Azmanov.Entities.MenuItemDetail", b =>
                {
                    b.HasOne("Azmanov.Entities.MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId");
                });
        }
    }
}
