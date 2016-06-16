using UnityEngine;
using System.Collections;

// Activate head tracking using the gyroscope
public class PlayerGyroScope : MonoBehaviour {
    public GameObject player; // First Person Controller parent node
  //  public GameObject head; // First Person Controller camera

    // The initials orientation
   // private float initialOrientationX;
   [SerializeField]
    private Animator animator;
  
   // private int initialOrientationY;
   // private int initialOrientationZ;

    // Use this for initialization
    void Awake () 
    {
    	animator = GetComponent<Animator> ();

    }

    // Update is called once per frame
    void Update ()
    { 
     

    }






}
