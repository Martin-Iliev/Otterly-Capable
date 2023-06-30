using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Health : AnimationSprite
{
    SquareBrickFriend friend;
    public Health(SquareBrickFriend target) : base("assets/health ui.png", 3, 2)
    {
        SetOrigin(width / 2, height / 2);
        this.scale = 0.35f;
        friend = target;
    }
    void Update()
    {
        if (friend.friendHealth == 3 && !friend.isEnd)
        {
            SetFrame(0);
        }
        if (friend.friendHealth == 2 && !friend.isEnd)
        {
            SetFrame(1);
        }
        if (friend.friendHealth == 1 && !friend.isEnd)
        {
            SetFrame(2);
        }
    }
}
