﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPDATA.Models
{
    public class Voucher
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ReduceForm { get; set; }
        public int Status { get; set; }
        public double DiscountAmount { get; set; }
        public DateTime Create_date { get; set; }
        public DateTime Update_date { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Bill>? Bill { get; set; }
    }
}
