using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras
{
    public partial class ArbolB_<TLlave,TValor>
    {
        #region Nodo//terminar 
        /// <summary>
        /// Clase base para nodo interno (nodos entre raiz y hojas) y nodo hojas 
        /// </summary>
        private abstract partial class Nodo
        {
            
        }




        #endregion

        #region Item Hojas
        /// <summary>
        /// representa un valor asociado a la clave usado para buscar y almacenar items en la hoja
        /// </summary>
        private partial struct LlaveValorItem
        {
            public TLlave LLave;
            public TValor Valor;
            public LlaveValorItem(TLlave llave, TValor valor)
            {
                LLave = llave;
                Valor = valor;
            }
            public static void CambiarValor(ref LlaveValorItem Item, TValor nuevoValor)
            {
                Item = new LlaveValorItem(Item.LLave, nuevoValor);
            }
        }
        #endregion

        #region Item Nodo Interno
        /// <summary>
        /// Representa a la llave y al puntero de los hijos derechos
        /// Se usa para buscar y almacenar items en nodos internos (entre raiz y hojas)
        /// </summary>
        private partial struct LLaveNodoItem
        {
            public TLlave Llave;
            public Nodo Derecha;
            public LLaveNodoItem(TLlave llave, Nodo derecha)
            {
                Llave = llave;
                Derecha = derecha;
            }
            public static void CambioLlave(ref LLaveNodoItem item, TLlave nuevaLlave)
            {
                item = new LLaveNodoItem(nuevaLlave, item.Derecha);
            }
            public static void IntercambiarLLaves(ref LLaveNodoItem x, ref LLaveNodoItem y)
            {
                var xLlave = x.Llave;
                CambioLlave(ref x, y.Llave);
                CambioLlave(ref y, x.Llave);
            }
            public static void CambioDerecha(ref LLaveNodoItem item, Nodo nuevaDerecha)
            {
                item = new LLaveNodoItem(item.Llave, nuevaDerecha);
            }
            public static void IntercambiarDerecha(ref LLaveNodoItem item, ref Nodo puntero)
            {
                var Temp = puntero;
                puntero = item.Derecha;
                item = new LLaveNodoItem(item.Llave, Temp);
            }
        }
        #endregion

        #region Llave comparador        
        /// <summary>
        /// contiene la llave comparador requiere encontrar una ruta de las hojas al item
        /// </summary>
        private sealed class NodoComparador:IComparer<LLaveNodoItem>,IComparer<LlaveValorItem>
        {
            public IComparer<TLlave> LlaveComparador;
            public NodoComparador(IComparer<TLlave>LlaveComparador)
            {
                LlaveComparador = LlaveComparador ?? Comparer<TLlave>.Default;//if corto comparando con null
            }
            public int Compare(LLaveNodoItem x, LLaveNodoItem y) => LlaveComparador.Compare(x.Llave, y.Llave);

            public int Compare(LlaveValorItem x, LlaveValorItem y) => LlaveComparador.Compare(x.LLave, y.LLave);            
        }
        #endregion

        #region Insertar Argumentos 
        //agregar referencia
        private struct InsertarArgumentos<TArg>
        {
            public readonly TLlave Llave;
            private readonly TArg Arg;//tambien puede ser un TValor o cualquier valor 
            private readonly Func<(TLlave llave, TArg arg), TValor> AgregarFuncion;
            private readonly Func<(TLlave llave, TArg arg, TValor viejoValor),TValor> ActualizarFuncion;
            public readonly NodoComparador Comparador;
            /// <summary>
            /// verdadero si el item fue agregado y no actualizado 
            /// </summary>
            public bool Agregar { get; set; }
            public TValor GetValor()
            {
                Agregar = true;
                return AgregarFuncion((Llave, Arg));
            }
            public TValor GetValorActualizado(TValor valorViejo)
            {
                return ActualizarFuncion((Llave, Arg, valorViejo));
            }
            public InsertarArgumentos(in TLlave llave, in TArg arg, in Func<(TLlave llave, TArg arg),TValor>agregarFuncion,
                in Func<(TLlave llave, TArg arg, TValor valorViejo),TValor>actualizarValor, in NodoComparador comparador)
            {
                Llave = llave;
                Arg = arg;
                AgregarFuncion = agregarFuncion;
                ActualizarFuncion = actualizarValor;
                Comparador=comparador;
                Agregar = false;
            }
        }
        #endregion

        #region Quitar Argumento
        
        private ref struct QuitarArgumento
        {
            public readonly TLlave Llave;
            public readonly NodoComparador Comparador;
            /// <summary>
            /// establece un valor encontrado en las hojas
            /// </summary>
            public TValor Valor { get; set; }
            /// <summary>
            /// verdadero sik se quito el item
            /// </summary>
            public bool Quitar { get; set; }
            public QuitarArgumento(in TLlave llave, in NodoComparador comparador)
            {
                Llave = llave;
                Comparador = comparador;
                Valor = default;
                Quitar = false;
            }
            public void QuitarValorAsignado(TValor valor)
            {
                Valor = valor;
                Quitar = true;
            }
        }
        #endregion

        #region Relacion de nodos

        private readonly ref struct RelacionNodos
        {
            public readonly Nodo HermanoIzquiero;
            public readonly Nodo HermanoDerecho;

            public readonly NodoInterno AntesesorIzquiedo;
            public readonly NodoInterno AntesesorDerecho;
            public readonly int IndexAntesesorIzquierdo;
            public readonly int IndexAntesesorDerecho;
            public readonly bool TieneHijoIzquierdo;
            public readonly bool TieneHijoDerecho;
            //revisa error tipo de dato NodoOnterno
            private NodosRelativos (NodoInterno antesesorIzquierdo, int indexAntesesorIzquierdo, Nodo hermanoIzquierdo, bool tieneHijpIzquierdo,
                NodoInterno antesesorDerecho, int indexAntesesroDerecho, Nodo hermanoDerecho, bool tieneHijoDerecho)
            {
                AntesesorIzquiedo = antesesorIzquierdo;
                IndexAntesesorIzquierdo = indexAntesesorIzquierdo;
                HermanoIzquiero = hermanoIzquierdo;
                TieneHijoIzquierdo = tieneHijpIzquierdo;
                AntesesorDerecho = antesesorDerecho;
                IndexAntesesorDerecho = indexAntesesroDerecho;
                HermanoDerecho = hermanoDerecho;
                TieneHijoDerecho = tieneHijoDerecho;
            }
            public static NodosRelativos Crear(Nodo hijo, int index, NodoInterno padre, in NodosRelativos padreRelativo )
            {//buscar Debug
                Debug.Asser(index >= -1 && index < padre.Length);
                NodoInterno antesesorIzquierdo, antesesorDerecho;
                int indexAntesesorIzquierdo, indexAntesesorDerecho;
                Nodo hermanoIzquierdo, hermanoDerecho;
                bool tieneHermanoIzquierdo, tieneHermanoDerecho;
                if (index==-1)
                {
                    antesesorIzquierdo = padreRelativo.AntesesorIzquierdo;
                    indexAntesesorIzquierdo = padreRelativo.IndexAntesesorIzquierdo;
                    hermanoIzquierdo = ((NodoInterno)padreRelativo.HermanoIzquierdo)?.GetUltimoHijo();//revisar metodo
                    tieneHermanoIzquierdo = false;
                    antesesorDerecho = padre;
                    indexAntesesorDerecho = index + 1;
                    hermanoDerecho = padre.GetHijo(indexAntesesorDerecho);//revisar metodo
                    tieneHermanoDerecho = false;
                }
                else if (index ==padre.Length-1)
                {
                    antesesorIzquierdo = padre;
                    indexAntesesorIzquierdo = index;
                    hermanoIzquierdo = padre.GetHijo(indexAntesesorIzquierdo - 1);//revisar metodo
                    tieneHermanoIzquierdo = true;
                    antesesorDerecho = padreRelativo.AntesesorDerecho;
                    indexAntesesorDerecho = padreRelativo.IndexAntesesorDerecho;
                    hermanoDerecho = ((NodoInterno)padreRelativo.HermanoDerecho)?.GetPrimerHijo();//Revisar metodo
                    tieneHermanoDerecho = false;
                }
                else
                {
                    antesesorIzquierdo = padre;
                    indexAntesesorIzquierdo = index;
                    hermanoIzquierdo = padre.getHijo(indexAntesesorIzquierdo - 1);//revisar metodo
                    tieneHermanoIzquierdo = true;
                    antesesorDerecho = padre;
                    indexAntesesorDerecho = index + 1;
                    hermanoDerecho = padre.GetHijo(indexAntesesorDerecho);
                    tieneHermanoDerecho = true;
                }
                return new NodosRelativos(antesesorIzquierdo, indexAntesesorIzquierdo, hermanoIzquierdo, tieneHermanoIzquierdo,
                    antesesorDerecho, indexAntesesorDerecho, hermanoDerecho, tieneHermanoDerecho);
            }
        }

        #endregion

    }
    class NodoArbolB_
    {
        
    }
}
