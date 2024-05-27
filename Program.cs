// See https://aka.ms/new-console-template for more information
using System;
using System.Net;

public enum Cargos
{
    Auxiliar,
    Administrativo,
    Ingeniero,
    Especialista,
    Investigador

}
public class Empleados
{

    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public char EstadoCivil { get; set; }
    public DateTime FechaIngreso { get; set; }
    public double SueldoBasico { get; set; }
    public Cargos Cargo { get; set; }

    public Empleados(string nombre, string apellido, DateTime fechaNacimiento, char estadoCivil, DateTime fechaIngreso, double sueldoBasico, Cargos cargo)
    {
        Nombre = nombre;
        Apellido = apellido;
        FechaNacimiento = fechaNacimiento;
        EstadoCivil = estadoCivil;
        FechaIngreso = fechaIngreso;
        SueldoBasico = sueldoBasico;
        Cargo = cargo;
    }


    public int ObtenerAntiguedad()
    {
        int antiguedad = DateTime.Now.Year - FechaIngreso.Year;
        if (DateTime.Now.DayOfYear < FechaIngreso.DayOfYear)
            antiguedad -= 1;

        return antiguedad;
    }

    public int ObtenerEdad()
    {
        int edad = DateTime.Now.Year - FechaNacimiento.Year;
        if (DateTime.Now.DayOfYear < FechaNacimiento.DayOfYear)
            edad -= 1;

        return edad;
    }

    public int tiempoJubilacion()
    {
        int jub = 65;
        int tiempoJub = jub - ObtenerEdad();
        return tiempoJub;

    }

    public double calcularSalario()
    {
        double adicional = 0;

        int antiguedad = ObtenerAntiguedad();

        if (antiguedad <= 20)
        {
            adicional = SueldoBasico * (antiguedad / 100);

        }
        else
        {
            adicional = SueldoBasico * 0.25;
        }

        if (Cargo == Cargos.Ingeniero || Cargo == Cargos.Especialista)
        {
            adicional += (adicional * 0.50);
        }

        if (EstadoCivil == 'S')
        {
            adicional += 150000;
        }

        return adicional;
    }



}

class Program
{
    static void Main(string[] args)
    {

        Empleados[] empleados = new Empleados[3];
        empleados[0] = new Empleados("Juan", "Pérez", new DateTime(1985, 5, 20), 'S', new DateTime(2010, 3, 15), 45000.00, Cargos.Ingeniero);
        empleados[1] = new Empleados("María", "García", new DateTime(1990, 10, 10), 'C', new DateTime(2015, 7, 20), 55000.00, Cargos.Administrativo);
        empleados[2] = new Empleados("Pedro", "López", new DateTime(1980, 3, 8), 'C', new DateTime(2005, 9, 10), 60000.00, Cargos.Especialista);

        
        double montoSalarioTotal = 0;

        for (int i = 0; i < empleados.Length; i++)
        {
            montoSalarioTotal += empleados[i].calcularSalario();
        }
        Console.WriteLine($"El salario total de los tres es {montoSalarioTotal}");

        double proxAjub = empleados[0].tiempoJubilacion();

        for (int j = 0; j < empleados.Length; j++)
        {
            if (empleados[j].tiempoJubilacion() < proxAjub)
            {
                proxAjub = empleados[j].tiempoJubilacion();
            }
        }
        Console.WriteLine("El empleado mas proximo a jubilarse es " + proxAjub);
        
    }
}






