using formulario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace formulario.Repository
{
    public class DocumentosRepository : IDocumentosRepository
    {
        public Documento Create(Documento documento)
        {
            return ApplicationDbContext.applicationDbContext.Documentos.Add(documento);
        }

        public Documento Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.Documentos.Find(id);
        }

        public IQueryable<Documento> Get()
        {
            IList<Documento> lista = new List<Documento>(ApplicationDbContext.applicationDbContext.Documentos);

            return lista.AsQueryable();
        }


        public void Put(Documento documento)
        {
            if (ApplicationDbContext.applicationDbContext.Documentos.Count(e => e.Id == documento.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(documento).State = EntityState.Modified;
        }

        public Documento Delete(long id)
        {
            Documento documento = ApplicationDbContext.applicationDbContext.Documentos.Find(id);
            if (documento == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.Documentos.Remove(documento);
            return documento;
        }
    }
}