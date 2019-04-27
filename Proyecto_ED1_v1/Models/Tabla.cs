using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_ED1_v1.Models
{
    public class Tabla
    {
        public static Dictionary<string, List<Tabla>> DiccionarioTabla = new Dictionary<string, List<Tabla>>();
        public static Dictionary<string, string> Variables = new Dictionary<string, string>();
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

        public static void CrearTabla(Tabla tabla, string nombre)
        {            
            Variables.Add(tabla.int1,"int1");
            Variables.Add(tabla.int2,"int2");
            Variables.Add(tabla.int3,"int3");
            Variables.Add(tabla.id,"id");
            Variables.Add(tabla.varchar1, "varchar1");
            Variables.Add(tabla.varchar2, "varchar2");
            Variables.Add(tabla.varchar3, "varchar3");
            Variables.Add(tabla.dateTime1, "dateTime1");
            Variables.Add(tabla.dateTime2, "dateTime2");
            Variables.Add(tabla.dateTime3, "dateTime3");
            List<Tabla> Tabla = new List<Tabla>();
            Tabla.Add(tabla);            
            DiccionarioTabla.Add(nombre, Tabla);
        }
        public static void ElimiarTabla(string Clave)
        {
            DiccionarioTabla.Remove(Clave);
        }

        public static void EliminarElemento(string Llave, string variable, string nombre)
        {
            Tabla tabla = new Tabla();
            List < Tabla > eliminando= new List<Tabla>();
            eliminando = DiccionarioTabla[Llave];
            bool Encontrado = true;
            int contadorPosiciones = 0;
            switch (Variables[variable])
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
                    break;
                default:
                    //mensaje error en varibale 
                    break;
            }            
            DiccionarioTabla.Remove(Llave);
            eliminando.Remove(tabla);
            DiccionarioTabla.Add(Llave, eliminando);            
        }

    }
}
