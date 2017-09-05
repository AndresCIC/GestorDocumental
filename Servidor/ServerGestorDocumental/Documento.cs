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
        public string FechaCreacion { get; set; }
        public string FechaUltimoModificado { get; set; }
        public float Tamanio { get; set; }
        public int Tipo { get; set; }
        public bool VersionFinal { get; set; }
        public bool SoloLectura { get; set; }
    }
}