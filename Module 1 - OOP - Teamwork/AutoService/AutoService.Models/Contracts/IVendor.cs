namespace AutoService.Models.Contracts
{
    public interface IVendor : ICompany
    {
        void PayInvoices();
    }
}
