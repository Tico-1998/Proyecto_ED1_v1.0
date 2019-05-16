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
            
            List<BaseDatos> pBDS = new List<BaseDatos>();

            pBDS.Add(new BaseDatos { Nombre = "Base1", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base2", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base3", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base4", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base5", Tables = new List<Tablas>() });



            List<Tablas> tablasBD1 = new List<Tablas>();
            tablasBD1.Add(new Tablas { table = "Nombre Tabla", columnas = new List<Columnas>() });


            List<Columnas> ColumnasTabla1 = new List<Columnas>();
            ColumnasTabla1.Add(new Columnas { tabla = "Col1", Id = "Varchar", Int1 = "Numero", Int2 = "2", Int3 = "3", Varchar1 = "Var1", Varchar2 = "Var2", Varchar3 = "var3", DateTime1 = "date1", DateTime2 = "Date2", DateTime3 = "Date3" });

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
            LecturaDatosController.Leer(textAreaSQL);
            
            List<BaseDatos> pBDS = new List<BaseDatos>();

            pBDS.Add(new BaseDatos { Nombre = "Base1", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base2", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base3", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base4", Tables = new List<Tablas>() });
            pBDS.Add(new BaseDatos { Nombre = "Base5", Tables = new List<Tablas>() });


            List<Tablas> tablasBD1 = new List<Tablas>();
            tablasBD1.Add(new Tablas { table = Tabla.nombretablas[0], columnas = new List<Columnas>() });

            List<Columnas> ColumnasTabla1 = new List<Columnas>();
            for (int i = 0; i < Tabla.ResultadoVistas.Count(); i++)
            {
                ColumnasTabla1.Add(new Columnas { tabla = Tabla.ResultadoVistas[i].nombre, Id = Tabla.ResultadoVistas[i].id, Int1 = Tabla.ResultadoVistas[i].int1, Int2 = Tabla.ResultadoVistas[i].int2,
                    Int3 = Tabla.ResultadoVistas[i].int3, Varchar1 = Tabla.ResultadoVistas[i].varchar1, Varchar2 = Tabla.ResultadoVistas[i].varchar2, Varchar3 = Tabla.ResultadoVistas[i].varchar3,
                    DateTime1 = Tabla.ResultadoVistas[i].dateTime1, DateTime2 = Tabla.ResultadoVistas[i].dateTime2, DateTime3 = Tabla.ResultadoVistas[i].dateTime3 });
            }

            //ColumnasTabla1.Add(new Columnas { Columna = tab, Tipo = Tabla.nombretablas[0] });

            tablasBD1[0].columnas = ColumnasTabla1;

            pBDS[0].Tables = tablasBD1;

            
            List<ResultadoGrid> lstResultado = new List<ResultadoGrid>();

            List<ColumnasResult> Columnas = new List<ColumnasResult>();

            if (Tabla.ResultadoVistas.Count() != 0)
            {
                Columnas.Add(new ColumnasResult { Columna = Tabla.ResultadoVistas[0].nombre });
                Columnas.Add(new ColumnasResult { Columna = Tabla.ResultadoVistas[0].id });
                Columnas.Add(new ColumnasResult { Columna = Tabla.ResultadoVistas[0].int1 });
                Columnas.Add(new ColumnasResult { Columna = Tabla.ResultadoVistas[0].int2 });
                Columnas.Add(new ColumnasResult { Columna = Tabla.ResultadoVistas[0].int3 });
                Columnas.Add(new ColumnasResult { Columna = Tabla.ResultadoVistas[0].varchar1 });
                Columnas.Add(new ColumnasResult { Columna = Tabla.ResultadoVistas[0].varchar2 });
                Columnas.Add(new ColumnasResult { Columna = Tabla.ResultadoVistas[0].varchar3 });
                Columnas.Add(new ColumnasResult { Columna = Tabla.ResultadoVistas[0].dateTime1 });
                Columnas.Add(new ColumnasResult { Columna = Tabla.ResultadoVistas[0].dateTime2 });
                Columnas.Add(new ColumnasResult { Columna = Tabla.ResultadoVistas[0].dateTime3 });


                DataTable Resultado = new DataTable();

                foreach (ColumnasResult col in Columnas)
                {
                    Resultado.Columns.Add(col.Columna);
                }

                DataRow DR = Resultado.NewRow();
                DataRow dataRow = Resultado.NewRow();
                DataRow data = Resultado.NewRow();
                DataRow row = Resultado.NewRow();
                Resultado.Rows.Clear();
                int cantidadFilas = 0;
                for (int i = 1; i < Tabla.ResultadoVistas.Count(); i++)
                {
                    if (cantidadFilas == 0)
                    {
                        if (Tabla.ResultadoVistas[0].nombre != null)
                        {
                            DR[Tabla.ResultadoVistas[0].nombre] = Tabla.ResultadoVistas[i].nombre;
                        }
                        if (Tabla.ResultadoVistas[0].id != null)
                        {
                            DR[Tabla.ResultadoVistas[0].id] = Tabla.ResultadoVistas[i].id;
                        }
                        if (Tabla.ResultadoVistas[0].int1 != null)
                        {
                            DR[Tabla.ResultadoVistas[0].int1] = Tabla.ResultadoVistas[i].int1;
                        }
                        if (Tabla.ResultadoVistas[0].int2 != null)
                        {
                            DR[Tabla.ResultadoVistas[0].int2] = Tabla.ResultadoVistas[i].int2;
                        }
                        if (Tabla.ResultadoVistas[0].int3 != null)
                        {
                            DR[Tabla.ResultadoVistas[0].int3] = Tabla.ResultadoVistas[i].int3;
                        }
                        if (Tabla.ResultadoVistas[0].varchar1 != null)
                        {
                            DR[Tabla.ResultadoVistas[0].varchar1] = Tabla.ResultadoVistas[i].varchar1;
                        }
                        if (Tabla.ResultadoVistas[0].varchar2 != null)
                        {
                            DR[Tabla.ResultadoVistas[0].varchar2] = Tabla.ResultadoVistas[i].varchar2;
                        }
                        if (Tabla.ResultadoVistas[0].varchar3 != null)
                        {
                            DR[Tabla.ResultadoVistas[0].varchar3] = Tabla.ResultadoVistas[i].varchar3;
                        }
                        if (Tabla.ResultadoVistas[0].dateTime1 != null)
                        {
                            DR[Tabla.ResultadoVistas[0].dateTime1] = Tabla.ResultadoVistas[i].dateTime1;
                        }
                        if (Tabla.ResultadoVistas[0].dateTime2 != null)
                        {
                            DR[Tabla.ResultadoVistas[0].dateTime2] = Tabla.ResultadoVistas[i].dateTime2;
                        }
                        if (Tabla.ResultadoVistas[0].dateTime3 != null)
                        {
                            DR[Tabla.ResultadoVistas[0].dateTime3] = Tabla.ResultadoVistas[i].dateTime3;
                        }
                        Resultado.Rows.Add(DR);
                        cantidadFilas++;
                    }
                    else if (cantidadFilas == 1)
                    {
                        if (Tabla.ResultadoVistas[0].nombre != null)
                        {
                            dataRow[Tabla.ResultadoVistas[0].nombre] = Tabla.ResultadoVistas[i].nombre;
                        }
                        if (Tabla.ResultadoVistas[0].id != null)
                        {
                            dataRow[Tabla.ResultadoVistas[0].id] = Tabla.ResultadoVistas[i].id;
                        }
                        if (Tabla.ResultadoVistas[0].int1 != null)
                        {
                            dataRow[Tabla.ResultadoVistas[0].int1] = Tabla.ResultadoVistas[i].int1;
                        }
                        if (Tabla.ResultadoVistas[0].int2 != null)
                        {
                            dataRow[Tabla.ResultadoVistas[0].int2] = Tabla.ResultadoVistas[i].int2;
                        }
                        if (Tabla.ResultadoVistas[0].int3 != null)
                        {
                            dataRow[Tabla.ResultadoVistas[0].int3] = Tabla.ResultadoVistas[i].int3;
                        }
                        if (Tabla.ResultadoVistas[0].varchar1 != null)
                        {
                            dataRow[Tabla.ResultadoVistas[0].varchar1] = Tabla.ResultadoVistas[i].varchar1;
                        }
                        if (Tabla.ResultadoVistas[0].varchar2 != null)
                        {
                            dataRow[Tabla.ResultadoVistas[0].varchar2] = Tabla.ResultadoVistas[i].varchar2;
                        }
                        if (Tabla.ResultadoVistas[0].varchar3 != null)
                        {
                            dataRow[Tabla.ResultadoVistas[0].varchar3] = Tabla.ResultadoVistas[i].varchar3;
                        }
                        if (Tabla.ResultadoVistas[0].dateTime1 != null)
                        {
                            dataRow[Tabla.ResultadoVistas[0].dateTime1] = Tabla.ResultadoVistas[i].dateTime1;
                        }
                        if (Tabla.ResultadoVistas[0].dateTime2 != null)
                        {
                            dataRow[Tabla.ResultadoVistas[0].dateTime2] = Tabla.ResultadoVistas[i].dateTime2;
                        }
                        if (Tabla.ResultadoVistas[0].dateTime3 != null)
                        {
                            dataRow[Tabla.ResultadoVistas[0].dateTime3] = Tabla.ResultadoVistas[i].dateTime3;
                        }
                        Resultado.Rows.Add(dataRow);
                        cantidadFilas++;
                    }
                    else if (cantidadFilas==2)
                    {
                        if (Tabla.ResultadoVistas[0].nombre != null)
                        {
                            data[Tabla.ResultadoVistas[0].nombre] = Tabla.ResultadoVistas[i].nombre;
                        }
                        if (Tabla.ResultadoVistas[0].id != null)
                        {
                            data[Tabla.ResultadoVistas[0].id] = Tabla.ResultadoVistas[i].id;
                        }
                        if (Tabla.ResultadoVistas[0].int1 != null)
                        {
                            data[Tabla.ResultadoVistas[0].int1] = Tabla.ResultadoVistas[i].int1;
                        }
                        if (Tabla.ResultadoVistas[0].int2 != null)
                        {
                            data[Tabla.ResultadoVistas[0].int2] = Tabla.ResultadoVistas[i].int2;
                        }
                        if (Tabla.ResultadoVistas[0].int3 != null)
                        {
                            data[Tabla.ResultadoVistas[0].int3] = Tabla.ResultadoVistas[i].int3;
                        }
                        if (Tabla.ResultadoVistas[0].varchar1 != null)
                        {
                            data[Tabla.ResultadoVistas[0].varchar1] = Tabla.ResultadoVistas[i].varchar1;
                        }
                        if (Tabla.ResultadoVistas[0].varchar2 != null)
                        {
                            data[Tabla.ResultadoVistas[0].varchar2] = Tabla.ResultadoVistas[i].varchar2;
                        }
                        if (Tabla.ResultadoVistas[0].varchar3 != null)
                        {
                            data[Tabla.ResultadoVistas[0].varchar3] = Tabla.ResultadoVistas[i].varchar3;
                        }
                        if (Tabla.ResultadoVistas[0].dateTime1 != null)
                        {
                            data[Tabla.ResultadoVistas[0].dateTime1] = Tabla.ResultadoVistas[i].dateTime1;
                        }
                        if (Tabla.ResultadoVistas[0].dateTime2 != null)
                        {
                            data[Tabla.ResultadoVistas[0].dateTime2] = Tabla.ResultadoVistas[i].dateTime2;
                        }
                        if (Tabla.ResultadoVistas[0].dateTime3 != null)
                        {
                            data[Tabla.ResultadoVistas[0].dateTime3] = Tabla.ResultadoVistas[i].dateTime3;
                        }
                        Resultado.Rows.Add(data);
                        cantidadFilas++;
                    }
                    else if (cantidadFilas==3)
                    {
                        if (Tabla.ResultadoVistas[0].nombre != null)
                        {
                            row[Tabla.ResultadoVistas[0].nombre] = Tabla.ResultadoVistas[i].nombre;
                        }
                        if (Tabla.ResultadoVistas[0].id != null)
                        {
                            row[Tabla.ResultadoVistas[0].id] = Tabla.ResultadoVistas[i].id;
                        }
                        if (Tabla.ResultadoVistas[0].int1 != null)
                        {
                            row[Tabla.ResultadoVistas[0].int1] = Tabla.ResultadoVistas[i].int1;
                        }
                        if (Tabla.ResultadoVistas[0].int2 != null)
                        {
                            row[Tabla.ResultadoVistas[0].int2] = Tabla.ResultadoVistas[i].int2;
                        }
                        if (Tabla.ResultadoVistas[0].int3 != null)
                        {
                            row[Tabla.ResultadoVistas[0].int3] = Tabla.ResultadoVistas[i].int3;
                        }
                        if (Tabla.ResultadoVistas[0].varchar1 != null)
                        {
                            row[Tabla.ResultadoVistas[0].varchar1] = Tabla.ResultadoVistas[i].varchar1;
                        }
                        if (Tabla.ResultadoVistas[0].varchar2 != null)
                        {
                            row[Tabla.ResultadoVistas[0].varchar2] = Tabla.ResultadoVistas[i].varchar2;
                        }
                        if (Tabla.ResultadoVistas[0].varchar3 != null)
                        {
                            row[Tabla.ResultadoVistas[0].varchar3] = Tabla.ResultadoVistas[i].varchar3;
                        }
                        if (Tabla.ResultadoVistas[0].dateTime1 != null)
                        {
                            row[Tabla.ResultadoVistas[0].dateTime1] = Tabla.ResultadoVistas[i].dateTime1;
                        }
                        if (Tabla.ResultadoVistas[0].dateTime2 != null)
                        {
                            row[Tabla.ResultadoVistas[0].dateTime2] = Tabla.ResultadoVistas[i].dateTime2;
                        }
                        if (Tabla.ResultadoVistas[0].dateTime3 != null)
                        {
                            row[Tabla.ResultadoVistas[0].dateTime3] = Tabla.ResultadoVistas[i].dateTime3;
                        }
                        Resultado.Rows.Add(row);
                        cantidadFilas++;
                    }
                }

                
                lstResultado.Add(new ResultadoGrid { Columnas = Columnas, Resultado = Resultado });
            }
            


            
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
