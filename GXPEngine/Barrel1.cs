using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Barrel1 : AnimationSprite
{
    SquareBrick barrel;
    public Barrel1(SquareBrick target) : base("assets/Barrel.png", 3, 3)
    {
        SetOrigin(width / 2, height / 2);
        SetScaleXY(0.3f);
        barrel = target;
    }
    void Update()
    {
        Animate(0.10f);
        if (barrel != null)
        {
            if (barrel.hits == 0)
            {
                SetFrame(0);
            }
            if (barrel.hits == 2)
            {
                SetFrame(1);
            }

            if (barrel.hits == 4)
            {
                SetFrame(2);
            }
            if (barrel.hits >= 5)
            {
                SetCycle(3, 6);
            }
            if (currentFrame == 5)
            {
                barrel.LateDestroy();
                LateDestroy();
            }
        }
    }
}
