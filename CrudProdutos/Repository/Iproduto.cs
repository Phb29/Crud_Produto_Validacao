using CrudProdutos.Models;

namespace CrudProdutos.Repository
{
    public interface Iproduto
    {
        List< Produto> ListEmployee();
        Produto NewEmployee(Produto employee);
        Produto IdLoc(int? id);
        Produto Detail(int? id);
        Produto Remove(int? id);
        Produto Update(Produto employee);
    }
}
    
