using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Fighter : MonoBehaviour
{
    public int PNum;
    public FighterBase Base;
    public Transform attackPos;
    public Animator playerAnim;
    public Transform groundPos;
    public Rigidbody2D myBody;
    private AudioSource Audio_Player;
    public Transform EnemyTransform;
    public Transform firePoint;
    public GameObject forwardPoint;
    public GameObject projectilePrefab;
    public FighterStats STATS;
    #region  CONDITIONS
    public bool isGrounded = false;
    private bool isStunned = false;
    public bool Player_Facing_Right = true; // For determining which way the player is currently facing.
    public bool isAttacking;
    private bool canJump = false;
    private bool isFlipping = false;
    private bool canUseLongAttack = true;
    #endregion
    #region AI
    public bool isAI;
    private bool AI_shouldAdvance;
    private bool AI_shouldBlock;
    private bool AI_shouldCrouch;
    private bool AI_shouldJump;
    private Vector3 RelativeEnemyPosition;
    #endregion
    #region INPUTS
    private string PrimaryFire;
    private string SecondaryFire;
    private string Block;
    private string Jump;
    private string Crouch;
    private string Horizontal;
    private string Veritical;
    private string Sprint;

    #endregion

    // Use this for initialization
    void Start()
    {
        SetFighterBaseStats();
        Audio_Player = this.GetComponent<AudioSource>();
        playerAnim.SetInteger("HealthTier", 3);
        myBody = this.GetComponent<Rigidbody2D>();
        canJump = true;
        if (isAI)
        {
            gameObject.name = "AI-" + Base.Name;
            AI_shouldAdvance = true;
            var co = StartCoroutine(ShouldAdvance());
        }
        else
        {
            gameObject.name = "Player-" + PNum.ToString();
        }
        SetInputs();
    }

    // Update is called once per frame
    void Update()
    {
        //Stops Attacks
        if (isStunned)
        {
            CancelInvoke();
        }
        
        //Check if AI
        if (isAI)
        {
            var distance = Vector2.Distance(EnemyTransform.position, transform.position);
            float _vertical = AI_shouldCrouch ? -1f : 0f;
            float _horizontal = AI_shouldAdvance && distance > Base.Secondary_Range_X ? EnemyTransform.position.x > transform.position.x ? 1f : -1f : 0f;
            STATS.Set_Current_Movement(_horizontal, _vertical, Player_Facing_Right,
                AI_shouldCrouch, AI_shouldJump, Utils.GetARandomBool(), AI_shouldBlock);
            Collider2D[] enemyInRange = Physics2D.OverlapBoxAll(attackPos.position,
                    new Vector2(Base.Secondary_Range_X, Base.Secondary_Range_Y), 0, MasterController.Controller.GameSettings.EnemyMask);
            if (enemyInRange.Length > 1 && !isAttacking && AI_shouldAdvance && !isStunned)
            {
                isAttacking = true;
                StopMoving();
                AttackType _type = Utils.GetARandomAttack();
                AttackButton _btn = Utils.GetARandomButton();
                TryAttack(_type, _btn);
            }
        }
        else
        {
            STATS.Set_Current_Movement(Input.GetAxisRaw(Horizontal), Input.GetAxisRaw(Veritical), Player_Facing_Right,
                Input.GetAxisRaw(Crouch) > 0, Input.GetButtonDown(Jump), Input.GetButtonDown(Sprint), Input.GetAxisRaw(Block) > 0);

            var movement = STATS.Get_Current_Movement();
            if (Input.GetAxisRaw(PrimaryFire) > 0 && !isAttacking && !isStunned)
            {
                isAttacking = true;
                StopMoving();
                if (movement == Movement_Direction.Forward)
                {
                    TryAttack(AttackType.Forward, AttackButton.Primary);
                }
                else if (movement == Movement_Direction.Backward)
                {
                    TryAttack(AttackType.Back, AttackButton.Primary);
                }
                else if (movement == Movement_Direction.Neutral)
                {
                    TryAttack(AttackType.Neutral, AttackButton.Primary);
                }
            }
            if (Input.GetAxisRaw(SecondaryFire) > 0 && !isAttacking && !isStunned)
            {
                isAttacking = true;
                StopMoving();
                if (movement == Movement_Direction.Forward)
                {
                    TryAttack(AttackType.Forward, AttackButton.Secondary);
                }
                else if (movement == Movement_Direction.Backward)
                {
                    TryAttack(AttackType.Back, AttackButton.Secondary);
                }
                else if (movement == Movement_Direction.Neutral)
                {
                    TryAttack(AttackType.Neutral, AttackButton.Secondary);
                }
            }
        }
        var move = STATS.Get_Current_Action();
        if (move == Movement_Direction.Blocking || move == Movement_Direction.Crouching || move == Movement_Direction.Crouch_Blocking)
            StopMoving();
        playerAnim.SetBool("IsBlocking", move == Movement_Direction.Blocking || move == Movement_Direction.Crouch_Blocking);
        playerAnim.SetBool("IsCrouching", move == Movement_Direction.Crouching || move == Movement_Direction.Crouch_Blocking);
        playerAnim.SetBool("IsGrounded", isGrounded);
    }

    void FixedUpdate()
    {
        RelativeEnemyPosition = EnemyTransform.position - transform.position;
        if (RelativeEnemyPosition.x < 0 && Player_Facing_Right)
        {
            Flip();
        }
        if (RelativeEnemyPosition.x > 0 && !Player_Facing_Right)
        {
            Flip();
        }
        //Check if falling
        if (myBody.velocity.y < 0)
        {
            myBody.velocity += Vector2.up * Physics2D.gravity.y *
                (MasterController.Controller.GameSettings.FallMultiplier) * Time.deltaTime;
        }
        else if (myBody.velocity.y > 1)
        {
            myBody.velocity += Vector2.up * Physics2D.gravity.y *
                (MasterController.Controller.GameSettings.FallMultiplier * .75f) * Time.deltaTime;
        }
        isGrounded = Physics2D.OverlapCircle(groundPos.position, .2f, MasterController.Controller.GameSettings.GroundMask);
        Move();
    }
    public void Move()
    {
        var movement = STATS.Get_Current_Movement();
        var action = STATS.Get_Current_Action();
        if (!isStunned && (action.Equals(Movement_Direction.Jumping) || action.Equals(Movement_Direction.Neutral)))
        {
            if (action == Movement_Direction.Jumping && isGrounded && canJump)
            {
                PerformJump();
            }
            if (!isAttacking && !(action == Movement_Direction.Jumping || action == Movement_Direction.Blocking))
            {
                var _horizontal = movement == Movement_Direction.Forward ? 1f : movement == Movement_Direction.Backward ? -1f : 0.0f;
                playerAnim.SetFloat("Speed", Mathf.Abs(_horizontal));
                if (STATS.Get_Player_Sprinting() && isGrounded)
                {
                    myBody.velocity = new Vector2(_horizontal * Base.Speed * 1.5f, myBody.velocity.y);
                }
                else
                {
                    if (isGrounded)
                        myBody.velocity = new Vector2(_horizontal * Base.Speed, myBody.velocity.y);
                    else
                    {
                        myBody.velocity = new Vector2(myBody.velocity.x, myBody.velocity.y);
                    }
                }
            }
        }
        int set = -1;
        if (action.Equals(Movement_Direction.Crouching) || action.Equals(Movement_Direction.Crouch_Blocking) || action.Equals(Movement_Direction.Blocking))
        {
            switch (action)
            {
                case Movement_Direction.Crouching:
                    set = 0;
                    break;
                case Movement_Direction.Crouch_Blocking:
                    set = 0;
                    break;
                case Movement_Direction.Blocking:
                    set = 4;
                    break;
            }
        }
        else
        {
            switch (movement)
            {
                case Movement_Direction.Neutral:
                    set = 1;
                    break;
                case Movement_Direction.Forward:
                    set = 2;
                    break;
                case Movement_Direction.Backward:
                    set = 3;
                    break;
                default:
                    set = -1;
                    break;
            }
        }
        playerAnim.SetInteger("Movement", set);
    }
    private void PerformJump()
    {
        playerAnim.SetBool("IsGrounded", false);
        playerAnim.SetTrigger("Jump");
        Audio_Player.clip = Base.Jump_Sound;
        Audio_Player.Play();
        canJump = false;
        myBody.AddForce(new Vector2(0, Base.JumpVelocity * 2), ForceMode2D.Impulse);
        var co = StartCoroutine(WaitForPlayerToLand());
    }
    private void StopMoving()
    {
        if (!isGrounded)
        {
            myBody.velocity = new Vector2(myBody.velocity.x * .75f, myBody.velocity.y);
        }
        else
        {
            myBody.velocity = Vector2.zero;
        }
    }
    private void TryAttack(AttackType _attack, AttackButton _btn)
    {
        Debug.Log(string.Format("ATTACK: {0}", _attack));
        if (_attack == AttackType.Back && Base.Back_Damage == 0f && isGrounded)
        {
            _attack = AttackType.Projectile;
        }
        if (STATS.Get_Current_Action() == Movement_Direction.Crouching)
        {
            _attack = AttackType.Crouch;
        }

        isAttacking = true;
        float _cd = STATS.Get_Attack_CoolDown(_attack, _btn, Base);
        float _damage = STATS.Get_Attack_Damage(_attack, _btn, Base);
        Vector2 _range = STATS.Get_Attack_Range(_attack, _btn, Base);

        if (_attack == AttackType.Projectile)
        {
            var CoolDownTimer = StartCoroutine(AnimateAttack(_cd, _btn));
            var co = StartCoroutine(FireProjectile(_attack, _btn, _cd / 3));
        }
        else if (_attack == AttackType.Forward && _btn == AttackButton.Primary)
        {
            var co = StartCoroutine(FireLongAttack());
        }
        else
        {
            var CoolDownTimer = StartCoroutine(AnimateAttack(_cd, _btn));
            Collider2D[] enemyInRange = Physics2D.OverlapBoxAll(attackPos.position, _range, 0, MasterController.Controller.GameSettings.EnemyMask);
            for (int i = 0; i < enemyInRange.Length; ++i)
            {
                if (enemyInRange[i] != this.GetComponent<Collider2D>())
                {
                    var enemy = enemyInRange[i];
                    if (enemy.gameObject.name == "Rectangle")
                    {
                        Destroy(enemy.gameObject);
                    }
                    if (enemy != null)
                    {
                        enemy.GetComponent<Fighter>().TakeDamage(_damage, _attack, _btn);
                    }
                }

            }
        }
    }
    private void Flip()
    {
        if (!isFlipping)
        {
            isFlipping = true;
            Player_Facing_Right = !Player_Facing_Right;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            var co = StartCoroutine(SmoothFlip());
        }
    }
    public void TakeDamage(float damage, AttackType a_type, AttackButton a_btn)
    {
        if (STATS.Get_Current_Action() == Movement_Direction.Blocking)
        {
            STATS.Apply_Damage(damage * MasterController.Controller.GameSettings.Damage_Reduction_From_Block, Base.Health);
            Play_Sound(Base.Blocked_Hit_Sound, .3f);
        }
        else
        {
            STATS.Apply_Damage(damage, Base.Health);
            Play_Sound(Base.Hit_Sound, .3f);
            Coroutine stun;
            float stunTime = 0f, x_knock = 0f, y_knock = 0f;

            switch (a_type)
            {
                case AttackType.Forward:
                    stunTime += MasterController.Controller.GameSettings.Forward_Stun_Time;
                    x_knock += MasterController.Controller.GameSettings.Forward_KB;
                    break;
                case AttackType.Back:
                    stunTime += MasterController.Controller.GameSettings.Back_Stun_Time;
                    x_knock += MasterController.Controller.GameSettings.Back_KB;
                    break;
                case AttackType.Neutral:
                    stunTime += MasterController.Controller.GameSettings.Neutral_Stun_Time;
                    x_knock += MasterController.Controller.GameSettings.Neutral_KB;
                    break;
                case AttackType.Air:
                    stunTime += MasterController.Controller.GameSettings.Air_Stun_Time;
                    x_knock += MasterController.Controller.GameSettings.Air_KB;
                    break;
                case AttackType.Crouch:
                    stunTime += MasterController.Controller.GameSettings.Crouch_Stun_Time;
                    x_knock += MasterController.Controller.GameSettings.Crouch_KB;
                    break;
                case AttackType.Projectile:
                    stunTime += MasterController.Controller.GameSettings.Projectile_Speed;
                    x_knock += MasterController.Controller.GameSettings.Projectile_KB;
                    break;
                case AttackType.Wall:
                    break;
            }
            y_knock = x_knock; //set to same as x
            if (a_btn == AttackButton.Primary)
            {
                stunTime += MasterController.Controller.GameSettings.PrimaryAttack_Stun_Time;
                x_knock += MasterController.Controller.GameSettings.Primary_KB_X;
                y_knock += MasterController.Controller.GameSettings.Primary_KB_Y;
            }
            else if (a_btn == AttackButton.Secondary)
            {
                stunTime += MasterController.Controller.GameSettings.SecondaryAttack_Stun_Time;
                x_knock += MasterController.Controller.GameSettings.Secondary_KB_X;
                y_knock += MasterController.Controller.GameSettings.Secondary_KB_Y;
            }
            stun = StartCoroutine(ApplyStunToPlayer(stunTime, x_knock, y_knock));
        }
        if (STATS.Get_Current_Stats().Current_Health <= 0)
        {
            if (PNum == 1)
            {
                FindObjectOfType<BattleController>().SetScore(2);
            }
            else if (PNum == 2)
            {
                FindObjectOfType<BattleController>().SetScore(1);

            }
            gameObject.SetActive(false);
        }
        //check health tier
        var t = STATS.Get_Current_Stats().Current_Health_Tier;
        if (t == HealthTier.low)
        {
            playerAnim.SetInteger("HealthTier", 1);
            AddClassMultiplier(MasterController.Controller.GameSettings.LowTier_Primary_Class_Multiplier,
                MasterController.Controller.GameSettings.LowTier_Secondary_Class_Multiplier);
        }
        else if (t == HealthTier.medium)
        {
            playerAnim.SetInteger("HealthTier", 2);
            AddClassMultiplier(MasterController.Controller.GameSettings.MidTier_Primary_Class_Multiplier,
                MasterController.Controller.GameSettings.MidTier_Secondary_Class_Multiplier);
        }
    }
    private IEnumerator AnimateAttack(float _cooldown, AttackButton _btn)
    {
        if (_btn == AttackButton.Primary)
        {
            playerAnim.SetTrigger("Primary_Attack");
        }
        else if (_btn == AttackButton.Secondary)
        {
            playerAnim.SetTrigger("Secondary_Attack");
        }
        playerAnim.SetBool("AttackFinished", false);
        yield return new WaitForSeconds(_cooldown);
        isAttacking = false;
        playerAnim.SetBool("AttackFinished", true);
    }
    private IEnumerator FireProjectile(AttackType _type, AttackButton _btn, float _timer)
    {
        yield return new WaitForSeconds(_timer);
        var projectile = Instantiate(projectilePrefab, firePoint.transform.position, firePoint.transform.rotation);
        var rb_mult = 0f;
        float damage = STATS.Get_Attack_Damage(_type, _btn, Base);
        if (RelativeEnemyPosition.x > 0)
        {
            Debug.Log(RelativeEnemyPosition.x);
            rb_mult = -1f;
        }
        else
        {
            rb_mult = 1f;
        }
        if (_btn == AttackButton.Primary)
            projectile.GetComponent<Projectile>()
                .ThrowProjectile(rb_mult, PNum, Base.Primary_Projectile_Sprite, Base.Primary_Projectile_Animator, _btn, damage);
        else if (_btn == AttackButton.Secondary)
            projectile.GetComponent<Projectile>().
                ThrowProjectile(rb_mult, PNum, Base.Secondary_Projectile_Sprite, Base.Secondary_Projectile_Animator, _btn, damage);
    }
    private IEnumerator FireLongAttack()
    {
        playerAnim.SetTrigger("Primary_Attack");
        var dmg = STATS.Get_Attack_Damage(AttackType.Forward, AttackButton.Primary, Base);
        forwardPoint.GetComponent<HoldAttack>().Set_Params(dmg, PNum);
        forwardPoint.gameObject.SetActive(true);
        forwardPoint.gameObject.transform.Translate(.01f, 0f, 0f);
        var cd = STATS.Get_Attack_CoolDown(AttackType.Forward, AttackButton.Primary, Base);
        playerAnim.SetBool("AttackFinished", false);
        while (Input.GetAxisRaw(PrimaryFire) > 0 && STATS.Get_Current_Movement().Equals(Movement_Direction.Forward))
        {
            yield return new WaitForSecondsRealtime(cd);
        }
        forwardPoint.gameObject.SetActive(false);
        isAttacking = false;
        playerAnim.SetBool("AttackFinished", true);

    }
    private IEnumerator WaitForPlayerToLand()
    {
        while (!isGrounded)
        {
            yield return null;
        }
        canJump = true;
    }
    private IEnumerator SmoothFlip()
    {
        yield return new WaitForSecondsRealtime(.3f);
        isFlipping = false;
    }
    private IEnumerator ApplyStunToPlayer(float stun_time, float x_knock, float y_knock)
    {
        playerAnim.SetBool("Stunned", true);
        this.isStunned = true;
        //Apply slight knock back
        if (RelativeEnemyPosition.x > 0)
        {
            x_knock *= -1; //make sure to add force in correct direction
        }
        myBody.AddForce(new Vector2(x_knock, y_knock), ForceMode2D.Impulse);
        yield return new WaitForSeconds(stun_time);
        playerAnim.SetBool("Stunned", false);
        this.isStunned = false;
    }
    private void Play_Sound(AudioClip _clip, float _delay = 0)
    {
        Audio_Player.clip = _clip;
        if (_delay > 0)
            Audio_Player.PlayDelayed(_delay);
        else
            Audio_Player.Play();
    }
    private IEnumerator ShouldAdvance()
    {
        int reset = 0;
        var stats = STATS.Get_Current_Stats();
        while (stats.Current_Health > 20)
        {
            //Every 3 seconds check if the AI should be advancing or not
            bool prev = AI_shouldAdvance;
            AI_shouldAdvance = Utils.GetARandomBool();
            if (prev == AI_shouldAdvance)
            {
                reset++;
                if (reset > 2)
                {
                    AI_shouldAdvance = !AI_shouldAdvance;
                    reset = 0;
                }
            }
            //Check if enemy is jumping
            if (RelativeEnemyPosition.y > 0)
            {
                AI_shouldJump = Utils.GetARandomBool();
            }
            else
            {
                AI_shouldJump = false;
            }
            yield return new WaitForSeconds(1f);
        }
        while (stats.Current_Health > 0)
        {
            AI_shouldAdvance = false;
            AI_shouldBlock = Utils.GetARandomBool();
            AI_shouldCrouch = Utils.GetARandomBool();
            AI_shouldJump = false;
            yield return new WaitForSeconds(2f);
        }

    }
    private void SetFighterBaseStats()
    {
        STATS = new FighterStats();
        STATS.Set_Stat_Multipliers(1, 1, 1);
        STATS.Set_Current_Health(Base.Health, Base.Health);
    }
    public void AddClassMultiplier(float primary_att_level, float secondary_att_level)
    {
        if (Base.Fighter_Class == FighterClass.Speed)
        {
            STATS.Set_Stat_Multipliers(secondary_att_level, primary_att_level, secondary_att_level);
        }
        if (Base.Fighter_Class == FighterClass.Cannon)
        {
            STATS.Set_Stat_Multipliers(primary_att_level, secondary_att_level, secondary_att_level);
        }
        if (Base.Fighter_Class == FighterClass.Tank)
        {
            STATS.Set_Stat_Multipliers(secondary_att_level, secondary_att_level, primary_att_level);
        }
    }
    private void SetInputs()
    {
        string controllerType;
        string player;
        string platform;
#if UNITY_STANDALONE_OSX
        platform = "";
#else
        platform = "PC_";
#endif

        //determine which player
        if (PNum == 1)
        {
            if (MasterController.Controller != null)
            {
                controllerType = MasterController.Controller.Player1InputMethod == "Keyboard" ? "Keyboard_" : "Controller_";
                player = MasterController.Controller.Player1InputMethod == "Keyboard" ? "" : "_P1";
                if (MasterController.Controller.Player1InputMethod == "Keyboard")
                    platform = "";
            }
            else
            {
                //testing
                Debug.Log("Using test controller");
                controllerType = "Keyboard_";
                player = "";
            }
        }
        else
        {
            controllerType = MasterController.Controller.Player2InputMethod == "Keyboard" ? "Keyboard_" : "Controller_";
            if (MasterController.Controller.Player1InputMethod == "Keyboard")
            {
                //p1 is using keyboard so set to controller 1
                player = MasterController.Controller.Player2InputMethod == "Keyboard" ? "" : "_P1";
            }
            else
            {
                player = MasterController.Controller.Player2InputMethod == "Keyboard" ? "" : "_P2";
            }
            if (MasterController.Controller.Player2InputMethod == "Keyboard")
                platform = "";
        }

        PrimaryFire = platform + controllerType + "Fire1" + player;
        SecondaryFire = platform + controllerType + "Fire2" + player;
        Block = platform + controllerType + "Block" + player;
        Jump = platform + controllerType + "Jump" + player;
        Crouch = controllerType + "Crouch" + player;
        Horizontal = controllerType + "Horizontal" + player;
        Veritical = controllerType + "Vertical" + player;
        Sprint = platform + controllerType + "Sprint" + player;
    }
}