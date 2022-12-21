using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PasswordValidatorApi.Models;
using PasswordValidatorApi.Models.ChainManagement;
using PasswordValidatorApi.Models.Handler;
using PasswordValidatorApi.Models.HandlerChain;

namespace PasswordValidatorApi
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
            services.AddSingleton<ChainManager<string>>(new ChainManager<string>(true)
                        .AppendHandlerToChain(new IChainHandler<string>[] {
                                new CharacterLengthFilterValidationHandler(6, 15),
                                new ContainsAtLeastOneLowerCaseValidationHandler(),
                                new ContainsAtLeastOneDigitsValidationHandler(),
                                new LowerCaseAndDigitsOnlyValidationHandler(),
                                new NotContainAdjacentSameSequenceValidationHandler()
                            }
                        ));
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
