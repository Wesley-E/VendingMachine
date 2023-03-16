namespace VendingMachine.Models.StateMachine;

public class VendingContext
{
    public decimal VendingMachineBalance = 100m;
    public decimal CustomerBalance = 0m;
    public string? SelectedProductName;
    public Products.Product? SelectedProductInfo;
}