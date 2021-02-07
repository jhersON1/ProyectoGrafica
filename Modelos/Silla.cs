using OpenTK;
using ProyectoGrafica.Modelos.PartesMesa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
namespace ProyectoGrafica.Modelos
{
    public class Silla : IFigura
    {

        List<IFigura> objects;

        public Silla(float cx, float cy, float cz)
        {
            this.centrox = cx;
            this.centroy = cy;
            this.centroz = cz;

            estadoInicial();

        }

        public void estadoInicial()
        {
            Pata pata1 = new Pata("pata1");
            Pata pata2 = new Pata("pata2");
            Pata pata3 = new Pata("pata3");
            Pata pata4 = new Pata("pata4");
            Pata pata5 = new Pata("pata5");
            Tabla tabla = new Tabla();

            tabla.moverA(centrox, centroy, centroz);
            tabla.cambiarDimensiones(0.6f, 0.55f, 0.1f);

            pata1.cambiarDimensiones(0.05f, 0.05f, 1f);
            pata2.cambiarDimensiones(0.05f, 0.05f, 1f);
            pata3.cambiarDimensiones(0.05f, 0.05f, 2.5f);
            pata4.cambiarDimensiones(0.05f, 0.05f, 2.5f);
            pata5.cambiarDimensiones(0.05f, 0.5f, 0.2f);
            //0.0,-0.6,0.5
            //-0.5f,0f,-1.5f
            pata1.moverA(tabla.centrox - 0.5f, tabla.centroy - 0.45f, tabla.centroz);
            pata2.moverA(tabla.centrox - 0.5f, tabla.centroy + 0.45f, tabla.centroz);
            pata3.moverA(tabla.centrox + 0.5f, tabla.centroy - 0.45f, tabla.centroz + 1.5f);
            pata4.moverA(tabla.centrox + 0.5f, tabla.centroy + 0.45f, tabla.centroz + 1.5f);
            pata5.moverA(tabla.centrox + 0.5f, tabla.centroy, tabla.centroz + 1.5f);

            objects = new List<IFigura>
            {
               tabla, pata1,pata2,pata3,pata4,pata5
            };
        }


        public override void draw()
        {
            GL.PushMatrix();
            GL.Translate(trasladarOb.X, trasladarOb.Y, trasladarOb.Z);
            GL.Rotate(angulo.X, 1, 0, 0);
            GL.Rotate(angulo.Y, 0, 1, 0);
            GL.Rotate(angulo.Z, 0, 0, 1);           
            GL.Scale(escala.X, escala.Y, escala.Z);
            foreach (var ob in objects)
            {
                ob.draw();
            }
            GL.PopMatrix();
        }

        public override void mover(float cx, float cy, float cz)
        {

            trasladarOb.X = centrox + cx;
            trasladarOb.Y = centroy + cy;
            trasladarOb.Z = centroz + cz;
                centrox = cx;
                centroy = cy;
                centroz = cz;
           
        }
        public override void rotar(float angx, float angy, float angz)
        {
            angulo.X = angx;
            angulo.Y = angy;
            angulo.Z = angz;
        }
        public override void escalar(float escx, float escy, float escz)
        {
            escala.X =  escx;
            escala.Y =  escy;
            escala.Z =  escz;

        }

    }
}
