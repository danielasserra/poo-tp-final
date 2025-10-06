using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio01_Druida_Final
{
    public enum TipoHechizo
    {
        Ataque,
        Defensa,
        Curacion,
        Movimiento,
        Otro
    }
    internal class Hechizo
    {
        #region Atributos

        private string nombre;
        private TipoHechizo tipo;
        private int nivel; // si no tiene suficiente nivel, no puede realizar el hechizo
        private int costoMana; // si no tiene suficiente mana, no puede realizar el hechizo


        #endregion

        #region Propiedades

        public string Nombre
        {
            get
            {
                return nombre;
            }
        }

        public TipoHechizo Tipo
        {
            get
            {
                return tipo;
            }
        }

        public int Nivel
        {
            get
            {
                return nivel;
            }
        }

        public int CostoMana
        {
            get
            {
                return nivel; // asignacion directa: CostoMana = nivel del hechizo.
            }
            private set
            {
                CostoMana = nivel;
            }
        }

        public int Daño { get; private set; } = 0; // auto-referencial 

        public int Curacion { get; private set; } = 0;

        public int Defensa { get; private set; } = 0;

        #endregion

        #region Constructor

        // constructor genérico
        public Hechizo(string nombre, TipoHechizo tipo, int nivel)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.nivel = nivel;
        }

        // constructor ataque
        public Hechizo(string nombre, TipoHechizo tipo, int nivel, int daño)
            : this(nombre, TipoHechizo.Ataque, nivel)
        {
            this.Daño = daño;
            this.CostoMana = nivel;
        }

        // constructor curacion
        public Hechizo(string nombre, TipoHechizo tipo, int nivel, int curacion)
            : this(nombre, TipoHechizo.Curacion, nivel)
        {
            this.Curacion = curacion;
            this.CostoMana = nivel;
        }
        #endregion

        #region Metodos


        #endregion
    }
}