using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carroAI : carros
{
   public float curvar;
   public float temporizador;
   public float temporizador_re;
   public Vector3 dir;
   public bool dar_re;
   
   public int cor_carro;
   public Material[] materiais;

   public MeshRenderer [] render;
   private void Start() {
      incializar();
      //GetComponent<MeshRenderer>().material = materiais[cor_carro];
      cor_carro = Random.Range(0,5);
      
      for(int i = 0; i < render.Length; i++) {
         render[i].material = materiais[cor_carro];
      }

   }

    void Update()
    {
        
        descapotar();
        verificador_posicao();
       
    }
   
   private void FixedUpdate() {

      //dar ré
      if(veloKMH < 5){temporizador+= Time.deltaTime;}
      else{
         temporizador=0;
      }
      if(temporizador > 3){
         dar_re = true;
      }
      
      if(dar_re){andar(-1);temporizador_re+= Time.deltaTime;virar(-angulo_giro);}
      else{andar(acelerar);virar(angulo_giro);}
      
      if(temporizador_re > 2){temporizador_re=0;dar_re=false;}


      //mudar velocidade
      if(lista_waipoints[atual].velocidade_recomendada > veloKMH){
         if(menu.n_dificuldade==0){acelerar = 0.4f;}
         if(menu.n_dificuldade==1){acelerar = 0.5f;}
         if(menu.n_dificuldade==2){acelerar = 0.6f;}
         if(menu.n_dificuldade==3){acelerar = 0.7f;}
         if(menu.n_dificuldade==4){acelerar = 1f;}
         
      }
      else{
         if(menu.n_dificuldade==0){acelerar = -0.4f;}
         if(menu.n_dificuldade==1){acelerar = -0.5f;}
         if(menu.n_dificuldade==2){acelerar = -0.6f;}
         if(menu.n_dificuldade==3){acelerar = -0.7f;}
         if(menu.n_dificuldade==4){acelerar = -1f;}
      }

      //direcao
      dir = transform.InverseTransformPoint(new Vector3(
         lista_waipoints[atual].transform.position.x,
         transform.position.y,
         lista_waipoints[atual].transform.position.z));

      curvar = Mathf.Clamp((dir.x / dir.magnitude) * 10f,-1f,1f);

      angulo_giro = curvar;
      contway();  
   }
}
