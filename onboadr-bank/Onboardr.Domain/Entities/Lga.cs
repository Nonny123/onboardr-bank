using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboardr.Domain.Entities
{
    public class Lga
    {
        public int LgaId { get; set; }
        public string Name { get; set; }


        [ForeignKey("StateId")]
        public int StateId { get; set; }

        public State State { get; set; }
    }
}
