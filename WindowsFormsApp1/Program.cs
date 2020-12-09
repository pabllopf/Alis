using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());


            // initialize the form
            System.Windows.Forms.Form form = new System.Windows.Forms.Form(); // create our form
            form.Size = new System.Drawing.Size(600, 600); // set form size to 600 width & 600 height
            form.Show(); // show our form
            DrawingSurface rendersurface = new DrawingSurface(); // our control for SFML to draw on
            rendersurface.Size = new System.Drawing.Size(400, 400); // set our SFML surface control size to be 500 width & 500 height
            form.Controls.Add(rendersurface); // add the SFML surface control to our form
            rendersurface.Location = new System.Drawing.Point(100, 100); // center our control on the form

            // initialize sfml
            SFML.Graphics.RenderWindow renderwindow = new SFML.Graphics.RenderWindow(rendersurface.Handle); // creates our SFML RenderWindow on our surface control

            // drawing loop
            while (form.Visible) // loop while the window is open
            {
                System.Windows.Forms.Application.DoEvents(); // handle form events
                renderwindow.DispatchEvents(); // handle SFML events - NOTE this is still required when SFML is hosted in another window
                renderwindow.Clear(SFML.Graphics.Color.Yellow); // clear our SFML RenderWindow
                renderwindow.Display(); // display what SFML has drawn to the screen
            }

        }
    }

    public class DrawingSurface : System.Windows.Forms.Control
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            // don't call base.OnPaint(e) to prevent forground painting
            // base.OnPaint(e);
        }
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
            // don't call base.OnPaintBackground(e) to prevent background painting
            //base.OnPaintBackground(pevent);
        }
    }
}

