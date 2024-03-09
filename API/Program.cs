using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utiilites.IoC;
using Core.Utiilites.Security.JWT;
using Core.Utilities.Security.Encryption;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        // Add services to the container.


        builder.Services.AddControllers();


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors(opts =>
        {
            opts.AddDefaultPolicy(x =>
            {
                x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddSingleton<IUserService, UserManager>();
        builder.Services.AddSingleton<IUserDal, EfUserDal>();

        builder.Services.AddSingleton<IAuthService, AuthManager>();
        builder.Services.AddSingleton<ITokenHelper, JwtHelper>();

        builder.Services.AddSingleton<IProfileImageDal, EfProfileImageDal>();
        builder.Services.AddSingleton<IProfileImageService, ProfileImageManager>();

        builder.Services.AddSingleton<IMailService, MailManager>();

        builder.Services.AddSingleton<IMeetingDal, EfMeetingDal>();
        builder.Services.AddSingleton<IMeetingService, MeetingManager>();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });
        builder.Services.AddDependencyResolvers(new ICoreModule[] { new CoreModule() });
        var app = builder.Build();

        //builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
        //{
        //    builder.RegisterModule(new AutofacBusinessModule());
        //});

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseCors();

        app.UseAuthorization();
        app.UseAuthentication();
        app.MapControllers();

        app.Run();
    }

}