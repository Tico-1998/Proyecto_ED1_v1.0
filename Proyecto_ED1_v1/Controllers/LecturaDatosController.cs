using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Proyecto_ED1_v1.Models;


namespace Proyecto_ED1_v1.Controllers
{
    public class LecturaDatosController : Controller
    {
        [HttpGet]
        public ActionResult MostrarResultadosBusqueda()
        {
            return View();//agregar lista solicitado Tabla.Buscar.Solicitado);
        }

        public static string[] lectura;
        static Tabla tabla = new Tabla();
        public static List<string> Lectura = new List<string>();
        public static string texto { get; set; }

        public static void Leer(string[] textoIngresado)
        {
            //leer texto 
            //guardar texto en variable 

            //contar lineas
            String fileName=Path.GetFullPath("Palabra_Reservadas.txt");
            Sintaxis.LeerArchivo(fileName);

            for (int i = 0; i < textoIngresado.Length; i++)
            {
                Lectura.Add(textoIngresado[i]);
            }
            if (textoIngresado.Length<=12)
            {
                char caracter = Convert.ToChar('\r');
                int cantidadLectura = Lectura.Count() - 1;
                lectura = Lectura[cantidadLectura].Split(caracter);
                caracter = '\n';
                for (int i = 0; i < lectura.Length; i++)
                {
                    lectura[i] = lectura[i].TrimEnd(caracter);
                    lectura[i] = lectura[i].TrimStart(caracter);
                }

                int contadorLineas = textoIngresado.Length;
                if (lectura[0] == Sintaxis.CreateTable)
                {
                    int cantidadLineas = lectura.Count() - 1;
                    CreateTableEnter(cantidadLineas);
                }
                else if (lectura[0] == Sintaxis.DropTable)
                {
                    DropTableEnter();
                }
                else if (lectura[0] == Sintaxis.Delete)
                {
                    DeleteEnter();
                }
                else if (lectura[0] == Sintaxis.Select)
                {
                    SelectEnter();
                }
                else if (lectura[0] == Sintaxis.InsertInto)
                {
                    InsertIntoEnter();
                }
            }
            else
            {
                //crear else de textoIngresado sin /n
            }
        }
        #region Create table
        static public void CreateTableEnter(int contadorLineas)
        {
            int contador = 3;
            int contadorInt = 0;
            int ContadorVarChar = 0;
            int ContadorDateTime = 0;
            string Llave = lectura[1];
            while (contador<contadorLineas)
            {
                string[] separador;
                separador = lectura[contador].Split(' ');
                int contadorID = 0;
                if (separador[0]=="ID"&&contadorID<1||separador[0]=="Id"&&contadorID<1||separador[0]=="id"&&contadorID<1)
                {
                    tabla.id = separador[0];
                    contadorID++;
                }
                else if (separador[1]=="INT"||separador[1]=="Int"||separador[1]=="int")
                {
                    if (contadorInt==0)
                    {
                        tabla.int1 = separador[0];
                        contadorInt++;
                    }
                    else if (contadorInt==1)
                    {
                        tabla.int2 = separador[0];
                        contadorInt++;
                    }
                    else if (contadorInt==2)
                    {
                        tabla.int3 = separador[0];
                        contadorInt++;
                    }
                    else
                    {
                        //mensaje se supero la cantidad de INT
                    }
                }
                else if (separador[1]=="VARCHAR(100)"||separador[1]=="VarChar(100)"||separador[1]=="Varchar(100)"||separador[1]=="varchar(100)")
                {
                    if (ContadorVarChar==0)
                    {
                        tabla.varchar1 = separador[0];
                        ContadorVarChar++;
                    }
                    else if (ContadorVarChar==1)
                    {
                        tabla.varchar2 = separador[0];
                        ContadorVarChar++;
                    }
                    else if (ContadorVarChar==2)
                    {
                        tabla.varchar3 = separador[0];
                        ContadorVarChar++;
                    }
                    else
                    {
                        //mensaje se supero la cantidad de varchar
                    }
                }
                else if (separador[1]=="DATETIME"||separador[1]=="DateTime"||separador[1]=="Datetime"||separador[1]=="datetime")
                {
                    if (ContadorDateTime==0)
                    {
                        tabla.dateTime1 = separador[0];
                        ContadorDateTime++;
                    }
                    else if (ContadorDateTime==1)
                    {
                        tabla.dateTime2 = separador[0];
                        ContadorDateTime++;
                    }
                    else if (ContadorDateTime==2)
                    {
                        tabla.dateTime3 = separador[0];
                        ContadorDateTime++;
                    }
                    else
                    {
                        //mensaje se supero la cantidad de datetime
                    }
                }
                else
                {
                    //mensaje tipo de variable no valida
                }
                contador++;
            }
            Tabla.CrearTabla(tabla, Llave);
        }
        public void CreateTable()
        {
            int contadorInt = 0;
            int ContadorVarChar = 0;
            int ContadorDateTime = 0;
            string[] Separado;
            Separado = Lectura[0].Split(' ');
            string Llave = Separado[3];
            int contadorPalabra = 5;
            while (contadorPalabra == Separado.Length)
            {
                if (Separado[contadorPalabra] == "ID")
                {
                    tabla.id = Separado[contadorPalabra];
                    contadorPalabra++;
                }
                if (Separado[contadorPalabra] == "Int" || Separado[contadorPalabra] == "INT" || Separado[contadorPalabra] == "int")
                {
                    if (Separado[contadorPalabra - 1] != "ID")
                    {
                        if (contadorInt == 0)
                        {
                            tabla.int1 = Separado[contadorPalabra - 1];
                            contadorPalabra++;
                        }
                        else if (contadorInt == 1)
                        {
                            tabla.int2 = Separado[contadorPalabra - 1];
                            contadorPalabra++;
                        }
                        else if (contadorInt == 2)
                        {
                            tabla.int3 = Separado[contadorPalabra - 1];
                            contadorPalabra++;
                        }
                        else
                        {
                            //mensaje maximo int superado
                        }
                    }
                    else
                    {
                        contadorPalabra++;
                    }
                }
                else if (Separado[contadorPalabra] == "VARCHAR(100)" || Separado[contadorPalabra] == "VarChar(100)" ||
                    Separado[contadorPalabra] == "Varchar(100)" || Separado[contadorPalabra] == "varchar(100)")
                {
                    if (ContadorVarChar==0)
                    {
                        tabla.varchar1 = Separado[contadorPalabra - 1];
                        contadorPalabra++;
                    }
                    else if (ContadorVarChar==1)
                    {
                        tabla.varchar2 = Separado[contadorPalabra - 1];
                        contadorPalabra++;
                    }
                    else if (ContadorVarChar==2)
                    {
                        tabla.varchar3 = Separado[contadorPalabra - 1];
                        contadorPalabra++;
                    }
                    else
                    {
                        //mensaje maximo varchar superado
                    }
                }
                else if (Separado[contadorPalabra]=="DATETIME"||Separado[contadorPalabra]=="DateTime"||
                    Separado[contadorPalabra] == "Datetime"||Separado[contadorPalabra]=="datetime")
                {
                    if (ContadorDateTime==0)
                    {
                        tabla.dateTime1 = Separado[contadorPalabra - 1];
                        contadorPalabra++;
                    }
                    else if (ContadorDateTime==1)
                    {
                        tabla.dateTime2 = Separado[contadorPalabra - 1];
                        contadorPalabra++;
                    }
                    else if (ContadorDateTime==2)
                    {
                        tabla.dateTime3 = Separado[contadorPalabra - 1];
                        contadorPalabra++;
                    }
                    else
                    {
                        //mensaje maximo datetime superado
                    }
                }
            }
            tabla.nombre = Llave;
            Tabla.CrearTabla(tabla, Llave);

        }
        #endregion

