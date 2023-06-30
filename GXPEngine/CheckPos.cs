using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using Physics;

class CheckPos : EasyDraw
{
    public CheckPos(int pRadius, Vec2 pPosition, bool moving = true) : base(pRadius * 2 + 1, pRadius * 2 + 1, false)
    {
        base.SetOrigin(pRadius, pRadius);
        base.Ellipse(pRadius, pRadius, 2 * pRadius, 2 * pRadius);
    }

    void Update()
    {
        Step();
    }

    void Step()
    {
        x = Input.mouseX;
        y = Input.mouseY;
    }
}

