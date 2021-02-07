using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace ProyectoGrafica.Modelos.PartesMesa
{
    class Pata : IFigura
    {
        //public float pataGx;
        //public float pataGy;
        //public float pataGz;
        public float ancho;
        public float largo;
        public float alto;
        public String nombre;
        public Pata(string nombre)
        {
            this.centrox = 0;
            this.centroy = 0;
            this.centroz = 0;

            this.ancho = 0.1f;
            this.largo = 0.1f;
            this.alto = 2f;

            this.nombre = nombre;

        }
        public override void moverA(float puntoRefx, float puntoRefy, float puntoRefz)
        {
            this.centrox = puntoRefx;
            this.centroy = puntoRefy;
            this.centroz = puntoRefz;
        }
        public void cambiarDimensiones(float nuevoAncho, float nuevoLargo, float nuevoAlto)
        {
            this.ancho = nuevoAncho;
            this.largo = nuevoLargo;
            this.alto = nuevoAlto;
        }

        //    //(- 1.4f, -1.4f, 0.5f, 0.1f, 0.1f, -2f);
        //    //(- 1.4f,  0.1f, 0.5f, 0.1f, 0.1f, -2f);
        //    //(  1.4f, -1.4f, 0.5f, 0.1f, 0.1f, -2f);
        //    //(  1.4f,  0.1f, 0.5f, 0.1f, 0.1f, -2f);

        public override void draw()
        {

            float x = centrox;
            float y = centroy;
            float z = centroz;
            GL.PushMatrix();

            GL.Translate(trasladarOb.X, trasladarOb.Y, trasladarOb.Z);
            GL.Rotate(angulo.X, 1, 0, 0);
            GL.Rotate(angulo.Y, 0, 1, 0);
            GL.Rotate(angulo.Z, 0, 0, 1);
            
            GL.Scale(escala.X, escala.Y, escala.Z);
            //patas(pataGx, pataGy, pataGz);
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(0.52, 0.37, 0.26);
            //x,  y,   z
            //parte baja
            GL.Vertex3(x - ancho, y - largo, z);
            GL.Vertex3(x + ancho, y - largo, z);
            GL.Vertex3(x + ancho, y + largo, z);
            GL.Vertex3(x - ancho, y + largo, z);

            GL.Color3(1.0, 0.0, 0.0);

            GL.Vertex3(x - ancho, y - largo, z);
            GL.Vertex3(x + ancho, y - largo, z);
            GL.Vertex3(x + ancho, y - largo, z - alto);
            GL.Vertex3(x - ancho, y - largo, z - alto);

            GL.Color3(0.0, 1.0, 1.0);

            GL.Vertex3(x + ancho, y - largo, z);
            GL.Vertex3(x + ancho, y + largo, z);
            GL.Vertex3(x + ancho, y + largo, z - alto);
            GL.Vertex3(x + ancho, y - largo, z - alto);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex3(x + ancho, y + largo, z);
            GL.Vertex3(x - ancho, y + largo, z);
            GL.Vertex3(x - ancho, y + largo, z - alto);
            GL.Vertex3(x + ancho, y + largo, z - alto);

            GL.Color3(0.0, 1.0, 0.0);

            GL.Vertex3(x - ancho, y + largo, z);
            GL.Vertex3(x - ancho, y - largo, z);
            GL.Vertex3(x - ancho, y - largo, z - alto);
            GL.Vertex3(x - ancho, y + largo, z - alto);

            //parte alta
            GL.Color3(0.91, 0.76, 0.65);

            GL.Vertex3(x - ancho, y - largo, z - alto);
            GL.Vertex3(x + ancho, y - largo, z - alto);
            GL.Vertex3(x + ancho, y + largo, z - alto);
            GL.Vertex3(x - ancho, y + largo, z - alto);

            GL.End();
            GL.PopMatrix();
        }
        public override void trasladar()
        {

        }
        public override void mover(float cx, float cy, float cz)
        {
            //trasladarOb.X = centrox + cx;
            //trasladarOb.Y = centroy + cy;
            //trasladarOb.Z = centroz + cz;
            //centrox = cx;
            //centroy = cy;
            //centroz = cz;

            trasladarOb.X =  cx;
            trasladarOb.Y = cy;
            trasladarOb.Z =  cz;
            //centrox = cx;
            //centroy = cy;
            //centroz = cz;
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
