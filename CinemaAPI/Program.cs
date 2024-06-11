var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BancoDeDados>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapClienteApi();
app.MapFilmeApi();
app.MapSalaApi();
app.MapIngressoAPI();


app.Run();
