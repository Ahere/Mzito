using UnityEngine;
using System.Collections;

public class CloudSpawnerScript : MonoBehaviour {

    [SerializeField]

    private GameObject[] clouds; // or clouds

    [SerializeField]

    private GameObject[] cloudsInGame;	
	
	public float distanceBetweenClouds = 3.0f; // distancate between y position of the cluds
	
	public  float minX, maxX; // min and max x for clouds

	private PlayerScript playerScript;  // player script
	
	private float lastCloudPositionY; 




  void Awake()
    {

    	Vector2 g = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        maxX = g.x - 0.8f;
        minX = -g.x + 0.8f;

        float center = Screen.width / Screen.height; // center of the sceen)
     
      CreateClouds (center);

     }


    void Start()
    {
 
         playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
         
         cloudsInGame = GameObject.FindGameObjectsWithTag("Clouds");

         Vector3 temp = new Vector3(cloudsInGame[0].transform.position.x, cloudsInGame[0].transform.position.y + 0.6f , cloudsInGame[0].transform.position.z);
         
         playerScript.transform.position = temp;
   
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
						
						
						
						
					} // if clouds is not activate
					
				} // loop through clouds
				
			} // if target transform position == lastCloudPosition
			
		} // if target tag == deadly or cloud	
		
	} // On Trigger enter 2D






  void Update()
   {



   }
   

  void  CreateClouds(float positionY)

  {

  	Shuffle (clouds);

  	for (int i = 0; i< clouds.Length; i++)
  	{
  		clouds[i] = Instantiate(clouds[i] , Vector3.zero , Quaternion.identity) as GameObject;

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