using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour {

    public GameObject[] Cells; // Dynamic Cell Array for housing all in game cells

    //Bounds for starting location
    int maxY = 12;
    int minY = -11;
    int fixedX = -25;

    public float timer = 0;

    //currently Slected Prefab? (Karim if this is wrong, change it)
	int prefabSelect;

	int objInitNum; //number of objects instanciated

    //Array of positions used for random placement without collison 
	int [] posUsed;


	void Start()
	{	
		prefabSelect = objInitNum = 0;
		posUsed = new int[5];

        //Cleans the posUsed list
		resetPosUsed ();
	}

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        prefabSelect = Random.Range(0, 6);
        if (timer > 10.0 && timer < 20.0)
        {
            //Add something fancy
        }
		else if (timer % 2 > 0 && timer % 2 < .1)
        {
            Vector2 position = new Vector2(fixedX, Random.Range(minY, maxY));

			//loop through all five possible object places, and if the position desired
			//matches an already used position, try a new position, and check them all again
			for (int i = 0; i < 5; i++)
				if (position.y == posUsed [i]) 
				{
                    if (position.y < maxY / 2)
                    {
                        position.y = Random.Range(minY, maxY / 2);
                    }
                    else
                    {
                        position.y = Random.Range(maxY / 2, maxY);
                    }
                    //position.y++; //this can change to a random number, I just didn't want it to guess too often
                    if (position.y == maxY)
                    {
                        position.y = minY;
                    }
					i = 0;
				}
			Instantiate(Cells[prefabSelect], position, Quaternion.identity);
			posUsed [objInitNum] = (int) position.y;

			objInitNum++;

			if (objInitNum == 5) 
			{
				objInitNum = 0;
				resetPosUsed ();
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
