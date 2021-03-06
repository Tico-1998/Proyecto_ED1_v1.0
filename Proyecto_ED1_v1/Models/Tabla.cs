﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto_ED1_v1.Models;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;


namespace Proyecto_ED1_v1.Models
{
    //public delegate int compareTo<T>(T Tabla, T Valor);
    public class Tabla
    {
        public static List<Tabla> ResultadoVistas = new List<Tabla>();
        public static Excel.Application ArchivoExcel = new Excel.Application();
        public static List<Tabla> Solicitado = new List<Tabla>();
        public static Dictionary<string, int> diccionarioNumeroTabla = new Dictionary<string, int>();
        public static ArbolB<Tabla> Arbol = new ArbolB<Tabla>();
        public static Dictionary<string, int> posicionTabla = new Dictionary<string, int>();
        public static Dictionary<string, ArbolB<Tabla>> Arboles = new Dictionary<string, ArbolB<Tabla>>();
        public string TextoIngresado = "";
        public static Dictionary<string, List<Tabla>> DiccionarioTabla = new Dictionary<string, List<Tabla>>();
        public static List<Tabla>[] arraytablas = new List<Tabla>[5];
        public static string[] nombretablas = new string[5];
        public static Dictionary<string, string> Variables = new Dictionary<string, string>();//la llave es el nombre de la variable, el valor es cual variable es 
        public static Dictionary<string, Dictionary<string,string>> DiccionarioVariables= new Dictionary<string,Dictionary<string,string>>();
        public static int cantidadTablas = 0;
        public static int numeroTabla = 0;
        public string id;        
        public string int1;
        public string int2;
        public string int3;
        public string varchar1;
        public string varchar2;
        public string varchar3;
        public string dateTime1;
        public string dateTime2;
        public string dateTime3;
        public string nombre;

