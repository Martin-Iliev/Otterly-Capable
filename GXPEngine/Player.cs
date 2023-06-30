using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using Physics;

public class Player : AnimationSprite
{
    Collider myCollider;
    float speed = 3;
    Vec2 velocity;
    ColliderManager engine;
    Barrel _barrel;
    public int bulletType = 1;
    bool isFiring = false;
    bool isIdling = true;
    public Player() : base("assets/player.png", 5, 5)
    {
        SetOrigin(width / 2, height / 2);
        SetScaleXY(0.2f);
        _barrel = new Barrel();
        _barrel.visible = false;
        _barrel.SetOrigin(_barrel.width / 3, _barrel.height / 2);
        AddChild(_barrel);
    }

    protected override void OnDestroy()
    {
        // Remove the collider when the sprite is destroyed:
        engine.RemoveSolidCollider(myCollider);
    }

    void Update()
    {
        Step();
        if (isFiring)
        {
            AnimationFire();
        }
        else AnimationIdle();

        if (currentFrame == 14)
        {
            isFiring = false;
        }
    }

    void Step()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }
        // Don't forget to update the sprite position too!

        if (Input.GetKeyUp(Key.ONE))
        {
            bulletType = 1;
        }
        if (Input.GetKeyUp(Key.TWO))
        {
            bulletType = 2;
        }
        if (Input.GetKeyUp(Key.THREE))
        {
            bulletType = 3;
        }
    }
    void AnimationIdle()
    {
        isIdling = true;
        SetCycle(15, 24);
        Animate(0.1f);
    }
    void AnimationFire()
    {
        SetCycle(0, 15);
        Animate(0.1f);
        isIdling = false;
    }
    void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
             isFiring = true;
            if (!Input.GetMouseButtonDown(1))
            {
                if (bulletType == 1)
                {
                    if (isIdling)
                    {
                        new Sound("Throwing.mp3").Play();
                        Bullet bullet = new Bullet(new Vec2(x, y) + (Vec2.GetUnitVectorDegree(_barrel.rotation + rotation) * 70), Vec2.GetUnitVectorDegree(_barrel.rotation + rotation) * 6 + new Vec2(1.2f, -1.0f));
                        game.AddChildAt(bullet, 1);
                    }
                }
                if (bulletType == 2)
                {
                    if (isIdling)
                    {
                        new Sound("Throwing.mp3").Play();
                        BulletBig bulletbig = new BulletBig(new Vec2(x, y) + (Vec2.GetUnitVectorDegree(_barrel.rotation + rotation) * 70), Vec2.GetUnitVectorDegree(_barrel.rotation + rotation) * 5f + new Vec2(0.9f, -0.75f));
                        game.AddChildAt(bulletbig, 1);
                    }
                }
                if (bulletType == 3)
                {
                    if (isIdling)
                    {
                        new Sound("Throwing.mp3").Play();
                        BulletSpecial bulletspecial = new BulletSpecial(new Vec2(x, y) + (Vec2.GetUnitVectorDegree(_barrel.rotation + rotation) * 70), Vec2.GetUnitVectorDegree(_barrel.rotation + rotation) * 6 + new Vec2(1.2f, -1.0f));
                        game.AddChildAt(bulletspecial, 1);
                    }
                }
            }
        }
        if (Input.GetMouseButton(1))
        {
            isFiring = true;
            if (!Input.GetMouseButtonDown(0))
            {
                if (bulletType == 1)
                {
                    if (isIdling)
                    {
                        new Sound("Throwing.mp3").Play();
                        Bullet bullet = new Bullet(new Vec2(x, y) + (Vec2.GetUnitVectorDegree(_barrel.rotation + rotation) * 70), Vec2.GetUnitVectorDegree(_barrel.rotation + rotation) * 8.8f + new Vec2(1.8f, -1.0f));
                        game.AddChildAt(bullet, 1);
                    }
                }
                if (bulletType == 2)
                {
                    if (isIdling)
                    {
                        new Sound("Throwing.mp3").Play();
                        BulletBig bulletbig = new BulletBig(new Vec2(x, y) + (Vec2.GetUnitVectorDegree(_barrel.rotation + rotation) * 70), Vec2.GetUnitVectorDegree(_barrel.rotation + rotation) * 7f + new Vec2(0.9f, -0.75f));
                        game.AddChildAt(bulletbig, 1);
                    }
                }
                if (bulletType == 3)
                {
                    if (isIdling)
                    {
                        
                        BulletSpecial bulletspecial = new BulletSpecial(new Vec2(x, y) + (Vec2.GetUnitVectorDegree(_barrel.rotation + rotation) * 70), Vec2.GetUnitVectorDegree(_barrel.rotation + rotation) * 8.8f + new Vec2(1.8f, -1.0f));
                        game.AddChildAt(bulletspecial, 1);
                    }
                }
            }
        }
    }
}

