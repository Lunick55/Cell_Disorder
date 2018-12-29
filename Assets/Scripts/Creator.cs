using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour {

    public GameObject[] FluWave; //Dyanmic Array for the Flu Wave
    public GameObject[] Cells; // Dynamic Cell Array for housing all in game cells
    public GameObject[] spawnLocations; // Dynamic Spawner array for spawn locations

    public float timer = 0;

    //currently Slected Prefab? (Karim if this is wrong, change it)
	int prefabSelect;

	int objInitNum; //number of objects instanciated

    //Current Spawner to use
    int spawner;

    //Array of positions used for random placement without collison 
	int [] posUsed;


	void Start()
	{
        prefabSelect = 0;
        objInitNum = 0;
		posUsed = new int[5];

        //Cleans the posUsed list
		resetPosUsed ();
	}

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        
		if ((timer > 60.0 && timer < 70.0) || (timer > 120.0 && timer < 130.0) || (timer > 180.0 && timer < 190.0))
        {
            prefabSelect = Random.Range(0, FluWave.Length);
            if ((timer % 2 > 0 && timer % 2 < .1))
            {
                spawner = Random.Range(0, spawnLocations.Length);

                //loop through all five possible object places, and if the position desired
                //matches an already used position, try a new position, and check them all again
                for (int i = 0; i < 5; i++)
                {
                    if (spawner == posUsed[i])
                    {
                        spawner++; //this can change to a random number, I just didn't want it to guess too often
                        if (spawner == 5)
                        {
                            spawner = 0;
                        }
                        i = -1;
                    }
                }

                Instantiate(FluWave[prefabSelect], spawnLocations[spawner].transform.position, Quaternion.identity);
                posUsed[objInitNum] = spawner;

                objInitNum++;

                if (objInitNum == 5)
                {
                    objInitNum = 0;
                    resetPosUsed();
                }
            }
           
        }
		else 
        {
            prefabSelect = Random.Range(0, Cells.Length);
            if (timer % 2 > 0 && timer % 2 < .1)
            {
                spawner = Random.Range(0, spawnLocations.Length);

                //loop through all five possible object places, and if the position desired
                //matches an already used position, try a new position, and check them all again
                for (int i = 0; i < 5; i++)
                {
                    if (spawner == posUsed[i])
                    {
                        spawner++; //this can change to a random number, I just didn't want it to guess too often
                        if (spawner == 5)
                        {
                            spawner = 0;
                        }
                        i = -1;
                    }
                }

                Instantiate(Cells[prefabSelect], spawnLocations[spawner].transform.position, Quaternion.identity);
                posUsed[objInitNum] = spawner;

                objInitNum++;

                if (objInitNum == 5)
                {
                    objInitNum = 0;
                    resetPosUsed();
                }
            }
		}
    }

    //Cleans the posUsed List
	void resetPosUsed()
	{
		for (int i = 0; i < 5; i++) 
		{
			posUsed [i] = 1000;//a number that no cell will ever occupy
		}	
	}
}
