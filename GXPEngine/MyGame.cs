using System;
using GXPEngine;
using System.Drawing;
using Physics;

public class MyGame : Game
{
    Background background;

    public MyGame() : base(1600, 900, false)
    {
        Menu menu = new Menu();
        AddChild(menu);
        background = new Background("assets/main menu.png");
        AddChildAt(background, 0);
    }
    void Update()
    {
        if (background != null)
        {
            if (Input.GetKey(Key.SPACE))
            {
                background.LateDestroy();
            }
        }
    }
    static void Main()
    {
        new MyGame().Start();
    }
}