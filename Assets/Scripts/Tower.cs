using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float cooldown = 1.0f;
    List<Enemy> targets = new List<Enemy>();
    [SerializeField] int upgrateCost = 1;
    Coins coins;
    [SerializeField] GameObject nexlevel;
    void Start()
    {
        StartCoroutine(Attack());
        coins = FindAnyObjectByType<Coins>();
    }

    IEnumerator Attack()
    {
        while (true)
        {
            if (targets.Count > 0)
            {
                for (int i = 0; i < targets.Count; i++)
                {
                    if (targets[i])
                    {
                        if (!targets[i].TakeDamage(damage))
                        {
                            targets.RemoveAt(i);
                        }
                        break;
                    }
                    else
                    {
                        targets.RemoveAt(i);
                    }
                }
            }
            yield return new WaitForSeconds(cooldown);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy target))
        {
            targets.Add(target);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy target))
        {
            targets.Remove(target);
        }
    }
    void OnMouseDown()
    {
        if (coins.CanSpendcoins(upgrateCost) && nexlevel != null)
        {
            coins.Spendcoins(upgrateCost);
            Instantiate(nexlevel, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
