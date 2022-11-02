using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class TrafficObjects
    {
        static Form1 f;

        public TrafficObjects(Form1 fPointer)
        {
            f = fPointer;
        }
        /// <summary>
        /// Светофор
        /// </summary>
        public class TrafficLight
        {
            PictureBox image;


            public TrafficLight(Point location, Bitmap imageBMP)
            {
                image = new PictureBox();
                image.Image = imageBMP;
                image.SizeMode = PictureBoxSizeMode.AutoSize;
                image.Location = new Point(location.X, location.Y);
            }

            /// <summary>
            /// Изменить изображение
            /// </summary>
            public void SetImage(Bitmap imageBMP)
            {
                image.Image = imageBMP;
            }

            /// <summary>
            /// Добавить изображение на форму
            /// </summary>
            /// <param name="fpointer"></param>
            public void AddImgToForm(Panel Ppointer)
            {
                Ppointer.Controls.Add(image);
            }

        }
        /// <summary>
        /// Переключатель светофоров
        /// </summary>
        public class TrafficLightSwitcher
        {
            int TrafficLightState;

            public TrafficLightSwitcher()
            {
                TrafficLightState = 0;
            }


            public int trafficlightstate
            {
                get
                {
                    return TrafficLightState;
                }
            }

            /// <summary>
            /// Переключение состояний светофоров
            /// </summary>
            public void SwitchTrafficLights()
            {
                TrafficLightState++;
                TrafficLightState %= 5;
                switch (TrafficLightState)
                {
                    case 0:
                        SetTrafficVerticalOnly();
                        break;
                    case 1:
                        SetTrafficAllYellow();
                        break;
                    case 2:
                        SetTrafficHorizontalOnly();
                        break;
                    case 3:
                        SetTrafficHorizontalWithVerticalArrows();
                        break;
                    case 4:
                        SetTrafficAllYellow();
                        break;
                }
            }

            public void SetTrafficHorizontalOnly()
            {
                f.TrafficLightDown.SetImage(Properties.Resources.redarrow);
                f.TrafficLightRight.SetImage(Properties.Resources.green);
                f.TrafficLightUp.SetImage(Properties.Resources.redarrow);
                f.TrafficLightLeft.SetImage(Properties.Resources.green);
            }

            public void SetTrafficHorizontalWithVerticalArrows()
            {
                f.TrafficLightDown.SetImage(Properties.Resources.greenarrow);
                f.TrafficLightRight.SetImage(Properties.Resources.green);
                f.TrafficLightUp.SetImage(Properties.Resources.greenarrow);
                f.TrafficLightLeft.SetImage(Properties.Resources.green);
            }

            public void SetTrafficAllYellow()
            {
                f.TrafficLightDown.SetImage(Properties.Resources.yellowarrow);
                f.TrafficLightRight.SetImage(Properties.Resources.yellow);
                f.TrafficLightUp.SetImage(Properties.Resources.yellowarrow);
                f.TrafficLightLeft.SetImage(Properties.Resources.yellow);
            }

            public void SetTrafficVerticalOnly()
            {
                f.TrafficLightDown.SetImage(Properties.Resources.greenarrow1);
                f.TrafficLightRight.SetImage(Properties.Resources.red);
                f.TrafficLightUp.SetImage(Properties.Resources.greenarrow1);
                f.TrafficLightLeft.SetImage(Properties.Resources.red);
            }
        }

        public enum SpeedValue
        {
            VeryFast = 24,
            Fast = 18,
            Medium = 14,
            Slow = 7,
            Stop = 0,
            ManSpeed = 4
        }

        public class BasicAuto
        {

            protected PictureBox CarImage;
            protected int speed;

            public BasicAuto(Point location, Bitmap imageBMP)
            {
                CarImage = new PictureBox();
                CarImage.Image = imageBMP;
                CarImage.SizeMode = PictureBoxSizeMode.AutoSize;
                CarImage.Location = new Point(location.X, location.Y);
                speed = (int)SpeedValue.Medium;
            }

            public void SetImage(Bitmap imageBMP)
            {
                CarImage.Image = imageBMP;
            }

            public Point Location
            {
                get
                {
                    return new Point(CarImage.Location.X, CarImage.Location.Y);
                }
                set
                {
                    CarImage.Location = new Point(value.X, value.Y);
                }
            }

            public int Speed
            {
                set
                {
                    speed = value;
                }
            }

            public void Stop()
            {
                speed = 0;
            }

            public void Start(int SpeedVal)
            {
                speed = SpeedVal;
            }

            public void SlowDown()
            {
                speed = (int)SpeedValue.Slow;
            }

            /// <summary>
            /// Движение по оси X
            /// </summary>
            /// <param name="IsMotionRight"></param>
            public void XMoveForward(int IsMotionRight)
            {
                CarImage.Location = new Point(CarImage.Location.X + IsMotionRight * speed, CarImage.Location.Y);
            }

            public void AddCarToPanel(Panel Ppointer)
            {
                Ppointer.Controls.Add(CarImage);
            }
        }

        /// <summary>
        /// Машина,которая может поворачивать
        /// </summary>
        public class AutoTurningRightOrLeft : BasicAuto
        {
            public AutoTurningRightOrLeft(Point location, Bitmap imageBMP) : base(location, imageBMP)
            {
            }

            /// <summary>
            /// Загружаем изображение повернутое направо или налево
            /// </summary>
            /// <param name="path"></param>
            public void Turn(Bitmap imageBMP)
            {
                CarImage.Image = imageBMP;
            }

            public void YMoveForward(int IsMotionDown)
            {
                CarImage.Location = new Point(CarImage.Location.X, CarImage.Location.Y + IsMotionDown * speed);
            }
        }
    }
}
