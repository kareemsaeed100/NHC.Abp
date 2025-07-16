﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NHC.Abp.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AbpDbContextFactory : IDesignTimeDbContextFactory<AbpDbContext>
{
    public AbpDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        AbpEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<AbpDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new AbpDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../NHC.Abp.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
