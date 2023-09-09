using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IStaffDal, EfStaffDal>();// Haf�zada bir kez nesne �rne�i olu�tur ve bunu kullan. "IStaffDal" g�rd���n zaman "EfStaffDal" kullan demi� olduk.
builder.Services.AddScoped<IStaffService, StaffManager>();

builder.Services.AddScoped<IServicesDal, EfServiceDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>();

builder.Services.AddScoped<IRoomDal, EfRoomDal>();
builder.Services.AddScoped<IRoomService, RoomManager>();

builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();

builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(opt =>
{
    // "AddPolicy" ile belirli �eylere izin tan�mlamas� yap�caz. "OtelApiCors" ismini veririz
    opt.AddPolicy("OtelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();// "AllowAnyOrigin" her hangi bir kayna�a, "AllowAnyHeader" her hangi bir ba�l��a, "AllowAnyMethod" her hangi bir metoda izin vermi� olduk

    });
});// API i�lemlerinde bir API'�n ba�ka kaynaklar taraf�ndan consume edilmesini sa�layan metot.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("OtelApiCors");// Yukar�da tan�mlad���m�z Policy'i burada kullanaca��m�z� bildirmi� olduk. Tan�mlama bu �ekilde yap�l�yor.
app.UseAuthorization();

app.MapControllers();

app.Run();
