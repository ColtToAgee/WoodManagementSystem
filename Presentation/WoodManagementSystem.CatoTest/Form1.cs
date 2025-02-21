using WoodManagementSystem.Domain.Entities;

namespace WoodManagementSystem.CatoTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(1600, 720);
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
            Pattern pattern = new Pattern()
            {
                Width = 280,
                Height = 210,
            };
            CatoAlgortihm algorithm = new CatoAlgortihm(pattern);
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
                a.DimensionWidth *= 100;
                a.DimensionLength *= 100;
            });
            var deneme = algorithm.PackSizes(newCustomerCartItems, layoutList);
            float offsetX = 0; // X eksenindeki boþluk
            float offsetY = 0; // Y eksenindeki boþluk
            deneme.Reverse();
            int counter = 1; // Sayýlarý baþlat

            foreach (var l in deneme)
            {
                foreach (var w in l.Rects)
                {
                    Random random = new Random();

                    // Rastgele RGB deðerlerini oluþtur
                    int red = random.Next(0, 256);
                    int green = random.Next(0, 256);
                    int blue = random.Next(0, 256);
                    //if (red == 255 && green == 255 && blue == 255)
                    //{
                    //    red = 210;
                    //    green = 210;
                    //    blue = 210;
                    //}
                    // Rastgele rengi oluþtur
                    Color randomColor = Color.FromArgb(red, green, blue);
                    using (Brush backgroundBrush = new SolidBrush(randomColor))
                    {
                        // Dikdörtgeni çiz
                        g.FillRectangle(
                            backgroundBrush,
                            (float)w.DimensionX + offsetX,
                            (float)w.DimensionY + offsetY,
                            (float)w.DimensionWidth,
                            (float)w.DimensionLength
                        );
                    }

                    // Metni yazmak için Brush ve Font
                    using (Brush textBrush = new SolidBrush(Color.Black)) // Siyah renkli yazý
                    using (Font font = new Font("Arial", 5, FontStyle.Bold)) // Arial 16 Bold
                    {
                        // Sayýnýn merkezde olmasý için koordinatlarý hesapla
                        float textX = (float)w.DimensionX + offsetX + (float)w.DimensionWidth / 2;
                        float textY = (float)w.DimensionY + offsetY + (float)w.DimensionLength / 2;
                        if (newCustomerCartItems.FirstOrDefault(a => a.DimensionWidth == w.DimensionWidth && a.DimensionLength == w.DimensionLength) is null)
                        {
                            g.DrawString("X", font, textBrush, textX, textY);
                        }
                        else
                        {
                            g.DrawString(counter.ToString(), font, textBrush, textX, textY);
                        }
                        // Sayýyý çiz
                    }

                    counter++; // Sayýyý artýr
                }

                using (Pen borderPen = new Pen(Color.Black, 3)) // Siyah, 3 px kalýnlýkta çerçeve
                {
                    g.DrawRectangle(borderPen, offsetX, offsetY, 280, 210);
                }

                // Her l için 400 piksel boþluk ekle
                offsetX += 400;
                if (offsetX >= 1280)
                {
                    offsetY += 400;
                    offsetX = 0;
                }
            }
        }

    }
}
