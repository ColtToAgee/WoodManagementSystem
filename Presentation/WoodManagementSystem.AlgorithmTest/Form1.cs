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
        //List<OrderDetails> orderDetails = new List<OrderDetails>()
        //    {
        //        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //                        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //                                        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //                                                        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //                        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //                        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //                        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //                        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //                        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //                        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //                        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //                        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //                        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //                        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },
        //                        new OrderDetails()
        //{
        //    DimensionWidth = 40,
        //            DimensionLength = 70
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 60
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 50,
        //            DimensionLength = 50
        //        },
        //        new OrderDetails()
        //{
        //    DimensionWidth = 70,
        //            DimensionLength = 70
        //        },

        //    };

        public void setupWindows(Graphics g)
        {
            BinPackingAlgorithm algorithm = new BinPackingAlgorithm();
            Pattern pattern = new Pattern()
            {
                Width = 210,
                Height = 280,
            };
            var layoutList = new List<Layout>();
            var newCustomerCartItems = new List<CustomerCartItem>()
            {
                new CustomerCartItem()
                {
                    Id= 1,
                    DimensionWidth = 1.860,
                    DimensionLength= 0.360,
                    EdgeBand= "4044"
                },
                new CustomerCartItem()
                {
                    Id= 2,
                    DimensionWidth = 1.860,
                    DimensionLength= 0.360,
                    EdgeBand= "4044"
                },
                new CustomerCartItem()
                {
                    Id= 3,
                    DimensionWidth = 0.840,
                    DimensionLength= 0.360,
                    EdgeBand= "4044"
                },
                new CustomerCartItem()
                {
                    Id= 4,
                    DimensionWidth = 0.840,
                    DimensionLength= 0.360,
                    EdgeBand= "4044"
                },
                new CustomerCartItem()
                {
                    Id= 5,
                    DimensionWidth = 0.840,
                    DimensionLength= 0.360,
                    EdgeBand= "4044"
                },
                new CustomerCartItem()
                {
                    Id= 6,
                    DimensionWidth = 0.840,
                    DimensionLength= 0.360,
                    EdgeBand= "4044"
                },
                new CustomerCartItem()
                {
                    Id= 7,
                    DimensionWidth = 0.424,
                    DimensionLength= 0.360,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 8,
                    DimensionWidth = 0.424,
                    DimensionLength= 0.360,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 9,
                    DimensionWidth = 0.424,
                    DimensionLength= 0.360,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 10,
                    DimensionWidth = 0.424,
                    DimensionLength= 0.360,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 11,
                    DimensionWidth = 0.424,
                    DimensionLength= 0.360,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 12,
                    DimensionWidth = 1.959,
                    DimensionLength= 0.360,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 13,
                    DimensionWidth = 1.959,
                    DimensionLength= 0.360,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 14,
                    DimensionWidth = 0.804,
                    DimensionLength= 0.350,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 15,
                    DimensionWidth = 0.804,
                    DimensionLength= 0.350,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 16,
                    DimensionWidth = 0.804,
                    DimensionLength= 0.350,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 17,
                    DimensionWidth = 0.804,
                    DimensionLength= 0.350,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 18,
                    DimensionWidth = 0.804,
                    DimensionLength= 0.350,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 19,
                    DimensionWidth = 1.992,
                    DimensionLength= 0.417,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 20,
                    DimensionWidth = 1.992,
                    DimensionLength= 0.417,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 21,
                    DimensionWidth = 0.457,
                    DimensionLength= 0.417,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 22,
                    DimensionWidth = 0.457,
                    DimensionLength= 0.417,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 23,
                    DimensionWidth = 0.457,
                    DimensionLength= 0.462,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 24,
                    DimensionWidth = 0.457,
                    DimensionLength= 0.462,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 25,
                    DimensionWidth = 0.457,
                    DimensionLength= 0.462,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 26,
                    DimensionWidth = 0.457,
                    DimensionLength= 0.462,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 27,
                    DimensionWidth = 1.964,
                    DimensionLength= 0.400,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 28,
                    DimensionWidth = 1.964,
                    DimensionLength= 0.400,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 29,
                    DimensionWidth = 0.800,
                    DimensionLength= 0.400,
                    EdgeBand= "4044"
                },
                new CustomerCartItem()
                {
                    Id= 30,
                    DimensionWidth = 0.800,
                    DimensionLength= 0.400,
                    EdgeBand= "4044"
                },
                new CustomerCartItem()
                {
                    Id= 31,
                    DimensionWidth = 0.764,
                    DimensionLength= 0.390,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 32,
                    DimensionWidth = 0.764,
                    DimensionLength= 0.390,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 33,
                    DimensionWidth = 0.764,
                    DimensionLength= 0.390,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 34,
                    DimensionWidth = 0.764,
                    DimensionLength= 0.390,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 35,
                    DimensionWidth = 0.764,
                    DimensionLength= 0.390,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 36,
                    DimensionWidth = 0.400,
                    DimensionLength= 0.130,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 37,
                    DimensionWidth = 0.400,
                    DimensionLength= 0.130,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 38,
                    DimensionWidth = 0.400,
                    DimensionLength= 0.130,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 39,
                    DimensionWidth = 0.400,
                    DimensionLength= 0.130,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 40,
                    DimensionWidth = 0.702,
                    DimensionLength= 0.130,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 41,
                    DimensionWidth = 0.702,
                    DimensionLength= 0.130,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 42,
                    DimensionWidth = 0.702,
                    DimensionLength= 0.130,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 43,
                    DimensionWidth = 0.702,
                    DimensionLength= 0.130,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 44,
                    DimensionWidth = 1.597,
                    DimensionLength= 0.397,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 45,
                    DimensionWidth = 1.597,
                    DimensionLength= 0.397,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 46,
                    DimensionWidth = 0.788,
                    DimensionLength= 0.177,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 47,
                    DimensionWidth = 0.788,
                    DimensionLength= 0.177,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 48,
                    DimensionWidth = 1.032,
                    DimensionLength= 0.570,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 49,
                    DimensionWidth = 0.662,
                    DimensionLength= 0.310,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 50,
                    DimensionWidth = 0.662,
                    DimensionLength= 0.310,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 51,
                    DimensionWidth = 0.313,
                    DimensionLength= 0.310,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 52,
                    DimensionWidth = 1.045,
                    DimensionLength= 0.397,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 53,
                    DimensionWidth = 1.045,
                    DimensionLength= 0.397,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 54,
                    DimensionWidth = 1.045,
                    DimensionLength= 0.397,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 55,
                    DimensionWidth = 1.045,
                    DimensionLength= 0.397,
                    EdgeBand= "4444"
                },
                new CustomerCartItem()
                {
                    Id= 56,
                    DimensionWidth = 0.764,
                    DimensionLength= 0.310,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 57,
                    DimensionWidth = 2.780,
                    DimensionLength= 0.330,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 58,
                    DimensionWidth = 2.780,
                    DimensionLength= 0.330,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 59,
                    DimensionWidth = 2.780,
                    DimensionLength= 0.330,
                    EdgeBand= "4000"
                },
                new CustomerCartItem()
                {
                    Id= 60,
                    DimensionWidth = 2.780,
                    DimensionLength= 0.330,
                    EdgeBand= "4000"
                },
            };
            newCustomerCartItems.ForEach(a =>
            {
                (a.DimensionWidth, a.DimensionLength) = (a.DimensionLength, a.DimensionWidth);

                a.DimensionWidth *= 100;
                a.DimensionLength *= 100;
            });
            var deneme = algorithm.Pack(newCustomerCartItems, pattern, layoutList);
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
                    if (red == 255 && green == 255 && blue == 255)
                    {
                        red = 210;
                        green = 210;
                        blue = 210;
                    }
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
