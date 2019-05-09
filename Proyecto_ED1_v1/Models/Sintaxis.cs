using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Proyecto_ED1_v1.Controllers;

namespace Proyecto_ED1_v1.Models
{
    //Pendiente creaqr formulario para cambiar palabras reservadas (VISTA)
    public class Sintaxis
    {
        public static string Select = "Select";
        public static string From = "From";
        public static string Delete = "Delete";
        public static string Where = "Where";
        public static string CreateTable = "Create Table";
        public static string DropTable = "Drop Table";
        public static string InsertInto = "Insert into";
        public static string Values = "Values";
        public static string Go = "Go";
        public static string mensaje;

        public static void LeerArchivo(string path)
        {
            //expresiones regulares 
            try
            {
                using (StreamReader stream_Reader = System.IO.File.OpenText(path))
                {
                    string Linea=stream_Reader.ReadLine();
                    string[] separado;
                    int numeroLinea = 0;
                    while (Linea!=null)
                    {
                        if (Linea!="")
                        {
                            if (numeroLinea==0)
                            {
                                separado = Linea.Split('=');
                                Select = separado[1];
                            }
                            else if (numeroLinea==1)
                            {
                                separado = Linea.Split('=');
                                From = separado[1];
                            }
                            else if (numeroLinea==2)
                            {
                                separado = Linea.Split('=');
                                Delete = separado[1];
                            }
                            else if (numeroLinea==3)
                            {
                                separado = Linea.Split('=');
                                Where = separado[1];
                            }
                            else if (numeroLinea==4)
                            {
                                separado = Linea.Split('=');
                                CreateTable = separado[1];
                            }
                            else if (numeroLinea==5)
                            {
                                separado = Linea.Split('=');
                                DropTable = separado[1];
                            }
                            else if (numeroLinea==6)
                            {
                                separado = Linea.Split('=');
                                InsertInto = separado[1];
                            }
                            else if (numeroLinea==7)
                            {
                                separado = Linea.Split('=');
                                Values = separado[1];
                            }
                            else if (numeroLinea==8)
                            {
                                separado = Linea.Split('=');
                                Go = separado[1];
                            }
                        }
                        numeroLinea++;
                    }
                }
            }
            catch (Exception ex)//terminar catch
            {

                string mensaje = Convert.ToString(ex);
                   
            }
            

        }
    }    
}
