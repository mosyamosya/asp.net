using Microsoft.EntityFrameworkCore;
using ASp_Lr12_new.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//using (var dbContext = new AppDbContext())
//{
//    dbContext.Users.AddRange(new List<User>
//            {
//                new User { FirstName = "John", LastName = "Doe", Age = 25 },
//                new User { FirstName = "Jane", LastName = "Smith", Age = 30 },
//                new User { FirstName = "Alice", LastName = "Johnson", Age = 22 }
//            });

//    dbContext.Companies.AddRange(new List<Company>
//        {
//            new Company { Name = "Company A", YearFounded=1985 },
//            new Company { Name = "Company B",YearFounded=1947 },
//            new Company { Name = "Company C",YearFounded=1986 },
//            new Company { Name = "Company D",YearFounded=1991 },
//            new Company { Name = "Company E",YearFounded=2005 }
//        });

//    dbContext.SaveChanges();

//    var users = dbContext.Users.ToList();
//    var companies = dbContext.Companies.ToList();
//    Console.WriteLine(companies);
//    foreach (var user in users)
//    {
//        Console.WriteLine($"Id: {user.Id}, Name: {user.FirstName} {user.LastName}, Age: {user.Age}");
//    }
//}

app.Run();
