#nullable disable
using Bank.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Domain.Entity;

[Table(nameof(BankAccount), Schema = nameof(Schema.Base))]
public class BankAccount
{
    [Key]
    public int BankAccountId { get; set; }

    [ForeignKey(nameof(CutomerId))]
    public Customer Customer { get; set; }

    public int CutomerId { get; set; }

    [Column(TypeName = "char")]
    [MaxLength(10)]
    public int AccountNumber { get; set; }

    [Required]
    public TypeAccount TypeAccount { get; set; }

    [Required]
    public int Balance { get; set; }
    public int Deposite { get; set; }
    public int Withdraw { get; set; }
}
