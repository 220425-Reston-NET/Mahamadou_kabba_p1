using storeDL;
using storeBL;
using storeModel;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Initializing my logger
    Log.Logger = new LoggerConfiguration() //LoggerConfiguration used to configure your logger and create it
    .WriteTo.File("./logs/user.txt") //Configuring the logger to save information to a file called user.txt inside of logs folder
    .CreateLogger(); //A method to create the logger

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  let api frame work handel the job
//  let the from work now what class we making object out of
//  now these two lines will do all our object creatioons for us
//  chgnae configuration to point to aws from appsetting
builder.Services.AddScoped<IRepository<CustomerClass>, SQLStoreRepository>(repo => new SQLStoreRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IstoreBL, MyStoreBL>();

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
