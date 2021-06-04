using System.Drawing;
using System.Windows.Forms;

namespace Pr29
{
    static class Transform
    {
        static bool isPress = false;
        static Point startPst;
        /// <summary>
        /// Функция выполняется при нажатии на перемещаемый контрол
        /// </summary>
        /// <param name="sender">контролл</param>
        /// <param name="e">событие мышки</param>
        private static void mDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;//проверка что нажата левая кнопка
            isPress = !isPress;
            startPst = e.Location;
            //sender.GetType().GetProperty("Enabled").SetValue(sender, false);
        }
        /// <summary>
        /// Функция выполняется при отжатии перемещаемого контрола
        /// </summary>
        /// <param name="sender">контролл</param>
        /// <param name="e">событие мышки</param>
        private static void mUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;//проверка что нажата левая кнопка
            isPress = false;
        }
        /// <summary>
        /// Функция выполняется при перемещении контрола
        /// </summary>
        /// <param name="sender">контролл</param>
        /// <param name="e">событие мышки</param>
        private static void mMove(object sender, MouseEventArgs e)
        {
            if (isPress)
            {
                Control control = (Control)sender;
                control.Top += e.Y - startPst.Y;
                control.Left += e.X - startPst.X;
            }
        }
        /// <summary>
        /// обучает контролы передвигаться
        /// </summary>
        /// <param name="sender">контролл(это может быть кнопка, лейбл, календарик и.т.д)</param>
        public static void LearnToMove(object sender)
        {
            Control control = (Control)sender;
            control.MouseDown += new MouseEventHandler(mDown);
            //control.MouseUp += new MouseEventHandler(mUp);
            control.MouseMove += new MouseEventHandler(mMove);
        }

        /// <summary>
        /// Поворачивает PictureBox на определённый угл.
        /// </summary>>
        public static void RotateImgage(this System.Windows.Forms.PictureBox pic, System.Drawing.RotateFlipType angel)
        {
            pic.Image.RotateFlip((RotateFlipType)7);
            pic.Size = new System.Drawing.Size(pic.Height, pic.Width);
            pic.Invalidate();
        }

        /// <summary>
        /// method to rotate an image either clockwise or counter-clockwise
        /// </summary>
        /// <param name="img">the image to be rotated</param>
        /// <param name="rotationAngle">the angle (in degrees).
        /// NOTE: 
        /// Positive values will rotate clockwise negative values will rotate counter-clockwise
        /// </param>
        /// <returns></returns>
        public static Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            return bmp; //return the image
        }

        public static bool OnCollision(object sender, object sender2)
        {
            Control current = (Control)sender;
            Control target = (Control)sender2;

            if ((target.Location.X < current.Location.X + current.Width) && (target.Location.X > current.Location.X))
                if ((target.Location.Y < current.Location.Y + current.Height))
                    return true;
            return false;
        }
    }
}
