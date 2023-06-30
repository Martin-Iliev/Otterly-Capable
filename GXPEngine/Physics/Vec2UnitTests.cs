using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

class Vec2UnitTests
{
    public static void DoUnitTests()
    {
        //length unit test
        Vec2 vectorLength = new Vec2(3, 4);
        Console.WriteLine($"Length():\n Vector: {vectorLength.Length()}.\n Should be: 5\n");

        //normalize
        Vec2 vectorNormalize = new Vec2(3, 4);
        vectorNormalize.Normalize();
        Console.WriteLine($"Normalize():\n Vector: {vectorNormalize}.\n Should be: (0.6,0.8)\n");

        //normalized
        Vec2 vectorNormalized = new Vec2(3, 4);
        Vec2 controlVector = vectorNormalized.Normalized();
        Console.WriteLine($"Normalized():\n Original Vector: {vectorNormalized}\n Vector result: {controlVector}.\n Should be: (3,4) and (0.6,0.8)\n");

        //SetXY
        Vec2 modifiedVector = new Vec2(3, 4);
        Vec2 originalVector = modifiedVector;
        modifiedVector.SetXY(0, 0);
        Console.WriteLine($"SetXY():\n Original Vector: {originalVector}\n Vector result: {modifiedVector}.\n Should be: (3,4) and (0,0)\n");

        //operator tests
        Vec2 mathVector = new Vec2(3, 4);
        Console.WriteLine($"Multiply operator:\n Vectors:  {2 * mathVector} and {mathVector * 8}.\n Should be: (6,8) and (24,32)\n");
        Console.WriteLine($"Division operator:\n Vectors: {3 / mathVector} and {mathVector / 8}.\n Should be: (1,0.75) and (0.375,0.5)\n");
        Console.WriteLine($"Minus operator:\n Vector results: {2 - mathVector} and {mathVector - 8}.\n Should be: (-1,-2) and (-5,-4)\n");
        Console.WriteLine($"Addition operator:\n Vector results: {2 + mathVector} and {mathVector + 8}.\n Should be: (5,6) and (11,12)\n");

        //convert to radians and to degrees
        float f1 = Vec2.Deg2Rad(180);
        float f2 = Vec2.Rad2Deg(Mathf.PI);
        Console.WriteLine($"GetUnitVectorRadians():\n Vector results: {f1}.\n Should be: {Mathf.PI}\n");
        Console.WriteLine($"GetUnitVectorDegrees():\n Vector results: {f2}.\n Should be: {180}\n");

        Vec2 radianRotate = new Vec2(10, 4);
        radianRotate.RotateRadians(4);
        Console.WriteLine($"RotateRadians():\n Vector results: {radianRotate}.\n Should be: (-3.51, -10.18).\n");

        Vec2 degreeRotate = new Vec2(10, 4);
        degreeRotate.RotateDegree(4);
        Console.WriteLine($"RotateDegrees():\n Vector results: {degreeRotate}.\n Should be: (9.70,4.69).\n");

        //GetUnitVectorDegree() test
        Vec2 unitVector = Vec2.GetUnitVectorDegree(16);
        Console.WriteLine($"GetUnitVectorDegree():\n Vector results: {unitVector}.\n Should be: (0.96,0.28).\n");

        //GetUnitVectorRadians() test
        unitVector = Vec2.GetUnitVectorRadians(Mathf.PI * 1.6f);
        Console.WriteLine($"GetUnitVectorRadians():\n Vector results: {unitVector}.\n Should be: (0.31,-0.95).\n");

        //RandomUnitVector() test
        unitVector = Vec2.RandomUnitVector();
        if(unitVector.x < 1 && unitVector.y < 1)
        {
            Console.WriteLine($"RandomUnitVector():\n Vector results: {unitVector}.\n this is a unit vector.\n");
        }
        else Console.WriteLine($"RandomUnitVector():\n Vector results: {unitVector}.\n this is not a unit vector.\n");

            //GetAngleDegree() test
            float angle = new Vec2(3, 6).GetAngleDegrees();
        Console.WriteLine($"GetAngleDegree():\n Vector results: {angle}.\n Should be: 63.43495.\n");

        //GetAngleRadians() test
        angle = new Vec2(2, 12).GetAngleRadians();
        Console.WriteLine($"GetAngleRadians():\n Vector results: {angle}.\n Should be: 1.405648.\n");

        //SetAngleDegree() test
        Vec2 vector = new Vec2(1, 3);
        vector.SetAngleDegree(60);
        Console.WriteLine($"SetAngleDegree():\n Vector results: {vector}.\n Should be: (1.58,2.74).\n");

        //SetAngleRadians() test
        vector = new Vec2(2, 8);
        vector.SetAngleRadians(Mathf.PI * 1.6f);
        Console.WriteLine($"SetAngleRadians():\n Vector results: {vector}.\n Should be: (2.55,-7.84).\n");

        //RotateAroundDegree() test
        vector = new Vec2(1, 3);
        vector.RotateAroundDegrees(60, new Vec2(2, 1));
        Console.WriteLine($"RotateAroundDegree():\n Vector results: {vector}.\n Should be: (-0.23,1.13).\n");

        //RotateAroundRadians() test
        vector = new Vec2(2, 8);
        vector.RotateAroundRadians(Mathf.PI * 1.6f, new Vec2(5, 10));
        Console.WriteLine($"RotateAroundRadians():\n Vector results: {vector}.\n Should be: (2.17,12.24).\n");

        //dot product test
        float dotProduct = Vec2.Dot(new Vec2(1, 3), new Vec2(2, 1));
        Console.WriteLine($"DotProduct():\n Vector results: {dotProduct}.\n Should be: 5.\n");

        float dotProduct2 = new Vec2(1,3).Dot(new Vec2(2, 1));
        Console.WriteLine($"DotProduct():\n Vector results: {dotProduct2}.\n Should be: 5.\n");


        //reflect test
        Vec2 vectorReflect = new Vec2(3, 5);
        vectorReflect.Reflect(new Vec2(7, 1));
        Console.WriteLine($"Reflect():\n Vector results: {vectorReflect}.\n Should be: (-361.00,-47.00).\n");

        //zero test
        Vec2 vectorZero = new Vec2(0, 0);
        Console.WriteLine($"Zero():\n Vector results: {vectorZero}.\n Should be: (0,0).\n");

        //project test
        Vec2 vectorToProject = new Vec2(3, 4);
        Vec2 vectorToProjectOn = new Vec2(6, -8);
        Console.WriteLine($"Project():\n Vector results: {vectorToProject.Project(vectorToProjectOn)}.\n Should be: (-0.84,1.12).\n");


    }
}
