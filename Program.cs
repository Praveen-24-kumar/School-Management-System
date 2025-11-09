using SchoolManagement;
using SchoolManagement.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IWebHostEnvironment>(builder.Environment);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Common>();
builder.Services.AddScoped<DAL>();
builder.Services.AddScoped<TeacherDAL>();
builder.Services.AddScoped<SetBookDAL>();
builder.Services.AddScoped<FeeDAL>();
builder.Services.AddScoped<ExpenseDAL>();
builder.Services.AddScoped<SubjectDAL>();
builder.Services.AddScoped<ParentDAL>();
builder.Services.AddScoped<RoutineDLA>();
builder.Services.AddScoped<ExamDAL>();
builder.Services.AddScoped<TransportDAL>();
builder.Services.AddScoped<NoticeDAL>();

builder.Services.AddScoped<DashboardDAL>();
builder.Services.AddScoped<AttendanceDAL>();


builder.Services.AddScoped<LoginDAL>();
builder.Services.AddScoped<UserDAL>();
builder.Services.AddScoped<MasterDAL>();



//  Add session
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



//  Use session
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
