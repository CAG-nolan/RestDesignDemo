var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register repositories (add your concrete implementations)
builder.Services.AddSingleton<ApiDesignDemo.Repositories.IUserRepository, ApiDesignDemo.Repositories.InMemoryUserRepository>();
builder.Services.AddSingleton<ApiDesignDemo.Repositories.IPostRepository, ApiDesignDemo.Repositories.InMemoryPostRepository>();
builder.Services.AddSingleton<ApiDesignDemo.Repositories.ILikeRepository, ApiDesignDemo.Repositories.InMemoryLikeRepository>();
builder.Services.AddSingleton<ApiDesignDemo.Repositories.IFriendshipRepository, ApiDesignDemo.Repositories.InMemoryFriendshipRepository>();

// Register services
builder.Services.AddScoped<ApiDesignDemo.Services.UserService>();
builder.Services.AddScoped<ApiDesignDemo.Services.PostService>();
builder.Services.AddScoped<ApiDesignDemo.Services.LikeService>();
builder.Services.AddScoped<ApiDesignDemo.Services.FriendshipService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}