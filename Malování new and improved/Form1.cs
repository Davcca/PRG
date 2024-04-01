using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Malování_new_and_improved
{
    public partial class pic : Form
    {
        public pic()
        {
            InitializeComponent();
            this.Width = 993;
            this.Height = 565;
            bm = new Bitmap(picB.Width, picB.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            picB.Image = bm;
        }
        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);
        int index;
        int x, y, sX, sY, cX, cY;
        Color new_color = Color.Black;

        static Point set_point(PictureBox pb, Point pt)
        {
            float pX = 1f * pb.Width / pb.Height;
            float pY = 1f * pb.Height / pb.Height;
            return new Point((int)(pt.X*pX), (int)(pt.Y*pY));
        }
        private void rectangle_btn_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void line_btn_Click(object sender, EventArgs e)
        {
            index = 4;
        }


        private void circle_btn_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            picB.Image = bm;
            index = 0;
        }

        private void picB_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                if (index == 1)
                {
                    px = e.Location;
                    g.DrawLine(p, px, py);
                    py = px;
                }
                picB.Refresh();
                x = e.X;
                y = e.Y;
                sX = e.X - cX;
                sY = e.Y - cY;
            }

        }

        private void pic_color_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = set_point(pic_color, e.Location);         
            pic_color.BackColor = ((Bitmap)pic_color.Image).GetPixel(point.X, point.Y);
            new_color = pic_color.BackColor;
            p.Color = pic_color.BackColor;
           
        }

        private void picB_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            sX = x - cX;
            sY = y - cY;
            if (index == 2)
            {
                g.DrawEllipse(p, cX, cY, sX, sY);
            }
            if (index == 3)
            {
                g.DrawRectangle(p, cX, cY, sX, sY);
            }
            if (index == 4)
            {
                g.DrawLine(p, cX, cY, x, y);
            }
            picB.Refresh();
        }

        private void picB_MouseClick(object sender, MouseEventArgs e)
        {
            if (index == 6)
            {
                Fill(bm, e.X, e.Y,new_color);
            }
        }

        private void fill_btn_Click(object sender, EventArgs e)
        {
            index = 6;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Image Files (*.jpg)|*.jpg|All Files (*.*)|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (Bitmap btm = bm.Clone(new Rectangle(0, 0, picB.Width, picB.Height), bm.PixelFormat))
                {
                    EncoderParameters encoderParams = new EncoderParameters(1);
                    encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L); // 100L for highest quality

                    ImageCodecInfo jpegCodec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(codec => codec.FormatID == ImageFormat.Jpeg.Guid);

                    if (jpegCodec != null)
                    {
                        btm.Save(sfd.FileName, jpegCodec, encoderParams);
                    }
                    else
                    {
                        btm.Save(sfd.FileName, ImageFormat.Jpeg);
                    }
                }

                // Show message box centered
                MessageBox.Show(this, "Image saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pencil_btn_Click(object sender, EventArgs e)
        {
            p.Color = Color.Black;
            index = 1;
        }
        private void eraser_btn_Click(object sender, EventArgs e)
        {
            p.Color = Color.White;
        }

        private void picB_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;
            cX = e.X;
            cY = e.Y;
        }
        private void picB_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (paint)
            {
                if (index == 2)
                {
                    g.DrawEllipse(p, cX, cY, sX, sY);
                }
                if (index == 3)
                {
                    g.DrawRectangle(p, cX, cY, sX, sY);
                }
                if (index == 4)
                {
                    g.DrawLine(p, cX, cY, x, y);
                }
            }

        }
        private void validate (Bitmap bm,Stack<Point>sp,int x, int y, Color old_color, Color new_color)
        {
            Color cx = bm.GetPixel(x, y);
            if (cx == old_color) 
            { 
                sp.Push(new Point(x, y));
                bm.SetPixel(x, y,new_color);
            }
        }
        public void Fill (Bitmap bm, int x, int y, Color new_clr)
        {
            Color old_color = bm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x,y));
            bm.SetPixel (x, y,new_clr);
            if (old_color == new_clr) return;
            
            while(pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();
                if(pt.X>0 &&  pt.Y>0 && pt.X<bm.Width-1 && pt.Y< bm.Height -1)
                {
                    validate(bm, pixel, pt.X - 1, pt.Y, old_color, new_clr);
                    validate(bm, pixel, pt.X, pt.Y - 1, old_color, new_clr);
                    validate(bm, pixel, pt.X + 1, pt.Y, old_color, new_clr);
                    validate(bm, pixel, pt.X, pt.Y + 1, old_color, new_clr);


                }
            }

        }
      
    }
}
