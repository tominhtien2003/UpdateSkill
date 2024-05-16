using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField] private Transform bullerBasePrefab;
    [SerializeField] private BulletSO[] bulletSOArray;
    private Dictionary<string , Transform> bulletDictionary = new Dictionary<string , Transform>();
    public enum BulletType
    {
        BulletCircle,
        BulletSquare
    }
    private void Start()
    {
        CreateBullet(BulletType.BulletCircle);
        //CreateBullet(BulletType.BulletCircle);
        CreateBullet(BulletType.BulletSquare);
    }
    public Transform CreateBullet(BulletType bulletType)
    {
        Transform res;
        switch (bulletType)
        {
            case BulletType.BulletCircle:   
                //Debug.Log(bulletType.ToString());
                if (!bulletDictionary.ContainsKey(bulletType.ToString()))
                {
                    BulletSO bulletSO = Array.Find(bulletSOArray, x => x.nameBullet == bulletType.ToString());
                    //Debug.Log(bulletSO.nameBullet);
                    Transform obj = Instantiate(bullerBasePrefab);
                    obj.GetComponent<Bullet>().SetBulletSO(bulletSO);
                    //Debug.Log(obj.GetComponent<Bullet>().GetBulletSO().nameBullet);
                    obj.GetComponent<Bullet>().DisplayBullet();
                    bulletDictionary.Add(bulletType.ToString(), obj);
                    res = obj;
                }
                else
                {
                    res = bulletDictionary[bulletType.ToString()];
                }
                return res;
            case BulletType.BulletSquare:
                if (!bulletDictionary.ContainsKey(bulletType.ToString()))
                {
                    BulletSO bulletSO = Array.Find(bulletSOArray, x => x.nameBullet == bulletType.ToString());
                    Transform obj = Instantiate(bullerBasePrefab);
                    obj.GetComponent<Bullet>().SetBulletSO(bulletSO);
                    obj.GetComponent<Bullet>().DisplayBullet();
                    bulletDictionary.Add(bulletType.ToString(), obj);
                    res = obj;
                }
                else
                {
                    res = bulletDictionary[bulletType.ToString()];
                }
                return res; 
            default:
                return null;
        }
    }
}
