using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BulletSO bulletSO;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        bulletSO.Move();
    }
    public void SetBulletSO(BulletSO _bulletSO)
    {
        bulletSO = _bulletSO;
    }
    public BulletSO GetBulletSO()
    {
        return bulletSO;
    }
    public void DisplayBullet()
    {
        spriteRenderer.color = bulletSO.color;
        spriteRenderer.sprite = bulletSO.sprite;
    }
}
