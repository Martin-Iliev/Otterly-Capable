using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using GXPEngine;
using TiledMapParser;

public class Win : AnimationSprite
{
    public Win() : base("winning.png", 8, 8)
    {

    }

    void Update()
    {

    }

    public void Animation()
    {
        if (currentFrame == 31)
        {
            SetFrame(31);
            SetCycle(31, 31);
        }
        else
            Animate(0.1f);
    }
}
