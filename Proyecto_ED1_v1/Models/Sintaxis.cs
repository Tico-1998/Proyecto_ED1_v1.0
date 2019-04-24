using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_ED1_v1.Models
{
    //Pendiente creaqr formulario para cambiar palabras reservadas (VISTA)
    public class Sintaxis
    {
        string Select = "Select";
        string From = "From";
        string Delete = "Delete";
        string Where = "Where";
        string CreateTable = "Create Table";
        string DropTable = "Drop Table";
        string InsertInto = "Insert into";
        string Values = "Values";
        string Go = "Go";

        void LeerArchivo()
        {
            //expresiones regulares 
            try
            {
                string Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Archivo.txt";
                StreamReader streamReader = System.IO.File.OpenText(Path);
                using (StreamReader stream_Reader = System.IO.File.OpenText(Path))
                {
                    string Linea=stream_Reader.ReadLine();
                    while (Linea!=null)
                    {
                        if (Linea!="")
                        {
                            Select = Linea.Split('=')[0];
                            Select = Select.Trim();
                            From = Linea.Split('=')[1];
                            From = From.Trim();
                            Delete = Linea.Split('=')[2];
                            Delete = Delete.Trim();
                            Where = Linea.Split('=')[3];
                            Where = Where.Trim();
                            CreateTable = Linea.Split('=')[4];
                            CreateTable = CreateTable.Trim();
                            DropTable = Linea.Split('=')[5];
                            DropTable = DropTable.Trim();
                            InsertInto = Linea.Split('=')[6];
                            InsertInto = InsertInto.Trim();
                            Values = Linea.Split('=')[7];
                            Values = Values.Trim();
                            Go = Linea.Split('=')[8];
                            Go = Go.Trim();
                        }
                    }
                }
            }
            catch (Exception)//terminar catch
            {

                throw;
            }
            

        }
    }    
}
