using UnityEngine;

public class ObserverPattern : MonoBehaviour
{
    [SerializeField] private string nameObject;
    private void Start()
    {
        InvokeRepeating("CloneObject", 1f, 1f);
        Invoke("CancleClone", 5f);
    }
    public ObserverPattern CloneObject()
    {
        ObserverPattern observerPattern = Instantiate(this, transform.position, Quaternion.identity);
        if (observerPattern.name != "ObserverPattern")
        {
            return null;
        }
        return observerPattern;
    }
    public void CancleClone()
    {
        CancelInvoke("CloneObject");
    }
}
