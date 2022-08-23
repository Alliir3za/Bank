using Bank.Domain.Entity;

namespace Bank.Service.Interface;

public interface ICustomerService
{
    public Task<List<Customer>> GetAllAsync();
    public List<BankAccount> GetMaxTransfer();

    //public List<Customer> GetAllMale();
}
