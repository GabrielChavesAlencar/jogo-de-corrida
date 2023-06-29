using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject carro;

    private void OnTriggerEnter(Collider other) {
        
        if(other.GetComponent<carros>()){
            carro = other.gameObject;
            other.GetComponent<carros>().checkpoint_contagem++;
        }
    }
    public bool Passou_carro(){
        if(carro != null){
            return true;
        }
        else{
            return false;
        }
    }
}
