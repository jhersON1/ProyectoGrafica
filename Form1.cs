using System;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;
using ProyectoGrafica.Modelos;
using System.Threading;
using ProyectoGrafica.animacion;

namespace ProyectoGrafica
{
    public partial class Form1 : Form
    {
        Animacion a = new Animacion();
        int paso;
        int contadorListBox = 0;
        Camara camara = new Camara();
        private Escenario scene= new Escenario();
     
        public Form1()
        {
            InitializeComponent();
            paso = 0;
            Thread thread = new Thread(() =>
            {
                while (a.moviendo)
                {
                    imagenGl.Invalidate();
                }

            });
            thread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void GLControl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0.3f, 0.2f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            imagenGl.Invalidate();
        }

        private void GLControl_Resize(object sender, EventArgs e)
        {

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Viewport(0, 0, imagenGl.Width, imagenGl.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            int v = 3;
            GL.Ortho(-1*v, 1*v, -1*v, 1*v, -1*v, 10*v);
            GL.MatrixMode(MatrixMode.Modelview);
            imagenGl.Invalidate();
        }

        private void GLControl_Paint(object sender, PaintEventArgs e)
        {
            imagenGl.MakeCurrent();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.PushMatrix();

            camara.angulo();
            scene.drawScene();
            GL.PopMatrix();
            imagenGl.SwapBuffers();
            //MessageBox.Show("hola", "que onda");         
            //System.Threading.Thread.Sleep(50);
            // imagenGl.Refresh();
        }

        //añade los objetos
        private void sillaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add("Silla");
            scene.addObjeto(1);
            contadorListBox++;
            imagenGl.Invalidate();
        }
        private void mesaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add("Mesa");
            scene.addObjeto(2);
            contadorListBox++;
            imagenGl.Invalidate();
        }
        private void robotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add("Robot");
            scene.addObjeto(3);
            contadorListBox++;
            imagenGl.Invalidate();
        }

        //captura de teclas para mover "camara" y animar el robot
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.A)
            {
                camara.anguloY -= 10;
                
            }
            if (e.KeyData == Keys.D)
            {
                camara.anguloY += 10;
            }
            if (e.KeyData == Keys.W)
            {
                camara.anguloX -= 10;
            }
            if (e.KeyData == Keys.S)
            {
                camara.anguloX += 10;
            }
            if (e.KeyData == Keys.Q)
            {
                for (int indice = 0; indice < contadorListBox; indice++)
                {
                    if (checkedListBox1.GetItemChecked(indice) == true)
                    {
                        if (radioButton1.Checked)
                        {
                            if ("Robot" == checkedListBox1.Items[indice].ToString())
                            {


                                if (paso == 0)
                                {
                                    scene.caminar( indice);


                                }                              
                                paso++;
                            }
                        }
                    }
                }

                imagenGl.Invalidate();
            }
            imagenGl.Invalidate();
        }

        // elimina objetos
        private void button1_Click(object sender, EventArgs e)
        {
            for (int indice = 0; indice < contadorListBox; indice++)
            {
                if (checkedListBox1.GetItemChecked(indice) == true)
                {
                    if ("Silla" == checkedListBox1.Items[indice].ToString())
                    {
                        checkedListBox1.Items.RemoveAt(indice);
                        scene.eliminarObjeto(1);
                           
                    }
                    else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                    {
                        checkedListBox1.Items.RemoveAt(indice);
                        scene.eliminarObjeto(2);

                    }else if ("Robot" == checkedListBox1.Items[indice].ToString())
                    {
                        checkedListBox1.Items.RemoveAt(indice);
                        scene.eliminarObjeto(3);

                    }
                    scene.drawScene();
                    imagenGl.Invalidate();
                    contadorListBox--;
                    indice--;

                }
            }

            
        }

        // traslada, rota y escala los objetos
        private void button2_Click(object sender, EventArgs e)
        {
            for (int indice = 0; indice < contadorListBox; indice++)
            {
                if (checkedListBox1.GetItemChecked(indice) == true)
                {
                    if (radioButton1.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0.2f, 0f, 0f, indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0.2f, 0f, 0f, indice);

                            //scene.rotarMesa(indice);   
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0.2f, 0f, 0f, indice);   
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(15, 0, 0, indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(15, 0, 0, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(15,0,0,indice);
                        }
                    }
                    else if (radioButton3.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0.3f, 0, 0, indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0.3f, 0, 0, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0.3f, 0f, 0f, indice);
                        }

                    }
                }
                imagenGl.Invalidate();
            }
            
            imagenGl.Invalidate();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int indice = 0; indice < contadorListBox; indice++)
            {
                if (checkedListBox1.GetItemChecked(indice) == true)
                {
                    if (radioButton1.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(-0.2f, 0f, 0f, indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(-0.2f, 0f, 0f, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(-0.2f, 0f, 0f, indice);
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(-15, 0, 0, indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(-15, 0, 0, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(-15, 0, 0, indice);
                        }
                    }
                    else if (radioButton3.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(-0.3f, 0, 0, indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(-0.3f, 0, 0, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(-0.3f, 0f, 0f, indice);
                        }
                    }

                }
            }

            imagenGl.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int indice = 0; indice < contadorListBox; indice++)
            {
                if (checkedListBox1.GetItemChecked(indice) == true)
                {
                    if (radioButton1.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0f, 0.2f, 0f, indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0f, 0.2f, 0f, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0f, 0.2f, 0f, indice);
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(0, 15, 0, indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(0, 15, 0, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(0, 15, 0, indice);
                        }
                    }
                    else if (radioButton3.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0, 0.3f, 0, indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0, 0.3f, 0, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0f, 0.3f, 0f, indice);
                        }
                    }
                }
            }

            imagenGl.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int indice = 0; indice < contadorListBox; indice++)
            {
                if (checkedListBox1.GetItemChecked(indice) == true)
                {
                    if (radioButton1.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0f, -0.2f, 0f, indice);

                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0f, -0.2f, 0f, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0f, -0.2f, 0f, indice);
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(0, -15, 0, indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(0, -15, 0, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(0, -15, 0, indice);
                        }
                    }
                    else if (radioButton3.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0, -0.3f, 0, indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0, -0.3f, 0, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0f, -0.3f, 0f, indice);
                        }
                    }

                }
            }

            imagenGl.Invalidate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int indice = 0; indice < contadorListBox; indice++)
            {
                if (checkedListBox1.GetItemChecked(indice) == true)
                {
                    if (radioButton1.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0f, 0f, 0.2f, indice);

                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0f, 0f, 0.2f, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0, 0, 0.2f, indice);
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(0, 0, 15, indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(0, 0, 15, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(0, 0, 15, indice);
                        }
                    }
                    else if (radioButton3.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0, 0, 0.3f, indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0, 0, 0.3f, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0f, 0f, 0.3f, indice);
                        }
                    }
                }
            }

            imagenGl.Invalidate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int indice = 0; indice < contadorListBox; indice++)
            {
                if (checkedListBox1.GetItemChecked(indice) == true)
                {
                    if (radioButton1.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0f, 0f, -0.2f, indice);

                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0f, 0f, -0.2f, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.mover(0, 0, -0.2f, indice);
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(0, 0, -15 ,indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(0,0, -15, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.rotar(0, 0, -15, indice);
                        }
                    }
                    else if (radioButton3.Checked)
                    {
                        if ("Silla" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0, 0, -0.3f, indice);
                        }
                        else if ("Mesa" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0, 0,- 0.3f, indice);
                        }
                        else if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {
                            scene.escalar(0f, 0f, -0.3f, indice);
                        }
                    }
                }
            }

            imagenGl.Invalidate();
        }

        // Pausa la animacion

        private void button8_Click(object sender, EventArgs e)
        {
            for (int indice = 0; indice < contadorListBox; indice++)
            {
                if (checkedListBox1.GetItemChecked(indice) == true)
                {
                    if (radioButton1.Checked)
                    {
                        if ("Robot" == checkedListBox1.Items[indice].ToString())
                        {

                            scene.dejarDeCaminar();
                        }
                    }
                }
            }

            imagenGl.Invalidate();
        }

        // Comienza o renauda la animacion

        private void button9_Click(object sender, EventArgs e)
        {
            for (int indice = 0; indice < contadorListBox; indice++)
            {
                if (checkedListBox1.GetItemChecked(indice) == true)
                {
                    
                    if ("Robot" == checkedListBox1.Items[indice].ToString())
                    {
                            scene.caminar(indice);
                    }
                    
                }
            }

            imagenGl.Invalidate();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            scene.cargarJson();
        }


    }
}
