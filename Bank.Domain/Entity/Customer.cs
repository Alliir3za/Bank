#nullable disable
using Bank.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Domain.Entity;

[Table(nameof(Customer), Schema = nameof(Schema.Base))]
public class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [Required]
    [MaxLength(80)]
    public string Name { get; set; }

    [Required]
    [MaxLength(80)]
    public string Family { get; set; }

    [Column(TypeName = "char")]
    [MaxLength(10)]
    public int NationalCode { get; set; }

    [Required]
    public string Telephone { get; set; }

    [Required]
    [MaxLength(150)]
    public string Address { get; set; }

    public Gender Gender { get; set; }

    [Required]
    public byte Age { get; set; }
    public DateTime BirthtDate { get; set; }

    public ICollection<BankAccount> BankAccounts { get; set; }
    public ICollection<GeneralBank> generalBanks { get; set; }
}
