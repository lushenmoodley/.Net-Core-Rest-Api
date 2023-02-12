using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*Preparing the application for 3rd party usage*/
/*Cross Resource sharing-enable our api to be accessed by clients not the same server*/
/*Without cors policy to faciliate only computers(Clients apps) are on the same computer as the api can access it */
/*Control this security from a firewall or other security tools on the network level. You don't have to necessarily do it at application level.You can 
                                   *configure the policy to allow certain apis,it can be a request that came from a certain source 
                                   *which can be rejected at api level
                                   */
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",b=>b.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod());
    //we are allowing this policy to access all resources

   


});

//configuration for serilog when the app executes
builder.Host.UseSerilog((ctx,lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));
//ctx-context variable
//lc-logger configuration
//the above we created a method,to write to the console. And Read from the configuration



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();//start logging different httprequest

app.UseHttpsRedirection();

app.UseCors("AllowAll");//we are telling the pipeline to use this policy
//we are perparing it for 3rd party access,access from application deployed onto machine not on the same resource has the api.


app.UseAuthorization();

 

app.MapControllers();

app.Run();
