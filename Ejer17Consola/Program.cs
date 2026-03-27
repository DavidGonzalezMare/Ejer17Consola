namespace Ejer17Consola
{
    internal class Program
    {
        static int LeerEntero(string mensaje)
        {
            int num;
            bool correcto;

            do
            {
                Console.Write(mensaje);
                // Si lo que leemos no es un entero devuelve false
                correcto = int.TryParse(Console.ReadLine(), out num);

                if (!correcto)
                {
                    Console.WriteLine("El texto introducido no es un entero correcto.");
                }

            } while (!correcto);
            // Continuamos pidiendo el número mientras no sea correcto

            return num;
        }

        static bool EsBisiesto(int anyo)
        {
            bool res;

            res = false;

            if (anyo % 4 == 0)
            {
                // Si es divisible entre 4 consideramos que es bisiesto.
                res = true;

                if (anyo % 100 == 0 && anyo % 400 != 0)
                    res = false;    // Si es divisible entre 100 y no entre 400.
            }

            return res;
        }

        // Tercera versión de fecha correcta.
        // Modularizamos más, utilizando varias funciones
        static private bool EsAnyoCorrecto(int anyo)
        {
            bool res = true;

            if (anyo < 0 || anyo > 2025)
                res = false;

            return res;
        }

        static private bool EsMesCorrecto(int mes)
        {
            bool res = true;

            if (mes < 1 || mes > 12)
                res = false;

            return res;
        }

        // Función que recibe el número de mes y año 
        // y devuelve el número de días correspondiente
        static private int CalcularNumeroDiasDelMes(int mes, int anyo)
        {
            int numDias = 31;

            if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
            {
                numDias = 30;
            }
            else
            {
                if (mes == 2)
                {
                    if (EsBisiesto(anyo))
                        numDias = 29;
                    else
                        numDias = 28;
                }
            }

            return numDias;
        }

        // Esta es la función que llamaremos para comprobar la fecha
        static private bool FechaValidaVersion3(int dia, int mes, int anyo)
        {
            bool res;

            if (EsAnyoCorrecto(anyo) && EsMesCorrecto(mes) && dia <= CalcularNumeroDiasDelMes(mes, anyo))
                res = true;
            else
                res = false;

            return res;
        }

        // Versión 1
        static void CambiarFechaDiaSiguienteVersion1(ref int dia, ref int mes, ref int anyo)
        {
            dia = dia + 1;
            if (dia > 31)
            {
                dia = 1;
                mes = mes + 1;
                if (mes > 12)
                {
                    mes = 1;
                    anyo = anyo + 1;
                }
            }
            else
            {
                if (mes == 4 || mes == 6 || mes == 9 || mes == 11)
                {
                    if (dia > 30)
                    {
                        dia = 1;
                        mes = mes + 1;
                    }
                }
                else
                {
                    if (mes == 2)
                    {
                        if (EsBisiesto(anyo))
                        {
                            if (dia > 29)
                            {
                                dia = 1;
                                mes = mes + 1;
                            }
                        }
                        else
                        {
                            if (dia > 28)
                            {
                                dia = 1;
                                mes = mes + 1;
                            }
                        }
                    }
                }
            }
        }

        // Versión utilizando funciones creadas antes.
        static void CambiarFechaDiaSiguienteVersion2(ref int dia, ref int mes, ref int anyo)
        {
            // Sumamos uno al día
            dia++;

            if (dia > CalcularNumeroDiasDelMes(mes, anyo))
            {
                // Hemos pasado al mes siguiente
                dia = 1;
                mes++;

                if (mes > 12)
                {
                    // Año siguiente
                    mes = 1;
                    anyo++;
                }
            }
        }


        static void Main(string[] args)
        {
            int dia, mes, anyo;
            bool fechaCorrecta;

            do
            {
                dia = LeerEntero("Introduzca el día: ");
                mes = LeerEntero("Introduzca el mes: ");
                anyo = LeerEntero("Introduzca el año: ");

                // Comprobamos la fecha. Utilizamos argumentos por nombre
                fechaCorrecta = FechaValidaVersion3(dia: dia, mes: mes, anyo: anyo);

                if (!fechaCorrecta)
                {
                    Console.WriteLine($"\n{dia:D2}/{mes:D2}/{anyo:D4} NO es una fecha correcta.\n");
                }

            } while (!fechaCorrecta);

            CambiarFechaDiaSiguienteVersion2(ref dia, ref mes, ref anyo);

            Console.WriteLine($"\nFecha del día siguiente: {dia:D2}/{mes:D2}/{anyo:D4}.\n");

            Console.WriteLine("Esta linea es solo para probar el push");
           
        }
    }
}

