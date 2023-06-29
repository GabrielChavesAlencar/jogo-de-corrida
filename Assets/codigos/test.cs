using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

   public int[] valores;
   public bool ordemCrescente;

   void Start () {
      OrdenarValores (valores, ordemCrescente);
   }

   void OrdenarValores(int[] vetor, bool ordemTempCrescente){
      for (int x = 0; x < vetor.Length; x++) {
         for (int i = 0; i < vetor.Length - 1; i++) {
            if (ordemTempCrescente) {
               if (vetor [i] > vetor [i + 1]) {
                  int aux = vetor [i];
                  vetor [i] = vetor [i + 1];
                  vetor [i + 1] = aux;
               }
            } else {
               if (vetor [i] < vetor [i + 1]) {
                  int aux = vetor [i];
                  vetor [i] = vetor [i + 1];
                  vetor [i + 1] = aux;
               }
            }
         }
      }
   }
}