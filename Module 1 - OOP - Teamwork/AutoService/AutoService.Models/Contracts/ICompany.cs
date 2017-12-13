namespace AutoService.Models.Contracts
{
    public interface ICompany
    {
        string Name { get; }

        string Address { get; }

        string TaxNumber { get; }

        string UniqueNumber { get; }

        decimal CreditLimit { get; }

        void UpdateCreditLimit(decimal creditLimit);

        void ChangeAddress(string address);
    }
}
