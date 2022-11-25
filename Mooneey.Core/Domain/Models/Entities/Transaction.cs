﻿using System;
using Mooneey.Core.Enums;

namespace Mooneey.Core.Models.Entities
{
    public class Transaction : EntityBase
    {
        public TransactionTypeEnum TransactionType { get; set; }
        public decimal Ammount { get; set; }
        public string? Comment { get; set; }

        public Guid AccountId { get; set; }
        public Account? Account { get; set; }

        public Guid CatagiryId { get; set; }
        public Category? Category { get; set; }
    }
}
