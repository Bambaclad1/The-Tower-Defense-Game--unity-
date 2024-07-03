using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyScript : MonoBehaviour
{
    public int HP = 5; 
    public int CoinReward = 1;
    public static int kills = 0;

    private void Start()
    {
        kills++;
    }
    private void Update()
    {
        //Debug.Log($"{gameObject.name} HP: {HP}"); 
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            godie();
        }
    }

    private void godie()
    {
        Money.coins = Money.coins + CoinReward;
        Destroy(gameObject);
    }
}
