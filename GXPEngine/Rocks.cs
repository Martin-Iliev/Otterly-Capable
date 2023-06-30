using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Rocks : AnimationSprite
{
    Player player;
    SquareBrickFriend friend;
    public Rocks(Player target1, SquareBrickFriend target2) : base("assets/rocks ui.png", 9, 1)
    {
        SetOrigin(width / 2, height / 2);
        this.scaleX = 1f;
        this.scaleY = 1f;
        player = target1;
        friend = target2;
    }
    void Update() { 
        if (player != null && friend != null)
        {
            if (player.bulletType == 1)
            {
                if(friend.friendHealth == 3) 
                {
                SetFrame(6);
                }
                if (friend.friendHealth == 2)
                {
                    SetFrame(7);
                }
                if (friend.friendHealth == 1)
                {
                    SetFrame(8);
                }
            }
            if (player.bulletType == 2)
            {
                if (friend.friendHealth == 3)
                {
                    SetFrame(0);
                }
                if (friend.friendHealth == 2)
                {
                    SetFrame(1);
                }
                if (friend.friendHealth == 1)
                {
                    SetFrame(2);
                }
            }
            if (player.bulletType == 3)
            {
                if (friend.friendHealth == 3)
                {
                    SetFrame(3);
                }
                if (friend.friendHealth == 2)
                {
                    SetFrame(4);
                }
                if (friend.friendHealth == 1)
                {
                    SetFrame(5);
                }
            }
        }
    }
}
