using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;
using TiledMapParser;

public class Friend : AnimationSprite
{

    public Friend() : base("assets/friend.png", 4, 3)
    {
        SetOrigin(width / 2, height / 2);
        this.scale = 0.23f;
    }
    void Update()
    {
        SetCycle(0, 9);
        Animate(0.08f);

    }
}