        public static void CrearTabla(Tabla tabla, string nombre)
        {
            
            Variables.Clear();
            if (tabla.int1 != null) { Variables.Add(tabla.int1, "int1"); }
            if (tabla.int2 != null) { Variables.Add(tabla.int2, "int2"); }
            if (tabla.int3 != null) { Variables.Add(tabla.int3, "int3"); }
            if (tabla.id != null) { Variables.Add(tabla.id, "id"); }
            if (tabla.varchar1 != null) { Variables.Add(tabla.varchar1, "varchar1"); }
            if (tabla.varchar2 != null) { Variables.Add(tabla.varchar2, "varchar2"); }
            if (tabla.varchar3 != null) { Variables.Add(tabla.varchar3, "varchar3"); }
            if (tabla.dateTime1 != null) { Variables.Add(tabla.dateTime1, "dateTime1"); }
            if (tabla.dateTime2 != null) { Variables.Add(tabla.dateTime2, "dateTime2"); }
            if (tabla.dateTime3 != null) { Variables.Add(tabla.dateTime3, "dateTime3"); }
            
            tabla.nombre = nombre;
            DiccionarioVariables.Add(nombre, Variables);
            List<Tabla> Tabla = new List<Tabla>();
            Tabla.Add(tabla);
            DiccionarioTabla.Add(nombre, Tabla);
            Arboles.Add(nombre, Arbol);
            if (cantidadTablas > 5)
            {
                if (arraytablas[0] == null)
                {
                    cantidadTablas = 0;
                }
                else if (arraytablas[1] == null)
                {
                    cantidadTablas = 1;
                }
                else if (arraytablas[2] == null)
                {
                    cantidadTablas = 2;
                }
                else if (arraytablas[3] == null)
                {
                    cantidadTablas = 3;
                }
                else if (arraytablas[4] == null)
                {
                    cantidadTablas = 4;
                }
            }
            arraytablas[cantidadTablas] = Tabla;
            nombretablas[cantidadTablas] = tabla.nombre;
            posicionTabla.Add(nombre, cantidadTablas);
            cantidadTablas++;
            Arbol.Orden = 5;
            ResultadoVistas.Clear();
            for (int i = 0; i < Tabla.Count(); i++)
            {
                ResultadoVistas.Add(Tabla[i]);
            }            
            //creacion txt
            string nombre_archivo = "Tabla"+numeroTabla+".txt";
            string pathfinal = nombre_archivo;
            using (StreamWriter outputFile = new StreamWriter(pathfinal))
            {
                outputFile.Write(tabla.nombre +", "+ tabla.id +", "+ tabla.int1 +", "+ tabla.int2 +", "+ tabla.int3+", ");
                outputFile.Write(tabla.varchar1 +", "+ tabla.varchar2 +", "+ tabla.varchar3 +", "+ tabla.dateTime1+", " +
                    "");
                outputFile.Write(tabla.dateTime2 +", "+ tabla.dateTime3);                
            }
            diccionarioNumeroTabla.Add(nombre, numeroTabla);
            //creacion Excel         
            
            Object opc = Type.Missing;
            Excel.Workbook libro;
            libro = ArchivoExcel.Workbooks.Add(opc);
            ArchivoExcel.Visible = false;
            libro = ArchivoExcel.Workbooks.Add(opc);
            Excel.Worksheet hoja = new Excel.Worksheet();
            hoja = (Excel.Worksheet)libro.Sheets.Add(opc, opc, opc, opc);
            hoja.Activate();
            hoja.Cells[1, 1] = tabla.nombre;
            hoja.Cells[1, 2] = tabla.id;
            hoja.Cells[1, 3] = tabla.int1;
            hoja.Cells[1, 4] = tabla.int2;
            hoja.Cells[1, 5] = tabla.int3;
            hoja.Cells[1, 6] = tabla.varchar1;
            hoja.Cells[1, 7] = tabla.varchar2;
            hoja.Cells[1, 8] = tabla.varchar3;
            hoja.Cells[1, 9] = tabla.dateTime1;
            hoja.Cells[1, 10] = tabla.dateTime2;
            hoja.Cells[1, 11] = tabla.dateTime3;
            ArchivoExcel.Visible = true;
            libro.SaveAs("Excel" + numeroTabla);
            numeroTabla++;
        }
        //eliminar tabla de la vista
        public static void ElimiarTabla(string Clave)
        {
            DiccionarioTabla.Remove(Clave);
            Arboles.Remove(Clave);
            int posicion = posicionTabla[Clave];
            arraytablas[posicion] = null;
            nombretablas[posicion] = null;
            cantidadTablas--;
            int tablaNumero = diccionarioNumeroTabla[Clave];
            string nombre = "Tabla" + tablaNumero + ".txt";
            File.Delete(nombre);
            string Ruta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            int numeroArchivo = diccionarioNumeroTabla[Clave];
            string nombreArchivo = "Excel" + numeroArchivo+".xlsx";
            string path = Ruta + "\\" + nombreArchivo;
            File.SetAttributes(path, FileAttributes.Normal);
            File.Delete(path);
        }
       
