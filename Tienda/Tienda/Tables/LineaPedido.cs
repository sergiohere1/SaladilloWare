using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Tables
{
    public class LineaPedido
    {
        #region Campos
        public string cliente;
        public string placa;
        public string procesador;
        public string torre;
        public string memoria;
        public string grafica;
        public double precio;
        #endregion

        #region Propiedades 
        public string Cliente
        {
            set
            {
                this.cliente = value;
            }
            get
            {
                return cliente;
            }
        }

        public string Placa
        {
            set
            {
                this.placa = value;
            }
            get
            {
                return placa;
            }
        }

        public string Procesador
        {
            set
            {
                this.procesador = value;
            }
            get
            {
                return procesador;
            }
        }

        public string Torre
        {
            set
            {
                this.torre = value;
            }
            get
            {
                return torre;
            }
        }

        public string Memoria
        {
            set
            {
                this.memoria = value;
            }
            get
            {
                return memoria;
            }
        }

        public string Grafica
        {
            set
            {
                this.grafica = value;
            }
            get
            {
                return grafica;
            }
        }

        public double Precio
        {
            set
            {
                this.precio = value;
            }
            get
            {
                return precio;
            }
        }

        #endregion

        #region Constructor
        public LineaPedido(string cliente, string placa, string procesador, string torre, string memoria, string grafica, double precio)
        {
            this.cliente = cliente;
            this.placa = placa;
            this.procesador = procesador;
            this.torre = torre;
            this.memoria = memoria;
            this.grafica = grafica;
            this.precio = precio;
        }
        #endregion

        override
        public string ToString()
        {
            return string.Format("Cliente : {0} | Placa: {1} | Procesador:{2} | Torre: {3} | " +
                "Memoria: {4} | Gráfica: {5} | Precio: {6} € |", cliente, placa, procesador, torre, memoria, grafica, precio);
        }
    }
}
