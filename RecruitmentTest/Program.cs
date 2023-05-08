using RecruitmentTest.RepositoryDirectory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var config = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();

builder.Services.AddSingleton<IFindOrder>(new FindOrderCSV(config.GetSection("ConnectionStrings:Connec1tionToCSV").Value));
//builder.Services.AddSingleton<IFindOrder>(new FindOrderMSSQL(config.GetSection("ConnectionStrings:ConnectionToMSSQL").Value));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
