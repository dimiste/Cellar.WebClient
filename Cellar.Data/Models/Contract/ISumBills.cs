namespace Cellar.Data.Models
{
    public interface ISumBills
    {
        double BaseNormal { get; set; }
        double BaseReducido { get; set; }
        double BaseSuperReducido { get; set; }
        double BaseTotal { get; set; }
        double Exento { get; set; }
        double ImporteTotal { get; set; }
        double IVANormal { get; set; }
        double IVAReducido { get; set; }
        double IVASuperReducido { get; set; }
        double IVATotal { get; set; }
        string Mes { get; set; }
    }
}