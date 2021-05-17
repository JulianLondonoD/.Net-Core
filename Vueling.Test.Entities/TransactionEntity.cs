using System;
using System.Collections.Generic;
using System.Text;

namespace Vueling.Test.Entities
{
    public class TransactionEntity
    {
        public int IdTransaction { get; set; }
        public string Sku { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
    }
}
