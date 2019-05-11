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
        public ActionResult Index()
        {
            //Al inicialisar tienes que crear el pBDS como te lo tengo de ejemplo usando tus lista para que se pueda mostrar en la vista.
            List<BaseDatos> pBDS = new List<BaseDatos>();

            pBDS.Add(new BaseDatos { Nombre = "Base1", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base2", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base3", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base4", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base5", Tables = new List<Tablas>() });


            List<Tablas> tablasBD1 = new List<Tablas>();
            tablasBD1.Add(new Tablas { table = Tabla.nombretablas[0], columnas = new List<Columnas>() });
            Tabla tabbla = new Tabla();
            if (Tabla.Solicitado.Count()>0)
            {
                tabbla = Tabla.Solicitado[0];
            }


            List<Columnas> ColumnasTabla1 = new List<Columnas>();
            ColumnasTabla1.Add(new Columnas { Columna = tabbla, Tipo = Tabla.nombretablas[0] });

            tablasBD1[0].columnas = ColumnasTabla1;

            pBDS[0].Tables = tablasBD1;

            // Cargar el resultado del Grid Aqui VA VACIO YA QUE ES CUANDO INICIA PAGINA

            List<ResultadoGrid> lstResultado = new List<ResultadoGrid>();
            List<ColumnasResult> Columnas = new List<ColumnasResult>();
            DataTable Resultado = new DataTable();

            lstResultado.Add(new ResultadoGrid { Columnas = Columnas, Resultado = Resultado });

            //pBDS ES EL ARBOL PARA LLENAR EL GRID DE LAS BD Y TABLAS lstResutado debe ser un clase con una lista columnas y lista resultados para llenar el grid.
            ModelParams md = new ModelParams { BDS = pBDS, Resultado = lstResultado };

            return View(md);
        }

        [HttpPost]
        public ActionResult Index(string[] textAreaSQL)
        {
            // en textAreaSQL viene en forma de array lo que escribas dentro del text area y a partir de ahi tienes que desarrollar tus metodos
            // para poder llenar pBDS que serian las bd yo utilize listas pero debes usar lo que necesites
            List<BaseDatos> pBDS = new List<BaseDatos>();

            pBDS.Add(new BaseDatos { Nombre = "Base1", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base2", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base3", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base4", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base5", Tables = new List<Tablas>() });


            List<Tablas> tablasBD1 = new List<Tablas>();
            tablasBD1.Add(new Tablas { table = Tabla.nombretablas[0], columnas = new List<Columnas>() });


            List<Columnas> ColumnasTabla1 = new List<Columnas>();
            Tabla tab = new Tabla();
            if (Tabla.Solicitado.Count()>0)
            {
                tab = Tabla.Solicitado[0];
            }

            ColumnasTabla1.Add(new Columnas { Columna = tab, Tipo = Tabla.nombretablas[0] });

            tablasBD1[0].columnas = ColumnasTabla1;

            pBDS[0].Tables = tablasBD1;

            //Cargar el resultado del Grid Aqui
            // En esta parte tenes que crear el datatable como viene a continuacion con las columnas y los datos de las columnas despues eso 
            // va a hacer que en la vista se vean los resultados
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

            DR["Col1"] = Tabla.Solicitado[0];
            DR["Col2"] = "2";
            DR["Col3"] = "TEST3";

            Resultado.Rows.Add(DR);

            lstResultado.Add(new ResultadoGrid { Columnas = Columnas, Resultado = Resultado });


            //pBDS ES EL ARBOL PARA LLENAR EL GRID DE LAS BD Y TABLAS lstResutado debe ser un clase con una lista columnas y lista resultados para llenar el grid.
            ModelParams md = new ModelParams { BDS = pBDS, Resultado = lstResultado };


            return View(md);
        }

        //public ActionResult Resultados(String textAreaSQL)
        //{
        //    ///you can use int txtId  here 
        //    ///

        //    List<BaseDatos> BDS = new List<BaseDatos>();

        //    BDS.Add(new BaseDatos { Nombre = "Base1", Tables = new List<Tablas>() });
        //    BDS.Add(new BaseDatos { Nombre = "Base2", Tables = new List<Tablas>() });
        //    BDS.Add(new BaseDatos { Nombre = "Base3", Tables = new List<Tablas>() });
        //    BDS.Add(new BaseDatos { Nombre = "Base4", Tables = new List<Tablas>() });
        //    BDS.Add(new BaseDatos { Nombre = "Base5", Tables = new List<Tablas>() });


        //    List<Tablas> tablasBD1 = new List<Tablas>();
        //    tablasBD1.Add(new Tablas { table = "TableA", columnas = new List<Columnas>() });


        //    List<Columnas> ColumnasTabla1 = new List<Columnas>();
        //    ColumnasTabla1.Add(new Columnas { Columna = "Col1", Tipo = "Varchar" });

        //    tablasBD1[0].columnas = ColumnasTabla1;

        //    BDS[3].Tables = tablasBD1;

        //    return View(BDS);
        //}

    }
}
