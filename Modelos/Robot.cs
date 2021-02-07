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
    public class Robot : IFigura
    {

        List<IFigura> objects;

        public Robot(float cx, float cy, float cz)
        {
            this.centrox = cx;
            this.centroy = cy;
            this.centroz = cz;


            estadoInicial();
        }

        private void estadoInicial()
        {

            Pata pieI = new Pata("pieI");
            Pata pieD = new Pata("pieD");
            Pata antepiernaI = new Pata("antepiernaI");
            Pata antepiernaD = new Pata("antepiernaD");
            Pata piernaI = new Pata("piernaI");
            Pata piernaD = new Pata("piernaD");
            Pata cuerpo = new Pata("cuerpo");
            Pata brazoI = new Pata("brazoI");
            Pata brazoD = new Pata("brazoD");
            Pata antebrazoI = new Pata("antebrazoI");
            Pata antebrazoD = new Pata("antebrazoD");
            Pata cabeza = new Pata("cabeza");


            pieI.cambiarDimensiones(0.05f, 0.15f, 0.1f);
            pieD.cambiarDimensiones(0.05f, 0.15f, 0.1f);
            antepiernaI.cambiarDimensiones(0.05f, 0.05f, 0.4f);
            antepiernaD.cambiarDimensiones(0.05f, 0.05f, 0.4f);
            piernaI.cambiarDimensiones(0.05f, 0.05f, 0.5f);
            piernaD.cambiarDimensiones(0.05f, 0.05f, 0.5f);
            cuerpo.cambiarDimensiones(0.3f, 0.3f, 1.1f);
            brazoI.cambiarDimensiones(0.05f, 0.05f, 0.6f);
            brazoD.cambiarDimensiones(0.05f, 0.05f, 0.6f);
            antebrazoI.cambiarDimensiones(0.05f, 0.05f, 0.55f);
            antebrazoD.cambiarDimensiones(0.05f, 0.05f, 0.55f);
            cabeza.cambiarDimensiones(0.4f, 0.4f, 0.5f);


            pieI.mover(-0.2f, -1f, -0.8f);
            pieD.mover( 0.2f, -1f, -0.8f);
            antepiernaI.mover(-0.2f, -0.9f, -0.4f);
            antepiernaD.mover( 0.2f, -0.9f,- 0.4f);
            piernaI.mover(-0.2f, -0.9f, 0.13f);
     
    
            piernaD.mover( 0.2f, -0.9f, 0.13f);
            cuerpo.mover(0.0f, -0.9f, 1.13f);
            brazoI.mover(-0.4f, -0.9f, 1.12f);
            brazoD.mover( 0.4f, -0.9f, 1.12f);
            antebrazoI.mover(-0.4f,- 0.9f, 0.52f);
            antebrazoD.mover( 0.4f, -0.9f, 0.52f);
            cabeza.mover(0.0f, -0.9f, 1.68f);
            objects = new List<IFigura>
            {
               //pieI,pieD,
                antepiernaI,
                antepiernaD,
               piernaI,piernaD,

                cuerpo,brazoI,brazoD,
               antebrazoI,antebrazoD,cabeza
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
            //trasladarOb.X =  cx;
            //trasladarOb.Y =  cy;
            //trasladarOb.Z =  cz;
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

        //rotar partes del robot

        public void moverParte(float ejex, float ejey, float ejez,string nombre)
        {

            foreach (var ob in objects)
            {

                if (ob.GetType() == typeof(Pata))
                {
                    Pata unaPata = (Pata)ob;
                    if (unaPata.nombre == nombre)
                    {
                        unaPata.mover(unaPata.trasladarOb.X + ejex, unaPata.trasladarOb.Y + ejey, unaPata.trasladarOb.Z + ejez);

                    }
                }
            }

        }
        public void rotarParte(float angx,string nombre)
        {

            foreach (var ob in objects)
            {

                if (ob.GetType() == typeof(Pata))
                {
                    Pata unaPata = (Pata)ob;
                    if (unaPata.nombre == nombre)
                    {
                        unaPata.rotar(unaPata.angulo.X + angx, unaPata.angulo.Y, unaPata.angulo.Z);
                        //moverAntePiernaI(0, -0.095f, 0.07f);
                        //rotarAntePiernaI(-angx + 0.05f);
                       
                        
                    }
                }
            }

        }

        //animacion de subida para las dos piernas
        
        // para la DERECHA
        //paso 1 con 10 grados de parametro, se ejecuta 3 veces
        public void paso1D()
        {
            rotarParte(10f, "piernaD");
            moverParte(0, 0.08f,0.03f,"antepiernaD");
            rotarParte(-10f - 1.5f, "antepiernaD");

            //de las piernas para arriba
            moverParte(0f, 0.025f, 0.001f, "cuerpo");
            moverParte(0f, 0.025f, 0.001f, "brazoI");
            moverParte(0f, 0.025f, 0.001f, "brazoD");
            moverParte(0f, 0.025f, 0.001f, "antebrazoI");
            moverParte(0f, 0.025f, 0.001f, "antebrazoD");
            moverParte(0f, 0.025f, 0.001f, "cabeza");

            rotarParte(-1, "brazoD");
            rotarParte(-2, "antebrazoD");
            rotarParte(1, "brazoI");
            rotarParte(2, "antebrazoI");

        }
        // paso #2 se ejecuta 1 vez
        public void paso2D()
        {
            rotarParte(10f, "piernaD");
            moverParte(0, 0.08f, 0.03f, "antepiernaD");
            rotarParte(10f , "antepiernaD");

            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");

            //movimiento de brazos
            rotarParte(-1, "brazoD");
            rotarParte(-2, "antebrazoD");
            rotarParte(1, "brazoI");
            rotarParte(2, "antebrazoI");

        }
        //paso #3 se ejecuta 1 vez
        public void paso3D()
        {
            moverParte(0, 0.02f, -0.02f, "piernaD");
            moverParte(0, 0.02f, -0.02f, "antepiernaD");
            rotarParte(-5f,"piernaI");
            rotarParte(-5f,"antepiernaI");
            moverParte(0, 0.05f, -0.02f, "piernaI");

            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(-1, "brazoD");
            rotarParte(-2, "antebrazoD");
            rotarParte(1, "brazoI");
            rotarParte(2, "antebrazoI");
        }
        //paso #4 ejecuta 1 veces
        public void paso4D()
        {
            moverParte(0, 0.02f, -0.02f, "piernaD");
            moverParte(0, 0.02f, -0.02f, "antepiernaD");
            rotarParte(-7f, "piernaD");
            rotarParte(10f, "antepiernaD");
            rotarParte(-3f, "piernaI");
            rotarParte(-3f, "antepiernaI");
            moverParte(0, 0.05f, -0.02f, "piernaI");
            moverParte(0, 0.05f, -0.01f, "piernaD");

            //de las piernas para arriba
            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");

            //movimiento de brazos
            rotarParte(-1, "brazoD");
            rotarParte(-2, "antebrazoD");
            rotarParte(1, "brazoI");
            rotarParte(2, "antebrazoI");
        }
        //paso # 5 se ejecuta 1 vez
        public void paso5D()
        {
            moverParte(0, 0.04f, -0.04f, "piernaD");
            moverParte(0, 0.04f, -0.04f, "antepiernaD");
            rotarParte(10f, "antepiernaD");
            rotarParte(-3f, "piernaI");
            rotarParte(-3f, "antepiernaI");

            //de las piernas para arriba
            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(-1, "brazoD");
            rotarParte(-2, "antebrazoD");
            rotarParte(1, "brazoI");
            rotarParte(2, "antebrazoI");
        }
        // paso #6 se ejecuta 1 vez
        public void paso6D()
        {
            moverParte(0, -0.01f, -0.04f, "piernaD");
            moverParte(0, -0.01f, -0.04f, "antepiernaD");
            rotarParte(8f, "antepiernaD");

            //de las piernas para arriba
            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(1, "brazoD");
            rotarParte(2, "antebrazoD");
            rotarParte(-1, "brazoI");
            rotarParte(-2, "antebrazoI");

        }
        // paso #7 se ejecuta 2 veces
        public void paso7D()
        {
            moverParte(0, 0.08f, 0.04f, "piernaD");
            rotarParte(-9f, "piernaD");
            moverParte(0, 0.05f, 0.04f, "piernaI");
            moverParte(0, 0.05f, 0.05f, "antepiernaI");
            rotarParte(-9f, "antepiernaI");

            //de las piernas para arriba
            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(1, "brazoD");
            rotarParte(2, "antebrazoD");
            rotarParte(-1, "brazoI");
            rotarParte(-2, "antebrazoI");
        }
        //paso #8 se ejecuta 2 veces
        public void paso8D()
        {
            rotarParte(-10f, "piernaD");
            moverParte(0, 0.08f, 0.02f, "piernaD");

            //rotarParte(-9f, "piernaI");
            moverParte(0, 0.05f, 0.01f, "piernaI");
            rotarParte(-9f, "antepiernaI");
            moverParte(0, 0.05f, 0.02f, "antepiernaI");

            //de las piernas para arriba
            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(1, "brazoD");
            rotarParte(2, "antebrazoD");
            rotarParte(-1, "brazoI");
            rotarParte(-2, "antebrazoI");

        }
        //paso #9 se ejecuta 2 veces
        public void paso9D()
        {
            moverParte(0, 0.01f, 0.001f, "piernaD");

            moverParte(0, 0.05f, 0.01f, "piernaI");
            rotarParte(5f, "piernaI");
            rotarParte(9f, "antepiernaI");
            moverParte(0, 0.08f, 0.000f, "antepiernaI");

            //de las piernas para arriba
            moverParte(0f, 0.025f, 0.001f, "cuerpo");
            moverParte(0f, 0.025f, 0.001f, "brazoI");
            moverParte(0f, 0.025f, 0.001f, "brazoD");
            moverParte(0f, 0.025f, 0.001f, "antebrazoI");
            moverParte(0f, 0.025f, 0.001f, "antebrazoD");
            moverParte(0f, 0.025f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(1, "brazoD");
            rotarParte(2, "antebrazoD");
            rotarParte(-1, "brazoI");
            rotarParte(-2, "antebrazoI");
        }
        //paso #10 se ejecuta 2 veces
        public void paso10D()
        {
            moverParte(0, 0.02f, -0.001f, "antepiernaD");
            rotarParte(-2f, "antepiernaD");
            moverParte(0, 0.02f, 0.0009f, "piernaD");
            rotarParte(-1.5f, "piernaD");

            moverParte(0, 0.05f, -0.03f, "piernaI");
            rotarParte(1.75f, "piernaI");
            moverParte(0, 0.07f, -0.05f, "antepiernaI");
            rotarParte(10f, "antepiernaI");
            //de las piernas para arriba
            moverParte(0f, 0.025f, 0.001f, "cuerpo");
            moverParte(0f, 0.025f, 0.001f, "brazoI");
            moverParte(0f, 0.025f, 0.001f, "brazoD");
            moverParte(0f, 0.025f, 0.001f, "antebrazoI");
            moverParte(0f, 0.025f, 0.001f, "antebrazoD");
            moverParte(0f, 0.025f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(1, "brazoD");
            rotarParte(2, "antebrazoD");
            rotarParte(-1, "brazoI");
            rotarParte(-2, "antebrazoI");

        }
        public void paso11D()
        {

            moverParte(0, 0.03f, 0.039f, "piernaD");
            moverParte(0, 0.0f, 0.00f, "piernaI");
            moverParte(0, 0.02f, 0.015f, "antepiernaD");
            moverParte(0, 0.0f, -0.0088f, "antepiernaI");

            rotarParte(-2f, "piernaD");
            rotarParte(0.5f, "antepiernaD");
            rotarParte(-2.5f, "piernaI");

            //de las piernas para arriba
            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");
        }
        //para la IZQUIERDA
        public void paso1I()
        {
            rotarParte(10f, "piernaI");
            moverParte(0, 0.08f, 0.03f, "antepiernaI");
            rotarParte(-10f - 1.5f, "antepiernaI");

            //de las piernas para arriba
            moverParte(0f, 0.025f, 0.001f, "cuerpo");
            moverParte(0f, 0.025f, 0.001f, "brazoI");
            moverParte(0f, 0.025f, 0.001f, "brazoD");
            moverParte(0f, 0.025f, 0.001f, "antebrazoI");
            moverParte(0f, 0.025f, 0.001f, "antebrazoD");
            moverParte(0f, 0.025f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(-0.7f, "brazoI");
            rotarParte(-2, "antebrazoI");
            rotarParte(0.7f, "brazoD");
            rotarParte(2, "antebrazoD");

            moverParte(0f, -0.015f, 0f, "antebrazoI");
        }
        // paso #2 se ejecuta 1 vez
        public void paso2I()
        {
            rotarParte(10f, "piernaI");
            moverParte(0, 0.08f, 0.03f, "antepiernaI");
            rotarParte(10f, "antepiernaI");
            //de las piernas para arriba
            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(-0.7f, "brazoI");
            rotarParte(-2, "antebrazoI");
            rotarParte(0.7f, "brazoD");
            rotarParte(2, "antebrazoD");

            moverParte(0f, -0.015f, 0f, "antebrazoI");

        }
        //paso #3 se ejecuta 1 vez
        public void paso3I()
        {
            moverParte(0, 0.02f, -0.02f, "piernaI");
            moverParte(0, 0.02f, -0.02f, "antepiernaI");
            rotarParte(-5f, "piernaD");
            rotarParte(-5f, "antepiernaD");
            moverParte(0, 0.05f, -0.02f, "piernaD");

            //de las piernas para arriba
            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(-0.7f, "brazoI");
            rotarParte(-2, "antebrazoI");
            rotarParte(0.7f, "brazoD");
            rotarParte(2, "antebrazoD");

            moverParte(0f, -0.015f, 0f, "antebrazoI");
        }
        //paso #4 ejecuta 1 veces
        public void paso4I()
        {
            moverParte(0, 0.02f, -0.02f, "piernaI");
            moverParte(0, 0.02f, -0.02f, "antepiernaI");
            rotarParte(-7f, "piernaI");
            rotarParte(10f, "antepiernaI");
            rotarParte(-3f, "piernaD");
            rotarParte(-3f, "antepiernaD");
            moverParte(0, 0.05f, -0.02f, "piernaD");
            moverParte(0, 0.05f, -0.01f, "piernaI");

            //de las piernas para arriba
            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(-0.7f, "brazoI");
            rotarParte(-2, "antebrazoI");
            rotarParte(0.7f, "brazoD");
            rotarParte(2, "antebrazoD");

            moverParte(0f, -0.015f, 0f, "antebrazoI");
        }
        //paso # 5 se ejecuta 1 vez
        public void paso5I()
        {
            moverParte(0, 0.04f, -0.04f, "piernaI");
            moverParte(0, 0.04f, -0.04f, "antepiernaI");
            rotarParte(10f, "antepiernaI");
            rotarParte(-3f, "piernaD");
            rotarParte(-3f, "antepiernaD");

            //de las piernas para arriba
            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(-0.7f, "brazoI");
            rotarParte(-2, "antebrazoI");
            rotarParte(0.7f, "brazoD");
            rotarParte(2, "antebrazoD");

            moverParte(0f, -0.015f, 0f, "antebrazoI");
        }
        // paso #6 se ejecuta 1 vez
        public void paso6I()
        {
            moverParte(0, -0.01f, -0.04f, "piernaI");
            moverParte(0, -0.01f, -0.04f, "antepiernaI");
            rotarParte(8f, "antepiernaI");

            //de las piernas para arriba
            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(0.7f, "brazoI");
            rotarParte(2, "antebrazoI");
            rotarParte(-0.7f, "brazoD");
            rotarParte(-2, "antebrazoD");

            moverParte(0f, 0.015f, 0f, "antebrazoI");
        }
        // paso #7 se ejecuta 2 veces
        public void paso7I()
        {
            moverParte(0, 0.08f, 0.04f, "piernaI");
            rotarParte(-9f, "piernaI");
            moverParte(0, 0.05f, 0.04f, "piernaD");
            moverParte(0, 0.05f, 0.05f, "antepiernaD");
            rotarParte(-9f, "antepiernaD");

            //de las piernas para arriba
            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(0.7f, "brazoI");
            rotarParte(2, "antebrazoI");
            rotarParte(-0.7f, "brazoD");
            rotarParte(-2, "antebrazoD");

            moverParte(0f, 0.015f, 0f, "antebrazoI");
        }
        //paso #8 se ejecuta 2 veces
        public void paso8I()
        {
            rotarParte(-10f, "piernaI");
            moverParte(0, 0.08f, 0.02f, "piernaI");

            //rotarParte(-9f, "piernaI");
            moverParte(0, 0.05f, 0.01f, "piernaD");
            rotarParte(-9f, "antepiernaD");
            moverParte(0, 0.05f, 0.02f, "antepiernaD");

            //de las piernas para arriba
            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(0.7f, "brazoI");
            rotarParte(2, "antebrazoI");
            rotarParte(-0.7f, "brazoD");
            rotarParte(-2, "antebrazoD");

            moverParte(0f, 0.015f, 0f, "antebrazoI");

        }
        //paso #9 se ejecuta 2 veces
        public void paso9I()
        {
            moverParte(0, 0.01f, 0.001f, "piernaI");

            moverParte(0, 0.05f, 0.01f, "piernaD");
            rotarParte(5f, "piernaD");
            rotarParte(9f, "antepiernaD");
            moverParte(0, 0.08f, 0.000f, "antepiernaD");

            //de las piernas para arriba
            moverParte(0f, 0.025f, 0.001f, "cuerpo");
            moverParte(0f, 0.025f, 0.001f, "brazoI");
            moverParte(0f, 0.025f, 0.001f, "brazoD");
            moverParte(0f, 0.025f, 0.001f, "antebrazoI");
            moverParte(0f, 0.025f, 0.001f, "antebrazoD");
            moverParte(0f, 0.025f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(0.7f, "brazoI");
            rotarParte(2, "antebrazoI");
            rotarParte(-0.7f, "brazoD");
            rotarParte(-2, "antebrazoD");
            moverParte(0f, 0.015f, 0f, "antebrazoI");



        }
        //paso #10 se ejecuta 2 veces
        public void paso10I()
        {
            moverParte(0, 0.02f, -0.001f, "antepiernaI");
            rotarParte(-2f, "antepiernaI");
            moverParte(0, 0.02f, 0.0009f, "piernaI");
            rotarParte(-1.5f, "piernaI");

            moverParte(0, 0.05f, -0.03f, "piernaD");
            rotarParte(1.75f, "piernaD");
            moverParte(0, 0.07f, -0.05f, "antepiernaD");
            rotarParte(10f, "antepiernaD");

            //de las piernas para arriba
            moverParte(0f, 0.025f, 0.001f, "cuerpo");
            moverParte(0f, 0.025f, 0.001f, "brazoI");
            moverParte(0f, 0.025f, 0.001f, "brazoD");
            moverParte(0f, 0.025f, 0.001f, "antebrazoI");
            moverParte(0f, 0.025f, 0.001f, "antebrazoD");
            moverParte(0f, 0.025f, 0.001f, "cabeza");
            //movimiento de brazos
            rotarParte(0.7f, "brazoI");
            rotarParte(2, "antebrazoI");
            rotarParte(-0.7f, "brazoD");
            rotarParte(-2, "antebrazoD");

            moverParte(0f, 0.015f, 0f, "antebrazoI");

        }
        public void paso11I()
        {
            moverParte(0, 0.03f, 0.039f, "piernaI");
            moverParte(0, 0.0f, 0.00f, "piernaD");
            moverParte(0, 0.02f, 0.015f, "antepiernaI");
            moverParte(0, 0.0f, -0.0088f, "antepiernaD");

            rotarParte(-2f, "piernaI");
            rotarParte(0.5f, "antepiernaI");
            rotarParte(-2.5f, "piernaD");
            //de las piernas para arriba
            moverParte(0f, 0.03f, 0.001f, "cuerpo");
            moverParte(0f, 0.03f, 0.001f, "brazoI");
            moverParte(0f, 0.03f, 0.001f, "brazoD");
            moverParte(0f, 0.03f, 0.001f, "antebrazoI");
            moverParte(0f, 0.03f, 0.001f, "antebrazoD");
            moverParte(0f, 0.03f, 0.001f, "cabeza");
        }

      
    }
}
