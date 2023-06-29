using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banner : MonoBehaviour
{
   // public Material ban1;
   // public Material ban2;
    //public Renderer Renderizador;

    public Texture  ban1;
    public Texture ban2;
    public Material mat;
    public  float tempo_final;

    public float tempo;
    // Start is called before the first frame update
    void Start()
    {
        //Renderizador = GetComponent<Renderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        tempo+=Time.deltaTime;
        if(tempo> tempo_final &&   tempo<tempo_final+0.2f){
           // Renderizador.material = ban1;
           mat.mainTexture = ban1;
        }
        if(tempo>(tempo_final*2) &&   tempo<(tempo_final*2+0.2f)){
           // Renderizador.material = ban2;
           mat.mainTexture = ban2;
        }
        if(tempo >(tempo_final*2+0.2f)){
            tempo = 0;
        }
    }
}
