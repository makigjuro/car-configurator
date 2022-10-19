namespace CarConfigurator.Framework.Domain;

public interface IBusinessRule
{
    bool IsBroken();

    string Message { get; }
}