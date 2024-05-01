using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Transform squareEnemy = FindObjectOfType<EnemyFactor>().CreateEnemy(EnemyFactor.EnemyType.Square);
            squareEnemy.GetComponent<SquareEnemy>().Attack();
            Transform circleEnemy = FindObjectOfType<EnemyFactor>().CreateEnemy(EnemyFactor.EnemyType.Circle);
            circleEnemy.GetComponent<CircleEnemy>().Move();
        }
    }
}
