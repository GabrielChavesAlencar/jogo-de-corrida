using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCreator : MonoBehaviour
{
    public GameObject waypoint;
    public GameObject way;
    public carros carro;

    public bool criar;
    private void Start() {
        carro = GetComponent<carros>();
    }

    IEnumerator colocar(){
        yield return new WaitForSeconds(0.6f);
        way = Instantiate(waypoint,  transform.position, Quaternion.identity);
        way.GetComponent<Waypoint>().velocidade_recomendada = carro.veloKMH;
        if(criar){
            StartCoroutine(colocar());
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.C)){
            criar= !criar;
            if(criar){
                StartCoroutine(colocar());
            }
        }
    }
}
