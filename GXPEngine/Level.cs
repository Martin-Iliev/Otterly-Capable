using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using GXPEngine;
using System.Threading;
using TiledMapParser;
using System.Reflection.Emit;
//The level of the game.
public class Level : GameObject
{
    Player player;
    CheckPos checkPos;
    Background background;
    Background foreground;
    public SquareBrickFriend friend;
    BoxCounter boxCounter;
    Friend friendSprite;
    public Fail fail;
    public Win win;
    public SquareBrick box1;
    public SquareBrick box2;
    public SquareBrick box3;
    public SquareBrick box4;
    public SquareBrick box5;
    public SquareBrick box6;
    public SquareBrick box7;
    public SquareBrick box8;
    public SquareBrick barrel1;
    public SquareBrick barrel2;
    public SquareBrick barrel3;
    public SquareBrick beam1;
    public SquareBrick beam2;
    public SquareBrick beam3;
    public SquareBrick beam4;
    public SquareBrick couch1;
    public SquareBrick couch2;
    public SquareBrickBouncy tire1;
    public SquareBrickBouncy tire2;
    public SquareBrickBouncy tire3;
    public Box box1Sprite;
    public Box box2Sprite;
    public Box box3Sprite;
    public Box box4Sprite;
    public Box box5Sprite;
    public Box box6Sprite;
    public Box box7Sprite;
    public Box box8Sprite;
    public Beam beam1Sprite;
    public Beam beam2Sprite;
    public Beam beam3Sprite;
    public Beam beam4Sprite;
    public Couch couch1Sprite;
    public Couch couch2Sprite;
    public Barrel1 barrel1Sprite;
    public Barrel1 barrel2Sprite;
    public Tire tire1Sprite;
    public Tire tire2Sprite;
    public Tire tire3Sprite;
    public Health heart;
    public Rocks rocks;
    
    LineSegmentSolid ground;
    public Level(Menu _menu)
    {
        boxCounter = new BoxCounter();
        player = new Player();
        AddChildAt(player, 3);
        player.x = 120;
        player.y = 630;
        checkPos = new CheckPos(1, new Vec2(800, 450), true);
        AddChild(checkPos);
        background = new Background("assets/background.png");
        AddChildAt(background, 0);
        foreground = new Background("assets/foreground.png");
        AddChildAt(foreground, 1);
        CreateLevelBoundaries();
        SpawnBricks();
        new Sound("music.mp3", true).Play();

        fail = new Fail();
        AddChildAt(fail, 1000);
        fail.visible = false;
        win = new Win();
        AddChildAt(win, 1000);
        win.visible = false;
        rocks = new Rocks(player, friend);
        AddChild(rocks);
        rocks.scale = 0.25f;
        rocks.x= 95;
        rocks.y= 160;
        heart = new Health(friend);
        AddChild(heart);
        heart.x = 800;
        heart.y = 100;

    }
    void Update()
    {
        if (Input.GetKeyDown(Key.ENTER))
        {
            SpawnBricks();
        }
        // Console.WriteLine(checkPos.x);
        // Console.WriteLine(checkPos.y);
        Console.WriteLine(boxCounter.boxes);

        if (friend != null) 
        {
            if (friend.friendHealth <= 0)
            {
                fail.visible = true;
                rocks.LateDestroy();
                heart.LateDestroy();
                friend.LateDestroy();
                friendSprite.LateDestroy();
                fail.Animation();
            }
        }
        if (boxCounter.boxes <= 0)
        {
            heart.visible = false;
            rocks.LateDestroy();
           // friend.LateDestroy();
           // friendSprite.LateDestroy();
            win.visible = true;
            win.Animation();
            if (win.currentFrame == 57)
            {
                friend.isEnd = true;
                heart.visible = true;
                heart.y = 275;
                if (friend.friendHealth == 3)
                {
                    heart.SetFrame(3);
                }
                if (friend.friendHealth == 2)
                {
                    heart.SetFrame(4);
                }
                if (friend.friendHealth == 1)
                {
                    heart.SetFrame(5);
                }
            }
        }
    }
    void Main()
    {
        new MyGame().Start();
    }

    void CreateLevelBoundaries()
    {
        //walls
        ground = new LineSegmentSolid(new Vec2(1595, 895), new Vec2(5, 895));
        AddChild(ground);
        ground.visible = false;
    }

