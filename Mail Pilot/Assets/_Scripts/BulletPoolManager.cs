using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

//[System.Serializable]
public class BulletPoolManager
{
    static BulletPoolManager instance;

    public GameObject bullet;
    int iterator;

    PlayerController playerController;

    //TODO: create a structure to contain a collection of bullets
    public  GameObject[] bullets = new GameObject[50];
    
        
    private BulletPoolManager()
    {
        // TODO: add a series of bullets to the Bullet Pool
        //bullet = playerController.bullet;
        bullet = Resources.Load("Bullet", typeof(GameObject)) as GameObject;
        for (int i = 0; i < 50; i++)
        {
            bullets[i] = MonoBehaviour.Instantiate(bullet, Vector3.zero, Quaternion.identity);
            bullets[i].SetActive(false);
        }
        iterator = 0;
        
    }
    

    public static BulletPoolManager getInstance
    {
        get
        {
            if (instance == null)
                instance = new BulletPoolManager();
            return instance;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet()
    {

        iterator++;
        if (iterator > 50)
            iterator = 1;

        bullets[iterator - 1].SetActive(true);
        return bullets[iterator - 1];
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
