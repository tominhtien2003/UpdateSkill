using System.Collections;
using UnityEngine;

public class Circle : MonoBehaviour, IShape , IPool
{
    private float timeLife = 0f;
    public void ChangeColor(Color _color)
    {
        GetComponent<SpriteRenderer>().color = _color;
    }
    private void Update()
    {
        timeLife+= Time.deltaTime;
        if (timeLife > 5f)
        {
            Deactivate();
        }
    }
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator TimeBeforeDeactivate()
    {
        yield return new WaitForSeconds(5f);
    }
}
