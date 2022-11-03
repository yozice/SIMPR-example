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

        uint simprMsgIdCond;
        uint simprMsgIdAct;

        public Form1 f;

        public SimprMessaging(Form1 form)
        {
            simprMsgIdCond = RegisterWindowMessage("MyMessageCond");
            simprMsgIdAct = RegisterWindowMessage("MyMessageAct");
            this.AssignHandle(form.Handle);
            f = form;
        }

        protected override void WndProc(ref Message m)
        {
            int wparamhi;
            int wparamlo;
            int wparam;
            int lParam = Convert.ToInt32(m.LParam.ToString());

            if (m.Msg == simprMsgIdCond)
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
                                            f.AddLineToLogs("Завершение");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    default:
                                        m.Result = new IntPtr(1);
                                        break;
                                }
                                break;
                            #endregion
                            #region Table2Conditions
                            case 2:
                                switch (lParam)
                                {
                                    case 1:
                                        if (350 <= f.AutoDL.Location.Y && f.AutoDL.Location.Y <= 365)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Машина снизу в левом ряду");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 2:
                                        m.Result = new IntPtr(1);
                                        break;
                                    case 3:
                                        if (f.trafficLightSwitcher.trafficlightstate == 2 || f.trafficLightSwitcher.trafficlightstate == 3)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Снизу красный сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 4:
                                        if (f.trafficLightSwitcher.trafficlightstate == 1 || f.trafficLightSwitcher.trafficlightstate == 4)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Снизу желтый сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 5:
                                        if (f.trafficLightSwitcher.trafficlightstate == 0)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Снизу зеленый сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 6:
                                        if (f.AutoDL.Location.Y <= 245)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Машина на перекрестке");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 7:
                                        if (f.AutoUR.Location.Y >= 192 && f.AutoUR.Location.X >= 300)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Встречная машина");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    default:
                                        m.Result = new IntPtr(1);

                                        break;
                                }
                                break;
                            #endregion
                            #region Table3Conditions
                            case 3:
                                switch (lParam)
                                {
                                    case 1:
                                        if (350 <= f.AutoDR.Location.Y && f.AutoDR.Location.Y <= 365)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Машина снизу в правом ряду");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 2:
                                        if (f.trafficLightSwitcher.trafficlightstate == 2 || f.trafficLightSwitcher.trafficlightstate == 3)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Снизу красный сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 3:
                                        if (f.trafficLightSwitcher.trafficlightstate == 1 || f.trafficLightSwitcher.trafficlightstate == 4)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Снизу желтый сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 4:
                                        if (f.trafficLightSwitcher.trafficlightstate == 0)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Снизу зеленый сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 5:
                                        if (f.trafficLightSwitcher.trafficlightstate == 3)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Снизу красный сигнал с зеленой стрелкой");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 6:
                                        if (f.AutoLRandom.Location.X >= 419 && f.AutoLRandom.Location.X <= 476)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Есть машина навстречу");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    default:
                                        m.Result = new IntPtr(1);

                                        break;
                                }
                                break;
                            #endregion
                            #region Table4Conditions
                            case 4:
                                switch (lParam)
                                {
                                    case 1:
                                        if (f.AutoRRandom.Location.X >= 530 && f.AutoRRandom.Location.X <= 550)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Машина справа");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 2:
                                        if (f.AutoRRandomMoveForwardFlag == 3)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Машина справа поворачивает налево");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 3:
                                        if (f.trafficLightSwitcher.trafficlightstate == 0)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Справа красный сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 4:
                                        if (f.trafficLightSwitcher.trafficlightstate == 1 || f.trafficLightSwitcher.trafficlightstate == 4)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Справа желтый сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 5:
                                        if (f.trafficLightSwitcher.trafficlightstate == 2 && f.trafficLightSwitcher.trafficlightstate == 3)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Справа зеленый сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 6:
                                        if (f.AutoRRandom.Location.X >= 385 && f.AutoRRandom.Location.X <= 400)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Машина на перекрестке");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 7:
                                        if (f.AutoLRandom.Location.X >= 310 && f.AutoLRandom.Location.X <= 400)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Машина навстречу");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    default:
                                        m.Result = new IntPtr(1);

                                        break;
                                }
                                break;
                            #endregion
                            #region Table5Conditions
                            case 5:
                                switch (lParam)
                                {
                                    case 1:
                                        m.Result = new IntPtr(0);
                                        break;
                                    case 2:
                                        m.Result = new IntPtr(0);
                                        break;
                                    case 3:
                                        if (f.trafficLightSwitcher.trafficlightstate == 2 || f.trafficLightSwitcher.trafficlightstate == 3)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Сверху красный сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 4:
                                        if (f.trafficLightSwitcher.trafficlightstate == 1 || f.trafficLightSwitcher.trafficlightstate == 4)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Сверху желтый сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 5:
                                        if (f.trafficLightSwitcher.trafficlightstate == 0)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Сверху зеленый сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 6:
                                        if (f.AutoDL.Location.Y >= 360)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Машина на перекрестке");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 7:
                                        m.Result = new IntPtr(0);
                                        break;
                                    default:
                                        m.Result = new IntPtr(1);

                                        break;
                                }
                                break;
                            #endregion
                            #region Table6Conditions
                            case 6:
                                switch (lParam)
                                {
                                    case 1:
                                        if (195 <= f.AutoDR.Location.Y && f.AutoDR.Location.Y <= 210)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Машина сверху в правом ряду");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 2:
                                        if (f.trafficLightSwitcher.trafficlightstate == 2 || f.trafficLightSwitcher.trafficlightstate == 3)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Сверху красный сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 3:
                                        if (f.trafficLightSwitcher.trafficlightstate == 1 || f.trafficLightSwitcher.trafficlightstate == 4)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Сверху желтый сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 4:
                                        if (f.trafficLightSwitcher.trafficlightstate == 0)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Сверху зеленый сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 5:
                                        if (f.trafficLightSwitcher.trafficlightstate == 3)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Сверху красный сигнал с зеленой стрелкой");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 6:
                                        if (f.AutoRRandom.Location.X >= 360 && f.AutoRRandom.Location.X <= 400)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Есть машина навстречу");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    default:
                                        m.Result = new IntPtr(1);

                                        break;
                                }
                                break;
                            #endregion
                            #region Table7Conditions
                            case 7:
                                switch (lParam)
                                {
                                    case 1:
                                        if (f.AutoLRandom.Location.X >= 250 && f.AutoLRandom.Location.X <= 380)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Машина слева");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 2:
                                        if (f.AutoLRandomMoveForwardFlag == 3)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Машина слева поворачивает налево");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 3:
                                        if (f.trafficLightSwitcher.trafficlightstate == 0)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Слева красный сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 4:
                                        if (f.trafficLightSwitcher.trafficlightstate == 1 || f.trafficLightSwitcher.trafficlightstate == 4)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Слева желтый сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 5:
                                        if (f.trafficLightSwitcher.trafficlightstate == 2 && f.trafficLightSwitcher.trafficlightstate == 3)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Слева зеленый сигнал");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 6:
                                        if (f.AutoLRandom.Location.X >= 400 && f.AutoLRandom.Location.X <= 450)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Машина на перекрестке");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    case 7:
                                        if (f.AutoRRandom.Location.X >= 430 && f.AutoRRandom.Location.X <= 500)
                                        {
                                            m.Result = new IntPtr(1);
                                            f.AddLineToLogs("Машина навстречу");
                                        }
                                        else
                                        {
                                            m.Result = new IntPtr(0);
                                        }
                                        break;
                                    default:
                                        m.Result = new IntPtr(1);

                                        break;
                                }
                                break;
                            #endregion
                            default:
                                m.Result = new IntPtr(1);

                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (m.Msg == simprMsgIdAct)
            {
                wparam = Convert.ToInt32(m.WParam.ToString());
                wparamhi = wparam / 65536;
                wparamlo = wparam - wparamhi * 65536;

                switch(wparamhi)
                {
                    case 0:
                        switch (wparamlo)
                        {
                            #region Table2Actions
                            case 2:
                                switch (lParam)
                                {
                                    case 1:
                                        f.AutoDL.Start();
                                        f.AddLineToLogs("Машина снизу в левом ряду поехала");
                                        break;
                                    case 2:
                                        f.AutoDL.Stop();
                                        f.AddLineToLogs("Машина снизу в левом ряду остановилась");
                                        break;
                                    default:
                                        m.Result = new IntPtr(1);

                                        break;
                                }
                                break;
                            #endregion
                            #region Table3Actions
                            case 3:
                                switch (lParam)
                                {
                                    case 1:
                                        f.AutoDR.Start();
                                        f.AddLineToLogs("Машина снизу в правом ряду поехала");
                                        break;
                                    case 2:
                                        f.AutoDR.Stop();
                                        f.AddLineToLogs("Машина снизу в правом ряду остановилась");
                                        break;
                                    default:
                                        m.Result = new IntPtr(1);

                                        break;
                                }
                                break;
                            #endregion
                            #region Table4Actions
                            case 4:
                                switch (lParam)
                                {
                                    case 1:
                                        f.AutoRRandom.Start();
                                        f.AddLineToLogs("Машина справа поехала");
                                        break;
                                    case 2:
                                        f.AutoRRandom.Stop();
                                        f.AddLineToLogs("Машина справа остановилась");
                                        break;
                                    default:
                                        m.Result = new IntPtr(1);

                                        break;
                                }
                                break;
                            #endregion
                            #region Table5Actions
                            case 5:
                                switch (lParam)
                                {
                                    case 1:
                                        //f.AutoU.Start();
                                        f.AddLineToLogs("Машина снизу в левом ряду поехала");
                                        break;
                                    case 2:
                                        //f.AutoDL.Stop();
                                        f.AddLineToLogs("Машина снизу в левом ряду остановилась");
                                        break;
                                    default:
                                        m.Result = new IntPtr(1);

                                        break;
                                }
                                break;
                            #endregion
                            #region Table6Actions
                            case 6:
                                switch (lParam)
                                {
                                    case 1:
                                        f.AutoUR.Start();
                                        f.AddLineToLogs("Машина сверху в правом ряду поехала");
                                        break;
                                    case 2:
                                        f.AutoUR.Stop();
                                        f.AddLineToLogs("Машина сверху в правом ряду остановилась");
                                        break;
                                    default:
                                        m.Result = new IntPtr(1);

                                        break;
                                }
                                break;
                            #endregion
                            #region Table7Actions
                            case 7:
                                switch (lParam)
                                {
                                    case 1:
                                        f.AutoLRandom.Start();
                                        f.AddLineToLogs("Машина слева поехала");
                                        break;
                                    case 2:
                                        f.AutoLRandom.Stop();
                                        f.AddLineToLogs("Машина слева остановилась");
                                        break;
                                    default:
                                        m.Result = new IntPtr(1);

                                        break;
                                }
                                break;
                            #endregion
                            default:
                                m.Result = new IntPtr(1);

                                break;
                        }
                        Application.DoEvents();

                        m.Result = new IntPtr(1);
                        break;
                    default:
                        m.Result = new IntPtr(1);
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