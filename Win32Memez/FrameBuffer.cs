using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Win32Memez
{
    class FrameBuffer
    {
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("User32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);

        private static IntPtr desktopPtr = GetDC(IntPtr.Zero);

        public static Graphics Drawer = Graphics.FromHdc(desktopPtr);
    }
}
