using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Tire : AnimationSprite
{
    SquareBrickBouncy tire;
    public Tire(SquareBrickBouncy target) : base("assets/Tire.png", 3, 3)
    {
        SetOrigin(width / 2, height / 2);
        SetScaleXY(0.3f);
        tire = target;
        
    }
    void Update()
    {
        Animate(0.10f);
        if (tire != null)
        {
            if (tire.hits == 0)
            {
                SetFrame(0);
            }
            if (tire.hits == 2)
            {
                SetFrame(1);
            }
            
            if (tire.hits == 4)
            {
                SetFrame(2);
            }
            if (tire.hits >= 5)
            {
                SetCycle(3, 6);
            }
            if (currentFrame == 5)
            {
                tire.LateDestroy();
                LateDestroy();
            }
        }

    }
}