    void SpawnBricks()
    {
        //friend
        friend = new SquareBrickFriend(new Vec2(820, 752), new Vec2(820, 791), new Vec2(1025, 791), new Vec2(1025, 752));
        AddChild(friend);
        friend.visible = false;
        friendSprite = new Friend();
        AddChild(friendSprite);
        friendSprite.x = 930;
        friendSprite.y = 760;
        

        //bricks
        box1 = new SquareBrick(new Vec2(641, 495 + 100), new Vec2(641 + 100, 495 + 100), new Vec2(641 + 100, 495), new Vec2(641, 495), boxCounter);
        AddChild(box1);
        box1.visible = false;
        box1Sprite = new Box(box1);
        box1Sprite.scale = 0.3f;
        box1Sprite.scaleY = 0.31f;
        AddChild(box1Sprite);
        box1Sprite.x = (641 + 641 + 100) / 2;
        box1Sprite.y = (495 + 495 + 100)  / 2;
        box2 = new SquareBrick(new Vec2(691, 595 + 100), new Vec2(691 + 100, 595 + 100), new Vec2(691 + 100, 595), new Vec2(691, 595), boxCounter);
        AddChild(box2);
        box2.visible = false;
        box2Sprite = new Box(box2);
        box2Sprite.scale = 0.3f;
        box2Sprite.scaleY = 0.31f;
        AddChild(box2Sprite);
        box2Sprite.x = (691 + 691 + 100) / 2;
        box2Sprite.y = (595 + 595 + 100) / 2;
        box3 = new SquareBrick(new Vec2(651, 695 + 100), new Vec2(651 + 100, 695 + 100), new Vec2(651 + 100, 695), new Vec2(651, 695), boxCounter);
        AddChild(box3);
        box3.visible = false;
        box3Sprite = new Box(box3);
        box3Sprite.scale = 0.3f;
        box3Sprite.scaleY = 0.31f;
        AddChild(box3Sprite);
        box3Sprite.x = (651 + 651 + 100) / 2;
        box3Sprite.y = (695 + 695 + 100) / 2;
        box4 = new SquareBrick(new Vec2(541, 695 + 100), new Vec2(541 + 100, 695 + 100), new Vec2(541 + 100, 695), new Vec2(541, 695), boxCounter);
        AddChild(box4);
        box4.visible = false;
        box4Sprite = new Box(box4);
        box4Sprite.scale = 0.3f;
        box4Sprite.scaleY = 0.31f;
        AddChild(box4Sprite);
        box4Sprite.x = (541 + 541 + 100) / 2;
        box4Sprite.y = (695 + 695 + 100) / 2;
        box5 = new SquareBrick(new Vec2(1436, 695 + 100), new Vec2(1436 + 100, 695 + 100), new Vec2(1436 + 100, 695), new Vec2(1436, 695), boxCounter);
        AddChild(box5);
        box5.visible = false;
        box5Sprite = new Box(box5);
        box5Sprite.scale = 0.3f;
        box5Sprite.scaleY = 0.31f;
        AddChild(box5Sprite);
        box5Sprite.x = (1436 + 1436 + 100) / 2;
        box5Sprite.y = (695 + 695 + 100) / 2;
        box6 = new SquareBrick(new Vec2(837, 509), new Vec2(875, 555), new Vec2(921, 518), new Vec2(887, 470), boxCounter);
        AddChild(box6);
        box6.visible = false;
        box6Sprite = new Box(box6);
        box6Sprite.scale = 0.27f;
        box6Sprite.rotation = -45;
        AddChild(box6Sprite);
        box6Sprite.x = (837 + 921) / 2;
        box6Sprite.y = (470 + 555) / 2;
        box7 = new SquareBrick(new Vec2(1326, 695 + 100), new Vec2(1326 + 100, 695 + 100), new Vec2(1326 + 100, 695), new Vec2(1326, 695), boxCounter);
        AddChild(box7);
        box7.visible = false;
        box7Sprite = new Box(box7);
        box7Sprite.scale = 0.3f;
        box7Sprite.scaleY = 0.31f;
        AddChild(box7Sprite);
        box7Sprite.x = (1326 + 1326 + 100) / 2;
        box7Sprite.y = (695 + 695 + 100) / 2;
        box8 = new SquareBrick(new Vec2(1426 - 50, 595 + 100), new Vec2(1426 - 50 + 100, 595 + 100), new Vec2(1426 - 50 + 100, 595), new Vec2(1426 - 50, 595), boxCounter);
        AddChild(box8);
        box8.visible = false;
        box8Sprite = new Box(box8);
        box8Sprite.scale = 0.3f;
        box8Sprite.scaleY = 0.31f;
        AddChild(box8Sprite);
        box8Sprite.x = (1426 - 50 + 100 + 1426 - 50) / 2;
        box8Sprite.y = (595 + 595 + 100) / 2;
        barrel2 = new SquareBrick(new Vec2(1070, 440), new Vec2(1070 + 60, 440), new Vec2(1070 + 60, 440 - 120), new Vec2(1070, 440 - 120), boxCounter);
        AddChild(barrel2);
        barrel2.visible = false;
        barrel2Sprite = new Barrel1(barrel2);
        barrel2Sprite.scale = 0.22f;
        //barrel2Sprite.rotation = 40;
        AddChild(barrel2Sprite);
        barrel2Sprite.x = (1070 + 1070 + 60) / 2;
        barrel2Sprite.y = (440 + 440 - 120) / 2;
        beam4 = new SquareBrick(new Vec2(1404, 598), new Vec2(1418, 566), new Vec2(1191, 437), new Vec2(1174, 482), boxCounter);
        AddChild(beam4);
        beam4.visible = false;
        beam4Sprite = new Beam(beam4);
        beam4Sprite.scale = 0.60f;
        beam4Sprite.rotation = 60;
        AddChild(beam4Sprite);
        beam4Sprite.x = (1418 + 1174) / 2;
        beam4Sprite.y = (598 + 437) / 2;
        beam3 = new SquareBrick(new Vec2(978, 526), new Vec2(960, 553), new Vec2(1246, 784), new Vec2(1267, 751), boxCounter);
        AddChild(beam3);
        beam3.visible = false;
        beam3Sprite = new Beam(beam3);
        beam3Sprite.scale = 0.68f;
        beam3Sprite.rotation = 72;
        AddChild(beam3Sprite);
        beam3Sprite.x = (1267 + 960) / 2;
        beam3Sprite.y = (526 + 784) / 2;
        beam1 = new SquareBrick(new Vec2(765,765), new Vec2(780, 780), new Vec2(975, 515), new Vec2(950, 500), boxCounter);
        AddChild(beam1);
        beam1.visible = false;
        beam1Sprite = new Beam(beam1);
        beam1Sprite.scale = 0.68f;
        beam1Sprite.rotation = -27;
        AddChild(beam1Sprite);
        beam1Sprite.x = (975 + 765) / 2;
        beam1Sprite.y = (500 + 780) / 2;
        beam2 = new SquareBrick(new Vec2(1074, 395), new Vec2(1071, 364), new Vec2(693, 472), new Vec2(700, 500), boxCounter);
        AddChild(beam2);
        beam2.visible = false;
        beam2Sprite = new Beam(beam2);
        beam2Sprite.scale = 0.68f;
        beam2Sprite.rotation = 15;
        AddChild(beam2Sprite);
        beam2Sprite.x = (693 + 1074) / 2;
        beam2Sprite.y = (364 + 500) / 2;
        couch1 = new SquareBrick(new Vec2(1109, 452), new Vec2(1033, 540), new Vec2(1264, 744), new Vec2(1338, 680), boxCounter);
        AddChild(couch1);
        couch1.visible = false;
        couch1Sprite = new Couch(couch1);
        couch1Sprite.scale = 0.5f;
        couch1Sprite.rotation = 40;
        AddChild(couch1Sprite);
        couch1Sprite.x = (1033 + 1338) / 2;
        couch1Sprite.y = (452 + 744) / 2;
        barrel1 = new SquareBrick(new Vec2(1058, 415), new Vec2(1026, 383), new Vec2(957, 478), new Vec2(1006, 512), boxCounter);
        AddChild(barrel1);
        barrel1.visible = false;
        barrel1Sprite = new Barrel1(barrel1);
        barrel1Sprite.scale = 0.22f;
        barrel1Sprite.rotation = 40;
        AddChild(barrel1Sprite);
        barrel1Sprite.x = (957 + 1058) / 2;
        barrel1Sprite.y = (383 + 512) / 2;
        





        //bricks bouncy
        tire2 = new SquareBrickBouncy(new Vec2(790, 570), new Vec2(800, 600), new Vec2(870, 580), new Vec2(860, 545), boxCounter);
        AddChild(tire2);
        tire2.visible = false;
        tire2Sprite = new Tire(tire2);
        tire2Sprite.scale = 0.05f;
        tire2Sprite.rotation = -75;
        AddChild(tire2Sprite);
        tire2Sprite.x = (790 + 870) / 2;
        tire2Sprite.y = (545 + 600) / 2;
        tire1 = new SquareBrickBouncy(new Vec2(760, 560), new Vec2(780, 590), new Vec2(840, 540), new Vec2(825, 515), boxCounter);
        AddChild(tire1);
        tire1.visible = false;
        tire1Sprite = new Tire(tire1);
        tire1Sprite.scale = 0.05f;
        tire1Sprite.rotation = -125;
        AddChild(tire1Sprite);
        tire1Sprite.x = (760 + 840) / 2;
        tire1Sprite.y = (515 + 590) / 2;
        tire3 = new SquareBrickBouncy(new Vec2(550, 625), new Vec2(550, 685), new Vec2(670, 685), new Vec2(670, 625), boxCounter);
        AddChild(tire3);
        tire3.visible = false;
        tire3Sprite = new Tire(tire3);
        tire3Sprite.scale = 0.07f;
        tire3Sprite.rotation = -95;
        AddChild(tire3Sprite);
        tire3Sprite.x = (550 + 670) / 2;
        tire3Sprite.y = (625 + 685) / 2;
    }
}