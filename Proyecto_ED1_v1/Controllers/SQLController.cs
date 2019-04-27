using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;


namespace Proyecto_ED1_v1.Controllers
{
    public class SQLController : Controller
    {
        // GET: SQL
        public ActionResult Index()
        {
            return View();
        }

        // GET: SQL/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SQL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SQL/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SQL/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SQL/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SQL/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SQL/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public void LeerSQL()
        {
            /*
            Regex RegexSelect = new Regex($".*\"SELECT\".*" "\\n" ^['a' - 'z', 'A' - 'Z']['a' - 'z', 'A' - 'Z', 0 - 9],RegexOptions.Singleline);//revisar los parentesis
            
            Regex RegexFrom = new Regex(".*(\"FROM\").*"\r\n ^['a' - 'z', 'A' - 'Z']['a' - 'z', 'A' - 'Z', 0 - 9]);
            Regex RegexDelete = new Regex(.*("DELETE").*"\n" ^['a' - 'z', 'A' - 'Z']['a' - 'z', 'A' - 'Z', 0 - 9]);
            Regex RegexWHERE = new Regex(.*("WHERE").*"\n" ^['a' - 'z', 'A' - 'Z']['a' - 'z', 'A' - 'Z', 0 - 9]);
            Regex RegexCreate = new Regex(.*("CREATE TABLE").*"\n" ^['a' - 'z', 'A' - 'Z']['a' - 'z', 'A' - 'Z', 0 - 9]);
            Regex RegexDrop = new Regex(.*("DROP TABLE").*"\n" ^['a' - 'z', 'A' - 'Z']['a' - 'z', 'A' - 'Z', 0 - 9]);
            Regex RegexInsert = new Regex(.*("INSERT INTO").*"\n" ^['a' - 'z', 'A' - 'Z']['a' - 'z', 'A' - 'Z', 0 - 9]);
            Regex RegexValues = new Regex(.*("VALUES").*"\n" ^['a' - 'z', 'A' - 'Z']['a' - 'z', 'A' - 'Z', 0 - 9]);
            Regex RegexGo = new Regex(.*("GO").*"\n" ^'a' - 'z', 'A' - 'Z','a' - 'z', 'A' - 'Z', 0 - 9);//revisar si sirve
            */
            //despues de leer SQL
            //agregar valores en lista 

            //guardar en lista 
            List<string> SqlIngresado = new List<string>();
            //escribir siempre sobre estas varibales
            string SQLIngesadoLINEA1 = "";
            string SQLIngresadoLinea2 = "";
            string SQLIngresadoLinea3 = "";
            string SQLIngresadoLinea4 = "";
            string SQLIngresadoLinea5 = "";
            string SQLIngresadoLinea6 = "";
            string SQLIngresadoLinea7 = "";
            string SQLIngresadoLinea8 = "";
            string SQLIngresadoLinea9 = "";            
            int cantidadLineas = 9;
            int contador = -1;

            SqlIngresado.Add(SQLIngesadoLINEA1);
            SqlIngresado.Add(SQLIngresadoLinea2);
            SqlIngresado.Add(SQLIngresadoLinea3);
            SqlIngresado.Add(SQLIngresadoLinea4);
            SqlIngresado.Add(SQLIngresadoLinea5);
            SqlIngresado.Add(SQLIngresadoLinea6);
            SqlIngresado.Add(SQLIngresadoLinea7);
            SqlIngresado.Add(SQLIngresadoLinea8);
            SqlIngresado.Add(SQLIngresadoLinea9);

            switch (SqlIngresado[0])
            {
                case "CREATE TABLE":
                    RegexCreateTable();
                    break;
                case "DROP TABLE":
                    RegexDropTable();
                    break;
                case "DELETE":
                    RegexDelete();
                    break;
                case "SELECT":
                    RegexSelect();
                    break;
                case "INSERT INTO":
                    RegexInsert();
                    break;                    
                default:
                    break;
            }


            ///el metodo recibe los valores de RegexCreateTable y valida si son correctos 
            void ValidarVariables(string sqlIngresado, int contadorInt, int contadorVarchar, int contadorDatetime)//revisar si funciona la recursividad
            {//asignar valorea a variables 
                if (contador < cantidadLineas-1)
                {
                    //casos sin , ver si es necesario validarla 
                    string Patron5v1 = "^['a'-'z','A'-'Z']['a'-'z','A'-'Z',0-9,_,-]{4}\\s[VARCHAR(100)]{12}";//v1 de version 1 de las 3 posibles varchar, int, datetime
                    string Patron5v2 = "^['a'-'z','A'-'Z']['a'-'z','A'-'Z',0-9,_,-]{4}\\s[INT]{3}";
                    string Patron5v3 = "^['a'-'z','A'-'Z']['a'-'z','A'-'Z',0-9,_,-]{4}\\s[DATETIME]{8}";
                    if (Regex.IsMatch(sqlIngresado, Patron5v1))
                    {//varchar
                        if (contadorVarchar == 3)
                        {
                            //mensaje error maximo varchar alcanzado
                        }
                        else
                        {
                            string prueba = "◙,○, ";
                            contador++;
                            contadorVarchar++;
                            ValidarVariables(SqlIngresado[contador++], contadorInt, contadorVarchar, contadorDatetime);
                        }
                    }
                    else if (Regex.IsMatch(sqlIngresado, Patron5v2))
                    {//int
                        if (contadorInt == 3)
                        {
                            //mensaje error amximo int alcanzado
                        }
                        else
                        {
                            contador++;
                            contadorInt++;
                            ValidarVariables(SqlIngresado[contador++], contadorInt, contadorVarchar, contadorDatetime);
                        }
                    }
                    else if (Regex.IsMatch(sqlIngresado, Patron5v3))
                    {//datetime
                        if (contadorDatetime == 3)
                        {
                            //mensaje error maximo datetime alcanzado
                        }
                        else
                        {
                            contador++;
                            contadorDatetime++;
                            ValidarVariables(SqlIngresado[contador++], contadorInt, contadorVarchar, contadorDatetime);
                        }
                    }
                    else
                    {
                        //mensaje error sintaxis
                    }
                }
                else if (contador<cantidadLineas)
                {
                    string patronFinal = "[\\)]";
                    if (Regex.IsMatch(SQLIngresadoLinea9,patronFinal))
                    {
                        //metodo crear arbol o salir del metodo crear arbol afuera
                    }
                    else
                    {
                        //mensaje error de sintaxis 
                    }
                }
            }
            ///Revisa sintaxis para crear tabla 
            void RegexCreateTable()
            {//asignar valores a variables 
                int contadorInt = 0;
                int contadorVarChar = 0;
                int contadorDateTime = 0;
                //Falta validar varias variables
                string PatronCompleto = ".*(CREATE TABLE).*[ ,\n]+^[a-zA-Z][a-zA-Z,0-9,_,-]+[ ,\n][(]{1}[ ,\n][ID]{2}\\s[a-zA-Z,(,),0,1, ]+[,]{1}[ ," +
                    "\n][a-zA-Z][a-zA-Z,0-9,_,-]+\\s[a-zA-Z,(,),0,1, ]+[,]{1}[ ,\n][)]{1}";
                
                string Patron = ".*\"CREATE TABLE\".*";//revisar si acepta el patron
                if (Regex.IsMatch(SQLIngesadoLINEA1, Patron))
                {
                    contador++;
                    string Patron2 = "^['a'-'z','A'-'Z']['a'-'z','A'-'Z',0-9,_,-]";
                    if (Regex.IsMatch(SQLIngresadoLinea2, Patron2))
                    {
                        contador++;
                        string Patron3 = "[(]";//revisar si no es \\(
                        if (Regex.IsMatch(SQLIngresadoLinea3, Patron3))
                        {
                            contador++;
                            string Patron4 = "[ID]{2}\\s[INT]{3}\\s^['a'-'z','A'-'Z']['a'-'z','A'-'Z',0-9,_,-]{4}";//cambiar numero de caracteres del string
                            if (Regex.IsMatch(SQLIngresadoLinea4, Patron4))
                            {
                                contador++;
                                ValidarVariables(SqlIngresado[contador++],contadorInt,contadorVarChar,contadorDateTime);                                
                            }
                            else
                            {
                                //mensaje error de sintaxis o en el nombre de la variable
                            }
                        }
                        else
                        {
                            //mensaje error en estructura de sintaxis
                        }
                    }
                    else
                    {
                        //mensaje nombre de tabla errorneo
                    }

                    //Llamar metodo de crear arbol 
                }
            }
            
            void RegexDropTable()
            {
                string intentoPatronCompleto = ".*(DROP TABLE).*[ \n]+^[a-zA-Z][a-zA-Z0-9_-]+";
                string patro1 = ".*DROP TABLE.*";
                if (Regex.IsMatch(SQLIngesadoLINEA1,intentoPatronCompleto))
                {
                    //revisar si existen las variables y llamr al metodo
                }
                else
                {
                    //error en sintaxis o nombre de tabla
                }
                /*if (Regex.IsMatch(SQLIngesadoLINEA1,patro1))
                {
                    string patron2 = "^['a'-'z','A'-'Z']['a'-'z','A'-'Z',0-9,-,_]";
                    if (Regex.IsMatch(SQLIngresadoLinea2,patron2))
                    {
                        //revisar si la variable existe y llamar al metodo
                    }
                    else
                    {
                        //error en sintaxis o nombre de tabla
                    }
                }*/
            }

            void RegexDelete()
            {
                string Del = "DELETE FROM";
                string patron1 = ".*"+Del+".*";
                string PatronCompleto = ".*(DELETE FROM).*[ ,\n]+^[a-z,A-Z][a-z,A-Z,0-9,-,_]+[ ,\n].*(WHERE).*[ ,\n]+[ID]{2}\\s[=]\\s[0-9]+";
                if (Regex.IsMatch(SQLIngesadoLINEA1,patron1))
                {
                    string patron2 = "^['a'-'z','A'-'Z']['a'-'z','A'-'Z',0-9,_,-]{4}";
                    if (Regex.IsMatch(SQLIngresadoLinea2,patron2))
                    {
                        string patron3 = ".*WHERE.*";
                        if (Regex.IsMatch(SQLIngresadoLinea3,patron3))
                        {
                            string patron4 = "[ID]{2}\\s[=]\\s[0-9]{1}";//cambiar numero de caracteres
                            if (Regex.IsMatch(SQLIngresadoLinea4,patron4))
                            {
                                //llamar al metodo de eliminar y verifica si existe la tabla y la variable 
                            }
                            else
                            {
                                //mensaje error sintaxis o nombre de variable incorrecto 
                            }
                        }
                        else
                        {
                            // mensaje sintaxis incorrecta
                        }
                    }
                    else
                    {
                        //mensaje error en el nombre de la tabla 
                    }
                }
            }
           
            void RegexSelect()
            {//se busca solo con 1 o con todos?
                string patron1 = ".*SELECT.*";
                string PatronCompleto = ".*(SELECT).*[ ,\n]+^[a-zA-Z][a-zA-Z,0-9,_,-]+[ ,\n].*(FROM).*[ ,\n]^[a-zA-Z]" +
                    "[a-zA-Z,0-9,_,-][ ,\n].*(WHERE).*^[a-zA-Z][a-zA-Z,0-9,-,_]+\\s[=]\\s^[a-zA-Z][a-zA-Z,_,-]";
                if (Regex.IsMatch(SQLIngesadoLINEA1,patron1))
                {
                    string patron2 = "^[a-z,A-Z][a-z,A-Z,0-9,_,-]";
                    if (Regex.IsMatch(SQLIngresadoLinea2,patron2))
                    {//revisar si hay que pedir todos los datos para eliminar 
                        string patron3 = ".*FROM.*";
                        if (Regex.IsMatch(SQLIngresadoLinea3,patron3))
                        {
                            string patron4 = "^[a-zA-Z][a-zA-Z0-9_-]{4}";
                            if (Regex.IsMatch(SQLIngresadoLinea4,patron4))
                            {
                                //validar si la variable y la tabla existe y llamar al metodo
                            }
                            else
                            {
                                //mensaje error al ingresar nombre de tabla
                            }
                        }
                        else
                        {
                            //mensaje error de sintaxis 
                        }
                    }
                    else
                    {
                        //mensaje error al ingresar variable
                    }
                }
            }

            void RegexInsert()
            {
                //pendiente leer todas las columnas y variables
                //validar que se esta comparando 
                string PatronCompleto = ".*(INSERT INTO).*[a-zA-Z][a-zA-Z,0-9,_,-]+[(]{1}[ID,]" +
                    "{3}[ ,\n][a-z,A-Z][a-zA-Z,0-9,-,_]+  [)]{1}.*(VALUES).*[(]{1}[0-9]+[,]{1}[ ,\n]" +
                    "[']{1}[a-zA-Z][a-zA-Z,0-9,-,_,/]+[']{1}[ ,/n]  [)]{1}";
                if (Regex.IsMatch(SqlIngresado[0],PatronCompleto))
                {
                    //llamar metodo de insertar
                }
                else
                {
                    //mensaje error en sintaxis o en variables 
                }
            }
        }

    }
}