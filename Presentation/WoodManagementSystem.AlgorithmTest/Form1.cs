using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.AlgorithmTest
{
    public partial class Form1 : Form
    {
        List<Test.Window> windows = new List<Test.Window>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(1280, 720);
            //prepAndPack();
            this.Paint += new PaintEventHandler(this.OnPaint);
        }
        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            setupWindows(g);

        }
        public void setupWindows(Graphics g)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>()
            {
                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                                                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                                                                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },
                                new OrderDetails()
                {
                    DimensionWidth=40,
                    DimensionLength = 70
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 60
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=50,
                    DimensionLength = 50
                },
                new OrderDetails()
                {
                    DimensionWidth=70,
                    DimensionLength = 70
                },

            };
            BinPackingAlgoritm algorithm = new BinPackingAlgoritm();
            Pattern pattern = new Pattern()
            {
                Width = 400,
                Height = 400,
            };
            var layoutList = new List<Layout>();
            var deneme = algorithm.Pack(orderDetails,pattern,layoutList);
            float offsetX = 0; // X eksenindeki boþluk
            float offsetY = 0; // Y eksenindeki boþluk
            foreach (var l in deneme)
            {
                foreach (var w in l.Rects)
                {
                    Random random = new Random();

                    // Rastgele RGB deðerlerini oluþtur
                    int red = random.Next(0, 256);
                    int green = random.Next(0, 256);
                    int blue = random.Next(0, 256);

                    // Rastgele rengi oluþtur
                    Color randomColor = Color.FromArgb(red, green, blue);
                    using (Brush backgroundBrush = new SolidBrush(randomColor))
                    {
                        // Offset ekleyerek boþluk býrak
                        g.FillRectangle(
                            backgroundBrush,
                            (float)w.DimensionX + offsetX,
                            (float)w.DimensionY + offsetY,
                            (float)w.DimensionWidth,
                            (float)w.DimensionLength
                        );
                    }
                }

                // Her l için 100 piksel boþluk ekle
                offsetX += 400; // Yatay boþluk artýrýlýr
                                // offsetY += 100; // Eðer dikey boþluk eklemek isterseniz
            }
        }
        //void prepAndPack()
        //{
        //    // TO MAKE IT AS UNIVERSAL AS POSSIBLE
        //    // THE PACK CLASS ACCEPTS INT ARRAY WITH
        //    // JUST THE WIDTH AND HEIGHT OF EACH RECT
        //    // SO I AM COPYING THE PARAMS FROM THE
        //    // WINDOWS OBJECTS TO A 2D ARRAY
        //    int windowsSize = windows.Count();
        //    int[,] rects = new int[windowsSize, 2];
        //    for (int i = 0; i < windowsSize; ++i)
        //    {
        //        Test.Window current = windows.GetRange(i, 1)[0];
        //        rects[i, 0] = current.W;
        //        rects[i, 1] = current.H;
        //    }

        //    GreedyPack p = new GreedyPack(rects, 500, 500);
        //    int[,] result = p.RESULT;

        //    for (int i = 0; i < windowsSize; ++i)
        //    {
        //        Test.Window current = windows.GetRange(i, 1)[0];
        //        if (result[i, 0] == 500)
        //        {
        //            Console.WriteLine("IMPOSSIBLE TO FIT THE WINDOW WITH TITLE: " + current.TITLE);
        //        }

        //        current.X = result[i, 0];
        //        current.Y = result[i, 1];
        //    }
        //}

        //// TEMP FUNCTION FOR ADDING COUPLE OF WINDOWS
        //void setupWindows()
        //{
        //    Test.Window w1 = new Test.Window(0, 0, 400, 500, "1");
        //    Test.Window w2 = new Test.Window(0, 0, 300, 200, "2");
        //    Test.Window w3 = new Test.Window(0, 0, 100, 300, "3");
        //    Test.Window w4 = new Test.Window(0, 0, 200, 300, "4");
        //    Test.Window w5 = new Test.Window(0, 0, 200, 300, "5");
        //    Test.Window w6 = new Test.Window(0, 0, 900, 100, "6");
        //    Test.Window w7 = new Test.Window(0, 0, 150, 200, "7");
        //    Test.Window w8 = new Test.Window(0, 0, 500, 400, "8");
        //    Test.Window w9 = new Test.Window(0, 0, 250, 500, "9");
        //    Test.Window w10 = new Test.Window(0, 0, 900, 100, "10");
        //    Test.Window w11 = new Test.Window(0, 0, 900, 100, "11");
        //    Test.Window w12 = new Test.Window(0, 0, 900, 100, "12");
        //    // CHANGING THE COLOR FOR EASIER DIFFERENTIATION
        //    w1.R = 140;
        //    w2.G = 140;
        //    w3.B = 140;
        //    w4.R = 200;
        //    w5.G = 200;
        //    w6.B = 200;
        //    w7.R = 210;
        //    w8.G = 210;
        //    w9.B = 210;
        //    w10.R = 220;
        //    w11.G = 220;
        //    w12.B = 220;

        //    windows.Add(w1);
        //    windows.Add(w2);
        //    windows.Add(w3);
        //    windows.Add(w4);
        //    windows.Add(w5);
        //    windows.Add(w6);
        //    windows.Add(w7);
        //    windows.Add(w8);
        //    windows.Add(w9);
        //    windows.Add(w10);
        //    windows.Add(w11);
        //    windows.Add(w12);
        //}
        //void draw(Graphics g)
        //{

        //    foreach (var w in windows)
        //    {
        //        // WINDOW BACKGROUND
        //        using (Brush backgroundBrush = new SolidBrush(Color.FromArgb(w.R, w.G, w.B)))
        //        {
        //            g.FillRectangle(backgroundBrush, w.X, w.Y, w.W, w.H);

        //            using (Font titleFont = new Font("Arial", w.TEXTSIZE))
        //            using (Brush textBrush = new SolidBrush(Color.Black))
        //            {
        //                g.DrawString(w.TITLE, titleFont, textBrush, w.X + 5, w.Y + 20);
        //            }

        //        }
        //    }
        //}
    }
}
