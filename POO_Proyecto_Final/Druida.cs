using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Proyecto_Final
{
    internal class Druida : Personaje
    {
        #region Atributos

        // estos atributos los paso a la clase base: PJ_Base
        //private string nombre;
        //private int nivel;
        //private int hpMax;
        //private int hpActual;
        //private int constitucion;
        //private bool consciente;
        private int manaMax;
        private int manaActual;
        private string formaSalvaje;
        private int formaSalvajeMax;
        private int formaSalvajeActual;
        // ataque?


        #endregion

        #region Propiedades

        //public string Nombre // se puede ver y modificar
        //{
        //    get
        //    {
        //        return this.nombre;
        //    }
        //    set
        //    {
        //        this.nombre = value;
        //    }
        //}
        //public int Nivel
        //{
        //    get
        //    {
        //        return this.nivel;
        //    }
        //    private set // solo se modifica con metodo SubirNivel()
        //    {
        //        if (this.nivel < 0)
        //        {
        //            this.nivel = 0;
        //        }
        //        else if (this.nivel > 20)
        //        {
        //            this.nivel = 20;
        //        }
        //        this.nivel = value;
        //    }
        //}
        //public int HpMax  // solo lectura porque se modifica mediante metodo
        //{                 // propiedad calculada, no va en constructor
        //    get
        //    {
        //        return this.Nivel * 10; // nivel x 10 = vida
        //    }
        //}
        //public int HpActual  // solo lectura porque se modifica mediante metodo (curarse(), defenderse()...)
        //{
        //    get
        //    {
        //        return this.hpActual;
        //    }
        //    private set
        //    {
        //        this.hpActual = value;
        //    }
        //}


        public int ManaMax  // solo se puede ver porque se modifica mediante metodo
        {                   // propiedad calculada, no va en constructor
            get
            {
                return this.Nivel * 2; // Nivel x 2 = energia magica
            }
        }

        public int ManaActual
        {
            get
            {
                return this.manaActual;
            }
            private set
            {
                this.manaActual = value; // permite usar la propiedad como interfaz interna y 
            }                            // mantener todo más encapsulado y uniforme
        }

        //public int Constitucion
        //{
        //    get
        //    {
        //        return (int)(this.HpMax * 0.25); // siempre 25% de la vida máxima actual
        //    }
        //}

        //public bool Consciente  // solo lectura porque se modifica mediante metodo
        //{
        //    get
        //    {
        //        return this.consciente;
        //    }
        //    private set
        //    {
        //        this.consciente = value;
        //    }
        //}
        public string FormaSalvaje  // solo lectura porque se modifica mediante metodo
        {
            get
            {
                return this.formaSalvaje;
            }
            private set
            {
                this.formaSalvaje = value;
            }
        }

        public int FormaSalvajeMax
        {
            get
            {
                return this.Nivel;
            }
        }

        public int FormaSalvajeActual
        {
            get
            {
                return this.formaSalvajeActual;
            }
            private set
            {
                this.formaSalvajeActual = value;
            }
        }

        #endregion

        #region Constructores

        public Druida(string nombre, int nivel)
            : base(nombre, nivel)
        {
            this.ManaActual = this.ManaMax; // inicia energia magica actual = energia magica maxima
            this.FormaSalvaje = "Aun no se transformó";
            this.FormaSalvajeActual = this.FormaSalvajeMax;
        }

        #endregion

        #region Metodos

        public override string MostrarPersonaje()
        {
            string infoBase = base.MostrarPersonaje();

            StringBuilder sb = new StringBuilder(infoBase);

            sb.AppendLine($"\nClase: Druida");
            sb.AppendLine($"\nForma Salvaje: " + this.FormaSalvaje);
            sb.AppendLine($"\nTransformaciones Disponibles: {this.FormaSalvajeActual} / {this.FormaSalvajeMax}");
            sb.AppendLine($"\nEnergía mágica Disponible: {this.ManaActual} / {this.ManaMax}");
            sb.AppendLine("\n----------------------------------------");
            return sb.ToString();
        }

        public string Transformarse(string animal)
        {
            StringBuilder sb = new StringBuilder();

            if (manaActual >= 1 && formaSalvajeActual >= 1)
            {
                this.formaSalvaje = animal;
                this.manaActual -= 1;
                this.formaSalvajeActual -= 1;
                sb.AppendLine($"{this.Nombre} convoca la fuerza de la naturaleza y se transforma en {animal}");
                sb.AppendLine("El rugido del espíritu salvaje resuena en todo el bosque...");
            }
            else
            {
                sb.AppendLine($"{this.Nombre} intenta transformarse en {animal}, pero la magia falla...");
                sb.AppendLine($"Energía actual: {this.ManaActual}, Transformaciones restantes: {this.formaSalvajeActual}");
                sb.AppendLine("El poder de la transformación ha sido insuficiente. ¡El bosque guarda silencio ante tu intento fallido!");
            }
            return sb.ToString();
        }


        public override string Descansar()
        {
            string infoBase = base.Descansar(); // llamo al metodo base
            this.ManaActual = this.ManaMax; // añado elementos especificos
            this.FormaSalvajeActual = this.FormaSalvajeMax;

            StringBuilder sb = new StringBuilder(infoBase);

            sb.AppendLine($"Su forma salvaje se renueva y su poder mágico alcanza su plenitud.");
            sb.AppendLine($"Vida actual: {this.HpActual} | Magia actual: {this.ManaActual} | Transformaciones disponibles: {this.FormaSalvajeActual}");

            return sb.ToString();
        }

        // Sobreescribiendo metodo para que funcione la clase, hay q modificarlo porq el Druida ataca con hechizos:
        public override void Atacar(Personaje p, int puntosDeDaño)
        {
            p.RecibirDaño(puntosDeDaño);
        }

        public void Defenderse(int puntosDeDaño)
        {
            if (puntosDeDaño < this.Constitucion)
            {
                return;
            }
            else if ((this.HpActual - puntosDeDaño) < 0)
            {
                this.HpActual = 0;
                this.Consciente = false;
            }
            else
            {
                this.HpActual -= puntosDeDaño;
            }
        }

        // --------- METODO RECIBIR DAÑO ------------
        // Heredado de clase padre Personaje
        // No necesita ser declarado
        // TENGO QUE MODIFICARLO con override porque el DRUIDA SE DEFIENDE CON HECHIZOS
        // por ahora lo dejo asi para probar.

        public void Curarse(int puntosDeVida)
        {
            if (this.ManaActual >= 1)
            {
                if ((this.hpActual + puntosDeVida) > this.hpMax)
                {
                    this.hpActual = this.hpMax;
                }
                else
                {
                    this.hpActual += puntosDeVida;
                }

                this.ManaActual -= 1;
            }
        }

        public void SubirNivel()
        {
            if (this.Nivel < 20)
            {
                this.Nivel++;
                this.HpActual = this.HpMax;
                this.ManaActual = this.ManaMax;
                this.Consciente = true;
            }
        }

        #endregion

    }
}