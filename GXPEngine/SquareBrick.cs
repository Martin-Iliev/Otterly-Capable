using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using GXPEngine;
using GXPEngine.Core;
using Physics;


public class SquareBrick : LineSegment, BrickInterface
{
    ColliderManager engine;
    public LineSegmentCollider line1;
    public LineSegmentCollider line2;
    public LineSegmentCollider line3;
    public LineSegmentCollider line4;
    BoxCounter boxCounter;
    BallCollider ball1;
    BallCollider ball2;
    BallCollider ball3;
    BallCollider ball4;
    public int hits = 0;
    private const double minimumInterval = 100;
    public float dT = 0;

    public SquareBrick(Vec2 first, Vec2 second, Vec2 third, Vec2 fourth, BoxCounter target) : base(first, second)
    {
        boxCounter = target;
        engine = ColliderManager.main;
        line1 = new LineSegmentCollider(this, first, second);
        line2 = new LineSegmentCollider(this, second, third);
        line3 = new LineSegmentCollider(this, third, fourth);
        line4 = new LineSegmentCollider(this, fourth, first);
        engine.AddSolidCollider(line1);
        engine.AddSolidCollider(line2);
        engine.AddSolidCollider(line3);
        engine.AddSolidCollider(line4);
        engine.AddSolidCollider(ball1);
        engine.AddSolidCollider(ball2);
        engine.AddSolidCollider(ball3);
        engine.AddSolidCollider(ball4);
    }

    protected override void OnDestroy()
    {
        // Remove the collider when the sprite is destroyed:
        engine.RemoveSolidCollider(line1);
        engine.RemoveSolidCollider(line2);
        engine.RemoveSolidCollider(line3);
        engine.RemoveSolidCollider(line4);
        engine.RemoveSolidCollider(ball1);
        engine.RemoveSolidCollider(ball2);
        engine.RemoveSolidCollider(ball3);
        engine.RemoveSolidCollider(ball4);
        boxCounter.boxes--;
    }

    void Update()
    {
        dT++;
    }

    public void GetsHit()
    {
        hits++;
    }

    public void GetsHitValue(int value)
    {
        if (dT >= minimumInterval)
        {
            hits = hits + value;
            dT = 0;
        }
    }

    protected override void RenderSelf(GLContext glContext)
    {
        if (game != null)
        {
            Gizmos.RenderLine(line1.start.x, line1.start.y, line2.start.x, line2.start.y, color, lineWidth);
            Gizmos.RenderLine(line2.start.x, line2.start.y, line3.start.x, line3.start.y, color, lineWidth);
            Gizmos.RenderLine(line3.start.x, line3.start.y, line4.start.x, line4.start.y, color, lineWidth);
            Gizmos.RenderLine(line4.start.x, line4.start.y, line1.start.x, line1.start.y, color, lineWidth);
        }
    }
}
