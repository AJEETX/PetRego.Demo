using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using PetRego.Demo.Domain;
using Swashbuckle.AspNetCore.Examples;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.Extension
{
    public static class PetRegoExtensions
    {
        static Info CreateInfoForApiVersion(this ApiVersionDescription description)
        {
            var info = new Info()
            {
                Title = $"PetRego Service {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = "REST API with Swagger, Swashbuckle, and API versioning.",
                Contact = new Contact
                {
                    Name = "Azy",
                    Email = "ajeetx@email.com",
                    Url = "github.com/ajeetx"
                }
            };
            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }
            return info;
        }
        public static IServiceCollection AddPetRegoService(this IServiceCollection services)
        {
            services.AddScoped<IPetRegoService, PetRegoService>();
            services.AddScoped<ILinkService, LinkService>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUrlHelper>(factory => new UrlHelper(factory.GetService<IActionContextAccessor>().ActionContext));
            services.AddMvcCore().AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            services.AddMvcCore().AddVersionedApiExplorer(options => options.SubstituteApiVersionInUrl = true);
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.OperationFilter<ExamplesOperationFilter>();
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                    options.SwaggerDoc(description.GroupName, description.CreateInfoForApiVersion());
            });

            return services;

        }

        public static IApplicationBuilder UsePetRegoService(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseMvc().UseSwagger().UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", "Version " + description.GroupName.ToUpperInvariant());
                }
            });
            return app;
        }
    }
}
