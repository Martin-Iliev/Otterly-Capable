using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using Physics;

class BulletBig : Sprite
{
    // public fields & properties:

    public Vec2 position
    {
        get
        {
            return _position;
        }
    }
    float savedY;
    float gravity = 0.05f;
    public Vec2 velocity;

    // private fields:
    Vec2 _position;

    int hits;

    ColliderManager engine;
    BallCollider bulletCollider;

    int timeSinceSpawn = 0;

    public BulletBig(Vec2 pPosition, Vec2 pVelocity) : base("assets/bulletBouncy.png")
    {
        SetOrigin(width / 2, height / 2);
        _position = pPosition;
        velocity = pVelocity;
        SetScaleXY(0.12f);

        engine = ColliderManager.main;
        bulletCollider = new BallCollider(this, 20, pPosition);
        engine.AddSolidCollider(bulletCollider);
    }

    protected override void OnDestroy()
    {
        // Remove the collider when the sprite is destroyed:
        engine.RemoveSolidCollider(bulletCollider);
    }

    public void Update()
    {
        Gravity();
        CollisionInfo collision = engine.MoveUntilCollision(bulletCollider, velocity);
        if (collision != null)
        {
            ResolveCollision(collision);

        }
        //engine.MoveUntilCollision(bulletCollider, velocity);
        x = bulletCollider.position.x;
        y = bulletCollider.position.y;

        //if (timeSinceSpawn >= 240) LateDestroy();
        //timeSinceSpawn++;

        if (hits >= 12) LateDestroy();
    }

    void ResolveCollision(CollisionInfo col)
    {
        if (col.other == null) return;
        if (col.other.owner is SquareBrick)
        {
            (col.other.owner as SquareBrick).GetsHitValue(2);
            velocity.y = savedY;
            //bounce square
            velocity.Reflect(col.normal, 0.6f);
            new Sound("thudd.mp3").Play();
        }
        if (col.other.owner is SquareBrickBouncy)
        {
            (col.other.owner as SquareBrickBouncy).GetsHitValue(2);
            velocity.y = savedY;
            //bounce square
            velocity.Reflect(col.normal, 0.7f);
            new Sound("rubber.mp3").Play();
        }
        if (col.other.owner is SquareBrickFriend)
        {
            (col.other.owner as SquareBrickFriend).GetsHitValue(2);
            LateDestroy();
        }
        if (col.other.owner is TriangleBrick)
        {
            (col.other.owner as TriangleBrick).GetsHit();
            velocity.y = savedY;
            //bounce triangle (default value)
            velocity.Reflect(col.normal, 0.6f);
        }
        
        if (col.other.owner is Player)
        {
            velocity.Reflect(col.normal, 0.35f);
        }
        if (col.other.owner is Bullet)
        {
            velocity.Reflect(col.normal, 0.45f);
        }
        if (col.other.owner is BulletBig)
        {
            velocity.Reflect(col.normal, 0.45f);
        }
        if (col == null) return;
        //if (bounciness <= 0) return;

        hits++;
    }

    void Gravity()
    {
        savedY = velocity.y;
        velocity.y = velocity.y + gravity;
    }
}
