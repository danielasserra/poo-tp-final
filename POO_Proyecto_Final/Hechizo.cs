using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Proyecto_Final
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
        public Hechizo(string nombre, int nivel, int daño)
            : this(nombre, TipoHechizo.Ataque, nivel)
        {
            this.Daño = daño;
            this.CostoMana = nivel;
        }

        // constructor curacion
        public Hechizo(string nombre, int nivel, int curacion, bool esCuracion)
            : this(nombre, TipoHechizo.Curacion, nivel)
        {
            this.Curacion = curacion;
            this.CostoMana = nivel;
        }

        // constructor defensa
        public Hechizo(string nombre, int nivel, int defensa, char tipoDefensa)
            : this(nombre, TipoHechizo.Defensa, nivel)
        {
            this.Defensa = defensa;
            this.CostoMana = nivel;
        }
        #endregion

        // ---------------- Lista estática de hechizos disponibles ----------------
        public static List<Hechizo> ListaHechizosDisponibles { get; } = new List<Hechizo>
        {
            //curacion
            
            new Hechizo("Curar Heridas", 1, 8, true),
            new Hechizo("Palabra de curacion", 5, 5, true),
            new Hechizo("Curar Heridas en Masa", 10, 25, true),
            new Hechizo("Curar", 15, 70, true),

            // ataque
            new Hechizo("Ola Atronadora", 1, 16),
            new Hechizo("Rayo de Luna", 2, 20),
            new Hechizo("Muro de viento", 5, 32),
            new Hechizo("Marchitar", 10, 60),
            new Hechizo("Tormenta de fuego", 15, 80),

            // defensa
            new Hechizo("Piel Robliza", 2, 8, 'D'),
            new Hechizo("Escudo de fuego", 8, 25, 'D'),
        };

        #region Metodos


        #endregion
    }
}