        #region Drop table
        static public void DropTableEnter()
        {
            string Llave = lectura[1];
            Llave = Llave.Trim();
            Tabla.ElimiarTabla(Llave);
        }

        public void DropTable()
        {
            string[] Separado;
            Separado = Lectura[0].Split(' ');
            string Llave = Separado[3];
            Tabla.ElimiarTabla(Llave);
        }

        #endregion

        #region Delete
        static public void DeleteEnter()
        {
            string Llave = lectura[1];
            string[] Separado;
            Separado = lectura[3].Split('=');
            for (int i = 0; i < Separado.Count(); i++)
            {
                Separado[i] = Separado[i].Trim();
            }
            string variable = Separado[0];
            string valor = Separado[1];
            Tabla.EliminarElemento(Llave, variable, valor);
        }

        public void Delete()
        {
            string[] Separado;
            Separado = Lectura[0].Split(' ');
            string Llave = Separado[3];
            string variable = Separado[5];
            string valor = Separado[7];
            Tabla.EliminarElemento(Llave, variable, valor);
        }

        #endregion

        #region Select
        static public void SelectEnter()
        {
            string AuxiliarVariable;//esta variable ayuda a elimar las , de los string para guardarlos en la lista
            List<string> Variable = new List<string>();
            int contadorVariables = 1;
            if (lectura[1]!="*")
            {
                
                while ((lectura[contadorVariables]!=Sintaxis.From))
                {
                    AuxiliarVariable = lectura[contadorVariables].TrimEnd(',');
                    Variable.Add(AuxiliarVariable);
                    contadorVariables++;
                }
                
            }
            else
            {
                Variable.Add("*");
                contadorVariables++;
            }
            contadorVariables++;
            string nombreTabla = lectura[contadorVariables];
            nombreTabla = nombreTabla.Trim();
            string Posicion="";
            string valor="";
            int cantidad_lectura = lectura.Count()-1;
            if (cantidad_lectura>contadorVariables+1)
            {
                contadorVariables += 2;
                if (lectura[contadorVariables] != null)
                {
                    string[] Separado;
                    Separado = lectura[contadorVariables].Split('=');
                    Posicion = Separado[0].Trim();
                    valor = Separado[1].Trim();
                }
            }
            Tabla.Buscar(Variable, nombreTabla, Posicion, valor);
        }

        public void Select()
        {
            //hacer metodo para leer en una linea 
        }

        #endregion

        #region Insert Into
        public static void InsertIntoEnter()
        {
            List<string> variables = new List<string>();
            List<string> valores = new List<string>();
            string Llave = lectura[1];
            int posicin = 3;
            int cantidadVaribles = 0;
            while (lectura[posicin]!=")")
            {
                lectura[posicin] = lectura[posicin].TrimEnd(',');
                variables.Add(lectura[posicin]);
                posicin++;
                cantidadVaribles++;
            }
            if (lectura[posicin+1]==Sintaxis.Values)
            {
                posicin += 3;
                for (int i = 0; i < cantidadVaribles; i++)
                {
                    lectura[posicin] = lectura[posicin].TrimEnd(',');
                    valores.Add(lectura[posicin]);
                    posicin++;
                }
            }
            Tabla.Insertar(variables,Llave,valores);
        }
        #endregion
    }
}