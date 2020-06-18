using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CalenderApp
{
	class PInvoke
	{
		[DllImport("user32.dll")]
		internal static extern int SetWindowPos(System.IntPtr pHWND, System.IntPtr pAfterHWND, int pX, int pY, int pCX, int pCY, int pFlags);
		[DllImport("user32.dll")]
		private static extern Boolean SetLayeredWindowAttributes(IntPtr hWnd, uint crkey, Byte bAlpha, Int32 dwFlags);
		[DllImport("user32.dll")]
		private static extern uint SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
		[DllImport("user32.dll")]
		private static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

		internal static readonly System.IntPtr HWND_BOTTOM = new System.IntPtr(0x01);
		internal const int SWP_NOACTIVATE = 0x10;
		internal const int SWP_NOMOVE = 0x02;
		internal const int SWP_NOSIZE = 0x01;

		static readonly int GWL_EXSTYLE = (-20);
		public const int WS_EX_LAYERED = 0x80000;
		public const int LWA_ALPHA = 0x2;

		internal static void setBottom(IntPtr handle)
		{
			SetWindowPos(handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOACTIVATE | SWP_NOMOVE | SWP_NOSIZE);
			//SetWindowLong(handle, GWL_EXSTYLE, GetWindowLong(handle, GWL_EXSTYLE) | WS_EX_LAYERED);

			//uint c = 0x00FF00FF;
			//SetLayeredWindowAttributes(handle, c, 125, LWA_ALPHA);
		}
	}
}
