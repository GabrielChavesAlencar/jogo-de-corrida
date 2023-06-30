using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pista : MonoBehaviour
{
    public int qt_carros;
    public int carro_player;
    public GameObject [] carros;
    public GameObject [] carros_jogador;
    public Transform [] posicoes;

    public int rand_car;
    public cameradojogo came;
    public GameObject player;
    public GameObject obj_camera;
    public HUD_carro hud;

    private void Awake() {
        qt_carros = menu.n_car;
        carro_player = menu.carro_player;
        //qt_carros = 2;
        if(menu.n_dificuldade == 0){rand_car = 0;}
        if(menu.n_dificuldade == 1){rand_car = Random.Range(0,2);}
        if(menu.n_dificuldade == 2){rand_car = Random.Range(0,carros.Length);}
        if(menu.n_dificuldade == 3){rand_car = Random.Range(2,3);}
        if(menu.n_dificuldade == 4){rand_car = 3;}
        
        for(int i = 0; i < qt_carros-1 ; i++) {
            Instantiate(carros[rand_car],posicoes[i].position,posicoes[i].rotation);
        }
        player = Instantiate(carros_jogador[carro_player],posicoes[qt_carros-1].position,posicoes[qt_carros-1].rotation);
        //came.alvo = player.transform.GetChild(0);
        hud.carro = player.GetComponent<carros>();
        obj_camera.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
