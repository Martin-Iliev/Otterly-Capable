using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
using GXPEngine.Core;
using Physics;


class TriangleBrick : LineSegment
{
    ColliderManager engine;
    LineSegmentCollider line1;
    LineSegmentCollider line2;
    LineSegmentCollider line3;
    BallCollider ball1;
    BallCollider ball2;
    BallCollider ball3;
    int hits = 0;

    public TriangleBrick(Vec2 first, Vec2 second, Vec2 third) : base(first, second)
    {
        engine = ColliderManager.main;
        line1 = new LineSegmentCollider(this, first, second);
        line2 = new LineSegmentCollider(this, second, third);
        line3 = new LineSegmentCollider(this, third, first);;
        ball1 = new BallCollider(this, 0, first);
        ball2 = new BallCollider(this, 0, second);
        ball2 = new BallCollider(this, 0, third);
        engine.AddSolidCollider(line1);
        engine.AddSolidCollider(line2);
        engine.AddSolidCollider(line3);
        engine.AddSolidCollider(ball1);
        engine.AddSolidCollider(ball2);
        engine.AddSolidCollider(ball3);
    }

    void Update()
    {
        BreakBrick();
    }

    public void GetsHit()
    {
        hits++;
    }

    public void GetsHitValue(int value)
    {
        hits = hits + value;
    }

    void BreakBrick()
    {
        if (hits >= 3)
        {
            LateDestroy();
        }
    }

    protected override void OnDestroy()
    {
        // Remove the collider when the sprite is destroyed:
        engine.RemoveSolidCollider(line1);
        engine.RemoveSolidCollider(line2);
        engine.RemoveSolidCollider(line3);
        engine.RemoveSolidCollider(ball1);
        engine.RemoveSolidCollider(ball2);
        engine.RemoveSolidCollider(ball3);
    }

    protected override void RenderSelf(GLContext glContext)
    {
        if (game != null)
        {
            Gizmos.RenderLine(line1.start.x, line1.start.y, line2.start.x, line2.start.y, color, lineWidth);
            Gizmos.RenderLine(line2.start.x, line2.start.y, line3.start.x, line3.start.y, color, lineWidth);
            Gizmos.RenderLine(line3.start.x, line3.start.y, line1.start.x, line1.start.y, color, lineWidth);
        }
    }
}