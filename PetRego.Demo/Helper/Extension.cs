using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRego.Demo.Helper
{
    public static class Extension
    {
        public static Info CreateInfoForApiVersion(this ApiVersionDescription description)
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
    }
}
