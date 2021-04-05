using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Olimpia
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                          IApplicationLifetime applicationLifetime)
        {
            applicationLifetime.ApplicationStarted.Register(() =>
            {
                if (System.IO.File.Exists("DatosPrograma.dat"))
                {
                    CargarDatos();
                }
                else
                {
                    DatosPrograma.HinchasEnum = new EvList<Hincha>();
                    DatosPrograma.VisitantesEnum = new EvList<Visitante>();
                    DatosPrograma.Capacidad = 80018;
                    DatosPrograma.Aforo = 30;
                    GuardarDatos();
                }
                DatosPrograma.HinchasEnum.OnChange += ListChanged;
                DatosPrograma.VisitantesEnum.OnChange += ListChanged;
                DatosPrograma.OnChange += ListChanged;
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        public static void ListChanged(object sender, System.EventArgs e) {
            GuardarDatos();
        }

    public static void GuardarDatos()
        {
            try
            {
                _DatosPrograma CDatosPrograma = new _DatosPrograma();
                CDatosPrograma.Capacidad = DatosPrograma.Capacidad ;
                CDatosPrograma.Aforo = DatosPrograma.Aforo;
                CDatosPrograma.HinchasEnum = DatosPrograma.HinchasEnum;
                CDatosPrograma.VisitantesEnum = DatosPrograma.VisitantesEnum;
                using (System.IO.StreamWriter file = System.IO.File.CreateText("DatosPrograma.dat"))
                {
                    new Newtonsoft.Json.JsonSerializer().Serialize(file, CDatosPrograma);
                }
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine("Error al Almacenar Datos. Motivo: " + e.Message);
                throw;
            }
        }

        private void CargarDatos()
        {
            try
            {
                using (System.IO.StreamReader file = System.IO.File.OpenText("DatosPrograma.dat"))
                {
                    _DatosPrograma CDatosPrograma = (_DatosPrograma)new Newtonsoft.Json.JsonSerializer().Deserialize(file, typeof(_DatosPrograma));
                    DatosPrograma.Capacidad = CDatosPrograma.Capacidad;
                    DatosPrograma.Aforo = CDatosPrograma.Aforo;
                    DatosPrograma.HinchasEnum = CDatosPrograma.HinchasEnum;
                    DatosPrograma.VisitantesEnum = CDatosPrograma.VisitantesEnum;
                }
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine("Error al Cargar Datos. Motivo: " + e.Message);
                throw;
            }
        }
    }
}