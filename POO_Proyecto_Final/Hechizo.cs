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
        private string nombre;
        private TipoHechizo tipo;
        private int nivel; // si no tiene suficiente nivel, no puede realizar el hechizo
        private int costoMana; // si no tiene suficiente mana, no puede realizar el hechizo
    }
}
