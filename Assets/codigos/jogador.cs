using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogador : carros
{
    public float temporizador;
    void Start()
    {
        
        incializar();
       // Time.timeScale = 10;
       nome = "YOU";
       numero_player = menu.n_player;
        
    }

    void Update()
    {
        angulo_giro = Input.GetAxis("Horizontal");
        acelerar = Input.GetAxis("Vertical");
        descapotar();
        verificador_posicao();
        
        contway();
        if(veloKMH < 5){temporizador+= Time.deltaTime;}
        else{
            temporizador=0;
        }
        if(temporizador>10){
            voltar_a_pista();
            temporizador=0;
        }
     


    }
    void FixedUpdate()
    {
        virar(angulo_giro);
        andar(acelerar);
    }
  

}

