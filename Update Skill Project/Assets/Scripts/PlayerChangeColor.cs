using UnityEngine;

public class PlayerChangeColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating("AutomaticChangeColorPlayer", 0f, .25f);
    }
    private void AutomaticChangeColorPlayer()
    {
        float red = Random.Range(0f, 1f);
        float green = Random.Range(0f, 1f);
        float blue = Random.Range(0f, 1f);
        spriteRenderer.color = new Color(red, green, blue);
    }
}
