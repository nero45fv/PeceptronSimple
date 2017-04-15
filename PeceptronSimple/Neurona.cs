using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeceptronSimple
{
    class Neurona
    {
        private List<Double> Entantes; // este arreglo guarda los dato q entraran a la neurona + el valor del  umbral
        private List<Double> W; // este arreglo guarda el peso de cada entraran + el valor del peso q pertenese umbral

        public int Salida
        { get; private set; }
        //public double Salida
        //{ get; private set; }

        public double TasaApredizaje
        { get; private set; }

        public String Name
        { get; private set; }

        public String ErrorString
        { get; private set; }

        public List<Double> Pesos
        { get { return this.W;} }

        public Neurona(String Name, Double TasaApredizaje)
        {
            this.Salida = 0;
            this.TasaApredizaje = TasaApredizaje;
            this.Name = Name;
            this.ErrorString = null;
            this.Entantes = new List<Double>();
            this.W = new List<Double>();
            
        }

        public void CargarDatos(List<Double> datoEntantes)
        {
            this.ErrorString = null;
            try
            {
                if (datoEntantes.Count != 0)
                {
                    this.Entantes = datoEntantes;
                    int Umbral = 1;
                    this.Entantes.Add(Umbral);
                    if (this.W.Count == 0)
                    { PesosAleatorios(); }
                }
                else { this.ErrorString = "Error: Neurona "+ this.Name + " CargarDatos, Parametro \"datoEntantes\" esta Vacio"; }
            }
            catch { this.ErrorString = "Error: Neurona " + this.Name + " CargarDatos, Parametro \"datoEntantes\" esta null"; }
            
        }

        private void PesosAleatorios()
        {
            Random azar = new Random();
            foreach (Double x in this.Entantes)
            { this.W.Add(azar.NextDouble() - azar.NextDouble()); }
        }

        private Double CalcularSumatoria()
        {
            Double resultado = 0;
            
            for (int i = 0; i < this.W.Count; i++)
            {
                Double tem = this.Entantes[i] * this.W[i];
                resultado = resultado + tem;
            }

            return resultado;
        }

        public void Calcula()
        {
            this.Salida = 0;
            //this.Salida = 1/(1+Math.Exp(-CalcularSumatoria()));
            if (CalcularSumatoria() > 0) Salida = 1; else Salida = 0;
        }

        public void ReCalcularPesos(Double Error)  //cambia los pesos con la fórmula de Frank Rosenblatt
        {
            for (int i = 0; i < this.W.Count; i++)
            {
                this.W[i] += this.TasaApredizaje * Error * this.Entantes[i];
            }
        }

    }
}
