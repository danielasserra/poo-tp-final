using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Proyecto_Final
{
    internal class Druida
    {
        #region Atributos

        private string nombre;
        private int nivel;
        private int hpMax;
        private int hpActual;
        private int constitucion;
        private int manaMax;
        private int manaActual;
        private bool consciente;
        private string formaSalvaje;
        private int formaSalvajeMax;
        private int formaSalvajeActual;
        // ataque?


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
            private set // solo se modifica con metodo SubirNivel()
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
            private set
            {
                this.hpActual = value;
            }
        }


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
            private set
            {
                this.consciente = value;
            }
        }
        public string FormaSalvaje  // solo lectura porque se modifica mediante metodo
        {
            get
            {
                return this.formaSalvaje;
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
        {
            this.nombre = nombre;
            this.nivel = nivel;
            this.hpActual = this.hpMax; // inicia vida actual = vida maxima
            this.manaActual = this.manaMax; // inicia energia magica actual = energia magica maxima
            this.consciente = true;
            this.formaSalvaje = "Aun no se transformó";
            this.formaSalvajeActual = this.FormaSalvajeMax;
        }

        #endregion

        #region Metodos

        public string MostrarDruida()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("================= D&D =================");
            sb.AppendLine("------------- CLASE DRUIDA -------------");

            sb.AppendLine($"\nNombre: {this.Nombre}");
            sb.AppendLine($"\nNivel: {this.Nivel}");
            sb.AppendLine($"\nVida: {this.HpActual} / {this.HpMax}");
            sb.AppendLine($"\nCapacidad defensiva: " + this.Constitucion);
            sb.AppendLine($"\nForma Salvaje: " + this.FormaSalvaje);
            sb.AppendLine($"\nTransformaciones Disponibles: {this.FormaSalvajeActual} / {this.FormaSalvajeMax}");
            sb.AppendLine($"\nEnergía mágica Disponible: {this.ManaActual} / {this.ManaMax}");
            sb.AppendLine($"\nEstá consciente: " + this.Consciente);
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
                sb.AppendLine($"{nombre} convoca la fuerza de la naturaleza y se transforma en {animal}");
                sb.AppendLine("El rugido del espíritu salvaje resuena en todo el bosque...");
            }
            else
            {
                sb.AppendLine($"{nombre} intenta transformarse en {animal}, pero la magia falla...");
                sb.AppendLine($"Energía actual: {this.ManaActual}, Transformaciones restantes: {this.formaSalvajeActual}");
                sb.AppendLine("El poder de la transformación ha sido insuficiente. ¡El bosque guarda silencio ante tu intento fallido!");
            }
            return sb.ToString();
        }


        public void Descansar()
        {
            this.HpActual = this.HpMax;
            this.ManaActual = this.ManaMax;
            this.Consciente = true;
        }

        public void Defenderse(int puntosDeDaño)
        {
            if (puntosDeDaño < this.Constitucion)
            {
                return;
            }
            else if ((this.HpActual - puntosDeDaño) <= 0)
            {
                this.HpActual = 0;
                this.Consciente = false;
            }
            else
            {
                this.HpActual -= puntosDeDaño;
            }
        }

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
// FALTA!!!

// Atacar() - dañoAtaque - Mana
// Ver metodos que falta completar