using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Tables;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            CargarDatos();

        }
        #endregion

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
        public List<Producto> Pedido
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
                        PropertyChanged(this, new PropertyChangedEventArgs("Pedido"));
                    }
                }
            }
        }
        #endregion


        /// <summary>
        /// Método encargado de cargar todos los datos referentes al mensaje de bienvenida y a
        /// los Pickers donde el usuario podrá elegir placa, torre, etc para su pedido.
        /// </summary>
        private async void CargarDatos()
        {
            MensajeLogin = String.Format("Bienvenido {0}", user.Name);
            ListaPlacas = new List<Producto>(await App.ProductoRepo.ObtenerPlacas());
            IndicePlaca = -1;
            ListaProcesadores = new List<Producto>(await App.ProductoRepo.ObtenerProcesadores());
            IndiceProcesador = -1;
            ListaTorres = new List<Producto>(await App.ProductoRepo.ObtenerTorres());
            IndiceTorre = -1;
            ListaMemorias = new List<Producto>(await App.ProductoRepo.ObtenerMemorias());
            IndiceMemoria = -1;
            ListaGraficas = new List<Producto>(await App.ProductoRepo.ObtenerGraficas());
            IndiceGrafica = -1;
        }  

        /// <summary>
        /// Mediante este método habilitaremos o deshabilitaremos el botón de aceptar, devolviendo
        /// su correspondiente estado.
        /// </summary>
        public void ComprobarSelect()
        {

            if (IndicePlaca != -1 && IndiceProcesador != -1 && IndiceTorre != -1 && IndiceMemoria != -1 
                && IndiceGrafica != -1)
            {
                EstadoAceptar = true;
            }
            else
            {
                EstadoAceptar = false;
            }

        }

        public void AniadirProductosPedido()
        {
            List<Producto> productosPedido = new List<Producto>();
            double precioTotal = 0;

            /* Añadimos a nuestra Propiedad de Pedido todos los elementos que haya seleccionado el usuario,
             usando para ello el Indice del Picker, lo que nos permite de manera fácil tener ya los productos
             que haya escogido el usuario. También comprobaremos que no le haya dado a Aceptar tras cambiar
             de decisión en algún producto elegido para limpiar lo anterior*/
            if(productosPedido.Count() > 0)
            {
                productosPedido.Clear();
                Pedido.Clear();
                precioTotal = 0;
                AniadirProductosAPedido(productosPedido);
                precioTotal = CalcularPrecio(productosPedido);
                Pedido = productosPedido;
                PrecioTotal = precioTotal;
            }
            else
            {               
                AniadirProductosAPedido(productosPedido);
                EstadoConfirmar = true;
                precioTotal = CalcularPrecio(productosPedido);
                Pedido = productosPedido;
                PrecioTotal = precioTotal;
            }          
        }


        public void AniadirProductosAPedido(List<Producto> productosLista)
        {
            productosLista.Add(ListaPlacas.ElementAt(IndicePlaca));
            productosLista.Add(ListaProcesadores.ElementAt(IndiceProcesador));
            productosLista.Add(ListaTorres.ElementAt(IndiceTorre));
            productosLista.Add(ListaMemorias.ElementAt(IndiceMemoria));
            productosLista.Add(ListaGraficas.ElementAt(IndiceGrafica));
        }

        public double CalcularPrecio(List<Producto> productosLista)
        {
            double precioTotal= 0;

            foreach (Producto p in productosLista)
            {
                precioTotal += p.Precio;
            }

            return precioTotal;
        }

        public async void RealizarPedido(Page currentPage)
        {
            await App.PedidoRepo.AddNewOrder(user.IdUser, ListaPlacas.ElementAt(IndicePlaca).IdProducto, ListaProcesadores.ElementAt(IndiceProcesador).IdProducto,
                ListaTorres.ElementAt(IndiceTorre).Nombre, ListaMemorias.ElementAt(IndiceMemoria).Nombre, ListaGraficas.ElementAt(IndiceGrafica).Nombre, PrecioTotal);

            await currentPage.DisplayAlert("", "Su pedido ha sido realizado, esté atento a su correo para el seguimiento del envío.", "Aceptar");
            App.Current.MainPage = new ClientPage(user);
        }
    }
}
