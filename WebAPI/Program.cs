using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.EFCore;
using WebAPI.AutoFaceDI;
using WebAPI.Filters;
using WebAPI.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//配置数据库上下文对象
builder.Services.AddDbContext<MyDbContext>(opt =>
{
    var connStr = builder.Configuration.GetConnectionString("StrConn");
    opt.UseSqlServer(connStr);
});

//配置全局过滤器
builder.Services.Configure<MvcOptions>(opt =>
{
    opt.Filters.Add<UnitOfWorkFilter>();
});

//替换DI容器
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(build =>
{
    build.RegisterModule(new AutofacModuleRegister());
});

//添加对象转换服务
builder.Services.AddAutoMapper(typeof(UserInfoProfile));

//配置Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//开发环境配置
if (app.Environment.IsDevelopment())
{
    //启用Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();