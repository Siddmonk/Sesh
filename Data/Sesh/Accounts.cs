﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace SeshDB.Data.Sesh
{
    public partial class Accounts
    {
        public Accounts()
        {
            Transactions = new HashSet<Transactions>();
        }

        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public int? CurrentBalance { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}