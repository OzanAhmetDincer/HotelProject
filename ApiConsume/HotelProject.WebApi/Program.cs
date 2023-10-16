using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IStaffDal, EfStaffDal>();// Hafýzada bir kez nesne örneði oluþtur ve bunu kullan. "IStaffDal" gördüðün zaman "EfStaffDal" kullan demiþ olduk.
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

builder.Services.AddScoped<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IGuestDal, EfGuestDal>();
builder.Services.AddScoped<IGuestService, GuestManager>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(opt =>
{
    // "AddPolicy" ile belirli þeylere izin tanýmlamasý yapýcaz. "OtelApiCors" ismini veririz
    opt.AddPolicy("OtelApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();// "AllowAnyOrigin" her hangi bir kaynaða, "AllowAnyHeader" her hangi bir baþlýða, "AllowAnyMethod" her hangi bir metoda izin vermiþ olduk

    });
});// API iþlemlerinde bir API'ýn baþka kaynaklar tarafýndan consume edilmesini saðlayan metot.

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

app.UseCors("OtelApiCors");// Yukarýda tanýmladýðýmýz Policy'i burada kullanacaðýmýzý bildirmiþ olduk. Tanýmlama bu þekilde yapýlýyor.
app.UseAuthorization();

app.MapControllers();

app.Run();
