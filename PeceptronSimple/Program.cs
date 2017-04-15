using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeceptronSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[,] datos = { { 1, 1, 1 }, { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } }; //Tabla de verdad AND 

            Double tasaAprendizaje = 0.2;
            Neurona neuro = new Neurona("name",tasaAprendizaje);


            List<Double> pesos = new List<double>();
            String verPesos; int i = 0;
            int interacciones = 0;
            bool aprendiendo = true;
            while (aprendiendo)
            {
                interacciones += 1;
                
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                Console.WriteLine(" interacciones =" + interacciones);
                //Hasta que aprenda la tabla AND 

                aprendiendo = false;
                for (int cont = 0; cont <= 3 ; cont++)
                {
                    List<Double> Datos = new List<double>();
                    Datos.Add(datos[cont, 0]);
                    Datos.Add(datos[cont, 1]);

                    neuro.CargarDatos(Datos);
                    neuro.Calcula();


                    pesos = neuro.Pesos;

                    i = 1;
                     verPesos = "";
                    foreach (Double x in pesos)
                    {
                        verPesos = verPesos + " w" + i + "= "+x.ToString();
                        i += 1;
                    }
                    Console.WriteLine(verPesos);
                    i = 0;
                    Console.WriteLine("E1= {0}  E2={1}  SalidaEsperado={2}  SalidaObtenida={3}", datos[cont, 0], datos[cont, 1], datos[cont, 2], neuro.Salida);

                    int error = datos[cont, 2] - neuro.Salida;

                    if (error != 0)
                    { //Si la salida no coincide con lo esperado, cambia los pesos con la fórmula de Frank Rosenblatt 
                        neuro.ReCalcularPesos(error);
                        aprendiendo = true; //Y sigue buscando 
                    }
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------------");

            }
            i = 1;
            verPesos = "";
            foreach (Double x in pesos)
            {
                verPesos = verPesos + " w" + i + "= " + x.ToString();
                i += 1;
            }
            Console.WriteLine(verPesos);
            i = 0;


            for (int cont = 0; cont <= 3; cont++)
            {
                //Muestra el perceptron con la tabla AND aprendida 
                List<Double> Datos = new List<double>();
                Datos.Add(datos[cont, 0]);
                Datos.Add(datos[cont, 1]);

                neuro.CargarDatos(Datos);
                neuro.Calcula();

                Console.WriteLine("E1= {0}  E2={1}  SalidaEsperado={2}  SalidaObtenida={3}", datos[cont, 0], datos[cont, 1], datos[cont, 2], neuro.Salida);

            }
            Console.ReadLine();
        }

        

    }

}
