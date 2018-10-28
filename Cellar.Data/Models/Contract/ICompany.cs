namespace Cellar.Data.Models
{
    public interface ICompany
    {
        string Commercial { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string Number { get; set; }
    }
}