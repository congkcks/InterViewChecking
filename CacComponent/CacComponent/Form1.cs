namespace CacComponent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //thay dôi mau cua form theo thanh cuon va mau la mau do
            //cuong co cua mau do thay doi theo thanh cuon
            hScrollBar1.Maximum = 224;
            hScrollBar1.Minimum = 0;
            this.BackColor = Color.FromArgb(hScrollBar1.Value, 0, 0);


        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            hScrollBar2.Maximum = 192;
            hScrollBar2.Minimum = 0;
            this.BackColor = Color.FromArgb(0, hScrollBar2.Value, 0);

        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            hScrollBar3.Maximum = 156;
            hScrollBar3.Minimum = 0;
            this.BackColor = Color.FromArgb(0, 0, hScrollBar3.Value);
        }
    }
}
