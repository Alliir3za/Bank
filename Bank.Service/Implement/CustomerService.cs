using Bank.Data;
using Bank.Domain.Entity;
using Bank.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Bank.Service.Implement;

public class CustomerService : ICustomerService
{
    public static void Main()
    {
    }
    
    private readonly BankDbContext _db;

    public CustomerService()
    {
        _db = new BankDbContext();
    }

    public async Task<List<Customer>> GetAllAsync()
    {

        var result = await _db.Customer.Where(a => a.Age > 39)
                       .Include(X => X.BankAccounts).
                              Select(X => new Customer
                              {
                                  Name = X.Name,
                                  Family = X.Family,
                                  CustomerId = X.CustomerId
                              })
                       .OrderBy(X => new { X.Family, X.Name })
                       .ToListAsync();
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
        return result;
    }

    //public List<Customer> GetAllMale()
    //{
    //    var result_5=_db.Customer.Where(x=>x.Gender==)
    //}

    public List<BankAccount> GetMaxTransfer() =>
        _db.BankAccount.Where(x => x.Deposite > 14000000).ToList();
}