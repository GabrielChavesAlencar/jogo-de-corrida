using System.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameradojogo : MonoBehaviour
{
    public Transform alvo;
    public Vector3 distancia;
    public float speed;
    public Transform cameratranf;




    void Star()
    {
       //cameratranf= GetComponent<Transform>();

       
       
    }
     void Awake() {
       
    }
    private void OnEnable()
    {
        cameratranf = GetComponent<Transform>();
    }


    void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            alvo.position + distancia,
            speed*Time.deltaTime
            );


      

        transform.LookAt(alvo,cameratranf.up);

    }


}
