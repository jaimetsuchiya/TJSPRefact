using System;
using System.Collections.Generic;
using System.Text;

namespace SGDAU.Account.Domain.Models
{
    public partial class EFAccount
    {
        public decimal EFAccountID { get; set; }

        public int AccTypeID { get; set; }

        public int? LevelCode { get; set; }

        public string AccountName { get; set; }

        public string AccountCode { get; set; }

        public decimal? EFAccountIDF { get; set; }

        /// <summary>
        /// Região
        /// </summary>
        public decimal? EFAccountID1 { get; set; }

        public decimal? EFAccountID2 { get; set; }

        public decimal? EFAccountID3 { get; set; }

        public decimal? EFAccountID4 { get; set; }

        public decimal? EFAccountID5 { get; set; }

        public decimal? EFAccountID6 { get; set; }

        public decimal? EFAccountID7 { get; set; }

        public decimal? CheckDistance { get; set; }

        public bool? CheckOpenOS { get; set; }

    }
}
