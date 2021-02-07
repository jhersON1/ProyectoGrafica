using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGrafica.Modelos
{
    public abstract class IFigura
    {
        public float centrox=0;
        public float centroy=0;
        public float centroz=0;

        public Vector3 angulo = new Vector3(0, 0, 0);
        public Vector3 escala = new Vector3(1, 1, 1);
        public Vector3 trasladarOb = new Vector3(0, 0, 0);
        public abstract void draw();

        public abstract void mover(float cx, float cy, float cz);

        //public abstract void añadir();

        //public abstract void eliminar();

        public abstract void rotar(float angx, float angy, float angz);

        public abstract void escalar(float escx, float escy, float escz);

        public virtual void trasladar()
        {

        }
        public virtual void moverA(float cx, float cy, float cz)
        {

        }
    }
}
