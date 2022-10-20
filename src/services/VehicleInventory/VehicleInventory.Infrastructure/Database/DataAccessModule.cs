using Autofac;
using CarConfigurator.Framework.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleInventory.Domain.CarBrands;
using VehicleInventory.Domain.CarItems;
using VehicleInventory.Domain.CarItemTypes;
using VehicleInventory.Domain.CarModels;
using VehicleInventory.Domain.Shared;
using VehicleInventory.Infrastructure.Domain;
using VehicleInventory.Infrastructure.Repositories;

namespace VehicleInventory.Infrastructure.Database;

public class DataAccessModule : Autofac.Module
{
    private readonly string _databaseConnectionString;

    public DataAccessModule(string databaseConnectionString)
    {
        this._databaseConnectionString = databaseConnectionString;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SqlConnectionFactory>()
            .As<ISqlConnectionFactory>()
            .WithParameter("connectionString", _databaseConnectionString)
            .InstancePerLifetimeScope();

        builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<CarBrandsRepository>()
            .As<ICarBrandsRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterType<CarModelsRepository>()
            .As<ICarModelsRepository>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<CarItemsRepository>()
            .As<ICarItemsRepository>()
            .InstancePerLifetimeScope();
        
        builder.RegisterType<CarItemTypesRepository>()
            .As<ICarItemTypesRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterType<StronglyTypedIdValueConverterSelector>()
            .As<IValueConverterSelector>()
            .SingleInstance();

        builder
            .Register(c =>
            {
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<VehicleInventoryContext>();
                dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);
                dbContextOptionsBuilder
                    .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                var context =  new VehicleInventoryContext(dbContextOptionsBuilder.Options);
                
                context.Database.Migrate();
                
                new VehicleInventoryContextSeed().Seed(context);
                
                return context;
            })
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();
    }


}
