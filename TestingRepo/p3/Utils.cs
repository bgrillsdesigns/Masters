using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static bool GetARandomBool()
    {
        UnityEngine.Random.InitState((int)Time.time * (int)Time.deltaTime);
        int rand = UnityEngine.Random.Range(0, 100);
        return rand % 2 == 0;
    }

    public static AttackType GetARandomAttack(){
        UnityEngine.Random.InitState((int)Time.time * (int)Time.deltaTime);
        int rand = UnityEngine.Random.Range(0,6);
        AttackType _type = (AttackType)rand;
        return _type;
    }

    public static AttackButton GetARandomButton(){
        UnityEngine.Random.InitState((int)Time.time * (int)Time.deltaTime);
        int rand = UnityEngine.Random.Range(0,2);
        AttackButton _btn = (AttackButton)rand;
        return _btn;
    }
}

public enum AttackType
{
    Projectile,
    Air,
    Forward,
    Back,
    Neutral,
    Crouch,
    Wall
}
public enum AttackButton{
    Primary,
    Secondary,
    Wall
}
public enum FighterClass
{
    Speed,
    Tank,
    Cannon
}
public enum HealthTier
{
    low,
    medium,
    full
}
public enum Player_Facing
{
    LEFT,
    RIGHT
}

public enum Player_Moving_Horizontal{
    Left,
    Right,
    Neutral
}
public enum Player_Moving_Vertical{
    Up,
    Down,
    Neutral
}

public enum Movement_Direction{
    Forward,
    Backward,
    Neutral,
    Blocking,
    Crouching,
    Crouch_Blocking,
    Jumping
}