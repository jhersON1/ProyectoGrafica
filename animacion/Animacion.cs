using ProyectoGrafica.Modelos;
using System.Threading;

namespace ProyectoGrafica.animacion
{
    public class Animacion 
    {
        
        Robot robot;
        int i;
        int pasos;
        public  bool moviendo;
        public string objeto;
        public int cuantosPasos;
        public int tipoAnimacion;
        public bool ejecucion;

        public Animacion(string objeto,int cuantosPasos,int tipoAnimacion, bool moviendo)
        {
            this.i = 0;
            this.pasos = 0;
            this.objeto = objeto;
            this.cuantosPasos = cuantosPasos;
            this.tipoAnimacion = tipoAnimacion;
            this.moviendo = moviendo;
           
            
        }
        public Animacion()
        {
            this.i = 0;
            this.moviendo = true;
        }
        public void setRobot(Robot nuevoRobot)
        {
            robot = nuevoRobot;
        }
        public void animarObjeto(string nombre, Robot nuevoRobot)
        {
            if (nombre == "Robot")
            {
                robot = nuevoRobot;
            }
        }


        //public void start()
        //{
        //    moviendo = true;
        //    Thread thread = new Thread(() =>
        //    {
        //        while (moviendo) { 
        //            if (i == 33)
        //            {
        //                i = 0;
        //            }
        //            caminarD(i);
        //            caminarI(i);
        //            //Thread.Sleep(50);

        //            i++;
        //        }
        //    });
        //    thread.Start();
        //}
        public void start(int cuantosPasos, int tipoAnimacion, bool moviendo )
        {
           
            Thread thread = new Thread(() =>
            {
                while (moviendo && pasos<=cuantosPasos*16)
                {
                    if (i == 33)
                    {
                        i = 0;
                    }
                    if (tipoAnimacion == 1)
                    {
                        caminarD(i);
                        caminarI(i);
                        
                    }
                    //else if(tipoAnimacion ==2 ){} --> para futuras animaciones
                    Thread.Sleep(50);
                    i++;
                    pasos++;
                }
            });
            thread.Start();

           
        }
        public void stop()
        {

            moviendo = false;
        }
        public void caminarD(int paso)
        {

            //IFigura[] vectorOb = objects.ToArray();
            //IFigura objeto = vectorOb[posicion];
            //Robot r = (Robot)objeto;
            if (paso < 3)
            {
                robot.paso1I();
            }
            else if (paso == 3)
            {
                robot.paso2I();
            }
            else if (paso == 4)
            {
                robot.paso3I();
            }
            else if (paso == 5)
            {
                robot.paso4I();
            }
            else if (paso == 6)
            {
                robot.paso5I();
            }
            else if (paso == 7)
            {
                robot.paso6I();
            }
            else if (paso > 7 && paso < 10)
            {
                robot.paso7I();
            }
            else if (paso == 10)
            {
                robot.paso8I();
            }
            else if (paso > 10 && paso < 13)
            {
                robot.paso9I();
            }
            else if (paso >= 13 && paso < 15)
            {
                robot.paso10I();
            }
            else if (paso == 15)
            {
                robot.paso11I();
            }
        }
        public void caminarI(int paso)
        {

            if (paso >= 16 && paso < 19)
            {
                robot.paso1D();
            }
            else if (paso == 19)
            {
                robot.paso2D();
            }
            else if (paso == 20)
            {
                robot.paso3D();
            }
            else if (paso == 21)
            {
                robot.paso4D();
            }
            else if (paso == 22)
            {
                robot.paso5D();
            }
            else if (paso == 23)//+3
            {
                robot.paso6D();
            }
            else if (paso > 23 && paso < 26)
            {
                robot.paso7D();
            }
            else if (paso >= 26 && paso < 27)
            {
                robot.paso8D();
            }
            else if (paso >= 28 && paso < 30)
            {
                robot.paso9D();
            }
            else if (paso >= 30 && paso < 32)
            {
                robot.paso10D();

            }
            else if (paso == 32)
            {
                robot.paso11D();
            }
        }
    }
}
