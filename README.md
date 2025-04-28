## ASP.NET Core Web API 项目模板 第一版

### 依赖的库

```C#
<ItemGroup>
	// DI容器，方便通过配置将程序集的服务一次性注入到容器中
    <PackageReference Include="Autofac" Version="8.2.1" />
    <PackageReference Include="Autofac.Extensions.DependencyInjection" Version="10.0.0" />
   	// 对象转换，方便实体类和DTO类之间的转换
    <PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.1" />
    // EFCore核心支持
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.4">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
     // EFCore SQL Server支持
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.4" />
     // EFCore 数据库迁移工具支持
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="9.0.4">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
      // Swagger 支持
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2"/>
</ItemGroup>
```

