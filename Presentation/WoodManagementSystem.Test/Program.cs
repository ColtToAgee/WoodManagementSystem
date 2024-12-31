using WoodManagementSystem.Test;

List<Window> windows = new List<Window>();

void setup()
{
    //size(1270, 720);

    setupWindows();
    prepAndPack();
}

void prepAndPack()
{
    // TO MAKE IT AS UNIVERSAL AS POSSIBLE
    // THE PACK CLASS ACCEPTS INT ARRAY WITH
    // JUST THE WIDTH AND HEIGHT OF EACH RECT
    // SO I AM COPYING THE PARAMS FROM THE
    // WINDOWS OBJECTS TO A 2D ARRAY
    int windowsSize = windows.Count();
    int[,] rects = new int[windowsSize,2];
    for (int i = 0; i < windowsSize; ++i)
    {
        Window current = windows.GetRange(i, 1)[0];
        rects[i,0] = current.W;
        rects[i,1] = current.H;
    }

    GreedyPack p = new GreedyPack(rects, 500, 500);
    int[,] result = p.RESULT;

    for (int i = 0; i < windowsSize; ++i)
    {
        Window current = windows.GetRange(i,1)[0];
        if (result[i,0] == 500)
        {
            Console.WriteLine("IMPOSSIBLE TO FIT THE WINDOW WITH TITLE: " + current.TITLE);
        }

        current.X = result[i,0];
        current.Y = result[i,1];
    }
}

// TEMP FUNCTION FOR ADDING COUPLE OF WINDOWS
void setupWindows()
{
    Window w1 = new Window(0, 0, 400, 500, "1");
    Window w2 = new Window(0, 0, 300, 200, "2");
    Window w3 = new Window(0, 0, 100, 300, "3");
    Window w4 = new Window(0, 0, 200, 300, "4");
    Window w5 = new Window(0, 0, 200, 300, "5");
    Window w6 = new Window(0, 0, 900, 100, "6");
    Window w7 = new Window(0, 0, 900, 100, "7");
    Window w8 = new Window(0, 0, 900, 100, "8");
    Window w9 = new Window(0, 0, 900, 100, "9");
    Window w10 = new Window(0, 0, 900, 100, "10");
    Window w11 = new Window(0, 0, 900, 100, "11");
    Window w12 = new Window(0, 0, 900, 100, "12");

    // CHANGING THE COLOR FOR EASIER DIFFERENTIATION
    w1.R = 140;
    w2.G = 140;
    w3.B = 140;
    w4.R = 200;
    w5.G = 200;
    w6.B = 200;
    w7.B = 200;
    w8.B = 200;
    w9.B = 200;
    w10.B = 200;
    w6.B = 200;
    w6.B = 200;

    windows.Add(w1);
    windows.Add(w2);
    windows.Add(w3);
    windows.Add(w4);
    windows.Add(w5);
    windows.Add(w6);
    windows.Add(w7);
    windows.Add(w8);
    windows.Add(w9);
    windows.Add(w10);
    windows.Add(w11);
    windows.Add(w12);
}

// -------------------------------------------
// FUNCTIONS FOR INTERACTING WITH THE WINDOWS
// -------------------------------------------

