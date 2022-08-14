﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboardr.Domain.Entities
{
    public class State
    {
        public int StateId { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public virtual IList<Lga> Lgas { get; set; }
    }
}
