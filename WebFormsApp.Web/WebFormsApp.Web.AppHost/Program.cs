using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<WebFormsApp_Web_ApiService>("apiservice");

builder.AddProject<WebFormsApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();