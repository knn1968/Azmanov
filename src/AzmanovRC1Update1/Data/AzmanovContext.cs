using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Azmanov.Entities;
using AzmanovRC1Update1;
using Microsoft.AspNet.Hosting;

namespace Azmanov.Data
{
    public class AzmanovContext : DbContext
    {
        private IHostingEnvironment _hostingEnvironment;

        public AzmanovContext(IHostingEnvironment hostingEnvironment)
        {
            //Database.EnsureCreated();
            Database.Migrate();

            _hostingEnvironment = hostingEnvironment;
        }
        public DbSet<Autobiography> Autobiographies { get; set; }
        public DbSet<AutobiographyDetail> AutobiographyDetails { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventDetail> EventDetails { get; set; }
        public DbSet<EventPicture> EventPictures { get; set; }
        public DbSet<EventPictureDetail> EventPictureDetails { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<GalleryDetail> GalleryDetails { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageDetail> LanguageDetails { get; set; }
        public DbSet<MediaEvent> MediaEvents { get; set; }
        public DbSet<MediaEventDetail> MediaEventDetails { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemDetail> MenuItemDetails { get; set; }
        public DbSet<ContactEntry> ContactEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString;

            //if (_hostingEnvironment.IsDevelopment())
                connString = Startup.Configuration["Data:AzmanovDevContextConnection"];
            //else
                //connString = Startup.Configuration["Data:AzmanovContextConnection"];

            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
