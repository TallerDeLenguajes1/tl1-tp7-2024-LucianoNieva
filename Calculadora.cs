using System.Reflection.Metadata.Ecma335;

namespace EspacioCalculadora
{
    public class Calculadora
    {
        private double dato;

        public Calculadora(){

            dato = 10;
        }
        public void Sumar(double termino)
        {

            dato += termino;

        }

        public void Restar(double termino)
        {

            dato -= termino;
        }

        public void Multiplicar(double termino)
        {

            dato *= termino;
        }

        public void Dividir(double termino)
        {
            if (termino != 0)
            {
                dato /= termino;
            }
            else
            {
                Console.WriteLine("Error: División por cero no es permitida.");
            }
        }

        public void limpiar(){

            dato = 0;
        }

        public double resultado
        {
            get => dato;
            set => dato = value;
        }
    }
}