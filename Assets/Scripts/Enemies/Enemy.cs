using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int hp;
    public int maxHP = 5;
    public int damage;
    public float damageCooldown;

    private void OnEnable()
    {
        StartCoroutine(DamagePlayer());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator DamagePlayer()
    {
        yield return new WaitForSeconds(damageCooldown);

        while (enabled)
        {
            Player.Instance.HP -= damage;

            yield return new WaitForSeconds(damageCooldown);
        }
    }
}
