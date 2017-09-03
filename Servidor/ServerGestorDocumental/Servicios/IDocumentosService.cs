﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formulario.Servicios
{
    public interface IDocumentosService
    {
        Documento Create(Documento documento);
        Documento Get(long id);
        IQueryable<Documento> Get();
        void Put(Documento documento);
        Documento Delete(long id);
    }
}
