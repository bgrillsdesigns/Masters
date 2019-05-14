using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Fighter", menuName = "Fighter")]
public class FighterBase : ScriptableObject {
	public string Name = "Fighter Name";
	public string Description = "Fighter Description";
	public float Health;
	public float Speed;
	public float JumpVelocity;
	public float DamageResistance;
	#region DAMAGE
	public float Primary_Damage;
	public float Secondary_Damage;
    public float Projectile_Damage;
    public float Crouch_Damage;
	public float Air_Damage;
    public float Forward_Damage;
    public float Back_Damage;
    public float Neutral_Damage;
	#endregion
	#region COOLDOWNS
	public float Primary_CD;
	public float Secondary_CD;
    public float Projectile_CD;
    public float Crouch_CD;
    public float Air_CD;
    public float Forward_CD;
    public float Back_CD;
    public float Neutral_CD;
	#endregion
	#region RANGES
	public float Primary_Range_X;
	public float Primary_Range_Y;
	public float Secondary_Range_X;
	public float Secondary_Range_Y;
	public float Forward_Range;
	public float Back_Range;
	public float Neutral_Range;
	public float Projectile_Range;
	public float Crouch_Range;
	public float Air_Range;
	#endregion
	#region SOUNDS
	public AudioClip Hit_Sound;
	public AudioClip Blocked_Hit_Sound;
	public AudioClip Jump_Sound;
	#endregion
	public FighterClass Fighter_Class;
	public GameObject DamageEffect;
	public RuntimeAnimatorController UI_Animation;
	public RuntimeAnimatorController Primary_Projectile_Animator;
	public RuntimeAnimatorController Secondary_Projectile_Animator;
	public Sprite Primary_Projectile_Sprite;
	public Sprite Secondary_Projectile_Sprite;
}