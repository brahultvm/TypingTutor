using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Keyboard
{
	internal static class Program
	{
		private const int SW_RESTORE = 9;

		[DllImport("User32")]
		private static extern int SetForegroundWindow(IntPtr hwnd);

		[DllImport("User32.DLL")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		[STAThread]
		private static void Main()
		{
			try
			{
				Process.GetCurrentProcess().SingleInstance();
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(defaultValue: false);
				Application.Run(new MainForm());
			}
			catch (OutOfMemoryException)
			{
				GC.Collect();
				Application.Restart();
			}
		}

		public static void SingleInstance(this Process thisProcess)
		{
			Process[] processesByName = Process.GetProcessesByName(thisProcess.ProcessName);
			foreach (Process process in processesByName)
			{
				if (process.Id != thisProcess.Id)
				{
					ShowWindow(process.MainWindowHandle, 9);
					thisProcess.Kill();
				}
			}
		}
	}
}
