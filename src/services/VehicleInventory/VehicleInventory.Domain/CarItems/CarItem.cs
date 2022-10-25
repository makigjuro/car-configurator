using CarConfigurator.Framework.Domain;
using VehicleInventory.Domain.CarItemTypes;
using VehicleInventory.Domain.CarModels;
using VehicleInventory.Domain.Shared;

namespace VehicleInventory.Domain.CarItems;

public class CarItem : Entity, IAggregateRoot
{
    public CarItem()
    {
        Description = String.Empty;
        PictureFileName = String.Empty;
        PictureUri = String.Empty;
        Price = MoneyValue.Of(0, "€");
    }
    
    public Guid Id { get; set; }
    
    public Guid? CarModelId { get; private set; }
    public CarModel CarModel { get; set; }

    public Guid CarItemTypeId { get; private set;}
    public CarItemType CarItemType { get; set;}
    
    public bool IsIncluded { get; set; }

    public string Name { get; set; }

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