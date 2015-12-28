using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Azmanov.Entities;
using Azmanov.Services.Interfaces;
using Azmanov.Services;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Azmanov.Data;
using Azmanov.ViewModels;
using Core.Paging;
using Azmanov.Dtos.Paging;
using Core;
using Core.Factories.Interfaces;
using Azmanov.ViewModels.Paging;
using Azmanov.Data.Interfaces;
using Newtonsoft.Json.Serialization;
using Azmanov.Data.Repositories;
using Core.Repositories;
using Azmanov.Factories.Interfaces;
using Azmanov.Factories;
using Azmanov.ViewModels.Interfaces.ViewModels;
using Azmanov.ViewModels.Models;
using Microsoft.Extensions.Logging;
using AutoMapper;
using AzmanovRC1Update1.ViewModels;

namespace AzmanovRC1Update1
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;
        private IHostingEnvironment _hostingEnvironment;

        public Startup(IApplicationEnvironment appEnv, IHostingEnvironment hostingEnvironment)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(appEnv.ApplicationBasePath)
              .AddJsonFile("config.json")
              .AddEnvironmentVariables();

            Configuration = builder.Build();

            _hostingEnvironment = hostingEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                }
                );

            //services.AddSession();
            services.AddCaching();
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<AzmanovContext>();

            services.AddScoped<IAzmanovDbSeedData, AzmanovDbSeedData>();

            services.AddLogging();

            // ViewModels
            services.AddScoped<IHomeViewModel, HomeViewModel>();
            services.AddScoped<IAutobiographyViewModel, AutobiographyViewModel>();
            services.AddScoped<IEventsViewModel, EventsViewModel>();
            services.AddScoped<IMediaViewModel, MediaViewModel>();
            services.AddScoped<IGalleryViewModel, GalleryViewModel>();
            services.AddScoped<IGalleryDetailViewModel, GalleryDetailViewModel>();
            services.AddScoped<IContactViewModel, ContactViewModel>();

            // Factories
            services.AddScoped<IModelFactory<Gallery, GalleryDisplayViewModel>, GalleryDisplayViewModelFactory>();
            services.AddScoped<IModelFactory<Gallery, GalleryUpdateViewModel>, GalleryUpdateViewModelFactory>();

            services.AddScoped<IModelFactory<Event, EventDisplayViewModel>, EventDisplayViewModelFactory>();

            services.AddScoped<IModelFactory<MediaEvent, MediaDisplayViewModel>, MediaDisplayViewModelFactory>();

            services.AddScoped<ILanguageViewModelFactory, LanguageViewModelFactory>();
            services.AddScoped<IMenuViewModelFactory, MenuViewModelFactory>();

            services.AddScoped<IAutobiographyDisplayViewModelFactory, AutobiographyDisplayViewModelFactory>();

            // Repositories
            services.AddScoped<IPagingRepository<Gallery>, GalleryRepository>();
            services.AddScoped<IRepository<Gallery>, GalleryRepository>();
            services.AddScoped<IGalleryRepository, GalleryRepository>();

            services.AddScoped<IPagingRepository<Event>, EventsRepository>();
            services.AddScoped<IRepository<Event>, EventsRepository>();
            services.AddScoped<IEventRepository, EventsRepository>();

            services.AddScoped<IPagingRepository<MediaEvent>, MediaRepository>();
            services.AddScoped<IRepository<MediaEvent>, MediaRepository>();

            services.AddScoped<IRepository<ContactEntry>, ContactRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();

            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IAutobiographyRepository, AutobiographyRepository>();

            IServiceProvider provider = services.BuildServiceProvider();

            // Pagers
            services.AddScoped<IPager<Gallery, GalleryDisplayViewModel>, Pager<Gallery, GalleryDisplayViewModel>>(p =>
            {
                return new Pager<Gallery, GalleryDisplayViewModel>(
                    provider.GetService<IPagingRepository<Gallery>>(),
                    provider.GetService<IModelFactory<Gallery, GalleryDisplayViewModel>>(),
                    itemsPerPage: Convert.ToInt32(Startup.Configuration["GallerySettings:ItemsPerPage"]),
                    pagesPerPageGroup: Convert.ToInt32(Startup.Configuration["GallerySettings:PagesPerPageGroup"]));
            });

            services.AddScoped<IPager<Event, EventDisplayViewModel>, Pager<Event, EventDisplayViewModel>>(p =>
            {
                return new Pager<Event, EventDisplayViewModel>(
                    provider.GetService<IPagingRepository<Event>>(),
                    provider.GetService<IModelFactory<Event, EventDisplayViewModel>>(),
                    itemsPerPage: 2,
                    pagesPerPageGroup: 2);
            });

            services.AddScoped<IPager<MediaEvent, MediaDisplayViewModel>, Pager<MediaEvent, MediaDisplayViewModel>>(p =>
            {
                return new Pager<MediaEvent, MediaDisplayViewModel>(
                    provider.GetService<IPagingRepository<MediaEvent>>(),
                    provider.GetService<IModelFactory<MediaEvent, MediaDisplayViewModel>>(),
                    itemsPerPage: 2,
                    pagesPerPageGroup: 2);
            });

            if (_hostingEnvironment.IsDevelopment())
            {
                services.AddScoped<IMailService, MailService>();
            }
            else
            {
                services.AddScoped<IMailService, MailService>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IAzmanovDbSeedData seeder,
            ILanguageRepository languageRepository,
            ILoggerFactory loggerFactory,
            AzmanovContext context)
        {
            //app.UseIISPlatformHandler();
            //app.UseDefaultFiles();
            loggerFactory.AddDebug(LogLevel.Information);

            Mapper.Initialize(config =>
            {
                config.CreateMap<Gallery, GalleryUpdateViewModel>().ReverseMap();
                config.CreateMap<GalleryDetail, GalleryUpdateViewModelDetail>()
                    .ForMember(p => p.LanguageShortDisplay, opt => opt.MapFrom(src => context.Languages.First(l => l.Id == src.LanguageId).ShortDisplay));
                config.CreateMap<GalleryUpdateViewModelDetail, GalleryDetail>()
                    .ForMember(p => p.LanguageId, opt => opt.MapFrom(src => context.Languages.First(l => l.ShortDisplay == src.LanguageShortDisplay).Id));

                config.CreateMap<Event, EventUpdateViewModel>();
                config.CreateMap<EventUpdateViewModel, Event>().ForMember(p => p.Id, opt => opt.Ignore());

                config.CreateMap<EventPicture, EventUpdateViewModelPicture>();
                config.CreateMap<EventUpdateViewModelPicture, EventPicture>()
                    .ForMember(p => p.Id, opt => opt.Ignore());
                    //.ForMember(p => p.EventPictureDetail, opt => opt.ResolveUsing<EventUpdateViewModelPictureToEventPictureResolver>());

                config.CreateMap<EventPictureDetail, EventUpdateViewModelPictureDetail>()
                    .ForMember(p => p.LanguageShortDisplay, opt => opt.MapFrom(src => context.Languages.First(l => l.Id == src.LanguageId).ShortDisplay));
                config.CreateMap<EventUpdateViewModelPictureDetail, EventPictureDetail>()
                    .ForMember(p => p.LanguageId, opt => opt.MapFrom(src => context.Languages.First(l => l.ShortDisplay == src.LanguageShortDisplay).Id))
                    .ForMember(p => p.Id, opt => opt.Ignore());

                config.CreateMap<EventDetail, EventUpdateViewModelDetail>()
                    .ForMember(p => p.LanguageShortDisplay, opt => opt.MapFrom(src => context.Languages.First(l => l.Id == src.LanguageId).ShortDisplay));
                config.CreateMap<EventUpdateViewModelDetail, EventDetail>()
                    .ForMember(p => p.LanguageId, opt => opt.MapFrom(src => context.Languages.First(l => l.ShortDisplay == src.LanguageShortDisplay).Id))
                    .ForMember(p => p.Id, opt => opt.Ignore());

                config.CreateMap<ContactFormViewModel, ContactEntry>();
            });

            app.UseStaticFiles();

            //seeder.EnsureSeedData();

            var defaultLanguage = languageRepository.GetDefaultLanguage();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{language}/{controller}/{action}/{id?}",
                    defaults: new { language = defaultLanguage?.ShortDisplay, controller = "Home", action = "Index" });
            }
            );
            //todo name images consistently - create ruleset
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
