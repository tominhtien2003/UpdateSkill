using UnityEngine;

public class SquareEnemy : MonoBehaviour, IEnemy
{
    public void Attack()
    {
        Debug.Log("Square Enemy Attack!");
    }

    public void Move()
    {
        Debug.Log("Square Enemy Move!");
    }
}
