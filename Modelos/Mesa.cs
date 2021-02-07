using ProyectoGrafica.Modelos.PartesMesa;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace ProyectoGrafica.Modelos
{
   public class Mesa : IFigura
    {

        List<IFigura> objects;


        public Mesa(float cx, float cy, float cz)
        {
            this.centrox = cx;
            this.centroy = cy;
            this.centroz = cz;



            Pata pata1 = new Pata("pata1");
            Pata pata2 = new Pata("");
            Pata pata3 = new Pata("");
            Pata pata4 = new Pata("");
            Tabla tabla = new Tabla();
            //0.0,-0.6,0.5
            tabla.moverA(this.centrox, this.centroy - 0.6f, this.centroz+ 0.5f);
            pata1.moverA(tabla.centrox - 1.4f, tabla.centroy - 0.8f, tabla.centroz);
            pata2.moverA(tabla.centrox - 1.4f, tabla.centroy + 0.7f, tabla.centroz);
            pata3.moverA(tabla.centrox + 1.4f, tabla.centroy - 0.8f, tabla.centroz);
            pata4.moverA(tabla.centrox + 1.4f, tabla.centroy + 0.8f, tabla.centroz);

            objects = new List<IFigura>
            {
               tabla, pata1,pata2,pata3,pata4
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
            escala.X = escx;
            escala.Y = escy;
            escala.Z = escz;

        }
    }
}
