using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacaoRodas : MonoBehaviour
{
    public WheelCollider collider_roda;
    public Vector3 pos;
    public Quaternion rot;

    public bool f;
    
    
    // Start is called before the first frame update
    void Start()
    {
         
         if(f){
           collider_roda = GetComponentInChildren<WheelCollider>();
         }
         else{
            collider_roda = GetComponent<WheelCollider>();
         }

    }

    // Update is called once per frame
    void Update()
    
    {
        
        collider_roda.GetWorldPose(out pos,out rot);
        transform.rotation = rot;
    }
}
