using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance { get; private set; }

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public Transform prefab;
        public int size;
        public int timeLife;
    }

    [SerializeField] private List<Pool> pools;
    [SerializeField] private Dictionary<string, Queue<Transform>> poolDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<Transform>>();
        foreach(var pool in pools)
        {
            Queue<Transform> queue = new Queue<Transform>();
            for (int i = 0; i < pool.size; i++)
            {
                Transform obj = Instantiate(pool.prefab);
                obj.gameObject.SetActive(false);
                queue.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, queue);
        }
    }
    public Transform GetTransform(string tag,Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogError("Don't have object with tag : " + tag);
            return null;
        }
        Transform obj = poolDictionary[tag].Dequeue();
        if (!obj.gameObject.activeInHierarchy)
        {
            obj.gameObject.SetActive(true);
            obj.position = position;
            obj.rotation = rotation;
            
        }
        IPool iPoolObj = obj.GetComponent<IPool>();
        iPoolObj.Deactivate();
        poolDictionary[tag].Enqueue(obj);
        return obj;
    }
}
