using DesafioFrequencia.Domain.Interfaces;
using DesafioFrequencia.Infra.Data.Context;
using DesafioFrequencia.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureSwagger();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DesafioFrequencia.API v1"));


using (var scope = app.Services.CreateScope())
{
    CreateDatabase(scope);

    SeedIdentity(scope);
}

app.UseHttpsRedirection();
app.UseStatusCodePages();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

static void SeedIdentity(IServiceScope scope)
{
    var seedUserRoleInitial = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();

    if (seedUserRoleInitial != null)
    {
        seedUserRoleInitial.SeedRoles();
        seedUserRoleInitial.SeedUsers();
    }
}

static void CreateDatabase(IServiceScope scope)
{
    var context = scope.ServiceProvider.GetRequiredService<DesafioFrequenciaContext>();
    context.Database.EnsureCreated();
}