using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_ED1_v1.Models
{

    public delegate int compareTo<T>(T Tabla,T Valor);
    

    public class ArbolBNodo<T>
    {
        public ArbolBNodo()
        {
            Valores = new T[5];
            Hijo = new ArbolBNodo<T>[5];
            Cuenta = 0;
        }
        public T[] Valores { get; set; }
        public ArbolBNodo<T>[] Hijo { get; set; }
        public int Cuenta { get; set; }
    }//Fin clase nodo arbol B

    public class ArbolB<T>
    {
        public Lazy<List<T>> Datos = new Lazy<List<T>>();
        #region variables
        //variables
        public int Minimo { get; set; }
        public int maximo { get; set; }
        public int Orden { get; set; }
        public ArbolBNodo<T> Raiz { get; set; }
        public Lazy<List<T>> Lista;
        public compareTo<T> Comparador;
        //Fin variables
        #endregion

        #region constructores
        //Constructores
        public ArbolB(int Orden,compareTo<T> Compare )
        {
            this.Orden = Orden;
            Minimo = (Orden - 1) / 2;
            maximo = Orden - 1;
            this.Raiz = null;
            this.Lista = new Lazy<List<T>>();
            this.Comparador = Compare;
        }
        public ArbolB()
        {
            Raiz = null;
        }
        //Fin Constructores
        #endregion

        #region Busqueda
        //Busqueda
        public static bool arbolVacio(ArbolBNodo<T> nodo) => nodo == null;
        private void BuscarNodo(T clave, ArbolBNodo<T> P,ref bool Encontadro, ref int K)
        {
            try
            {
                int valorClave = clave.GetHashCode();
                int valor = P.Valores[1].GetHashCode();
                if (valor < valorClave)
                {
                    Encontadro = false;
                    K = 0;//rama por donde continua
                }
                else
                {
                    //revisa los valores del nodo
                    K = P.Cuenta;
                    while (valorClave < valor && K > 1)
                    {
                        K--;
                        Encontadro = (Comparador(clave, P.Valores[K]) == 0);
                    }
                }
            }
            catch (Exception ex)
            {
                //agregar mensaje error
            }
            
        }//Fin metodo BuscarNodo
        public void Buscar(T clave, ArbolBNodo<T> Raiz, ref bool encontrado, ref ArbolBNodo<T> N,ref int posicion)
        {
            if (arbolVacio(Raiz))
            {
                encontrado = false;
            }
            else
            {
                BuscarNodo(clave, Raiz, ref encontrado, ref posicion);
                if (encontrado)
                {
                    N = Raiz;
                }
                else
                {
                    Buscar(clave, Raiz.Hijo[posicion], ref encontrado, ref N, ref posicion);
                }
            }
        }//fin metodo Buscar
         //FIn Busqueda
        #endregion

        #region Insertar
        //Insertar
        ///Este proceso se inicia cuando se ha encontrado espacio en el nodo
        ///Con el metodo de buscar
        ///parametro "X" clave a insertar 
        ///parametro "XDireccion" direccion del nodo
        ///parametro "P" Nodo sucesor
        ///parametro "K" Posicion donde se va a insertar
        private void MeterHoja(T x,ArbolBNodo<T> XDireccion, ArbolBNodo<T> P, int K)
        {
            for (int i = P.Cuenta; i >= K+1 ; i--)
            {
                P.Valores[i + 1] = P.Valores[i];
                P.Hijo[i + 1] = P.Hijo[i];
            }
            P.Valores[K + 1] = x;
            P.Hijo[K + 1] = XDireccion;
            P.Cuenta = P.Cuenta + 1;
        }//Fin metodo MeterHoja
        ///Metodo para dividir un nodo en nodos nuevos al momento de llenar un nodo
        ///parametro "X" clave a insertar
        ///parametro "XDireccion" 
        ///parametro "P" nodo sucesor
        ///parametro "K" posicion donde debe insertarse la nueva clave
        ///parametro "Media" clave que sube como nuevo padre de los nodos creados 
        ///parametro "Derecha" nuevo nodo donde van los valores mayores a la media 
        private void DividirNodo(T X, ArbolBNodo<T> XDireccion, ArbolBNodo<T> P,int K, ref T Media, ref ArbolBNodo<T> Derecha)
        {
            int posicionMedia;//la posicion media del nodo
            posicionMedia = K <= Minimo ? Minimo : Minimo + 1;//if corto
            Derecha = new ArbolBNodo<T>();//nuevo nodo
            for (int i = posicionMedia+1; i < Orden; i++)
            {
                Derecha.Valores[i - posicionMedia] = P.Valores[i];//es desplazada la mitad derecha del nodo nuevo, la clave media se queda en laizquierda
                Derecha.Hijo[i - posicionMedia] = P.Hijo[i];
            }
            Derecha.Cuenta = maximo - posicionMedia;//claves en el nuevo nodo
            P.Cuenta = posicionMedia;//claves que se quedan en el nodo original 
            //Inserccion de X y la rama derecha
            if (K <= Orden/2)
            {
                MeterHoja(X, XDireccion, P, K);//insertar nodo a la izquierda
            }
            else
            {
                var nuevoValor = K - posicionMedia;
                MeterHoja(X, XDireccion, Derecha, nuevoValor);
            }//extraer media del nodo izquierdo
            Media = P.Valores[P.Cuenta];
            Derecha.Hijo[0] = P.Hijo[P.Cuenta];//rama inicial del nuevo nodo, es la rama de la media 
            P.Cuenta = P.Cuenta - 1;//disminuye porque se quito el valor medio
        }//Fin metodo DividirNodo
        ///Proceso en el que se baja hasta una rama vacia, se revisa si el nodo hoja tiene un espacio libre
        ///de ser asi, se inserta el valor, de lo contrario, se divide el nodo actualy se crea uno nuevo, donde
        ///se reparten las claves entre el nodo original y el nuevo
        ///parametro "Clave" clave con la que se trabaja a insertar 
        ///parametro "Evaluando" nodo en el que se va evaluando el espacio
        ///parametro "empujarArriba" bandera que indica si el nodo se divide o no
        ///parametro "Media" valor medio para la division del nodo 
        ///parametro "Auxiliar" nodo nuevo en cado se necesitarlo se crea para repartir las llaves
        private void Empujar (T Clave, ArbolBNodo<T> Evaluando, ref bool empujarArriba,ref T Media, ref ArbolBNodo<T>Auxiliar)
        {
            var k = default(int);
            var esta = default(bool);//controla si ya ha sido insertado el valor 
            if (arbolVacio(Evaluando))
            {
                empujarArriba = true;
                Media = Clave;
                Auxiliar = null;
            }
            else
            {
                BuscarNodo(Clave, Evaluando, ref esta, ref k);
                if (esta)
                {
                    return;
                }
                Empujar(Clave, Evaluando.Hijo[k], ref empujarArriba, ref Media, ref Auxiliar);
                if (empujarArriba)
                {
                    if (Evaluando.Cuenta<maximo)//no esta lleno el nodo
                    {
                        empujarArriba = false;//termina el proceso de busqueda
                        MeterHoja(Media, Auxiliar, Evaluando, k);//se inserta la clave
                    }
                    else
                    {
                        empujarArriba = true;
                        DividirNodo(Media, Auxiliar, Evaluando, k, ref Media, ref Auxiliar);
                    }
                }
            }
        }//Fin metodoEmpujar
        /// <summary>
        /// proceso en el que se manipula la insercion de un nodo en el arbol
        /// </summary>
        /// <param name="clave"></param> clave o valor a insertar
        /// <param name="raiz"></param> nodo donde se inica la evaluacion para insertar
        private void Insertar(T clave, ref ArbolBNodo<T> raiz)
        {
            var empujarArriba = default(bool);
            var Auxiliar = default(ArbolBNodo<T>);
            var X = default(T);

            Empujar(clave, raiz, ref empujarArriba, ref X, ref Auxiliar);

            if (empujarArriba)//si la division de nodos llega hasta la raiz, se crea un nuevo nodo y se cambia la raiz
            {                
                var P = new ArbolBNodo<T>();
                P.Cuenta = 1;
                P.Valores[1] = X;
                P.Hijo[0] = raiz;
                P.Hijo[1] = Auxiliar;
                raiz = P;
            }
        }//Fin metodo insertar
        /// <summary>
        /// Controla la insercion en el arbol 
        /// </summary>
        /// <param name="Clave"></param> valor a insertar
        /// parametro "raiz" raiz del arbol 
        public void Insertar(T Clave,string nombre)
        {
            var nuevaraiz = this.Raiz;
            Insertar(Clave, ref nuevaraiz);
            this.Raiz = nuevaraiz;
            Datos.Value.Add(Clave);
            Archivo(Datos, nombre);
            //Inorder(Raiz);
        }//Fin metodo Insertar   

        //Fin Insertar
        #endregion

        #region Recorrido
        //Recorrido
        public  void Inorder(ArbolBNodo<T> Recorrido, string nombre)
        {

            if (!arbolVacio(Recorrido))
            {
                if (Recorrido.Hijo[0]!=null)
                {
                    Inorder(Recorrido.Hijo[0],nombre);
                }
                for (int i = 1; i <= Recorrido.Cuenta; i++)
                {
                    if (Recorrido.Valores[i]!=null)
                    {                        
                        Lista.Value.Add(Recorrido.Valores[i]);
                        if (Recorrido.Hijo[i] != null)
                        {
                            Inorder(Recorrido.Hijo[i],nombre);
                        }
                    }                 
                }
            }
        }//fin metodo Inorder
        public List<T> ToList(string nombre)
        {
            Lista = new Lazy<List<T>>();
            Inorder(Raiz,nombre);
            Archivo(Lista, nombre);
            return Lista.Value;
        }
        //Fin recorrido
        #endregion
    
        #region archivo
        public  void Archivo(Lazy<List<T>> Lista, string nombre)
        {
            Tabla tabla = new Tabla();
            List<T> listaTablas = new List<T>();
            listaTablas = Lista.Value;
            bool valor;
            string pathfinal = "Arbol_Archivo.ArbolB";
            using (StreamWriter outputFile = new StreamWriter(pathfinal))
            {
                for (int i = 0; i < listaTablas.Count(); i++)
                {
                    for (int j = 0; j < Tabla.DiccionarioTabla[nombre].Count();j++)
                    {
                        valor = listaTablas[i].Equals(Tabla.DiccionarioTabla[nombre][j]);
                        tabla = Tabla.DiccionarioTabla[nombre][j];
                        outputFile.WriteLine(tabla.nombre+" | "+tabla.id+" | "+tabla.int1+" | "+tabla.int2+" | "
                            +tabla.int3+" | "+tabla.varchar1+" | "+tabla.varchar2+" | "+tabla.varchar3+" | "+
                            tabla.dateTime1+" | "+tabla.dateTime2+" | "+tabla.dateTime3);
                        
                    }
                    
                    //datos = tabla;
                    
                    
                    /*for (int l = 0; l < 5; l++)
                    {
                        outputFile.WriteLine(Raiz);
                        for (int j = 0; j < 6; j++)
                        {
                            outputFile.WriteLine(Raiz.Hijo[j]);
                            for (int k = 0; k < 5; k++)
                            {
                                outputFile.WriteLine(Raiz.Hijo[j].Valores[k]);
                            }
                        }
                    } */                     
                                             
                    
                }
            }
        }

        #endregion

        #region Eliminacion
        //eliminacion

        /// <summary>
        /// Combina dos nodos dejando solo 1, esto ocurre cuando se elimina
        /// un elemento en un nodo y el nodo no cumple con la cantidad minima de llaves
        /// </summary>
        /// <param name="P"></param>
        /// <param name="K"></param>
        private void Combina(ArbolBNodo<T>P, int K)
        {
            int J;
            ArbolBNodo<T> Q;

            Q = P.Hijo[K];
            P.Hijo[K - 1].Cuenta = P.Hijo[K - 1].Cuenta + 1;
            P.Hijo[K - 1].Valores[P.Hijo[K - 1].Cuenta] = P.Valores[K];
            P.Hijo[K - 1].Hijo[P.Hijo[K - 1].Cuenta] = Q.Hijo[0];

            for (J = 1; J <= Q.Cuenta; J++)
            {
                P.Hijo[K - 1].Cuenta = P.Hijo[K - 1].Cuenta + 1;
                P.Hijo[K - 1].Valores[P.Hijo[K - 1].Cuenta] = Q.Valores[J];
                P.Hijo[K - 1].Hijo[P.Hijo[K - 1].Cuenta] = Q.Hijo[J];
            }
            for (J = K; J <= P.Cuenta-1; J++)
            {
                P.Valores[J] = P.Valores[J + 1];
                P.Hijo[J] = P.Hijo[J + 1];
            }
            P.Cuenta = P.Cuenta - 1;
        }//fin metodo Combina
        /// <summary>
        /// desciende la clave K=1 del nodo padre P al hijo y la inserta en la posicion mas alta, 
        /// de esta forma se restablece el minimo de claves 
        /// Despues sube la clave 1 del hermano derecho 
        /// </summary>
        /// <param name="P"></param> nodo que antecede al nodo que se esta restaurando 
        /// <param name="K"></param> posicion del nodo con menod claves que el minimo
        private void MoverIzquierda(ArbolBNodo<T> P, int K)
        {
            //P.Hijo[K-1] nodo con menos claves que el minimo
            P.Hijo[K - 1].Cuenta = P.Hijo[K - 1].Cuenta + 1;
            P.Hijo[K - 1].Valores[P.Hijo[K - 1].Cuenta] = P.Valores[K];
            P.Hijo[K - 1].Hijo[P.Hijo[K - 1].Cuenta] = P.Hijo[K].Hijo[0];

            P.Valores[K] = P.Hijo[K].Valores[1];
            P.Hijo[K].Hijo[0] = P.Hijo[K].Hijo[1];
            P.Hijo[K].Cuenta = P.Hijo[K].Cuenta - 1;

            for (int i = 1; i <= P.Hijo[K].Cuenta; i++)
            {
                P.Hijo[K].Valores[i] = P.Hijo[K].Valores[i + 1];
                P.Hijo[K].Hijo[i] = P.Hijo[K].Hijo[i + 1];
            }
        }//fin metodo MoverIzquierda
        /// <summary>
        /// se deja espacio en el nodo P.Hijo[K] que es el nodo que tiene menos claves que el minimo necesario,
        /// inserta la clave K del nodo antecesor y a su vez asciende la clave mayor del nodo hermano izquierdo al nodo 
        /// </summary>
        /// <param name="P"></param> nodo antecesor al nodo que se esta restaurando 
        /// <param name="K"></param> posicion del nodo con menos claves que el minimo 
        private void MoverDerecha(ArbolBNodo<T> P, int K)
        {
            //P.Hijo[K] es nodo con menos claves que el minimo
            for (int J = P.Hijo[K].Cuenta; J >= 1; J--)
            {
                P.Hijo[K].Valores[J + 1] = P.Hijo[K].Valores[J];
                P.Hijo[K].Hijo[J + 1] = P.Hijo[K].Hijo[J];
            }
            P.Hijo[K].Cuenta = P.Hijo[K].Cuenta + 1;
            P.Hijo[K].Hijo[1] = P.Hijo[K].Hijo[0];
            P.Hijo[K].Valores[1] = P.Valores[K];//Baja la clave del nodo padre
            //Ahora sube la clave desde el hermano izquierdo al nodo padre, para reemplazar
            //la que bajo antes {Hermano izquiero P.Hijo[K-1]}
            P.Valores[K] = P.Hijo[K - 1].Valores[P.Hijo[K - 1].Cuenta];
            P.Hijo[K].Hijo[0] = P.Hijo[K - 1].Hijo[P.Hijo[K - 1].Cuenta];
            P.Hijo[K - 1].Cuenta = P.Hijo[K - 1].Cuenta - 1;
        }//fin metodo MoverDerecha
        /// <summary>
        /// Restaura el nodo P.Hijo[K] elcual se queda debajo del minimo de claves 
        /// Si tiene hermono izquiero siempre se trabaja con ese, en caso no tenga se pasa al hermano derecho
        /// En caso no hay claves se combina los nodos
        /// </summary>
        /// <param name="P"></param> tiene la direccion del nodo antecesor del nodo P.Hijo[K] que se ha quedado con menos claves que el minimo 
        /// <param name="K"></param>
        private void Restablecer(ArbolBNodo<T> P,int K)
        {
            if (K > 0)//tiene hermano izquiero
            {
                if (P.Hijo[K - 1].Cuenta>Minimo)//tiene mas claves que el minimo y por lo tanto puede desplazarse una clave  
                {
                    MoverDerecha(P, K);
                }
                else
                {
                    Combina(P, K);
                }
            }
            else//solo tiene hermano derecho 
            {
                if (P.Hijo[1].Cuenta>Minimo)//tiene mas claves que el minimo
                {
                    MoverIzquierda(P, 1);
                }
                else
                {
                    Combina(P, 1);
                }
            }
        }//fin metodo Restablecer
        /// <summary>
        /// Se busca la clave inmediatamente sucesora de la clave k, y esta reemplaza a la clave K
        /// </summary>
        /// <param name="P"></param>Bidi donde se encuentra la clave k 
        /// <param name="K"></param>posicion de la clave
        private void Sucesor(ArbolBNodo<T> P, int K)
        {
            ArbolBNodo<T> Q;
            Q = P.Hijo[K];
            while (Q.Hijo[0]!=null)
            {
                Q = Q.Hijo[0];
                P.Valores[K] = Q.Valores[1];
            }
        }
        /// <summary>
        /// Elimina la clave junto con la rama que corresponde 
        /// </summary>
        /// <param name="P"></param>Direccion del nodo 
        /// <param name="K"></param>Posicion de la clave del nodo 
        private void Quitar(ArbolBNodo<T>P,int K)
        {
            for (int j = K+1; j <= P.Cuenta; j++)
            {
                P.Valores[j - 1] = P.Valores[j];//desplaza uan posicion a la izquierda, con la que elimina la referencia a la clave
                P.Hijo[j - 1] = P.Hijo[j];
            }
            P.Cuenta = P.Cuenta - 1;
        }
        /// <summary>
        /// Busca el nodo con la clave a eliminar, si el nodo es hoja se llama al metodo quitar 
        /// en caso no sea hoja, se encuentra el sucesor inmediato de la clave, se coloca en el nodo donde esta la clave 
        /// despues se elimina la clave sucesir en el nodo hoja 
        /// </summary>
        /// <param name="Clave"></param>
        /// <param name="Raiz"></param>
        /// <param name="Encontrado"></param>
        private void EliminarRegistro(T Clave, ArbolBNodo<T> Raiz, ref bool Encontrado)
        {
            var k = 0;
            if (arbolVacio(Raiz))
            {
                Encontrado = false;//se ha recorrido todo el arbol  
            }
            else
            {
                BuscarNodo(Clave, Raiz, ref Encontrado, ref k);
                if (Encontrado)
                {
                    if (Raiz.Hijo[k-1]==null)//Las ramas estan indexadas desde el indice 0 a Maximo, por lo que este nodo es hoja
                    {
                        Quitar(Raiz, k);
                    }
                    else//no es hoja
                    {
                        Sucesor(Raiz, k);//reemplaza Raiz.Claves[K] por su sucesor
                        EliminarRegistro(Raiz.Valores[k], Raiz.Hijo[k], ref Encontrado);//Elimina la clave sucesora en su nodo
                        if (!Encontrado)
                        {
                            return;
                        }
                    }
                }
                else//no ha sido localizada la clave
                {
                    EliminarRegistro(Clave, Raiz.Hijo[k], ref Encontrado);
                    //se comprueba que el nodo hijo mantenga un numero de claves igual o mayor que el minimo necesario
                    if (Raiz.Hijo[k]!=null)//condicion de que no sea hoja
                    {
                        if (Raiz.Hijo[k].Cuenta<Minimo)
                        {
                            Restablecer(Raiz, k);
                        }
                    }
                }
            }
        }//fin metodo EliminarRegistro
        /// <summary>
        /// establece la nueva raiz en caso sea nesecario
        /// </summary>
        /// <param name="Clave"></param>
        /// <param name="Raiz"></param>
        private void Eliminar(T Clave, ref ArbolBNodo<T> Raiz)
        {
            var Encontrado = false;
            ArbolBNodo<T> P;
            EliminarRegistro(Clave, Raiz, ref Encontrado);
            if (!Encontrado)
            {
                return;
            }
            else if (Raiz.Cuenta==0)
            {
                P = Raiz;
                Raiz = Raiz.Hijo[0];
            }
        }//Fin metodo Eliminar

        public ArbolBNodo<T> Eliminar(T Clave, ArbolBNodo<T> Raiz)
        {
            var nuevaRaiz = Raiz;
            Eliminar(Clave, ref nuevaRaiz);
            return nuevaRaiz;
        }

        #endregion

        #region Escritura de archivo



        #endregion

        
    }
}
