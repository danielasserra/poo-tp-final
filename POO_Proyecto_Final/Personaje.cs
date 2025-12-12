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
        public Personaje(string nombre, int nivel)
        {
            this.Nombre = nombre;
            this.Nivel = nivel;
            this.HpActual = this.HpMax; // inicia vida actual = vida maxima
            this.Consciente = true;
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

        public abstract void Atacar(Personaje p, int puntosdeDaño); // cada clase hija debe implementar este método definiendo su propio ataque.

        public virtual string RecibirDaño(int puntosDeDaño) // se pone en el metodo ataque del otro jugador
        {

            StringBuilder sb = new StringBuilder();

            int daño = puntosDeDaño - this.Constitucion;
            if (daño < 0)
            {
                daño = 0; // el daño no puede ser negativo.
            }

            if (daño > 0)
            {
                this.HpActual -= daño;

                sb.AppendLine($"El ataque impacta con fuerza y causa {daño} puntos de daño a {this.Nombre}.");
            }
            else
            {
                sb.AppendLine($"{this.Nombre} se mueve con maestria y ha logrado esquivar el ataque");
            }

            if (this.HpActual <= 0)
            {
                HpActual = 0;
                Consciente = false;
                sb.AppendLine($"{this.Nombre} ha caido inconsciente con la vida en 0.");
            }
            return sb.ToString();


        }
        public virtual string Descansar()
        {
            this.HpActual = this.HpMax;
            this.Consciente = true;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Tras un profundo respiro, {this.Nombre} siente cómo la energía vuelve a su cuerpo y espíritu.");

            return sb.ToString();
        }


        #endregion

    }
}