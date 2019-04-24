using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras
{
    class NodoInterno
    {//terminar
        public partial class ArbolB_<TLlave, TValor>
        {
            private sealed partial class NodoInterno : NodoArbolB_
            {
                public readonly ArregloCircular<ItemNodoLlave> Items;
                public NodoArbolB_ Izquierdo;
                #region Constructores
                public NodoInterno(ArregloCircular<ItemNodoLlave>items)
                {
                    Items = items;
                }
                public NodoInterno(int capacidad)
                {
                    Items = ArregloCircular<ItemNodoLlave>.nuevaCapacidadArreglo(capacidad);
                }
                #endregion
                #region Properties
                public override bool EsHoja => false;
                public override bool EstaLleno => Items.EstaLleno;
                public override bool EstaMedioLleno => Items.EstaMedioLleno;
                public override int Length => Items.Count;
                public override TLlave PrimeraLlave => Items.Primera.Llave;
                #endregion

                #region Encontrar / Atravesar
                public override int Encontrar(in TLlave llave, in NodoComparador comparador)
                {
                    return Items.BinarySearch(new ItemNodoLlave(llave, null), comparador);
                }
                public override NodoArbolB_ ObtenerHijo(int index)
                {
                    return index < 0 ? Izquierdo : Items[index].Derecho;
                }
                public override NodoArbolB_ ObtenerHijoCercano(TLlave llave, NodoComparador comparador)
                {
                    var index = Encontrar(llave, comparador);
                    if (index < 0) index = ~index - 1;//obtiene el item mas cercano
                    return ObtenerHijo(index);
                }
                public NodoArbolB_ ObtenerUltimoHijo() => Items.Last.Derecha;
                public NodoArbolB_ ObtenerPrimerHijo => Izquierdo;
                #endregion

                #region Insertar //linea 62
                public override ItemLlaveNodo?Insertar<TArg>(ref InsertarArgumento<TArg>args,in NodoRelativo relativo)
                {
                    var index = Encontrar(args.Llave, args.Comparar);
                    //-1 porque si el item es mas pequeño va al hijo izquierdo
                    if (index < 0) index = ~index - 1;
                    Debug.Afirmar(index >= -1 && index < Items.Contador);

                    var hijo = ObtenerHijo(index);
                    var HijoRelativo = NodoRelativo.Crear(hijo, index, this, relativo);

                }


                #endregion
            }
        }
    }
}
