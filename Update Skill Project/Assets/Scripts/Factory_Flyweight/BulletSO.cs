using UnityEngine;

[CreateAssetMenu(fileName = "BulletSO")]
public class BulletSO : ScriptableObject , IBullet
{
    public string nameBullet;
    public string descripition;
    public Sprite sprite;
    public Color color;

    public void Move()
    {
        Debug.Log(nameBullet + " is moving!");
    }
}
