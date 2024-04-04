using MongodbWebApi.Mapper;
using MongodbWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database Configuration
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("ApplicationDatabase"));
#endregion

#region Todo Services Configuration
builder.Services.AddSingleton<TodoService>();
#endregion

#region Mapper Configuration
builder.Services.AddAutoMapper(typeof(TodoMapperProfile));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
