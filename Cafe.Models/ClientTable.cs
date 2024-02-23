﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Models
{
    public class ClientTable
    {
        public int A;
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public IEnumerable<Order>? Orders { get; set; }
    }
}