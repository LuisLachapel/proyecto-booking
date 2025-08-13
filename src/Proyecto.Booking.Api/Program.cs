using Proyecto.Booking.Application;
using Proyecto.Booking.Common;
using Proyecto.Booking.External;
using Proyecto.Booking.Persistence;
using Proyecto.Booking.Api;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddWebApi().AddCommon().AddApplication().AddExternal(builder.Configuration).AddPersistence(builder.Configuration);
builder.Services.AddControllers();
//builder.Services.AddTransient<IDataBaseService, DataBaseService>();

// Add services to the container.

var app = builder.Build();


// Configure the HTTP request pipeline.
app.MapControllers();
app.Run();

