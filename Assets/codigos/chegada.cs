using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chegada : MonoBehaviour
{
    public carros car;

    public Checkpoint [] checkpoints;
    private void Awake() {
        checkpoints = FindObjectsOfType<Checkpoint>();
    }

    private void OnTriggerEnter(Collider other) {
        car =  other.GetComponent<carros>();
        
        if(car.checkpoint_contagem >=checkpoints.Length){car.somarVolta();resetar_volta();}
        /*
        foreach(Checkpoint ch in checkpoints) {
            if(!ch.Passou_carro()){
                resetar_volta();
                return;
            }
        }
        */
        
       

    }


    public void resetar_volta(){
        car.checkpoint_contagem=0;
        foreach(Checkpoint cha in checkpoints) {
           //cha.carro = null;
        }
    }
}