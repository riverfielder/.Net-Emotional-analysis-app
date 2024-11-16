using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

public static class ClipboardNotification
{
    public static event EventHandler ClipboardUpdated;

    private static HwndSource _hwndSource;

    public static void Start()
    {
        if (_hwndSource != null) return;

        var hwnd = new WindowInteropHelper(new Window()).EnsureHandle();
        _hwndSource = HwndSource.FromHwnd(hwnd);
        _hwndSource.AddHook(WndProc);
        NativeMethods.AddClipboardFormatListener(hwnd);
    }

    private static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        const int WM_CLIPBOARDUPDATE = 0x031D;
        if (msg == WM_CLIPBOARDUPDATE)
        {
            ClipboardUpdated?.Invoke(null, EventArgs.Empty);
        }
        return IntPtr.Zero;
    }

    private static class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddClipboardFormatListener(IntPtr hwnd);
    }
}