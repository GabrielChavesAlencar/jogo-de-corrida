using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inicio : MonoBehaviour
{
    public GameObject [] pista;
    
    private void Awake() {
        pista[menu.n_pista].SetActive(true);
    }
}
