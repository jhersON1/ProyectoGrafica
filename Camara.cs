
using OpenTK.Graphics.OpenGL;

namespace ProyectoGrafica
{
    public class Camara

    {

        public float anguloX = -80;
        public float anguloY = 45;
        public float anguloZ = 0;

        public float escala = 1;

        public void angulo()
        {
            GL.Rotate(anguloX, 1.0, 0.0, 0.0);
            GL.Rotate(anguloZ, 0.0, 1.0, 0.0);
            GL.Rotate(anguloY, 0.0, 0.0, 1.0);
            GL.Scale(escala, escala, escala);
        }
      
    }
}
