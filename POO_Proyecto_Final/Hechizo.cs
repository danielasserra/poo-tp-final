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
        #region ======= ATRIBUTOS =======

        private string nombre;
        private TipoHechizo tipo;
        private int nivel; // si no tiene suficiente nivel, no puede realizar el hechizo

        #endregion

        #region ======= PROPIEDADES =======

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

        // AUTOCALCULADA — SIEMPRE vale el nivel del hechizo
        public int CostoMana
        {
            get
            {
                return Nivel; // asignacion directa: CostoMana = nivel del hechizo.
            }                 // sin SET porq siempre vale el nivel del hechizo

        }

        // AUTORREFERENCIADAS - no tienen atributo
        public int Daño { get; private set; } = 0;

        public int Curacion { get; private set; } = 0;

        public int Defensa { get; private set; } = 0;

        #endregion

        #region ======= CONSTRUCTOR =======

        // constructor genérico
        public Hechizo(string nombre, TipoHechizo tipo, int nivel)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.nivel = nivel;
        }

        #region ======= METODOS FABRICA =======
        // No son constructores, crean objetos
        // Es una función que devuelve hechizos armados

        public static Hechizo CrearAtaque(string nombre, int nivelRequerido, int daño)
        {
            Hechizo h = new Hechizo(nombre, TipoHechizo.Ataque, nivelRequerido);
            h.Daño = daño;
            return h;
        }

        public static Hechizo CrearCuracion(string nombre, int nivelRequerido, int curacion)
        {
            Hechizo h = new Hechizo(nombre, TipoHechizo.Curacion, nivelRequerido);
            h.Curacion = curacion;
            return h;
        }

        public static Hechizo CrearDefensa(string nombre, int nivelRequerido, int defensa)
        {
            Hechizo h = new Hechizo(nombre, TipoHechizo.Defensa, nivelRequerido);
            h.Defensa = defensa;
            return h;
        }

        #endregion

        #region ===== LISTA ESTÁTICA DE HECHIZOS =====
        // Lista estática de hechizos disponibles 

        public static List<Hechizo> ListaHechizosDisponibles { get; } = new List<Hechizo>
        {
            // Curación
            CrearCuracion("Curar Heridas", 1, 8),
            CrearCuracion("Palabra de Curacion", 5, 5),
            CrearCuracion("Curar Heridas en Masa", 10, 25),
            CrearCuracion("Curar", 15, 70),

            // Ataque
            CrearAtaque("Ola Atronadora", 1, 16),
            CrearAtaque("Rayo de Luna", 2, 20),
            CrearAtaque("Muro de Viento", 5, 32),
            CrearAtaque("Marchitar", 10, 60),
            CrearAtaque("Tormenta de Fuego", 15, 80),

            // Defensa
            CrearDefensa("Piel Robliza", 2, 8),
            CrearDefensa("Escudo de Fuego", 8, 25)
        };

        #endregion
    }
}