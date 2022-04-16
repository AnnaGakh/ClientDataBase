using DataBaseWeb.Consumer;
using DataBaseWeb.Consumer.Read;
using DataBaseWeb.Mappers;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddTransient<IMapper<DbSchool, CreateSchoolRequest>, SchoolMapper>();
            services.AddScoped<IMapper<DbBook,CreateBookRequest>, BookMapper>();
            services.AddTransient<IMapper<DbStudent, CreateStudentRequest>, StudentMapper>();

            services.AddMemoryCache();
            services.AddMassTransit(mt =>
            {
                mt.AddConsumer<CreateStudentConsumer>();
                mt.AddConsumer<CreateSchoolConsumer>();
                mt.AddConsumer<CreateBookConsumer>();
                mt.AddConsumer<ReadBookConsumer>();
                mt.UsingRabbitMq((context, config) =>
                {
                    config.Host("localhost", "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    config.ReceiveEndpoint("createstudent", x =>
                    {
                        x.ConfigureConsumer<CreateStudentConsumer>(context);
                    });

                    config.ReceiveEndpoint("createschool", x =>
                    {
                        x.ConfigureConsumer<CreateSchoolConsumer>(context);
                    });

                    config.ReceiveEndpoint("createbook", x =>
                    {
                        x.ConfigureConsumer<CreateBookConsumer>(context);
                    });

                    config.ReceiveEndpoint("readbook", x =>
                    {
                        x.ConfigureConsumer<ReadBookConsumer>(context);
                    });
                });
            });
            services.AddMassTransitHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
