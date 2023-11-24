using JHobby.Repository.Implements;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Mapping;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Implements;
using JHobby.Service.Interfaces;
using JHobby.Website.Controllers.Api;
using Microsoft.EntityFrameworkCore;

namespace JHobby.Website
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // JHobby Coneection String
            builder.Services.AddDbContext<JhobbyContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("JHobby"));
            });

            // Swagger DI
            builder.Services.AddEndpointsApiExplorer();     
            builder.Services.AddSwaggerGen();

            // AutoMapper DI
            builder.Services.AddAutoMapper(option =>
            {
                option.AddProfile<RepositoryProfile>();
            });

            // Interface DI
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IIndexRepository, IndexRepository>();
            builder.Services.AddScoped<IIndexService, IndexService>();
            builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IIndexRepository,IndexRepository>();
            builder.Services.AddScoped<IIndexService,IndexService>();
            builder.Services.AddScoped<IMemberRepository, MemberRepository>();
            builder.Services.AddScoped<IMemberService, MemberService>();
			builder.Services.AddScoped<IActivityRepository, ActivityRepository>();          
			builder.Services.AddScoped<IActivityService, ActivityService>();
            builder.Services.AddScoped<IProfileSettingRepository, ProfileSettingRepository>();
            builder.Services.AddScoped<IProfileSettingService, ProfileSettingService>();
            builder.Services.AddScoped<IWishRepository, WishRepository>();
            builder.Services.AddScoped<IWishService,WishSerive>();
            builder.Services.AddScoped<IMiddleCenterRepository,MiddleCenterRepository>();
            builder.Services.AddScoped<IMiddleCenterService,MiddleCenterService>();
            builder.Services.AddScoped<IPastJoinAGroupRepostiory, PastJoinAGroupRepostiory>();
            builder.Services.AddScoped<IPastJoinAGroupService, PastJoinAGroupService>();
            builder.Services.AddScoped<ICommonService, CommonService>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IReviewService, ReviewService>();


            var app = builder.Build();

            // Swagger Use
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}