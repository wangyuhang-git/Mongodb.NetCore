using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Mongodb.NetCore.Business;
using Mongodb.NetCore.Business.DustHistoricalData;
using Mongodb.NetCore.Interface;
using Mongodb.NetCore.Interface.DustHistoricalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mongodb.NetCore.WebApi
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
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mongodb.NetCore.WebApi", Version = "v1" });
            });

            ////ע��session
            //services.AddSession();

            //ע��autoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //ʹ��autofacע�᷺�ͷ���˲ʱ��

            //�����λ������Ϣ
            builder.RegisterGeneric(typeof(ManagePostAttBusiness<>)).As(typeof(IManagePostAtt<>)).InstancePerDependency();//Ĭ��ʹ��˲ʱ����

            //�ﳾ��ʷ������Ϣ
            builder.RegisterGeneric(typeof(DustHistoricalDataBusiness<>)).As(typeof(IDustHistoricalData<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mongodb.NetCore.WebApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            ////����session
            //app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
