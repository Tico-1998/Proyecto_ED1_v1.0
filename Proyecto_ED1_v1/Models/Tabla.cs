using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_ED1_v1.Models
{
    public class Tabla
    {
        public string TextoIngresado = "";
        public static Dictionary<string, List<Tabla>> DiccionarioTabla = new Dictionary<string, List<Tabla>>();
        public static Dictionary<string, string> Variables = new Dictionary<string, string>();//la llave es el nombre de la variable, el valor es cual variable es 
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
        public static void prueba(string prueba)
        {
            Console.WriteLine(prueba);
            Console.ReadKey();
        }
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
            List<Tabla> eliminando = new List<Tabla>();
            eliminando = DiccionarioTabla[Llave];//se optiene la lista correcta
            bool Encontrado = true;
            int contadorPosiciones = 0;
            tabla = eliminando[0];
            switch (Variables[variable])//diccionario que guarda las variables 
            {
                case "id":
                    while (Encontrado)
                    {
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
            DiccionarioTabla.Remove(Llave);
            eliminando.Remove(tabla);
            DiccionarioTabla.Add(Llave, eliminando);
        }
        public static void Buscar(List<string> variables, string nombreTabla, string Posicion, string Valor)
        {
            Tabla tabla = new Tabla();
            List<Tabla> Resultado = new List<Tabla>();
            Resultado = DiccionarioTabla[nombreTabla];
            List<string> PosicionVariables = new List<string>();
            List<string> Solicitado = new List<string>();
            for (int i = 0; i < variables.Count - 1; i++)
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
                if (variables[0]!="*")
                {
                    for (int i = 0; i < PosicionVariables.Count - 1; i++)
                    {
                        switch (PosicionVariables[i])
                        {
                            case "id":
                                Solicitado.Add(tabla.id);
                                break;
                            case "int1":
                                Solicitado.Add(tabla.int1);
                                break;
                            case "int2":
                                Solicitado.Add(tabla.int2);
                                break;
                            case "int3":
                                Solicitado.Add(tabla.int3);
                                break;
                            case "varchar1":
                                Solicitado.Add(tabla.varchar1);
                                break;
                            case "varchar2":
                                Solicitado.Add(tabla.varchar2);
                                break;
                            case "varchar3":
                                Solicitado.Add(tabla.varchar3);
                                break;
                            case "dateTime1":
                                Solicitado.Add(tabla.dateTime1);
                                break;
                            case "dateTime2":
                                Solicitado.Add(tabla.dateTime2);
                                break;
                            case "dateTime3":
                                Solicitado.Add(tabla.dateTime3);
                                break;
                            default:
                                break;
                        }
                    }       
                }
                else
                {
                    //mostrar todos los valores de tabla
                }
                //mostrar valores de la lista solicitado
            }
            else
            {
                for (int i = 0; i < Resultado.Count-1; i++)
                {
                    tabla = Resultado[i];
                    for (int j = 0; j < PosicionVariables.Count - 1; j++)
                    {
                        switch (PosicionVariables[i])
                        {
                            case "id":
                                Solicitado.Add(tabla.id);
                                break;
                            case "int1":
                                Solicitado.Add(tabla.int1);
                                break;
                            case "int2":
                                Solicitado.Add(tabla.int2);
                                break;
                            case "int3":
                                Solicitado.Add(tabla.int3);
                                break;
                            case "varchar1":
                                Solicitado.Add(tabla.varchar1);
                                break;
                            case "varchar2":
                                Solicitado.Add(tabla.varchar2);
                                break;
                            case "varchar3":
                                Solicitado.Add(tabla.varchar3);
                                break;
                            case "dateTime1":
                                Solicitado.Add(tabla.dateTime1);
                                break;
                            case "dateTime2":
                                Solicitado.Add(tabla.dateTime2);
                                break;
                            case "dateTime3":
                                Solicitado.Add(tabla.dateTime3);
                                break;
                            default:
                                break;
                        }
                    }
                }
               //mostrar solicitado 
            }
        }
        //metodo agregar

    }
}
