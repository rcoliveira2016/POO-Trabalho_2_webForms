using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Trabalho_2_webForms.Dominio.Context;
using Trabalho_2_webForms.Dominio.Entidades;

namespace Trabalho_2_webForms.Dominio.Data
{
    public class RepositorioBase<T> where T : Entidade
    {
        private BancoDadosContexto bd;
        private DbSet<T> DbSet => bd.Set<T>();

        public RepositorioBase()
        {
            bd = new BancoDadosContexto();
        }

        public T Selecionar(long id)
        {

            var produtos = DbSet.Where(p => p.Id == id);

            var prod = produtos.FirstOrDefault();

            return prod;
        }

        public void Salvar(T o)
        {
            if (o.RegistroNovo)
                Adiciona(o);
            else
                Alterar(o);
        }

        public long Adiciona(T o)
        {
            DbSet.Add(o);
            bd.SaveChanges();

            long codigo = o.Id;

            return codigo;
        }

        public void Alterar(T o)
        {
            bd.Entry(o).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();
        }

        public void Deletar(long id)
        {
            var item = DbSet.Find(id);
            DbSet.Remove(item);
            bd.SaveChanges();

        }

        public List<T> ListaTodos()
        {

            var todos = DbSet.ToList();

            return todos;

        }

        public bool PossuiRegistro()
        {
            return DbSet.ToList().Any();
        }
    }
}