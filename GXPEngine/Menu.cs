using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using GXPEngine;
// Main Menu with a simple button to start the game.
public class Menu : GameObject
{

    public bool hasStarted = false;
    public Menu() : base()
    {

    }
    void Update()
    {
        if (Input.GetKey(Key.SPACE))
        {
            startGame();
        }
    }
    public void startGame()
    {
        if (hasStarted is false)
        {
            hasStarted = true;
            Level level = new Level(this);
            AddChild(level);
        }
    }
}