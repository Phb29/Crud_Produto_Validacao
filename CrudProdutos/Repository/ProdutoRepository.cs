using CrudProdutos.Data;
using CrudProdutos.Models;
using Microsoft.IdentityModel.Tokens;

namespace CrudProdutos.Repository
{
    public class ProdutoRepository:Iproduto
    {
        
        Context _context;
        
        public ProdutoRepository(Context contex)
        {
            _context = contex;
        }

        public Produto IdLoc(int? id)
        {
            return _context.Produtos.FirstOrDefault(x => x.IdProduto== id);
        }

        public Produto Detail(int? id)
        {
            if (id == null)
            {
                throw new Exception("not found");
            }
            var busca = IdLoc(id);
            if (busca == null)
            {
                throw new Exception("not found");
            }
            return busca;
            //primeiro verifica o id  é nulo e o segundo a busca do id é nula
        }



        public List<Produto> ListEmployee()
        {
            return _context.Produtos.ToList();
            
        }

        public Produto NewEmployee(Produto produto)
        {
            var nome = _context.Produtos.SingleOrDefault(n => n.Nome == produto.Nome);
            if (nome != null)
            {
                throw new Exception("Nome Invalido");
            }
            var preco = produto.Preco;
            string precoStr = preco.ToString();

            if (preco == 0 || string.IsNullOrEmpty(precoStr))
            {
                throw new Exception("Preço inválido!!");
            }

            
                _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public Produto Remove(int? id)
        {

            var delete = _context.Produtos.FirstOrDefault(d => d.IdProduto == id);
            _context.Remove(delete);
            _context.SaveChanges();
            return delete;

        }

        public Produto Update(Produto produto)
        {
            var id = IdLoc(produto.IdProduto);
            id.Nome = produto.Nome;
            id.Preco = produto.Preco;
            id.Quant = produto.Quant;
            _context.Update(id);
            _context.SaveChanges();
            return id;
        }
    }
}