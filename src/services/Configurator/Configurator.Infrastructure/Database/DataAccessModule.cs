using Autofac;
using CarConfigurator.Framework.Database;
using Configurator.Domain.Entities;
using Configurator.Domain.Repositories;
using Configurator.Infrastructure.Domain;
using Configurator.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Configurator.Infrastructure.Database;

public class DataAccessModule : Autofac.Module
{
    private readonly string _databaseConnectionString;

    public DataAccessModule(string databaseConnectionString)
    {
        this._databaseConnectionString = databaseConnectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ConfiguratorUnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();

        builder.RegisterType<ConfigurationsRepository>()
            .As<IConfigurationsRepository>()
            .InstancePerLifetimeScope();
        builder.RegisterType<StronglyTypedIdValueConverterSelector>()
            .As<IValueConverterSelector>()
            .SingleInstance();

        builder
            .Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<ConfiguratorContext>();
                dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);
                dbContextOptionsBuilder
                    .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                var context = new ConfiguratorContext(dbContextOptionsBuilder.Options);

                context.Database.Migrate();

                return context;
            })
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }
}
