    using UnityEngine;
     
    public class BGSpawner2 : MonoBehaviour {
        private Vector3 backPos;
        //public float width = 0f;
        public float height = 0f;
        //private float X;
         private float Y;

         private Vector2 newPos;
       
        void OnBecameInvisible()
        {
        	Debug.Log("Nanana");
            //calculate current position
            backPos = this.gameObject.transform.position;
            //calculate new position
            print (backPos);
           // X = backPos.x + width*2;
           //
            Y = backPos.y - height*2;
            newPos = new Vector3(0f, Y, 0f);
            //move to new position when invisible
           
            this.gameObject.transform.position = newPos;
            //new Vector3 (0f, Y, 0f);
            print(this.gameObject.transform.position);
        }
       
    }
