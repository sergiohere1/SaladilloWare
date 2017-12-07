using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Tables;

namespace Tienda.ViewModels
{
    class ClientVM : INotifyPropertyChanged
    {
        #region Campos del Viewmodel
        //Usuario actual
        private User user;
        //Mensaje de bienvenida cuando se conecte un usuario
        private String mensajeLogin;
        //Estado del boton aceptar en función a si se cumplen las condiciones de compra o no.
        private bool estadoAceptar;
        //Estado del boton confirmar compra en función a si se cumplen las condiciones de compra o no.
        private bool estadoConfirmar;
        // Lista que contendrá las placas bases de nuestra base de datos
        private List<Producto> placas;
        // Lista que contendrá los procesadores de nuestra base de datos
        private List<Producto> procesadores;
        // Lista de torres pertenecientes a nuestra base de datos
        private List<Producto> torres;
        // Lista de memorias de nuestra base de datos
        private List<Producto> memorias;
        // Lista de tarjetas graficas de nuestra base de datos
        private List<Producto> graficas;
        // Lista que contendrá los productos que haya pedido el usuario.
        private List<Producto> pedido;
        //Indice seleccionado de placa en su correspondiente Picker
        private int indicePlaca;
        //Indice seleccinado de procesador en su correspondiente Picker
        private int indiceProcesador;
        //Indice seleccionado de torre en su correspondiente picker
        private int indiceTorre;
        //Indice seleccionado de memoria en su correspondiente picker
        private int indiceMemoria;
        //Indice seleccionado de tarjeta grafica en su correspondiente picker
        private int indiceGrafica;
        //Precio total del pedido
        private double precioTotal;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor para nuestro Viewmodel de la página a la que accede un Cliente.
        /// </summary>
        /// <param name="user">Usuario actual que haya iniciado sesión, para así poder
        /// sacar su nombre en el mensaje de bienvenida y asignarle la compra cuando
        /// creemos un pedido.</param>
        public ClientVM(User user)
        {
            this.user = user;
            cargarDatos();

        }

        #region Propiedades para cada campo
        /// <summary>
        /// Mensaje de bienvenida para el usuario que se haya logueado.
        /// </summary>
        public string MensajeLogin
        {
            get
            {
                return mensajeLogin;
            }
            set
            {
                if (mensajeLogin != value)
                {
                    mensajeLogin = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("MensajeLogin"));
                    }
                }
            }
        }
        /// <summary>
        /// Estado del botón aceptar.
        /// </summary>
        public bool EstadoAceptar
        {
            get
            {
                return estadoAceptar;
            }
            set
            {
                if (estadoAceptar != value)
                {
                    if (estadoAceptar != value)
                    {
                        estadoAceptar = value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs("EstadoAceptar"));
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Estado del boton confirmar.
        /// </summary>
        public bool EstadoConfirmar
        {
            get
            {
                return estadoConfirmar;
            }
            set
            {
                if (estadoConfirmar != value)
                {
                    estadoConfirmar = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("EstadoConfirmar"));
                    }
                }
            }
        }
        /// <summary>
        /// Lista de placas base.
        /// </summary>
        public List<Producto> ListaPlacas
        {
            get
            {
                return placas;
            }
            set
            {
                if (placas != value)
                {
                    placas = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ListaPlacas"));
                    }
                }
            }
        }
        /// <summary>
        /// Lista de procesadores.
        /// </summary>
        public List<Producto> ListaProcesadores
        {
            get
            {
                return procesadores;
            }
            set
            {
                if (procesadores != value)
                {
                    procesadores = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ListaProcesadores"));
                    }
                }
            }
        }
        /// <summary>
        /// Lista de torres.
        /// </summary>
        public List<Producto> ListaTorres
        {
            get
            {
                return torres;
            }
            set
            {
                if (torres != value)
                {
                    torres = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ListaTorres"));
                    }
                }
            }
        }
        /// <summary>
        /// Lista de memorias.
        /// </summary>
        public List<Producto> ListaMemorias
        {
            get
            {
                return memorias;
            }
            set
            {
                if (memorias != value)
                {
                    memorias = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ListaMemorias"));
                    }
                }
            }
        }
        /// <summary>
        /// Lista de tarjetas gráficas.
        /// </summary>
        public List<Producto> ListaGraficas
        {
            get
            {
                return graficas;
            }
            set
            {
                if (graficas != value)
                {
                    graficas = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ListaGraficas"));
                    }
                }
            }
        }
        /// <summary>
        /// Indice actual seleccionado de placa.
        /// </summary>
        public int IndicePlaca
        {
            get
            {
                return indicePlaca;
            }
            set
            {
                if (indicePlaca != value)
                {
                    indicePlaca = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IndicePlaca"));
                    }
                }
            }
        }
        /// <summary>
        /// Indice actual seleccionado de procesador.
        /// </summary>
        public int IndiceProcesador
        {
            get
            {
                return indiceProcesador;
            }
            set
            {
                if (indiceProcesador != value)
                {
                    indiceProcesador = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IndiceProcesador"));
                    }
                }
            }
        }
        /// <summary>
        /// Indice actual de torre.
        /// </summary>
        public int IndiceTorre
        {
            get
            {
                return indiceTorre;
            }
            set
            {
                if (indiceTorre != value)
                {
                    indiceTorre = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IndiceTorre"));
                    }
                }
            }
        }
        /// <summary>
        /// Indice actual de memoria.
        /// </summary>
        public int IndiceMemoria
        {
            get
            {
                return indiceMemoria;
            }
            set
            {
                if (indiceMemoria != value)
                {
                    indiceMemoria = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IndiceMemoria"));
                    }
                }
            }
        }
        /// <summary>
        /// Indice actual de tarjeta grafica
        /// </summary>
        public int IndiceGrafica
        {
            get
            {
                return indiceGrafica;
            }
            set
            {
                if (IndiceGrafica != value)
                {
                    indiceGrafica = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IndiceGrafica"));
                    }
                }
            }
        }
        
        /// <summary>
        /// Precio total del pedido realizado.
        /// </summary>
        public double PrecioTotal
        {
            get
            {
                return precioTotal;
            }
            set
            {
                if (precioTotal != value)
                {
                    precioTotal = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("PrecioTotal"));
                    }
                }
            }
        }
        /// <summary>
        /// Lista de productos del pedido actual.
        /// </summary>
        public List<Producto> PedidoActual
        {
            get
            {
                return pedido;
            }
            set
            {
                if (pedido != value)
                {
                    pedido = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("PedidoActual"));
                    }
                }
            }
        }
        #endregion



        /// <summary>
        /// Método encargado de cargar todos los datos referentes al mensaje de bienvenida y a
        /// los Pickers donde el usuario podrá elegir placa, torre, etc para su pedido.
        /// </summary>
        private void cargarDatos()
        {
            throw new NotImplementedException();

        }
        #endregion
    }
}
