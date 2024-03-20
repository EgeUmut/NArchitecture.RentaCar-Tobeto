﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class OperationClaim : BaseEntity<int>
    {
        public string Name { get; set; } // Rol ismi
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

        public OperationClaim()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
        }

        public OperationClaim(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
