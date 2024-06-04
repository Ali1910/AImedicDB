using AA_Task.DataContext;
using AA_Task.Interface;
using AA_Task.Repository;
using howtohandelimages.Repository.Abstract;
using howtohandelimages.Repository.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using school;
using school.repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Defualtconnectionstring")));
builder.Services.AddScoped<IspecialtyRepo, SpecialtyRepo>();
builder.Services.AddTransient<iFileService, FileService>();
builder.Services.AddScoped<IDoctorRepo, DoctorRepo>();
builder.Services.AddScoped<IBodypartRepository, BodyPartRepo>();
builder.Services.AddScoped<ISymptomsRepo, SymptomRepo>();
builder.Services.AddScoped<ITimesRepo, TimesRepo>();
builder.Services.AddScoped<IAnswerRepo, AnswerRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
builder.Services.AddScoped<IHealthAdviceRepo, HealthAdviceRepo>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IBMI, BMIRepo>();
builder.Services.AddScoped<IdoctorTimes, DoctorTimesRepo>();
builder.Services.AddScoped<IdiagnosisSummary, DiagnosisSummary>();

var app = builder.Build();


// Configure the HTTP request pipeline.


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Uploads")),
//    RequestPath = "/Resources"
//});

app.UseAuthorization();

app.MapControllers();

app.Run();
