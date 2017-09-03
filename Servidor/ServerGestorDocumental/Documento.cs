using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario
{
    public class Documento
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimoModificado { get; set; }
        public float Tamanio { get; set; }
        public string Tipo { get; set; }
        public bool VersionFinal { get; set; }
        public bool SoloLectura { get; set; }
    }
}