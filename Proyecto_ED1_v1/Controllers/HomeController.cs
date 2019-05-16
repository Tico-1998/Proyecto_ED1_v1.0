using System;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_ED1_v1.Models;
using Proyecto_ED1_v1.Controllers;
using Microsoft.AspNetCore.Http;
using System.IO;

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
            
            string NombreTabla = Tabla.nombretablas[0];
            List<Columnas> ColumnasTabla1 = new List<Columnas>();
            Tabla tabla = new Tabla();
            List<Tabla> elementoTabla = new List<Tabla>();
            if (Tabla.DiccionarioTabla[NombreTabla]!=null)
            {
                tablasBD1.Add(new Tablas { table = Tabla.nombretablas[0], columnas = new List<Columnas>() });
                for (int i = 0; i < Tabla.ResultadoVistas.Count(); i++)
                {
                    elementoTabla = Tabla.DiccionarioTabla[NombreTabla];
                    tabla = elementoTabla[i];
                    ColumnasTabla1.Add(new Columnas
                    {
                        tabla = tabla.nombre,
                        Id = tabla.id,
                        Int1 = tabla.int1,
                        Int2 = tabla.int2,
                        Int3 = tabla.int3,
                        Varchar1 = tabla.varchar1,
                        Varchar2 = tabla.varchar2,
                        Varchar3 = tabla.varchar3,
                        DateTime1 = tabla.dateTime1,
                        DateTime2 = tabla.dateTime2,
                        DateTime3 = tabla.dateTime3
                    });
                }
            }
            
           

            //ColumnasTabla1.Add(new Columnas { Columna = tab, Tipo = Tabla.nombretablas[0] });

            tablasBD1[0].columnas = ColumnasTabla1;

            pBDS[0].Tables = tablasBD1;

            List<Tablas> tablasBD2 = new List<Tablas>();
            if (Tabla.nombretablas[1]!=null)
            {
                NombreTabla = Tabla.nombretablas[1];
                List<Columnas> ColumnasTabla2 = new List<Columnas>();
                if (Tabla.DiccionarioTabla[NombreTabla] != null)
                {
                    tablasBD2.Add(new Tablas { table = Tabla.nombretablas[1], columnas = new List<Columnas>() });
                    for (int i = 0; i < Tabla.ResultadoVistas.Count(); i++)
                    {
                        elementoTabla = Tabla.DiccionarioTabla[NombreTabla];
                        tabla = elementoTabla[i];
                        ColumnasTabla2.Add(new Columnas
                        {
                            tabla = tabla.nombre,
                            Id = tabla.id,
                            Int1 = tabla.int1,
                            Int2 = tabla.int2,
                            Int3 = tabla.int3,
                            Varchar1 = tabla.varchar1,
                            Varchar2 = tabla.varchar2,
                            Varchar3 = tabla.varchar3,
                            DateTime1 = tabla.dateTime1,
                            DateTime2 = tabla.dateTime2,
                            DateTime3 = tabla.dateTime3
                        });
                    }
                }
                tablasBD2[0].columnas = ColumnasTabla2;

                pBDS[1].Tables = tablasBD2;
            }

            

            List<Tablas> tablasBD3 = new List<Tablas>();

            if (Tabla.nombretablas[2]!=null)
            {
                NombreTabla = Tabla.nombretablas[2];
                List<Columnas> ColumnasTabla3 = new List<Columnas>();
                if (Tabla.DiccionarioTabla[NombreTabla] != null)
                {
                    tablasBD3.Add(new Tablas { table = Tabla.nombretablas[2], columnas = new List<Columnas>() });
                    for (int i = 0; i < Tabla.ResultadoVistas.Count(); i++)
                    {
                        elementoTabla = Tabla.DiccionarioTabla[NombreTabla];
                        tabla = elementoTabla[i];
                        ColumnasTabla3.Add(new Columnas
                        {
                            tabla = tabla.nombre,
                            Id = tabla.id,
                            Int1 = tabla.int1,
                            Int2 = tabla.int2,
                            Int3 = tabla.int3,
                            Varchar1 = tabla.varchar1,
                            Varchar2 = tabla.varchar2,
                            Varchar3 = tabla.varchar3,
                            DateTime1 = tabla.dateTime1,
                            DateTime2 = tabla.dateTime2,
                            DateTime3 = tabla.dateTime3
                        });
                    }
                }
                tablasBD3[0].columnas = ColumnasTabla3;

                pBDS[2].Tables = tablasBD3;
            }
            

            List<Tablas> tablasBD4 = new List<Tablas>();

            if (Tabla.nombretablas[3]!=null)
            {
                NombreTabla = Tabla.nombretablas[3];
                List<Columnas> ColumnasTabla4 = new List<Columnas>();
                if (Tabla.DiccionarioTabla[NombreTabla] != null)
                {
                    tablasBD4.Add(new Tablas { table = Tabla.nombretablas[3], columnas = new List<Columnas>() });
                    for (int i = 0; i < Tabla.ResultadoVistas.Count(); i++)
                    {
                        elementoTabla = Tabla.DiccionarioTabla[NombreTabla];
                        tabla = elementoTabla[i];
                        ColumnasTabla4.Add(new Columnas
                        {
                            tabla = tabla.nombre,
                            Id = tabla.id,
                            Int1 = tabla.int1,
                            Int2 = tabla.int2,
                            Int3 = tabla.int3,
                            Varchar1 = tabla.varchar1,
                            Varchar2 = tabla.varchar2,
                            Varchar3 = tabla.varchar3,
                            DateTime1 = tabla.dateTime1,
                            DateTime2 = tabla.dateTime2,
                            DateTime3 = tabla.dateTime3
                        });
                    }
                }
                tablasBD4[0].columnas = ColumnasTabla4;

                pBDS[3].Tables = tablasBD4;
            }
                    

            

            List<Tablas> tablasBD5 = new List<Tablas>();

            if (Tabla.nombretablas[4]!=null)
            {
                NombreTabla = Tabla.nombretablas[4];
                List<Columnas> ColumnasTabla5 = new List<Columnas>();
                if (Tabla.DiccionarioTabla[NombreTabla] != null)
                {
                    tablasBD5.Add(new Tablas { table = Tabla.nombretablas[4], columnas = new List<Columnas>() });
                    for (int i = 0; i < Tabla.ResultadoVistas.Count(); i++)
                    {
                        elementoTabla = Tabla.DiccionarioTabla[NombreTabla];
                        tabla = elementoTabla[i];
                        ColumnasTabla5.Add(new Columnas
                        {
                            tabla = tabla.nombre,
                            Id = tabla.id,
                            Int1 = tabla.int1,
                            Int2 = tabla.int2,
                            Int3 = tabla.int3,
                            Varchar1 = tabla.varchar1,
                            Varchar2 = tabla.varchar2,
                            Varchar3 = tabla.varchar3,
                            DateTime1 = tabla.dateTime1,
                            DateTime2 = tabla.dateTime2,
                            DateTime3 = tabla.dateTime3
                        });
                    }
                }
                tablasBD5[0].columnas = ColumnasTabla5;

                pBDS[4].Tables = tablasBD5;
            }               

            

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

        [HttpGet]
        public ActionResult About()
        {
            return View("About");
        }


        [HttpPost]
        public ActionResult About(FormCollection formCollection)
        {
            Sintaxis.Select = formCollection["Select"];
            Sintaxis.From = formCollection["From"];
            Sintaxis.Delete = formCollection["Delete"];
            Sintaxis.Where = formCollection["Where"];
            Sintaxis.CreateTable = formCollection["Create Table"];
            Sintaxis.DropTable = formCollection["Drop Table"];
            Sintaxis.InsertInto = formCollection["Insert Into"];
            Sintaxis.Values = formCollection["Values"];
            Sintaxis.Go = formCollection["Go"];
            using (StreamWriter outputFile = new StreamWriter("Palabra_Reservadas"))
            {
                outputFile.WriteLine("SELECT="+Sintaxis.Select);
                outputFile.WriteLine("FROM=" + Sintaxis.From);
                outputFile.WriteLine("DELETE=" + Sintaxis.Delete);
                outputFile.WriteLine("WHERE=" + Sintaxis.Where);
                outputFile.WriteLine("CREATE TABLE=" + Sintaxis.CreateTable);
                outputFile.WriteLine("DROP TABLE=" + Sintaxis.DropTable);
                outputFile.WriteLine("INSERT INTO=" + Sintaxis.InsertInto);
                outputFile.WriteLine("VALUES=" + Sintaxis.Values);
                outputFile.WriteLine("GO=" + Sintaxis.Go);
            }

                return View("About");
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
