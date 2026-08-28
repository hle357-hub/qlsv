using Client;
using QuanLySinhVien.Shared;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProtoBuf.Grpc.ClientFactory;
using AntDesign;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Đăng ký gRPC Client
builder.Services.AddCodeFirstGrpcClient<IQlsvService>((provider, options) =>
{
    options.Address = new Uri("https://localhost:5000");
})
.ConfigurePrimaryHttpMessageHandler(() => new GrpcWebHandler(new HttpClientHandler()));
builder.Services.AddCodeFirstGrpcClient<IChartDataService>((provider, options) =>
{
    options.Address = new Uri("https://localhost:5000");
})
.ConfigurePrimaryHttpMessageHandler(() =>
    new GrpcWebHandler(new HttpClientHandler()));
builder.Services.AddAntDesign();
await builder.Build().RunAsync();