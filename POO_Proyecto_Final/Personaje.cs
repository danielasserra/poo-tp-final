using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Proyecto_Final
{
    public abstract class Personaje
    {
        #region Atributos

        protected string nombre;
        protected int nivel;
        protected int hpMax;
        protected int hpActual;
        protected int constitucion;
        protected bool consciente;


        #endregion

        #region Propiedades

        public string Nombre // se puede ver y modificar
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        public int Nivel
        {
            get
            {
                return this.nivel;
            }
            protected set // solo se modifica con metodo SubirNivel()
            {
                if (this.nivel < 0)
                {
                    this.nivel = 0;
                }
                else if (this.nivel > 20)
                {
                    this.nivel = 20;
                }
                this.nivel = value;
            }
        }
        public int HpMax  // solo lectura porque se modifica mediante metodo
        {                 // propiedad calculada, no va en constructor
            get
            {
                return this.Nivel * 10; // nivel x 10 = vida
            }
        }
        public int HpActual  // solo lectura porque se modifica mediante metodo (curarse(), defenderse()...)
        {
            get
            {
                return this.hpActual;
            }
            protected set
            {
                this.hpActual = value;
            }
        }
        public int Constitucion
        {
            get
            {
                return (int)(this.HpMax * 0.25); // siempre 25% de la vida máxima actual
            }
        }

        public bool Consciente  // solo lectura porque se modifica mediante metodo
        {
            get
            {
                return this.consciente;
            }
            protected set
            {
                this.consciente = value;
            }
        }

        #endregion

        #region Constructor
        protected Personaje(string nombre, int nivel)
        {
            this.nombre = nombre;
            this.nivel = nivel;
            this.hpActual = this.HpMax; // inicia vida actual = vida maxima
            this.consciente = true;
        }

        #endregion

        #region Metodos

        public virtual string MostrarPersonaje()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("================= D&D =================");
            sb.AppendLine("---------- Hoja de personaje ----------");

            sb.AppendLine($"\nNombre: {this.Nombre}");
            sb.AppendLine($"\nNivel: {this.Nivel}");
            sb.AppendLine($"\nVida: {this.HpActual} / {this.HpMax}");
            sb.AppendLine($"\nCapacidad defensiva: " + this.Constitucion);
            sb.AppendLine($"\nEstá consciente: " + this.Consciente);

            return sb.ToString();

        }

        public abstract void Atacar(); // cada clase hija debe implementar este método definiendo su propio ataque.


        #endregion

    }
}