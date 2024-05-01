using UnityEngine;

public class Square : MonoBehaviour , IShape
{
    public void ChangeColor(Color _color)
    {
        GetComponent<SpriteRenderer>().color = _color;
    }
}
