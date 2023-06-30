using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Couch : AnimationSprite
{
    SquareBrick couch;
    public Couch(SquareBrick target) : base("assets/Couch.png", 3, 3)
    {
        SetOrigin(width / 2, height / 2);
        SetScaleXY(0.3f);
        couch = target;
    }
    void Update()
    {
        Animate(0.10f);
        if (couch != null)
        {
            if (couch.hits == 0)
            {
                SetFrame(0);
            }
            if (couch.hits == 2)
            {
                SetFrame(1);
            }

            if (couch.hits == 4)
            {
                SetFrame(2);
            }
            if (couch.hits >= 5)
            {
                SetCycle(3, 6);
            }
            if (currentFrame == 5)
            {
                couch.LateDestroy();
                LateDestroy();
            }
        }
    }
}
