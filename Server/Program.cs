using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Server;
using AutoMapper;
using Server.Mappings;
namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(5000, listenOptions =>
                {
                    listenOptions.UseHttps();
                    listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                });
            });
            builder.Services.AddCors(o => o.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
            }));
            builder.Services.AddCors();
            builder.Services.AddCodeFirstGrpc();
            builder.Services.AddSingleton<NHibernateHelper>();
            builder.Services.AddScoped<IStudentRes, StudentRes>();
            builder.Services.AddScoped<Studentservice>();
            builder.Services.AddScoped<IQlsvService, StudentGrpcService>();
            builder.Services.AddScoped<IChartRes, ChartRes>();
            builder.Services.AddScoped<ChartDataService>();
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            builder.Services.AddScoped<IChartDataService, ChartGrpcService>();
            var app = builder.Build();
            //_ = Task.Run(() =>
            //{
            //    try
            //    {
            //        DatabaseTestHelper.BomDuLieuTest();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString());
            //    }
            //});

            // 3. BẬT gRPC-Web Middleware (ĐẶT TRƯỚC CORS)
            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

            // 4. Bật CORS Policy
            app.UseCors("AllowAll");

            // 5. Map gRPC Service và kích hoạt gRPC-Web + CORS
            app.MapGrpcService<StudentGrpcService>()
               .EnableGrpcWeb()
               .RequireCors("AllowAll");
            app.MapGrpcService<ChartGrpcService>()
               .EnableGrpcWeb()
               .RequireCors("AllowAll");
            await app.RunAsync();
        }
    }
}