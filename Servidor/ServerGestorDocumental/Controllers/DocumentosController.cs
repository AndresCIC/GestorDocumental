using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using formulario;
using formulario.Models;
using formulario.Servicios;
using System.Web.Http.Cors;

namespace formulario.Controllers
{
    [EnableCors(origins: "http://localhost:8080, http://localhost:8081, http://localhost:3000", headers: "*", methods: "*")]

    public class DocumentosController : ApiController
    {
        private IDocumentosService documentosService;

        public DocumentosController(IDocumentosService _documentosService)
        {
            this.documentosService = _documentosService;
        }

        // GET: api/Documentos
        public IQueryable<Documento> GetDocumentos()
        {
            return documentosService.Get();
        }

        // GET: api/Documentos/5
        [ResponseType(typeof(Documento))]
        public IHttpActionResult GetDocumento(long id)
        {
            Documento documento = documentosService.Get(id);
            if (documento == null)
            {
                return NotFound();
            }

            return Ok(documento);
        }

        // PUT: api/Documentos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDocumento(long id, Documento documento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documento.Id)
            {
                return BadRequest();
            }

            try
            {
                documentosService.Put(documento);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Documentos
        [ResponseType(typeof(Documento))]
        public IHttpActionResult PostDocumento(Documento documento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            documento = documentosService.Create(documento);

            return CreatedAtRoute("DefaultApi", new { id = documento.Id }, documento);
        }

        // DELETE: api/Documentos/5
        [ResponseType(typeof(Documento))]
        public IHttpActionResult DeleteDocumento(long id)
        {
            Documento documento;
            try
            {
                documento = documentosService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(documento);
        }
    }
}