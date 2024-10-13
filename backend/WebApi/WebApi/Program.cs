var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("http://localhost:4200") 
            .AllowAnyMethod() 
            .AllowAnyHeader() 
            .AllowCredentials()); 
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngularApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
