using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    private int FromPlayer;
    public SpriteRenderer sprite_rend;
    public Animator anim;
    private AttackButton A_Type;
    private float damage;

    private void Start()
    {
        speed = MasterController.Controller.GameSettings.Projectile_Speed;
    }

    public void ThrowProjectile(float _rp, int _whoThrew, Sprite _projectileSprite, RuntimeAnimatorController _anim, AttackButton _btn, float _damage)
    {
        FromPlayer = _whoThrew;
        sprite_rend.sprite = _projectileSprite;
        anim.runtimeAnimatorController = _anim;
        A_Type = _btn;
        damage = _damage;
        if (_rp == 1)
        {
            rb.velocity = transform.right * -1 * speed;
        }
        else
        {
            rb.velocity = transform.right * speed;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Fighter player = collision.GetComponent<Fighter>();
        if (player.PNum != FromPlayer)
        {
            player.TakeDamage(damage, AttackType.Projectile, A_Type);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enviornment")
        {

            Destroy(gameObject);
        }
    }
}
