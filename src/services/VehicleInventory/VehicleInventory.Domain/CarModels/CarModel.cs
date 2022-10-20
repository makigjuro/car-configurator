using CarConfigurator.Framework.Domain;
using VehicleInventory.Domain.CarBrands;
using VehicleInventory.Domain.Shared;

namespace VehicleInventory.Domain.CarModels;

public class CarModel : Entity, IAggregateRoot
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public Guid CarBrandId { get; private set; }

    public CarBrand CarBrand { get; set; }

    
    public string Description { get; set; }

    public MoneyValue Price { get; set; }

    public string PictureFileName { get; set; }

    public string PictureUri { get; set; }
    
    public int AvailableStock { get; set; }

    public int RestockThreshold { get; set; }
    public int MaxStockThreshold { get; set; }

    /// <summary>
    /// True if item is on reorder
    /// </summary>
    public bool OnReorder { get; set; }
    
    public int RemoveStock(int quantityDesired = 1)
    {
        if (AvailableStock == 0)
        {
            throw new Exception($"Empty stock, product item {Name} is sold out");
        }

        if (quantityDesired <= 0)
        {
            throw new Exception($"Item units desired should be greater than zero");
        }   

        int removed = Math.Min(quantityDesired, this.AvailableStock);

        this.AvailableStock -= removed;

        return removed;
    }

    public int AddStock(int quantity)
    {
        int original = this.AvailableStock;

        if ((this.AvailableStock + quantity) > this.MaxStockThreshold)
        {
            this.AvailableStock += (this.MaxStockThreshold - this.AvailableStock);
        }
        else
        {
            this.AvailableStock += quantity;
        }

        this.OnReorder = false;

        return this.AvailableStock - original;
    }

}