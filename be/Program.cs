using be.DBContext;
using be.Services.ImplServices;
using be.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<IAuthService, ImplAuthService>();

// we use JWT Bearer tokens to authenticate users and 
// challenge unauthenticated requests by sending 401 requests
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            // validate person who issued the token
            ValidateIssuer = true,

            // validate if the this token is for this intended audience,
            ValidateAudience = true,

            // validate the token expiration time
            ValidateLifetime = true,

            // validate if key issuer used to sign matches the one 
            ValidateIssuerSigningKey = true,

            // the token issuer
            ValidIssuer = builder.Configuration["Jwt:Issuer"],

            // intended audience of token
            // to make things simple, we have issuer and audience to be the same issuer and audience
            ValidAudience = builder.Configuration["Jwt:Audience"],
        };
    });

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        // token is expected to be found in HTTP header
        In = ParameterLocation.Header,

        // this will be displayed in swagger
        Description = "Enter token here",

        // Name of header in http request
        Name = "Authorization",

        // use http
        Type = SecuritySchemeType.Http,

        // your token will be in JWT format
        BearerFormat = "JWT",

        // use bearer scheme for authorization header
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,

                    // id of security definition above
                    Id="Bearer"
                }
            },

            // jwt does not use scopes
            new string[]{}
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DisplayRequestDuration();
});



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
