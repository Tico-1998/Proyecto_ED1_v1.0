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
        public string Columna { get; set; }
        public string Tipo1 { get; set; }
        public string Tipo2 { get; set; }
        public string Tipo3 { get; set; }
        public string Tipo4 { get; set; }
        public string Tipo5 { get; set; }
        public string Tipo6 { get; set; }
        public string Tipo7 { get; set; }
        public string Tipo8 { get; set; }
        public string Tipo9 { get; set; }
        public string Tipo10 { get; set; }
        
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