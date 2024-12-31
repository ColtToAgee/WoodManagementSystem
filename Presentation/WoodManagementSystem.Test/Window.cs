namespace WoodManagementSystem.Test
{
    public class Window
    {
        public int X, Y, W, H;
        public int xOffset = 0, yOffset = 0;
        public int defaultColor = 80;
        public int R = 80;
        public int G = 80;
        public int B = 80;
        public int RO = 10, GO = 10, BO = 10;
        public int TEXTSIZE = 24;

        public int closeW = 20, closeH = 20;
        public int closeX() { return X + W - closeW - 10; }
        public int closeY() { return Y + 3; }

        public bool locked = false;
        public string TITLE = "no title";

        // THE CLASS CONSTRACTOR
        public Window(int x, int y, int w, int h, string title)
        {
            X = x; Y = y; W = w; H = h;
            TITLE = title;
        }

        // SETTING COLOR
        void SETCOLOR(int r, int g, int b)
        {
            R = r; G = g; B = b;
        }

        //// DRAWING THE WINDOW ON THE CANVAS
        //public void DRAW()
        //{
        //    noStroke();
        //    // WINDOW BACKGROUND
        //    (R, G, B);
        //    rect(X, Y, W, H);
        //    // WINDOW FRAME
        //    fill(R + 20, G + 20, B + 20);
        //    rect(X, Y, W, 10);
        //    // WINDOW BUTTONS
        //    // CLOSE
        //    fill(10, 10, 10);
        //    rect(closeX(), closeY(), closeW, closeH);
        //    // TITLE
        //    textSize(TEXTSIZE);
        //    text(TITLE, X + 5, Y + 20);
        //}

        // TESTING IF THE COORDINATES ARE
        // INSIDE THE SOME GIVEN BOX
        private bool overBox(int x, int y, int xB, int yB, int wB, int hB)
        {
            if (x >= xB && x < xB + wB)
            {
                if (y >= yB && y < yB + hB)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
