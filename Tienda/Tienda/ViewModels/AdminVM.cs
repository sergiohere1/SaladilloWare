using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Tables;

namespace Tienda.ViewModels
{
    public class AdminVM : INotifyPropertyChanged
    {
        public List<LineaPedido> pedidos;
        
       
        public event PropertyChangedEventHandler PropertyChanged;

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

        
    }
}
