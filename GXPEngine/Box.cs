using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Box : AnimationSprite
{
    SquareBrick box;
    public Box(SquareBrick target) : base("assets/Box.png", 3, 3)
    {
        SetOrigin(width / 2, height / 2);
        SetScaleXY(0.3f);
        box = target;
    }
    void Update()
    {
        Animate(0.10f);
        if (box != null)
        {
            if (box.hits == 0)
            {
                SetFrame(0);
            }
            if (box.hits == 2)
            {
                SetFrame(1);
            }

            if (box.hits == 4)
            {
                SetFrame(2);
            }
            if (box.hits >= 5)
            {
                SetCycle(3, 6);
            }
            if (currentFrame == 5)
            {
                box.LateDestroy();
                LateDestroy();
            }
        }
    }
}
