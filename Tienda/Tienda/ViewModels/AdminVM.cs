using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tienda.Tables;
using Xamarin.Forms;

namespace Tienda.ViewModels
{
    public class AdminVM : INotifyPropertyChanged
    {
        #region Campos
        /// <summary>
        /// Lista que contendrá todos los pedidos realizados.
        /// </summary>
        public List<LineaPedido> pedidos;
        /// <summary>
        /// Campo que se implementa tras implementar la interfaz INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad del campo pedidos
        /// </summary>
        public List<LineaPedido> Pedidos
        {
            get
            {
                return pedidos;
            }
            set
            {
                if (pedidos != value)
                {
                    pedidos = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Pedidos"));
                    }
                }
            }           
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que se encargará de cargar todos los pedidos realizados para que pueda visualizarlos
        /// el vendedor.
        /// </summary>
        public async void LoadContent()
        {
            List<Pedido> pedidos = await App.PedidoRepo.GetAllOrders();
            List<User> usuarios = await App.UsuarioRepo.GetAllUsers();
            List<Producto> placas = await App.ProductoRepo.ObtenerPlacas();
            List<Producto> procesadores = await App.ProductoRepo.ObtenerProcesadores();
            List<Producto> torres = await App.ProductoRepo.ObtenerTorres();
            List<Producto> memorias = await App.ProductoRepo.ObtenerMemorias();
            List<Producto> graficas = await App.ProductoRepo.ObtenerGraficas();
            List<LineaPedido> pedidosRealizados = new List<LineaPedido>();

            string nombreCliente = "";
            string nombrePlaca = "";
            string nombreProcesador = "";
            string nombreTorre = "";
            string nombreMemoria;
            string nombreGrafica;

            foreach(Pedido p in pedidos)
            {
                nombreCliente = usuarios.SingleOrDefault(usuario => usuario.IdUser == p.Cliente).Name;
                nombrePlaca = placas.SingleOrDefault(placa => placa.IdProducto == p.IdPlaca).Nombre;
                nombreTorre = torres.SingleOrDefault(torre => torre.IdProducto == p.IdTorre).Nombre;
                nombreMemoria = memorias.SingleOrDefault(memoria => memoria.IdProducto == p.IdMemoria).Nombre;
                nombreGrafica = graficas.SingleOrDefault(grafica => grafica.IdProducto == p.IdGrafica).Nombre;
                nombreProcesador = procesadores.SingleOrDefault(procesador => procesador.IdProducto == p.IdProcesador).Nombre;

                pedidosRealizados.Add(new LineaPedido(nombreCliente, nombrePlaca, nombreProcesador, nombreTorre, nombreMemoria, nombreGrafica, p.Precio));
            }

            Pedidos = pedidosRealizados;
        }

        /// <summary>
        /// Método para cerrar sesión para así poder iniciar sesión con otro usuario.
        /// </summary>
        public void CerrarSesion()
        {
            App.Current.MainPage = new MainPage();
        }

        /// <summary>
        /// Método encargado de actualizar los precios, obteniendo la ID y el precio nuevo del XML
        /// y llamando a la función de actualización que estará en el repositorio para la tabla
        /// Producto. Actualizaremos los precios de los productos, pero si un pedido está realizado
        /// antes de la actualización, mantendrá el precio que tenía de antes, no se le aplicará
        /// el nuevo precio.
        /// </summary>
        public async void ActualizarPrecios()
        {
            string ruta = "Tienda.Assets.Precios.xml";
            var assembly = typeof(AdminPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(ruta);
            var doc = XDocument.Load(stream);
            string idActualizar;
            double precioActualizar;

            foreach (XElement element in doc.Root.Elements())
            {                  
                if(element.Name == "Placas")
                {
                    foreach(XElement subelement in element.Elements())
                    {
                        precioActualizar = double.Parse(subelement.Element("PRECIO").Value);
                        idActualizar = subelement.Element("ID").Value;

                        await App.ProductoRepo.ActualizarProductos(idActualizar, precioActualizar);
                    }
                }

                if (element.Name == "Procesadores")
                {
                    foreach (XElement subelement in element.Elements())
                    {
                        precioActualizar = double.Parse(subelement.Element("PRECIO").Value);
                        idActualizar = subelement.Element("ID").Value;

                        await App.ProductoRepo.ActualizarProductos(idActualizar, precioActualizar);
                    }
                }

                if (element.Name == "Torres")
                {
                    foreach (XElement subelement in element.Elements())
                    {
                        precioActualizar = double.Parse(subelement.Element("PRECIO").Value);
                        idActualizar = subelement.Element("ID").Value;

                        await App.ProductoRepo.ActualizarProductos(idActualizar, precioActualizar);
                    }
                }

                if (element.Name == "Memorias")
                {
                    foreach (XElement subelement in element.Elements())
                    {
                        precioActualizar = double.Parse(subelement.Element("PRECIO").Value);
                        idActualizar = subelement.Element("ID").Value;

                        await App.ProductoRepo.ActualizarProductos(idActualizar, precioActualizar);
                    }
                }

                if (element.Name == "Graficas")
                {
                    foreach (XElement subelement in element.Elements())
                    {
                        precioActualizar = double.Parse(subelement.Element("PRECIO").Value);
                        idActualizar = subelement.Element("ID").Value;

                        await App.ProductoRepo.ActualizarProductos(idActualizar, precioActualizar);
                    }
                }




            }

            LoadContent();
        }

        #endregion

    }
}