        public static void EliminarElemento(string Llave, string variable, string nombre)
        {
            ArbolBNodo<Tabla> Raiz = new ArbolBNodo<Tabla>();
            ArbolB<Tabla> Eliminar = new ArbolB<Tabla>();
            Tabla tabla = new Tabla();
            List<Tabla> eliminando = new List<Tabla>();
            eliminando = DiccionarioTabla[Llave];//se optiene la lista correcta
            bool Encontrado = true;
            int contadorPosiciones = 0;
            try
            {
                switch (Variables[variable])//diccionario que guarda las variables 
                {
                    case "id":
                        while (Encontrado)
                        {
                            tabla = eliminando[contadorPosiciones];
                            if (tabla.id == nombre)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosiciones++;
                            }
                        }
                        tabla = eliminando[contadorPosiciones];
                        break;
                    case "int1":
                        while (Encontrado)
                        {
                            tabla = eliminando[contadorPosiciones];
                            if (tabla.int1 == nombre)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosiciones++;
                            }
                        }
                        tabla = eliminando[contadorPosiciones];
                        break;
                    case "int2":
                        while (Encontrado)
                        {
                            tabla = eliminando[contadorPosiciones];
                            if (tabla.int2 == nombre)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosiciones++;
                            }
                        }
                        tabla = eliminando[contadorPosiciones];
                        break;
                    case "int3":
                        while (Encontrado)
                        {
                            tabla = eliminando[contadorPosiciones];
                            if (tabla.int3 == nombre)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosiciones++;
                            }
                        }
                        tabla = eliminando[contadorPosiciones];
                        break;
                    case "varchar1":
                        while (Encontrado)
                        {
                            tabla = eliminando[contadorPosiciones];
                            if (tabla.varchar1 == nombre)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosiciones++;
                            }
                        }
                        tabla = eliminando[contadorPosiciones];
                        break;
                    case "varchar2":
                        while (Encontrado)
                        {
                            tabla = eliminando[contadorPosiciones];
                            if (tabla.varchar2 == nombre)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosiciones++;
                            }
                        }
                        tabla = eliminando[contadorPosiciones];
                        break;
                    case "varchar3":
                        while (Encontrado)
                        {
                            tabla = eliminando[contadorPosiciones];
                            if (tabla.varchar3 == nombre)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosiciones++;
                            }
                        }
                        tabla = eliminando[contadorPosiciones];
                        break;
                    case "dateTime1":
                        while (Encontrado)
                        {
                            tabla = eliminando[contadorPosiciones];
                            if (tabla.dateTime1 == nombre)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosiciones++;
                            }
                        }
                        tabla = eliminando[contadorPosiciones];
                        break;
                    case "dateTime2":
                        while (Encontrado)
                        {
                            tabla = eliminando[contadorPosiciones];
                            if (tabla.dateTime2 == nombre)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosiciones++;
                            }
                        }
                        tabla = eliminando[contadorPosiciones];
                        break;
                    case "dateTime3":
                        while (Encontrado)
                        {
                            tabla = eliminando[contadorPosiciones];
                            if (tabla.dateTime3 == nombre)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosiciones++;
                            }
                        }
                        tabla = eliminando[contadorPosiciones];
                        break;
                    default:
                        //mensaje error en varibale 
                        break;

                }
            }
            catch (Exception ex)
            {
                //Valor no existe
            }
            DiccionarioTabla.Remove(Llave);
            eliminando.Remove(tabla);
            DiccionarioTabla.Add(Llave, eliminando);
            Eliminar = Arboles[Llave];
            Arboles.Remove(Llave);
            Raiz = Eliminar.Raiz;
            Eliminar.Eliminar(tabla, Raiz);
            ResultadoVistas.Clear();
            for (int i = 0; i < eliminando.Count(); i++)
            {
                ResultadoVistas.Add(eliminando[i]);
            }
            Arboles.Add(Llave, Eliminar);
            int posicion = posicionTabla[Llave];
            arraytablas[posicion] = eliminando;
            int tablaNumero = diccionarioNumeroTabla[Llave];
            string nombre_archivo = "Tabla" + tablaNumero + ".txt";
            string pathfinal = nombre_archivo;
            using (StreamWriter outputFile = new StreamWriter(pathfinal))
            {
                for (int i = 0; i < eliminando.Count(); i++)
                {
                    tabla = eliminando[i];
                    outputFile.Write(tabla.nombre + ", " + tabla.id + ", " + tabla.int1 + ", " + tabla.int2 + ", " + tabla.int3 + ", ");
                    outputFile.Write(tabla.varchar1 + ", " + tabla.varchar2 + ", " + tabla.varchar3 + ", " + tabla.dateTime1 + ", ");
                    outputFile.Write(tabla.dateTime2 + ", " + tabla.dateTime3);
                    outputFile.WriteLine("");
                }
            }
            Object opc = Type.Missing;
            Excel.Workbook libro;
            libro = ArchivoExcel.Workbooks.Add(opc);
            ArchivoExcel.Visible = false;
            libro = ArchivoExcel.Workbooks.Add(opc);
            Excel.Worksheet hoja = new Excel.Worksheet();
            hoja = (Excel.Worksheet)libro.Sheets.Add(opc, opc, opc, opc);
            hoja.Activate();
            int cantidadLineas = eliminando.Count();
            for (int i = 0; i < cantidadLineas; i++)
            {
                tabla = eliminando[i];
                hoja.Cells[i + 1, 1] = tabla.nombre;
                hoja.Cells[i + 1, 2] = tabla.id;
                hoja.Cells[i + 1, 3] = tabla.int1;
                hoja.Cells[i + 1, 4] = tabla.int2;
                hoja.Cells[i + 1, 5] = tabla.int3;
                hoja.Cells[i + 1, 6] = tabla.varchar1;
                hoja.Cells[i + 1, 7] = tabla.varchar2;
                hoja.Cells[i + 1, 8] = tabla.varchar3;
                hoja.Cells[i + 1, 9] = tabla.dateTime1;
                hoja.Cells[i + 1, 10] = tabla.dateTime2;
                hoja.Cells[i + 1, 11] = tabla.dateTime3;
            }
            ArchivoExcel.Visible = true;
            libro.SaveAs("Excel" + tablaNumero);

        }
        
        public static void Buscar(List<string> variables, string nombreTabla, string Posicion, string Valor)
        {
            Dictionary<int, Tabla> tabla_solicitada = new Dictionary<int, Tabla>();
            Tabla pedido = new Tabla();
            Tabla tabla = new Tabla();
            List<Tabla> Resultado = new List<Tabla>();
            Resultado = DiccionarioTabla[nombreTabla];
            List<string> PosicionVariables = new List<string>();

            for (int i = 0; i < variables.Count; i++)
            {
                if (variables[0] != "*")
                {
                    PosicionVariables.Add(Variables[variables[i]]);
                }
            }

            if (Posicion != "")
            {
                int contadorPosicion = 0;
                tabla = Resultado[0];
                bool Encontrado = true;
                switch (Variables[Posicion])
                {
                    case "id":
                        while (Encontrado)
                        {
                            if (tabla.id==Valor)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosicion++;
                            }
                            tabla = Resultado[contadorPosicion];
                            
                        }
                        break;
                    case "int1":
                        while (Encontrado)
                        {
                            if (tabla.int1 == Valor)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosicion++;
                            }
                            tabla = Resultado[contadorPosicion];
                        }
                        break;
                    case "int2":
                        while (Encontrado)
                        {
                            if (tabla.int2 == Valor)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosicion++;
                            }
                            tabla = Resultado[contadorPosicion];
                        }
                        break;
                    case "int3":
                        while (Encontrado)
                        {
                            if (tabla.int3 == Valor)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosicion++;
                            }
                            tabla = Resultado[contadorPosicion];
                        }
                        break;
                    case "varchar1":
                        while (Encontrado)
                        {
                            if (tabla.varchar1 == Valor)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosicion++;
                            }
                            tabla = Resultado[contadorPosicion];
                        }
                        break;
                    case "varchar2":
                        while (Encontrado)
                        {
                            if (tabla.varchar2 == Valor)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosicion++;
                            }
                            tabla = Resultado[contadorPosicion];
                        }
                        break;
                    case "varchar3":
                        while (Encontrado)
                        {
                            if (tabla.varchar3 == Valor)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosicion++;
                            }
                            tabla = Resultado[contadorPosicion];
                        }
                        break;
                    case "dateTime1":
                        while (Encontrado)
                        {
                            if (tabla.dateTime1 == Valor)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosicion++;
                            }
                            tabla = Resultado[contadorPosicion];
                        }
                        break;
                    case "dateTime2":
                        while (Encontrado)
                        {
                            if (tabla.dateTime2 == Valor)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosicion++;
                            }
                            tabla = Resultado[contadorPosicion];
                        }
                        break;
                    case "dateTime3":
                        while (Encontrado)
                        {
                            if (tabla.dateTime3 == Valor)
                            {
                                Encontrado = false;
                            }
                            else
                            {
                                contadorPosicion++;
                            }
                            tabla = Resultado[contadorPosicion];
                        }
                        break;
                    default:
                        //variable no existe
                        break;
                }
                if (variables[0]!="*")//revisar posicion a ealuar podria ser variables[1]
                {
                    for (int i = 0; i < PosicionVariables.Count; i++)
                    {
                        switch (PosicionVariables[i])
                        {
                            case "id":
                                pedido.id=(tabla.id);//revisar que regresa solicitado
                                break;
                            case "int1":
                                pedido.int1=(tabla.int1);
                                break;
                            case "int2":
                                pedido.int2=(tabla.int2);
                                break;
                            case "int3":
                                pedido.int3=(tabla.int3);
                                break;
                            case "varchar1":
                                pedido.varchar1=(tabla.varchar1);
                                break;
                            case "varchar2":
                                pedido.varchar2=(tabla.varchar2);
                                break;
                            case "varchar3":
                                pedido.varchar3=(tabla.varchar3);
                                break;
                            case "dateTime1":
                                pedido.dateTime1=(tabla.dateTime1);
                                break;
                            case "dateTime2":
                                pedido.dateTime2=(tabla.dateTime2);
                                break;
                            case "dateTime3":
                                pedido.dateTime3=(tabla.dateTime3);
                                break;
                            default:
                                break;
                        }
                    }
                    Solicitado.Add(pedido);
                }
                else
                {
                    Solicitado.Add(tabla);
                }
                ResultadoVistas.Clear();
                for (int i = 0; i < Solicitado.Count(); i++)
                {
                    ResultadoVistas.Add(Solicitado[i]);
                }
                        
                //mostrar valores de la lista solicitado
            }
            else
            {
                if (variables[0] != "*")
                {
                    for (int i = 0; i < Resultado.Count; i++)
                    {
                        for (int j = 0; j < PosicionVariables.Count; j++)
                        {
                            tabla = Resultado[i];
                            switch (PosicionVariables[j])
                            {
                                case "id":
                                    pedido.id = (tabla.id);
                                    break;
                                case "int1":
                                    pedido.int1 = (tabla.int1);
                                    break;
                                case "int2":
                                    pedido.int2 = (tabla.int2);
                                    break;
                                case "int3":
                                    pedido.int3 = (tabla.int3);
                                    break;
                                case "varchar1":
                                    pedido.varchar1 = (tabla.varchar1);
                                    break;
                                case "varchar2":
                                    pedido.varchar2 = (tabla.varchar2);
                                    break;
                                case "varchar3":
                                    pedido.varchar3 = (tabla.varchar3);
                                    break;
                                case "dateTime1":
                                    pedido.dateTime1 = (tabla.dateTime1);
                                    break;
                                case "dateTime2":
                                    pedido.dateTime2 = (tabla.dateTime2);
                                    break;
                                case "dateTime3":
                                    pedido.dateTime3 = (tabla.dateTime3);
                                    break;
                                default:
                                    break;
                            }
                        }
                        tabla_solicitada.Add(i, pedido);
                    }
                }
                else
                {
                    for (int i = 0; i < Resultado.Count(); i++)
                    {
                        
                        if (Resultado[i].id != null)
                        {
                            pedido.id = Resultado[i].id;
                        }
                        if (Resultado[i].int1 != null)
                        {
                            pedido.int1 = Resultado[i].int1;
                        }
                        if (Resultado[i].int2 != null)
                        {
                            pedido.int2 = Resultado[i].int2;
                        }
                        if (Resultado[i].int3 != null)
                        {
                            pedido.int3 = Resultado[i].int3;
                        }
                        if (Resultado[i].varchar1 != null)
                        {
                            pedido.varchar1 = Resultado[i].varchar1;
                        }
                        if (Resultado[i].varchar2 != null)
                        {
                            pedido.varchar2 = Resultado[i].varchar2;
                        }
                        if (Resultado[i].varchar3 != null)
                        {
                            pedido.varchar3 = Resultado[i].varchar3;
                        }
                        if (Resultado[i].dateTime1 != null)
                        {
                            pedido.dateTime1 = Resultado[i].dateTime1;
                        }
                        if (Resultado[i].dateTime2 != null)
                        {
                            pedido.dateTime2 = Resultado[i].dateTime2;
                        }
                        if (Resultado[i].varchar3 != null)
                        {
                            pedido.dateTime3 = Resultado[i].varchar3;
                        }
                        tabla_solicitada.Add(i, pedido);
                    }
                }
                Resultado.Clear();
                for (int i = 0; i < tabla_solicitada.Count(); i++)
                {
                    ResultadoVistas.Add(tabla_solicitada[i]);
                }
               //mostrar solicitado 
            }
        }
        
        public static void Insertar(List<string>variables,string nombreTabla, List<string>valores)
        {
            ArbolB<Tabla> arbolInsertar = new ArbolB<Tabla>();
            Tabla tabla = new Tabla();
            List<Tabla> listaAgregar = new List<Tabla>();
            Dictionary<string, string> dicionarioVariables = new Dictionary<string, string>();
            dicionarioVariables = DiccionarioVariables[nombreTabla];
            List<string> listaVaribles = new List<string>();
            string tipoVariable;
            for (int i = 0; i < variables.Count(); i++)
            {
                tipoVariable = Variables[variables[i]];
                listaVaribles.Add(tipoVariable);
                switch (listaVaribles[i])
                {
                    case "id":
                        tabla.id = valores[i];
                        break;
                    case "int1":
                        tabla.int1 = valores[i];
                        break;
                    case "int2":
                        tabla.int2 = valores[i];
                        break;
                    case "int3":
                        tabla.int3 = valores[i];
                        break;
                    case "varchar1":
                        tabla.varchar1 = valores[i];
                        break;
                    case "varchar2":
                        tabla.varchar2 = valores[i];
                        break;
                    case "varchar3":
                        tabla.varchar3 = valores[i];
                        break;
                    case "dateTime1":
                        tabla.dateTime1 = valores[i];
                        break;
                    case "dateTime2":
                        tabla.dateTime2 = valores[i];
                        break;
                    case "dateTime3":
                        tabla.dateTime3 = valores[i];
                        break;
                    default:
                        break;
                }
            }

            listaAgregar = DiccionarioTabla[nombreTabla];
            DiccionarioTabla.Remove(nombreTabla);
            listaAgregar.Add(tabla);
            DiccionarioTabla.Add(nombreTabla, listaAgregar);
            arbolInsertar = Arboles[nombreTabla];
            Arboles.Remove(nombreTabla);
            arbolInsertar.Insertar(tabla, nombreTabla);
            ResultadoVistas.Clear();
            for (int i = 0; i < listaAgregar.Count(); i++)
            {
                ResultadoVistas.Add(listaAgregar[i]);
            }
            Arboles.Add(nombreTabla, arbolInsertar);
            int posicion = posicionTabla[nombreTabla];
            arraytablas[posicion] = listaAgregar;
            int tablaNumero = diccionarioNumeroTabla[nombreTabla];
            string nombre_archivo = "Tabla" + tablaNumero + ".txt";
            string pathfinal = nombre_archivo;
            using (StreamWriter outputFile = new StreamWriter(pathfinal))
            {
                for (int i = 0; i < listaAgregar.Count(); i++)
                {
                    tabla = listaAgregar[i];
                    outputFile.Write(tabla.nombre + ", " + tabla.id + ", " + tabla.int1 + ", " + tabla.int2 + ", " + tabla.int3 + ", ");
                    outputFile.Write(tabla.varchar1 + ", " + tabla.varchar2 + ", " + tabla.varchar3 + ", " + tabla.dateTime1 + ", ");
                    outputFile.Write(tabla.dateTime2 + ", " + tabla.dateTime3);
                    outputFile.WriteLine("");
                }               
            }

            Object opc = Type.Missing;
            Excel.Workbook libro;
            libro = ArchivoExcel.Workbooks.Add(opc);
            ArchivoExcel.Visible = false;
            libro = ArchivoExcel.Workbooks.Add(opc);
            Excel.Worksheet hoja = new Excel.Worksheet();
            hoja = (Excel.Worksheet)libro.Sheets.Add(opc, opc, opc, opc);
            hoja.Activate();
            int cantidadLineas = listaAgregar.Count();
            for (int i = 0; i < cantidadLineas; i++)
            {
                tabla = listaAgregar[i];
                hoja.Cells[i+1, 1] = tabla.nombre;
                hoja.Cells[i+1, 2] = tabla.id;
                hoja.Cells[i+1, 3] = tabla.int1;
                hoja.Cells[i+1, 4] = tabla.int2;
                hoja.Cells[i+1, 5] = tabla.int3;
                hoja.Cells[i+1, 6] = tabla.varchar1;
                hoja.Cells[i+1, 7] = tabla.varchar2;
                hoja.Cells[i+1, 8] = tabla.varchar3;
                hoja.Cells[i+1, 9] = tabla.dateTime1;
                hoja.Cells[i+1, 10] = tabla.dateTime2;
                hoja.Cells[i+1, 11] = tabla.dateTime3;
            }
            ArchivoExcel.Visible = true;
            libro.SaveAs("Excel" + tablaNumero);            
        }
    }
}
