using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProdutoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProdutoService.svc or ProdutoService.svc.cs at the Solution Explorer and start debugging.
    public class ProdutoService : IProdutoService
    {

        private WCFEntities _db;

        public PRODUTO Delete(PRODUTO produto)
        {
            using (_db = new WCFEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.Set<PRODUTO>().Remove(produto);
                _db.SaveChanges();
                return produto;
            }
        }

        public PRODUTO DeleteId(int id)
        {
            using (_db = new WCFEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                PRODUTO produto = _db.Set<PRODUTO>().Find(id);
                _db.Set<PRODUTO>().Remove(produto);
                _db.SaveChanges();
                return produto;
            }
        }

        public PRODUTO Find(int id)
        {
            using (_db = new WCFEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                PRODUTO produto = _db.PRODUTO.Single(x => x.ProdutoId.Equals(id));
                return produto;
            }
        }

        public List<PRODUTO> FindAll()
        {
            using (_db = new WCFEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                List<PRODUTO> produtos = _db.PRODUTO.Include("CLIENTE").ToList();
                return produtos;
            }
        }

        public PRODUTO New(PRODUTO produto)
        {
            using (_db = new WCFEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.PRODUTO.Add(produto);
                _db.SaveChanges();
                return produto;
            }
        }

        public PRODUTO Update(PRODUTO produto)
        {
            using (_db = new WCFEntities())
            {
                _db.Configuration.ProxyCreationEnabled = false;
                _db.Entry(produto).State = EntityState.Modified;
                _db.SaveChanges();
                return produto;
            }
        }
    }
}
