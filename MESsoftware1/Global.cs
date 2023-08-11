using MouseKeyboardActivityMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Vanara.PInvoke.User32;
using MouseKeyboardActivityMonitor.WinApi;
using MouseKeyboardActivityMonitor.Controls;
using MouseKeyboardActivityMonitor.HotKeys;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using ConfigInfomation;

namespace MESsoftware1
{
 internal class Global
{
    

public class GlobalEventDetector
    {
     
            private  KeyboardHookListener _inputListener;
            private  KeyboardHookListener _globalKeyboardListener;
            private  MouseHookListener _mouseHookListener;
            private MouseHookListener _globalMouseListener;
            public void Subscribe()
            {
                // for the application hook
                _inputListener = new KeyboardHookListener(new AppHooker());
                _inputListener.KeyDown += OnKeyDown;
                _inputListener.Start();

                // for the global hook
                _globalKeyboardListener = new KeyboardHookListener(new GlobalHooker());
                _globalKeyboardListener.KeyDown += OnGlobalKeyDown;
                _globalKeyboardListener.Start();

                //for the appliciation mouse hook
                _mouseHookListener = new MouseHookListener(new AppHooker());
                _mouseHookListener.MouseClick += OnMouseClick;
                _mouseHookListener.Start();
              
                //for the global hook

                _globalMouseListener=new MouseHookListener(new GlobalHooker());
                _globalMouseListener.MouseClick += OnGlobalMouseClick;
                _globalMouseListener.Start();
            }

            private void OnKeyDown(object sender, KeyEventArgs e)
            {
                

               
            }

            private void OnGlobalKeyDown(object sender, KeyEventArgs e)
            {
                ExtensionGlobalUtil.LastOperateTime = DateTime.Now;
                //Console.WriteLine(ExtensionGlobalUtil.LastOperateTime);

            }
            private void OnMouseClick(object sender , MouseEventArgs e)
            {

            }

            private void OnGlobalMouseClick(object sender , MouseEventArgs e)
            {
                ExtensionGlobalUtil.LastOperateTime = DateTime.Now;
               // Console.WriteLine(ExtensionGlobalUtil.LastOperateTime);
            }
            public void Unsubscribe()
            {
                _inputListener.KeyDown -= OnKeyDown;
                _globalKeyboardListener.KeyDown -= OnGlobalKeyDown;
                _mouseHookListener.MouseClick -= OnMouseClick;
                _globalMouseListener.MouseClick -= OnGlobalMouseClick;
                //It is recommened to dispose it
                _inputListener.Dispose();
                _globalKeyboardListener.Dispose();
                _mouseHookListener.Dispose();
                _globalMouseListener.Dispose();
            }
        }


}
}
