using System.ComponentModel.DataAnnotations;

namespace CrudProdutos.Models
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; } 
        public string Nome { get; set; }
        public  double Preco { get; set; }
        public double Quant { get; set; }
    }
}
