using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using GXPEngine;
using TiledMapParser;

public class Fail : AnimationSprite
{
    public Fail() : base("Fail.png", 6, 6)
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
