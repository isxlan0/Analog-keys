using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

class Program

{

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetWindowPos(
        IntPtr hWnd,
        IntPtr hWndInsertAfter,
        int x,
        int y,
        int cx,
        int cy,
        int uFlags);

    private const int HWND_TOPMOST = -1;
    private const int SWP_NOMOVE = 0x0002;
    private const int SWP_NOSIZE = 0x0001;

    [DllImport("user32.dll")] private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")] private static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll")] private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll")] private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll")] private static extern bool SetCursorPos(int X, int Y);
    [DllImport("user32.dll")] private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
    [DllImport("user32.dll")] private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
    [DllImport("user32.dll")] private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);
    private const int SW_SHOWNORMAL = 1;
    private const int SW_RESTORE = 9;
    private const int SW_SHOWNOACTIVATE = 4;
    private const int WM_KEYDOWN = 0X100;
    private const int WM_KEYUP = 0X101;
    private const int WM_SYSCHAR = 0X106;
    private const int WM_SYSKEYUP = 0X105;
    private const int WM_SYSKEYDOWN = 0X104;
    private const int WM_CHAR = 0X102;

    static void Main()

    {
        //IntPtr myIntPtr = FindWindow(null, "原神"); //null为类名，可以用Spy++得到，也可以为空
        //ShowWindow(myIntPtr, SW_RESTORE); //将窗口还原
        //SetForegroundWindow(myIntPtr); //这里是切换原神窗口到最顶层




        //设置区
        ////////////////////////////////////////////////////////////////////////////////////////////////
        int cs = 100;//这里是执行次数
        int yc = 5;//这里是延迟 单位秒
        ////////////////////////////////////////////////////////////////////////////////////////////////

        //置顶程序
        IntPtr hWnd = Process.GetCurrentProcess().MainWindowHandle;

        SetWindowPos(hWnd,
            new IntPtr(HWND_TOPMOST),
            0, 0, 0, 0,
            SWP_NOMOVE | SWP_NOSIZE);

        //执行任务前的输出
        Console.WriteLine("[Date:" + DateTime.Now + "]" + "程序开始运行，三秒后开启按键任务");
        Thread.Sleep(3000);
        Console.WriteLine("[Date:" + DateTime.Now + "]" + "任务已开启");





        //赋值
        int yc2=yc*1000;
        int counter = 0;//定义一个int型变量counter，并且赋初值为0
        int count = 1;//定义一个int型变量，并且赋初值为1
        int five = count;
        int sy = cs - 1;//定义一个int型变量，sy是剩余的次数 cs是总次数
        while (counter < cs)

        {

            //这里是想按的键
            SendKeys.SendWait("{RIGHT}");
            //SendKeys.Send("{RIGHT}"); //模拟键盘输入ENTER
            //SendKeys.SendWait("{ENTER}");
            //SendMessage(myIntPtr, WM_SYSKEYDOWN, 0X0D, 0); //输入ENTER（0x0d）
            //SendMessage(myIntPtr, WM_SYSKEYUP, 0X0D, 0);

            //找按键名称可前往https://www.cnblogs.com/swtool/p/6860760.html查询

            //执行时的输出
            Console.WriteLine("[Date:" + DateTime.Now +"]" +  "已执行一次任务,当前是第" + count+ "次,还剩下"+sy +"次");//输出的内容

            //这里是执行延迟
            Thread.Sleep(yc2);
            count++;
            counter++;
            sy--;
        }
        //判断是否执行完毕 如果完成的数量＞总个数 则输出下面的内容
        if (count > cs)
        {
            //执行完毕的输出
            Console.WriteLine("[Date:" + DateTime.Now+"]"+"任务运行完毕");
            Console.ReadLine();
        }


    }


   
}



