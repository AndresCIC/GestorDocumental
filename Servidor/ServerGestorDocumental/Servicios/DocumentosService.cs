using formulario.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario.Servicios
{
    public class DocumentosService : IDocumentosService
    {
        private IDocumentosRepository documentosRepository;
        public DocumentosService(IDocumentosRepository _documentosRepository)
        {
            this.documentosRepository = _documentosRepository;
        }

        public Documento Get(long id)
        {
            return documentosRepository.Get(id);
        }

        public IQueryable<Documento> Get()
        {
            return documentosRepository.Get();
        }

        public Documento Create(Documento documento)
        {
            return documentosRepository.Create(documento);
        }

        public void Put(Documento documento)
        {
            documentosRepository.Put(documento);
        }

        public Documento Delete(long id)
        {
            return documentosRepository.Delete(id);
        }
    }
}