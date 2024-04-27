using UnityEngine;

public class CircleEnemy : MonoBehaviour, IEnemy
{
    public void Attack()
    {
        Debug.Log("Circle Enemy Attack!");
    }

    public void Move()
    {
        Debug.Log("Circle Enemy Move!");
    }
}
