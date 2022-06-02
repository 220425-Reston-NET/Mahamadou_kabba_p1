using storeDL;
using storeBL;
using storeModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  let api frame work handel the job
//  let the from work now what class we making object out of
//  now these two lines will do all our object creatioons for us
builder.Services.AddScoped<IRepository<CustomerClass>, SQLStoreRepository>(repo => new SQLStoreRepository(builder.Configuration.GetConnectionString("KM_DB")));
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
