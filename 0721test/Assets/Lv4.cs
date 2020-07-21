
using UnityEngine;

public class Lv4 : MonoBehaviour
{


    public float speed =0.005f ;
    
    void Start()
    {
        
    }
    

    void Update()
    {
        transform.Translate(Vector3.forward * speed);
    }
}
