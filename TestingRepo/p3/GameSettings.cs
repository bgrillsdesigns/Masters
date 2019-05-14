using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings")]
public class GameSettings : ScriptableObject {

	//Set all values through UI
	public float Damage_Reduction_From_Block;
	
	#region BUTTON_STUNS
	public float PrimaryAttack_Stun_Time;
	public float SecondaryAttack_Stun_Time;
	#endregion

	#region MOVEMENT_STUNS
	public float Forward_Stun_Time;
	public float Back_Stun_Time;
	public float Neutral_Stun_Time;
	public float Air_Stun_Time;
	public float Crouch_Stun_Time;
	public float Projectile_Stun_Time;
	#endregion
	#region KnockBack_Forces
	public float Primary_KB_X;
	public float Primary_KB_Y;
	public float Secondary_KB_X;
	public float Secondary_KB_Y;
	public float Forward_KB;
	public float Back_KB;
	public float Neutral_KB;
	public float Air_KB;
	public float Projectile_KB;
	public float Crouch_KB;
	#endregion
	public LayerMask EnemyMask;
    public LayerMask GroundMask;
	public float MidTier_Primary_Class_Multiplier;
	public float MidTier_Secondary_Class_Multiplier;
	public float LowTier_Primary_Class_Multiplier;
	public float LowTier_Secondary_Class_Multiplier;
	public float FallMultiplier;
	public float Projectile_Speed;
}
