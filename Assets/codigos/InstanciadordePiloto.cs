using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadordePiloto : MonoBehaviour
{
    public GameObject [] pilotos;
    public Transform localdeSpaw;
    //public GameObject e
    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = Instantiate(pilotos[menu.n_player], localdeSpaw) as GameObject;
        temp.transform.SetParent(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
