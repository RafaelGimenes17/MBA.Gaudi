namespace MBA.Gaudi.Pagamentos.Domain.Interfaces.Payments
{
    public interface IConfigurationManager
    {
        string GetValue(string node);
    }
}