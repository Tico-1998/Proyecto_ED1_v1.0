using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Proyecto_ED1_v1.Models;

namespace Proyecto_ED1_v1.Models
{
    
    public class ModelParams
    {
        public List<BaseDatos> BDS { get; set; }
        public List<ResultadoGrid> Resultado { get; set; }
    }

    public class BaseDatos
    {
        public string Nombre { get; set; }
        public List<Tablas> Tables { get; set; }
    }

    public class Tablas
    {
        public string table { get; set; }
        public List<Columnas> columnas { get; set; }
    }

    public class Columnas
    {
        public string tabla  { get; set; }        
        public string Id { get; set; }        
        public string Int1 { get; set; }        
        public string Int2 { get; set; }
        public string Int3 { get; set; }
        public string Varchar1 { get; set; }
        public string Varchar2 { get; set; }
        public string Varchar3 { get; set; }
        public string DateTime1 { get; set; }
        public string DateTime2 { get; set; }
        public string DateTime3 { get; set; }
        
    }

    public class ResultadoGrid
    {
        public List<ColumnasResult> Columnas { get; set; }
        public DataTable Resultado { get; set; }
    }

    public class ColumnasResult
    {
        public string Columna { get; set; }
    }

}