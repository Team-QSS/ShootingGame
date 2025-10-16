using UnityEngine;

public class EnemyPoolStarter : MonoBehaviour,IPoolingObject
{
    [SerializeField] private AEnemy enemy;
    public void OnBirth()
    {
        enemy.Birth();
    }

    public void OnDeathInit()
    {
        enemy.OnDeathInit();
    }
}
