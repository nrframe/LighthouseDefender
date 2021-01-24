using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{

    [SerializeField]
    public GameObject enemyObject;

    private float time;

    private bool levelIsRunning = false;

    public static List<GameObject> currentEnemies = new List<GameObject>();

    private static float secondsRemaining; 

    private int enemyDistanceRange = 50;

    // Update is called once per frame
    void Update()
    {
        if (!UIManager.pauseGame)
        {
            if (time > 0)
                time -= Time.deltaTime;

            else
            {
                levelIsRunning = false;
                UIManager.pauseGame = true;
            }
            secondsRemaining = Mathf.FloorToInt(time % 60);

            MoveEnemiesCloser();
        }

        else
            levelIsRunning = false;
    }

    public void SpawnEnemies(int level)
    {
        
        levelIsRunning = true;
        float seconds;
        Vector3 location;

        int randomX;
        int randomY;
        int randomZ;

        while(levelIsRunning)
        {
            //seconds inbetween spawns
            seconds = Random.Range(.01f, ((15- level)*.25f));
            
            randomX = Random.Range(enemyDistanceRange, enemyDistanceRange += enemyDistanceRange / 2);
            if (randomX % 2 == 0)
                randomX = -randomX;

            randomY = Random.Range(enemyDistanceRange, enemyDistanceRange += enemyDistanceRange / 2);
            if (randomY % 2 == 0)
                randomY = -randomY;

            randomZ = Random.Range(enemyDistanceRange, enemyDistanceRange += enemyDistanceRange / 2);
            if (randomZ % 2 == 0)
                randomZ = -randomZ;
                randomZ = -randomZ;
            location = new Vector3(randomX, randomY, randomZ);

            StartCoroutine(Wait(seconds));

            currentEnemies.Add(Instantiate(enemyObject, location, Quaternion.identity));

        }
    }

    private void OnMouseDown()
    {
        //comboLevel++;
        currentEnemies.Remove(gameObject);
        Destroy(gameObject);

        //GameManager.essence += (comboLevel / 2);

    }

    public void MoveEnemiesCloser()
    {
        foreach (GameObject enemy in currentEnemies)
        {
            transform.LookAt(TrackingManager.lightouseLocation);

            if (Vector3.Distance(transform.position, TrackingManager.lightouseLocation) >= 5)
            {

                transform.position += transform.forward * 4 * Time.deltaTime;

            }
        }
    }
    public IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}

