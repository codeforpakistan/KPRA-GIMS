using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPRA_RIMS
{
    public class CustomGroupBox : GroupBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Azure, this.ClientRectangle);
            //base.OnPaint(e);
        }


        public Rectangle ClientRectangle { get; set; }
    }
}
