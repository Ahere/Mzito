using UnityEngine;
using System.Collections;

public  class CloudSpawnerScript : MonoBehaviour {

    [SerializeField]

    private GameObject[] clouds; // or clouds

    public  GameObject[] cloudsInGame;	
	
	public float distanceBetweenClouds = 1; // distancate between y position of the cluds
	
	public static  float minX, maxX; // min and max x for clouds

	public PlayerScript playerScript;  // player script
	
	private float lastCloudPositionY; 

	//public CloudScript cloudScript;

    [SerializeField]
	private GameObject [] collectables;




  void Awake()
    {

    	Vector2 g = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        maxX = g.x - 0.5f;
        minX = -g.x + 0.5f;

        float center = Screen.width / Screen.height; // center of the sceen)
     
      CreateClouds (center);


  	for (int i = 0; i< collectables.Length; i++)
  	{
  		collectables[i] = Instantiate(collectables[i]) as GameObject;
        collectables[i].SetActive(false);

    }


         playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
         
         cloudsInGame = GameObject.FindGameObjectsWithTag("Clouds");

         Vector3 temp = new Vector3(cloudsInGame[0].transform.position.x, cloudsInGame[0].transform.position.y + 0.5f , cloudsInGame[0].transform.position.z);
      
         playerScript.transform.position = temp;

               // Check if the plartform are blue 
   
    }

    void OnTriggerEnter2D(Collider2D target) 


    {
		
		if (target.tag == "Deadly" || target.tag == "Clouds")
		 {
			
			if(target.transform.position.y == lastCloudPositionY)
			 {
				
				Vector3 temp = target.transform.position;
				Shuffle(clouds);
				
				
				
				for(int i = 0; i < clouds.Length; i++)
				 {
					
					if(!clouds[i].activeInHierarchy) 
					{

						
						temp.x = Random.Range(minX, maxX);
						temp.y -= distanceBetweenClouds;
						
						lastCloudPositionY = temp.y;
						
						
						clouds[i].transform.position = temp;
						clouds[i].SetActive(true);
						
						int random = Random.Range(0, collectables.Length);
						
						if(clouds[i].tag != "Deadly") 
						{
							
							if(!collectables[random].activeInHierarchy)
							 {

								  if(collectables[random].tag == "Life") 
								  {

									if(PlayerScript.lifeCount < 2) 
									{ 
									  collectables[random].SetActive(true);
									  collectables[random].transform.position = new Vector3(clouds[i].transform.position.x - 0.2f,
										                                                        clouds[i].transform.position.y + 0.4f,
										                                                        clouds[i].transform.position.z);
									}

								  } // if tag == life


								 if (collectables[random].tag == "Door")
								    {

								    if(PlayerScript.scoreCount > 2000) 
								    {
                                     collectables[random].SetActive(true);
                                     collectables[random].transform.position = new Vector3(clouds[i].transform.position.x - 0.2f,
                                     	                                                   clouds[i].transform.position.y + 0.6f,
									                                                       clouds[i].transform.position.z);
                                    }


								    }

								    else 
								   {
                                   
									collectables[random].SetActive(true);
									collectables[random].transform.position = new Vector3(clouds[i].transform.position.x - 0.2f,
									                                                      clouds[i].transform.position.y + 0.4f,
									                                                      clouds[i].transform.position.z);
								   } 
								    

						       

						    }// if not actie in Heirachy

						} // if not Deadly
						
					} // if clouds is not activate
					
				} // loop through clouds
				
			} // if target transform position == lastCloudPosition
			
		} // if target tag == deadly or cloud	
		
	} // On Trigger enter 2D






  void Update()
   {
     playerScript.checkPlatforms();
   

   }
   

  void  CreateClouds(float positionY)

  {

  	Shuffle (clouds);

  	for (int i = 0; i< clouds.Length; i++)
  	{
  		clouds[i] = Instantiate(clouds[i] , Vector3.zero , Quaternion.identity) as GameObject;
  		//clouds[i].AddComponent<CloudScript>();
  		if (clouds[i].name == "Cloud1(Clone)")
  		{
  		clouds[i].name = "plat1";
        }

        if(clouds[i].name == "Cloud2(Clone)" )
        {
        	clouds[i].name = "plat2";
        }

        Vector3 temp = clouds[i].transform.position;

        temp.x = Random.Range(minX, maxX);;
        temp.y = positionY;

        lastCloudPositionY = temp.y;

        clouds[i].transform.position = temp;

        positionY -= distanceBetweenClouds;


  	}

   


  }

  void Shuffle(GameObject[] array) 
    {
		
		// loop through the array and shuffle it
		for(int i = 0; i < array.Length; i++)
		 {
			
			GameObject temp = array[i]; 
			int random = Random.Range(i, array.Length);
			array[i] = array[random];
			array[random] = temp;
			
		}



   	}




   


}