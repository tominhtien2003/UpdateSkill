using UnityEngine;

public class EnemyFactor : MonoBehaviour 
{
    [SerializeField] private Transform posSpawnSquareEnemyPref;
    [SerializeField] private Transform posSpawnCircleEnemyPref;
    [SerializeField] private Transform squareEnemyPref;
    [SerializeField] private Transform circleEnemyPref;
    private Transform targetSpawn;
    public enum EnemyType
    {
        Square,
        Circle
    }
    public Transform CreateEnemy(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Square:
                targetSpawn = Instantiate(squareEnemyPref, posSpawnSquareEnemyPref.position, Quaternion.identity);
                break;
            case EnemyType.Circle:
                targetSpawn = Instantiate(circleEnemyPref, posSpawnCircleEnemyPref.position, Quaternion.identity);
                break;
            default:
                targetSpawn = null;
                Debug.Log("Don't have object!");
                break;
        }
        return targetSpawn;
    }
}
