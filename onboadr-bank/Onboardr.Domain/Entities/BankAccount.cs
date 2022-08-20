using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboardr.Domain.Entities
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid CFId { get; set; }

        public string AccountNo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("BankAccountTypeId")]
        public int BankAccountTypeId { get; set; }
        public BankAccountType BankAccountType { get; set; }
    }
}
