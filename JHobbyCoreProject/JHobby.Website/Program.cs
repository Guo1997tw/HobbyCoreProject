using JHobby.Repository.Implements;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Mapping;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Implements;
using JHobby.Service.Interfaces;
using JHobby.Website.Controllers.Api;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;
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

            //CORS
            var allowCors = "allowCors";
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy(allowCors, policy =>
                {
                    policy.WithOrigins("*").WithHeaders("*").WithMethods("*");
                });
            });

            // Swagger DI
            builder.Services.AddEndpointsApiExplorer();     
            builder.Services.AddSwaggerGen();

            // AutoMapper DI
            //builder.Services.AddAutoMapper(option =>
            //{
            //    option.AddProfile<RepositoryProfile>();
            //});

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Interface DI
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            // Interface DI
            builder.Services.AddScoped<IGroupStartingRepository, GroupStartingRepository>();
			builder.Services.AddScoped<IGroupStartingService, GroupStartingService>();
			builder.Services.AddScoped<ILaunchaTeamRepository, LaunchaTeamRepository>();
			builder.Services.AddScoped<ILaunchaTeamService, LaunchaTeamService>();
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
            builder.Services.AddScoped<IUpdateProfileSettingRepository, UpdateProfileSettingRepository>();
            builder.Services.AddScoped<IUpdateProfileSettingService, UpdateProfileSettingService>();
            builder.Services.AddScoped<INowJoinAGroupRepository, NowJoinAGroupRepository>();
            builder.Services.AddScoped<INowJoinAGroupService, NowJoinAGroupService>();
            builder.Services.AddScoped<IWishListRepository, WishListRepository>();
            builder.Services.AddScoped<IWishListService, WishListService>();
            builder.Services.AddScoped<ISendMailService, SendMailService>();
            builder.Services.AddScoped<IGroupStartingRepository, GroupStartingRepository>();
            builder.Services.AddScoped<IGroupStartingService, GroupStartingService>();
 

            // DI Authentication
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
            {
                option.LoginPath = "/Member/Login";
                option.AccessDeniedPath = "/Home/NotFounds";
            });

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

            // CORS
            app.UseCors("allowCors");

            // Use Authentication
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}