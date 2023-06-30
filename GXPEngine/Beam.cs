using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Beam : AnimationSprite
{
    SquareBrick beam;
    public Beam(SquareBrick target) : base("assets/Beam.png", 3, 3)
    {
        SetOrigin(width / 2, height / 2);
        SetScaleXY(0.3f);
        beam = target;
    }
    void Update()
    {
        Animate(0.12f);
        if (beam != null)
        {
            if (beam.hits == 0)
            {
                SetFrame(0);
            }
            if (beam.hits == 2)
            {
                SetFrame(1);
            }

            if (beam.hits == 4)
            {
                SetFrame(2);
            }
            if (beam.hits >= 5)
            {
                SetCycle(3, 6);
            }
            if (currentFrame == 5)
            {
                beam.LateDestroy();
                LateDestroy();
            }
        }
    }
}
