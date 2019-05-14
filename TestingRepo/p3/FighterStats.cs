using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStats
{
    private Movement Fighter_Movement;
    private Stats Fighter_Stats;

    public FighterStats()
    {
        Fighter_Movement = new Movement();
        Fighter_Movement.Player_Action = new bool[4];
        Fighter_Stats = new Stats();
    }

    public void Set_Current_Movement(float _horizontal = 0, float _vertical = 0,
        bool _facing = true, bool _crouching = false, bool _jumping = false, bool _sprinting = false, bool _blocking = false)
    {
        Fighter_Movement.Horizontal_Direction = _horizontal > 0 ? Player_Moving_Horizontal.Right :
            _horizontal < 0 ? Player_Moving_Horizontal.Left : Player_Moving_Horizontal.Neutral;
        Fighter_Movement.Vertical_Direction = _vertical > 0 ? Player_Moving_Vertical.Up :
            _vertical < 0 ? Player_Moving_Vertical.Down : Player_Moving_Vertical.Neutral;
        Fighter_Movement.Player_Direction = _facing ? Player_Facing.RIGHT : Player_Facing.LEFT;

        Fighter_Movement.Player_Action[0] = _blocking;
        Fighter_Movement.Player_Action[1] = _vertical < 0 ? true : _crouching;
        Fighter_Movement.Player_Action[2] = _sprinting;
        Fighter_Movement.Player_Action[3] = _vertical > 0 ? true : _jumping;
    }

    public Movement_Direction Get_Current_Movement()
    {
        //Determine player direction
        if (Fighter_Movement.Horizontal_Direction == Player_Moving_Horizontal.Left && Fighter_Movement.Player_Direction == Player_Facing.RIGHT)
        {
            return Movement_Direction.Backward;
        }
        else if (Fighter_Movement.Horizontal_Direction == Player_Moving_Horizontal.Right && Fighter_Movement.Player_Direction == Player_Facing.LEFT)
        {
            return Movement_Direction.Backward;
        }
        else if (Fighter_Movement.Horizontal_Direction == Player_Moving_Horizontal.Left && Fighter_Movement.Player_Direction == Player_Facing.LEFT)
        {
            return Movement_Direction.Forward;
        }
        else if (Fighter_Movement.Horizontal_Direction == Player_Moving_Horizontal.Right && Fighter_Movement.Player_Direction == Player_Facing.RIGHT)
        {
            return Movement_Direction.Forward;
        }
        else
        {
            return Movement_Direction.Neutral;
        }
    }
    public Movement_Direction Get_Current_Action()
    {
        if (Fighter_Movement.Player_Action[3])
        {
            return Movement_Direction.Jumping;
        }
        else if (Fighter_Movement.Player_Action[0] && Fighter_Movement.Player_Action[1])
        {
            return Movement_Direction.Crouch_Blocking;
        }
        else if (Fighter_Movement.Player_Action[0])
        {
            return Movement_Direction.Blocking;
        }
        else if (Fighter_Movement.Player_Action[1])
        {
            return Movement_Direction.Crouching;
        }
        else{
            return Movement_Direction.Neutral;
        }
    }

    public bool Get_Player_Sprinting(){
        return Fighter_Movement.Player_Action[2] && Get_Current_Movement() == Movement_Direction.Forward;
    }

    public void Set_Current_Health(float _health, float _baseHealth)
    {
        Fighter_Stats.Current_Health = _health;
        if (Fighter_Stats.Current_Health == _baseHealth)
        {
            Fighter_Stats.Current_Health_Tier = HealthTier.full;
        }
        else if (Fighter_Stats.Current_Health <= (_baseHealth * (1f / 3f)) && Fighter_Stats.Current_Health_Tier != HealthTier.low)
        {
            Fighter_Stats.Current_Health_Tier = HealthTier.low;
        }
        else if (Fighter_Stats.Current_Health <= (_baseHealth * (2f / 3f)) && Fighter_Stats.Current_Health_Tier != HealthTier.medium)
        {
            Fighter_Stats.Current_Health_Tier = HealthTier.medium;
        }
    }
    public void Apply_Damage(float _damage, float _base)
    {
        var dmg_amt = _damage * Fighter_Stats.Current_Damage_Reduction;
        Set_Current_Health(Fighter_Stats.Current_Health - dmg_amt, _base);
    }
    public void Set_Stat_Multipliers(float _damage, float _speed, float _resist)
    {
        Fighter_Stats.Current_Damage_Multiplier = _damage;
        Fighter_Stats.Current_Speed_Multiplier = _speed;
        Fighter_Stats.Current_Damage_Reduction = _resist;
    }

    public Stats Get_Current_Stats()
    {
        return Fighter_Stats;
    }

    public float Get_Attack_CoolDown(AttackType _attack, AttackButton _btn, FighterBase Base)
    {
        var cd = 0f;
        switch (_attack)
        {
            case AttackType.Forward:
                cd += Base.Forward_CD;
                break;
            case AttackType.Back:
                cd += Base.Back_CD;
                break;
            case AttackType.Neutral:
                cd += Base.Neutral_CD;
                break;
            case AttackType.Air:
                cd += Base.Air_CD;
                break;
            case AttackType.Crouch:
                cd += Base.Crouch_CD;
                break;
            case AttackType.Projectile:
                cd += Base.Projectile_CD;
                break;
        }
        if (_btn == AttackButton.Primary)
        {
            cd += Base.Primary_CD;
        }
        else if (_btn == AttackButton.Secondary)
        {
            cd += Base.Secondary_CD;
        }
        return cd;
    }
    public float Get_Attack_Damage(AttackType _attack, AttackButton _btn, FighterBase Base)
    {
        float damage = 0f;
        switch (_attack)
        {
            case AttackType.Forward:
                damage += Base.Forward_Damage;
                break;
            case AttackType.Back:
                damage += Base.Back_Damage;
                break;
            case AttackType.Neutral:
                damage += Base.Neutral_Damage;
                break;
            case AttackType.Air:
                damage += Base.Air_Damage;
                break;
            case AttackType.Crouch:
                damage += Base.Crouch_Damage;
                break;
            case AttackType.Projectile:
                damage += Base.Projectile_Damage;
                break;
        }
        if (_btn == AttackButton.Primary)
        {
            damage += Base.Primary_Damage;
        }
        else if (_btn == AttackButton.Secondary)
        {
            damage += Base.Secondary_Damage;
        }
        return damage * Fighter_Stats.Current_Damage_Multiplier;
    }
    public Vector2 Get_Attack_Range(AttackType _attack, AttackButton _btn, FighterBase Base)
    {
        Vector2 range = new Vector2();
        switch (_attack)
        {
            case AttackType.Forward:
                range.x += Base.Forward_Range;
                break;
            case AttackType.Back:
                range.x += Base.Back_Range;
                break;
            case AttackType.Neutral:
                range.x += Base.Neutral_Range;
                break;
            case AttackType.Air:
                range.x += Base.Air_Range;
                break;
            case AttackType.Crouch:
                range.x += Base.Crouch_Range;
                break;
            case AttackType.Projectile:
                range.x += Base.Projectile_Range;
                break;
        }
        range.y = range.x;
        if (_btn == AttackButton.Primary)
        {
            range.x += Base.Primary_Range_X;
            range.y += Base.Primary_Range_Y;
        }
        else if (_btn == AttackButton.Secondary)
        {
            range.x += Base.Secondary_Range_X;
            range.y += Base.Secondary_Range_Y;
        }
        return range;
    }

    public struct Movement
    {
        public Player_Moving_Horizontal Horizontal_Direction;
        public Player_Moving_Vertical Vertical_Direction;
        public Player_Facing Player_Direction;
        public bool[] Player_Action; //blocking,crouching,sprinting,jumping
    }
    public struct Stats
    {
        public float Current_Health;
        public HealthTier Current_Health_Tier;
        public float Current_Speed_Multiplier;
        public float Current_Damage_Reduction;
        public float Current_Damage_Multiplier;
    }
}