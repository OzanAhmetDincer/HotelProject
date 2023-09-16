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
        ValidIssuer = "http://localhost",// Jwt'yi yay�nlayan� tan�mlad�k
        ValidAudience = "http://localhost",// Jwt'yi dinleyicisini tan�mlad�k, yani kar��layan�
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapi")),// jwt i�erisinde key yap�land�rmas� yapt�k
        ValidateIssuerSigningKey = true,// Yukar�da ki key bilgisine sahip birisi jwt i�erisinde i�lem yapabilir. Bunu tan�mlad�k
        ValidateLifetime = true,// Olu�turulan tokenin hayatta kalma s�resini aktif ettik.
        ClockSkew = TimeSpan.Zero// Token i�in olu�turdu�umuz s�re say�m�n� yapar ve tokeni siler
    };
});// G�venlik ile ilgili i�lemleri identity ile de yapar�z. Biz bu projede bu i�i jwt k�t�phanesi ile yapt�k.

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
