using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Doctors.DataLoaders;
using API_Doctors.Extensions;
using API_Doctors.Filters;
using API_Doctors.Mutations;
using API_Doctors.Types;
using Database.Data;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API_Doctors
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=apidoctors.db"))
                .AddGraphQLServer()
                
                .AddQueryType(x => x.Name("Query"))
                .AddTypeExtension<DoctorQuery>()
                .AddTypeExtension<PrescriptionQuery>()
                .AddTypeExtension<MedicineQuery>()

                .AddMutationType(x => x.Name("Mutation"))
                .AddTypeExtension<DoctorMutation>()
                .AddTypeExtension<PrescriptionMutation>()
                .AddTypeExtension<MedicineMutation>()

                .AddDataLoader<DoctorByIdDataLoader>()
                .AddDataLoader<PrescriptionByIdDataLoader>()
                .AddDataLoader<MedicineByIdDataLoader>()

                .AddType<DoctorType>()
                .AddType<PrescriptionType>()
                .AddType<MedicineType>()
                
                .AddErrorFilter<DoctorNotFoundExceptionFilter>()
                .AddErrorFilter<PrescriptionNotFoundExceptionFilter>()
                .AddErrorFilter<MedicineNotFoundExceptionFilter>();
                


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseVoyager();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

        }
    }
}