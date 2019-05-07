using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_ED1_v1.Models;
using Proyecto_ED1_v1.Controllers;

namespace Proyecto_ED1_v1.Controllers
{
    public class HomeController : Controller
    {
        public string texto { get; set; }
        public ActionResult Index()
        {
            
            List<BaseDatos> pBDS = new List<BaseDatos>();

            pBDS.Add(new BaseDatos { Nombre = "Base1", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base2", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base3", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base4", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base5", Tables = new List<Tablas>() });


            List<Tablas> tablasBD1 = new List<Tablas>();
            tablasBD1.Add(new Tablas { table = "TableA", columnas = new List<Columnas>() });


            List<Columnas> ColumnasTabla1 = new List<Columnas>();
            ColumnasTabla1.Add(new Columnas { Columna = "Col1", Tipo = "Varchar" });

            tablasBD1[0].columnas = ColumnasTabla1;

            pBDS[0].Tables = tablasBD1;

            

            List<ResultadoGrid> lstResultado = new List<ResultadoGrid>();
            List<ColumnasResult> Columnas = new List<ColumnasResult>();
            DataTable Resultado = new DataTable();

            lstResultado.Add(new ResultadoGrid { Columnas = Columnas, Resultado = Resultado });

            
            ModelParams md = new ModelParams { BDS = pBDS, Resultado = lstResultado };

            return View(md);
        }

        [HttpPost]
        public ActionResult Index(string[] textAreaSQL)
        {
            
            List<BaseDatos> pBDS = new List<BaseDatos>();

            pBDS.Add(new BaseDatos { Nombre = "Base1", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base2", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base3", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base4", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base5", Tables = new List<Tablas>() });


            List<Tablas> tablasBD1 = new List<Tablas>();
            tablasBD1.Add(new Tablas { table = "TableA", columnas = new List<Columnas>() });


            List<Columnas> ColumnasTabla1 = new List<Columnas>();
            ColumnasTabla1.Add(new Columnas { Columna = "Col1", Tipo = "Varchar" });

            tablasBD1[0].columnas = ColumnasTabla1;

            pBDS[0].Tables = tablasBD1;

            
            List<ResultadoGrid> lstResultado = new List<ResultadoGrid>();

            List<ColumnasResult> Columnas = new List<ColumnasResult>();
            
            Columnas.Add(new ColumnasResult { Columna = "Col1" });
            Columnas.Add(new ColumnasResult { Columna = "Col2" });
            Columnas.Add(new ColumnasResult { Columna = "Col3" });

            DataTable Resultado = new DataTable();

            foreach (ColumnasResult col in Columnas)
            {
                Resultado.Columns.Add(col.Columna);
            }

            DataRow DR = Resultado.NewRow();

            DR["Col1"] = "TEST1";
            DR["Col2"] = "2";
            DR["Col3"] = "TEST3";

            Resultado.Rows.Add(DR);

            lstResultado.Add(new ResultadoGrid { Columnas = Columnas, Resultado = Resultado });


            
            ModelParams md = new ModelParams { BDS = pBDS, Resultado = lstResultado };


            return View(md);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
