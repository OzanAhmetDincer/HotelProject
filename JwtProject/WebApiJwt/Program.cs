using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = "http://localhost",// Jwt'yi yayýnlayaný tanýmladýk
        ValidAudience = "http://localhost",// Jwt'yi dinleyicisini tanýmladýk, yani karþýlayaný
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapi")),// jwt içerisinde key yapýlandýrmasý yaptýk
        ValidateIssuerSigningKey = true,// Yukarýda ki key bilgisine sahip birisi jwt içerisinde iþlem yapabilir. Bunu tanýmladýk
        ValidateLifetime = true,// Oluþturulan tokenin hayatta kalma süresini aktif ettik.
        ClockSkew = TimeSpan.Zero// Token için oluþturduðumuz süre sayýmýný yapar ve tokeni siler
    };
});// Güvenlik ile ilgili iþlemleri identity ile de yaparýz. Biz bu projede bu iþi jwt kütüphanesi ile yaptýk.

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
