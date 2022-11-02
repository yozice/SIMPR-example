using System.Runtime.InteropServices;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public bool stop = false;
        public SimprMessaging si;

        public TrafficObjects.TrafficLight TrafficLightDown;
        public TrafficObjects.TrafficLight TrafficLightRight;
        public TrafficObjects.TrafficLight TrafficLightUp;
        public TrafficObjects.TrafficLight TrafficLightLeft;

        public TrafficObjects.TrafficLightSwitcher trafficLightSwitcher;

        public TrafficObjects.AutoTurningRightOrLeft AutoRRandom;
        public TrafficObjects.AutoTurningRightOrLeft AutoDR;
        public TrafficObjects.AutoTurningRightOrLeft AutoDL;
        public TrafficObjects.AutoTurningRightOrLeft AutoLRandom;
        public TrafficObjects.AutoTurningRightOrLeft AutoUR;
        Random LRndFlagValue;//для задания случайного занчения флага
        Random RRndFlagValue;
        public int AutoRRandomMoveForwardFlag;
        public int AutoLRandomMoveForwardFlag;//флаг для определения,едет ли 4 авто прямо или поворачивает направо
        public Random randLoc;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            si = new SimprMessaging(Program.mainForm);
            TrafficObjects trafficObjects = new TrafficObjects(this);
            TrafficLightDown = new TrafficObjects.TrafficLight(new Point(538, 352), Properties.Resources.greenarrow1);
            TrafficLightDown.AddImgToForm(panel1);
            TrafficLightRight = new TrafficObjects.TrafficLight(new Point(536, 167), Properties.Resources.red);
            TrafficLightRight.AddImgToForm(panel1);
            TrafficLightUp = new TrafficObjects.TrafficLight(new Point(265, 158), Properties.Resources.greenarrow1);
            TrafficLightUp.AddImgToForm(panel1);
            TrafficLightLeft = new TrafficObjects.TrafficLight(new Point(255, 346), Properties.Resources.red);
            TrafficLightLeft.AddImgToForm(panel1);

            trafficLightSwitcher = new TrafficObjects.TrafficLightSwitcher();

            //добавляем автомобили
            AutoRRandom = new TrafficObjects.AutoTurningRightOrLeft(new Point(725, 220), Properties.Resources.carRight);
            AutoRRandom.AddCarToPanel(panel1);
            AutoDR = new TrafficObjects.AutoTurningRightOrLeft(new Point(480, 515), Properties.Resources.carDownRight);
            AutoDR.AddCarToPanel(panel1);
            AutoDL = new TrafficObjects.AutoTurningRightOrLeft(new Point(420, 449), Properties.Resources.carDownLeft);
            AutoDL.AddCarToPanel(panel1);
            AutoLRandom = new TrafficObjects.AutoTurningRightOrLeft(new Point(-39, 281), Properties.Resources.carLeft);
            AutoLRandom.AddCarToPanel(panel1);
            AutoUR = new TrafficObjects.AutoTurningRightOrLeft(new Point(317, 47), Properties.Resources.carUpRight);
            AutoUR.AddCarToPanel(panel1);

            RRndFlagValue = new Random(5);
            LRndFlagValue = new Random(5);

            AutoRRandomMoveForwardFlag = 2;
            AutoLRandomMoveForwardFlag = LRndFlagValue.Next(4);

            randLoc = new Random();
        }

        public void AddLineToLogs(string m)
        {
            if (textBox1.TextLength > 10000)
            {
                textBox1.Text = "";
            }
            textBox1.Text += m + Environment.NewLine;
        }

        private void StopProgram(object sender, EventArgs e)
        {
            stop = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            trafficLightSwitcher.SwitchTrafficLights();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random(100);

            //автомобиль 1
            if (AutoRRandomMoveForwardFlag <= 1) // ехать прямо
            {

                AutoRRandom.XMoveForward(-1);
                if (AutoRRandom.Location.X < -r.Next(50))
                {
                    AutoRRandom.Location = new Point(850, 220);
                    AutoRRandomMoveForwardFlag = RRndFlagValue.Next(4);
                }
            }
            else if (AutoRRandomMoveForwardFlag == 2) // ехать направо
            {
                if (AutoRRandom.Location.Y <= -50)
                {
                    AutoRRandom.Location = new Point(850, 220);
                    AutoRRandom.SetImage(Properties.Resources.carRight);
                    AutoRRandomMoveForwardFlag = RRndFlagValue.Next(4);
                }
                else
                {
                    if (AutoRRandom.Location.X <= 490)
                    {
                        AutoRRandom.Turn(Properties.Resources.carDown);
                        AutoRRandom.YMoveForward(-1);
                    }
                    else
                    {
                        AutoRRandom.XMoveForward(-1);
                    }
                }
            }
            else // ехать налево
            {
                if (AutoRRandom.Location.Y >= 650)
                {
                    AutoRRandom.Location = new Point(850, 220);
                    AutoRRandom.SetImage(Properties.Resources.carRight);
                    AutoRRandomMoveForwardFlag = RRndFlagValue.Next(4);
                }
                else
                {
                    if (AutoRRandom.Location.X <= 365)
                    {
                        AutoRRandom.Turn(Properties.Resources.carDownRight);
                        AutoRRandom.YMoveForward(1);
                    }
                    else
                    {
                        AutoRRandom.XMoveForward(-1);
                    }
                }
            }



            //автомобиль 2
            if (AutoDR.Location.X > 800 + r.Next(150))
            {
                AutoDR.Location = new Point(480, 650);
                AutoDR.SetImage(Properties.Resources.carDownRight);
            }
            else
            {

                if (AutoDR.Location.Y <= 295)
                {
                    AutoDR.Turn(Properties.Resources.carLeft);
                    AutoDR.XMoveForward(1);
                }
                else
                {
                    AutoDR.YMoveForward(-1);
                }
            }

            // автомобиль сверху направо
            if (AutoUR.Location.X < -50 - r.Next(150))
            {
                AutoUR.Location = new Point(317, -50);
                AutoUR.SetImage(Properties.Resources.carUpRight);
            }
            else
            {
                if (AutoUR.Location.Y >= 218)
                {
                    AutoUR.Turn(Properties.Resources.carRight);
                    AutoUR.XMoveForward(-1);
                }
                else
                {
                    AutoUR.YMoveForward(1);
                }
            }


            //автомобиль 3
            if (AutoDL.Location.X < -75 - r.Next(90))
            {
                AutoDL.Location = new Point(420, 650);
                AutoDL.SetImage(Properties.Resources.carDownLeft);
            }
            else
            {

                if (AutoDL.Location.Y <= 225)
                {
                    AutoDL.Turn(Properties.Resources.carRight);
                    AutoDL.XMoveForward(-1);
                }
                else
                {
                    AutoDL.YMoveForward(-1);
                }

            }

            //автомобиль 4
            if (AutoLRandomMoveForwardFlag <= 1) // ехать прямо
            {

                AutoLRandom.XMoveForward(1);
                if (AutoLRandom.Location.X > 982)
                {
                    AutoLRandom.Location = new Point(-39, 281);
                    AutoLRandomMoveForwardFlag = LRndFlagValue.Next(4);
                }
            }
            else if (AutoLRandomMoveForwardFlag == 2) // ехать направо
            {
                if (AutoLRandom.Location.Y >= 650)
                {
                    AutoLRandom.Location = new Point(-39, 281);
                    AutoLRandom.SetImage(Properties.Resources.carLeft);
                    AutoLRandomMoveForwardFlag = LRndFlagValue.Next(4);
                }
                else
                {
                    if (AutoLRandom.Location.X >= 305)
                    {
                        AutoLRandom.Turn(Properties.Resources.carUp);
                        AutoLRandom.YMoveForward(1);
                    }
                    else
                    {
                        AutoLRandom.XMoveForward(1);
                    }
                }
            }
            else // ехать налево
            {
                if (AutoLRandom.Location.Y <= -50)
                {
                    AutoLRandom.Location = new Point(-39, 281);
                    AutoLRandom.SetImage(Properties.Resources.carLeft);
                    AutoLRandomMoveForwardFlag = LRndFlagValue.Next(4);
                }
                else
                {
                    if (AutoLRandom.Location.X >= 420)
                    {
                        AutoLRandom.Turn(Properties.Resources.carDownRight);
                        AutoLRandom.YMoveForward(-1);
                    }
                    else
                    {
                        AutoLRandom.XMoveForward(1);
                    }
                }
            }
        }

        //private int get
    }
}