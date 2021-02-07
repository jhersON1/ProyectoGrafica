
using Newtonsoft.Json;
using ProyectoGrafica.animacion;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProyectoGrafica.Modelos
{
    class Escenario
    {
        List<IFigura> objects;
        Animacion animacion;
        public Escenario()
        {
            objects = new List<IFigura> { };
            animacion = new Animacion();
        }

        public void drawScene()
        {
            foreach (var ob in objects)
            {
                ob.draw();
            }
        }

        //Mover objetos    
        public void mover(float cx, float cy, float cz, int posicion)
        {
            IFigura[] vectorOb = objects.ToArray();
            IFigura objeto = vectorOb[posicion];

            objeto.mover(objeto.centrox + cx, objeto.centroy + cy, objeto.centroz + cz);

        }

        //Añade objetos
        public void addObjeto(int x)
        {
            if (x == 1)
            {
                Silla silla = new Silla(0, 0, 0);
                objects.Add(silla);
            }
            else if (x == 2)
            {
                Mesa mesa = new Mesa(0.0f, 0.0f, 0.0f);
                objects.Add(mesa);

            }
            else if (x == 3)
            {
                Robot robot = new Robot(0.0f, 0.0f, 0.0f);
                objects.Add(robot);
            }
        }

        //Eliminar objetos
        public void eliminarObjeto(int x)
        {
            IFigura[] vectorOb = objects.ToArray();
            for (int i = 0; i < vectorOb.Length; i++)
            {
                if (x == 1)
                {
                    IFigura objeto = vectorOb[i];
                    if (objeto.GetType() == typeof(Silla))
                    {
                        //Silla ob = (Silla)objeto;
                        objects.RemoveAt(i);
                        break;
                    }
                }
                else if (x == 2)
                {
                    IFigura objeto = vectorOb[i];
                    if (objeto.GetType() == typeof(Mesa))
                    {
                        //Silla ob = (Silla)objeto;
                        objects.RemoveAt(i);
                        break;
                    }

                }
                else if (x == 3)
                {
                    IFigura objeto = vectorOb[i];
                    if (objeto.GetType() == typeof(Robot))
                    {
                        //Silla ob = (Silla)objeto;
                        objects.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        //Rotar objetos
        public void rotar(float angx, float angy, float angz, int posicion)
        {
            IFigura[] vectorOb = objects.ToArray();
            IFigura objeto = vectorOb[posicion];

            objeto.rotar(objeto.angulo.X + angx, objeto.angulo.Y + angy, objeto.angulo.Z + angz);
            //Robot r = (Robot)objeto;
            //// r.rotarPiernaI(r.angulo.X + angx);
            //r.animarPiernaS(angx, "piernaD");
        }



        public void caminar(int posicion)
        {
            IFigura[] vectorOb = objects.ToArray();
            IFigura objeto = vectorOb[posicion];
            Robot r = (Robot)objeto;

            Animacion[] a = cargarJson();

            animacion.animarObjeto(a[0].objeto,r);
            animacion.start(a[0].cuantosPasos,a[0].tipoAnimacion,a[0].moviendo);

        }
        public Animacion[] cargarJson()
        {
            Animacion[] a=null;
            string archivoJson;
            string path = @"C:\Users\neON\source\repos\ProyectoGrafica\archivo.json";

            using (var reader = new StreamReader(path))
            {
                archivoJson = reader.ReadToEnd();

            }
            try
            {
                 a = JsonConvert.DeserializeObject<Animacion[]>(archivoJson);
                
                
            }
            catch (Exception)
            {

            }
            return a; 
        }
        public void dejarDeCaminar()
        {
            animacion.stop();
        }

        //Escalar objetos
        public void escalar(float escx, float escy, float escz, int posicion)
        {
            IFigura[] vectorOb = objects.ToArray();
            IFigura objeto = vectorOb[posicion];

            objeto.escalar(objeto.escala.X + escx, objeto.escala.Y + escy, objeto.escala.Z + escz);
        }



    }
}


