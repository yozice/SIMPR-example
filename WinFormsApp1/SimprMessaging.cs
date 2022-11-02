using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
namespace WinFormsApp1
{
    public class SimprMessaging : NativeWindow
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint RegisterWindowMessage(string lpString);

        uint simprMsgId;
        public Form1 f;

        public SimprMessaging(Form1 form)
        {
            simprMsgId = RegisterWindowMessage("MyMessage");
            this.AssignHandle(form.Handle);
            f = form;
        }

        protected override void WndProc(ref Message m)
        {
            int wparamhi;
            int wparamlo;
            int wparam;
            int lParam = Convert.ToInt32(m.LParam.ToString());

            if (m.Msg == simprMsgId)
            {
                wparam = Convert.ToInt32(m.WParam.ToString());
                wparamhi = wparam / 65536;
                wparamlo = wparam - wparamhi * 65536;

                switch (wparamhi)
                {
                    case 0:   // Условия
                        switch (wparamlo) //Таблицы
                        {
                            #region Table1Conditions
                            case 1:
                                switch (lParam)
                                {
                                    case 1:
                                        if (f.stop)
                                        {
                                            m.Result = new IntPtr(1);
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        f.AddLineToLogs(lParam.ToString());

                                        break;
                                    default:
                                        break;
                                    }
                                break;
                            #endregion
                            #region Table2Conditions

                            case 2:
                                switch (lParam)
                                {
                                    case 1:
                                        m.Result = new IntPtr(1);
                                        break;
                                    case 2:
                                        m.Result = new IntPtr(1);
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            #endregion

                            default:
                                break;

                        }
                        break;

                    default:
                        break;
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}