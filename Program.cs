using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleMan.AutoDraw
{
    class Program
    {
        static uint X = 100;
        static uint Y = 300;

        // value should be same as X
        static uint horizontalOffset = 100;

        static void Main(string[] args)
        {
            LaunchPaint();

            // Wait a sec
            Thread.Sleep(2000);

            DrawImage();

            Console.ReadLine();
        }

        private static void LaunchPaint()
        {
            System.Diagnostics.Process.Start("mspaint.exe");
        }

        private static void DrawImage()
        {
            Bitmap img = new Bitmap("image.jpg");
            for (int i = 0; i < (int)img.Height; i++)
            {
                for (int j = 0; j < (int)img.Width; j++)
                {
                    Color pixelColor = img.GetPixel(j, i);

                    MoveAPixelHorizontal();

                    // Draw inverted
                    //if (Convert.ToInt32(pixelColor.R.ToString("D3")) > 200 && Convert.ToInt32(pixelColor.R.ToString("D3")) > 200
                    //    && Convert.ToInt32(pixelColor.R.ToString("D3")) > 200)
                    //    DrawAPixel();

                    if (Convert.ToInt32(pixelColor.R.ToString("D3")) < 30 && Convert.ToInt32(pixelColor.G.ToString("D3")) < 30
                        && Convert.ToInt32(pixelColor.B.ToString("D3")) < 30)
                        DrawAPixel();
                }

                MoveToStartOfLine();
                Thread.Sleep(500);
                MoveAPixelVertical();

                //if (i > 50)
                //    break;
            }
        }

        private static void DrawAPixel()
        {
            mouse_event((uint)MouseEvents.MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
            mouse_event((uint)MouseEvents.MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        private static void MoveAPixelHorizontal()
        {
            X++;
            SetCursorPos((int)X, (int)Y);
        }

        private static void MoveAPixelVertical()
        {
            Y++;
            SetCursorPos((int)X, (int)Y);
        }

        private static void MoveToStartOfLine()
        {
            X = horizontalOffset;
        }

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(
            [In] int X,
            [In] int Y);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(
            [In] uint dwFlags,
            [In] uint dx,
            [In] uint dy,
            [In] int dwData,
            [In] uint dwExtraInfo);

        public enum MouseEvents
        {
            MOUSEEVENTF_LEFTDOWN = 0x02,
            MOUSEEVENTF_LEFTUP = 0x04,
            MOUSEEVENTF_RIGHTDOWN = 0x08,
            MOUSEEVENTF_RIGHTUP = 0x10,
            MOUSEEVENTF_WHEEL = 0x0800,
        }
    }

}
