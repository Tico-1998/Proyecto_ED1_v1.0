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
        Tabla tabla = new Tabla();
        public IActionResult Index()
        {

            return View();
        }
        public static List<string> Lectura = new List<string>();
        public void Leer()
        {
            //leer texto 
            //guardar texto en variable 
            string textoIngresado = "";
            //contar lineas

           
            if (textoIngresado.Contains('\n'))
            {
                string[] Introducir;
                Introducir = textoIngresado.Split('\n');
                for (int i = 0; i < Introducir.Length; i++)
                {
                    Lectura.Add(Introducir[i]);
                }
                int contadorLineas = Introducir.Length;
                switch (Lectura[0])
                {
                    case "CREATE TABLE":
                        break;
                    case "DROP TABLE":
                        break;
                    case "DELETE":
                        break;
                    case "SELECT":
                        break;
                    case "INSERT INTO":
                        break;
                    default:
                        break;
                }

            }
        }
        #region Create table
        public void CreateTableEnter(int contadorLineas)
        {
            int contador = 3;
            int contadorInt = 0;
            int ContadorVarChar = 0;
            int ContadorDateTime = 0;
            string Llave = Lectura[1];
            while (contador<contadorLineas-1)
            {
                string[] separador;
                separador = Lectura[contador].Split(' ');
                int contadorID = 0;
                if (separador[0]=="ID"&&contadorID<1)
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
            Tabla.CrearTabla(tabla, Llave);

        }
        #endregion

        #region Drop table
        public void DropTableEnter()
        {
            string Llave = Lectura[1];
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
        public void DeleteEnter()
        {
            string Llave = Lectura[1];
            string[] Separado;
            Separado = Lectura[4].Split(' ');
            string variable = Separado[0];
            string valor = Separado[2];
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
        public void SelectEnter()
        {
            string AuxiliarVariable;//esta variable ayuda a elimar las , de los string para guardarlos en la lista
            List<string> Variable = new List<string>();
            int contadorVariables = 1;
            if (Lectura[1]!="*")
            {
                
                while (Lectura[contadorVariables]!="FROM"||Lectura[contadorVariables]!="From"||Lectura[contadorVariables]!="from")
                {
                    AuxiliarVariable = Lectura[contadorVariables].TrimEnd(',');
                    Variable.Add(AuxiliarVariable);
                    contadorVariables++;
                }
                
            }
            else
            {
                Variable.Add("*");
            }
            contadorVariables++;
            string nombreTabla = Lectura[contadorVariables];
            string Posicion="";
            string valor="";
            if (Lectura[contadorVariables + 1] != null)
            {
                contadorVariables += 2;
                if (Lectura[contadorVariables] != null)
                {
                    string[] Separado;
                    Separado = Lectura[contadorVariables].Split(' ');
                    Posicion = Separado[0];
                    valor = Separado[2];
                }
            }
            Tabla.Buscar(Variable, nombreTabla, Posicion, valor);
        }

        public void Select()
        {
            //hacer metodo para leer en una linea 
        }

        #endregion
    }
}