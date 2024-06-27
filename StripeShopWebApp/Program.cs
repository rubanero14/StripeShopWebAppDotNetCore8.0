using Stripe;

var builder = WebApplication.CreateBuilder(args);

// src:https://www.youtube.com/watch?v=6SAFgcMie4U&t=1230s&ab_channel=freeCodeCamp.org

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Stripe secret API key.
StripeConfiguration.ApiKey = builder.Configuration.GetSection("sk_test_51PWChXP9UQDFSDHQwqewqeq32428sfae0-Isgs0FDSJsbfhsbgdtazGLRbMNIFwhQ5Lm0wsCgdtazGLRbMNIFw").Get<string>();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
