#nullable disable
using Bank.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank.Domain.Entity;

[Table(nameof(GeneralBank), Schema = nameof(Schema.Base))]
public class GeneralBank
{
    [Key]
    public int BankId { get; set; }


    [ForeignKey(nameof(CustomerId))]
    public virtual Customer Customer { get; set; }
    public int? CustomerId { get; set; }


    [ForeignKey(nameof(BankAccountId))]
    public BankAccount BankAccount { get; set; }
    public int BankAccountId { get; set; }

    [Required]
    [MaxLength(80)]
    public string Name { get; set; }

    [MaxLength(80)]
    public string City { get; set; }

    [MaxLength(80)]
    public string Branch { get; set; }


}
