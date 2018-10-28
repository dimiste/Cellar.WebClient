using System;

namespace Cellar.Data.Models
{
    public interface IBill
    {
        double Base10 { get; set; }
        double Base21 { get; set; }
        double Base4 { get; set; }
        string BillScanned { get; set; }
        Company Company { get; set; }
        DateTime Date { get; set; }
        double Exento { get; set; }
        int Id { get; set; }
        string IdUser { get; set; }
        double IVA10 { get; }
        double IVA21 { get; }
        double IVA4 { get; }
        string Month { get; set; }
        double TotalBill { get; }
    }
}