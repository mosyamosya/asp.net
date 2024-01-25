using ASp_MVC.Models;
namespace ASp_MVC.ViewModels
{
   
    public record class ShowConsultsViewModel(IEnumerable<Consult> Consults);
}