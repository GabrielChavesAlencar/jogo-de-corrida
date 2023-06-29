using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public static int n_car;
    public static int n_lap;
    public static int n_pista;
    public static int n_player;
    public static int n_dificuldade;

    

    public Text n_car_text;
    public Text n_lap_text;
    public Text dificuldade_text;

    public Image image_pista;
    public Sprite sprite_1;
    public Sprite sprite_2;


    public static int carro_player;
    public Text nome_carro;

    public Image image_carro;
    public Sprite car1;
    public Sprite car2;
    public Sprite car3;
    public Sprite car4;


    public GameObject menu1;
    public GameObject menu2;
    public GameObject menu3;

    public GameObject botao_selecionar;
    public GameObject botao_comprar;
    public Text valor_car_text;
    public Text money_text;
    
    // Start is called before the first frame update
    void Start()
    {
        bancodedados.salvarint("car"+0,1);
        

        n_car = 2;
        n_lap = 2;
        n_pista =0;
        carro_player = 0;
        nome_carro.text="CAR";

    /*
        200
        750
        2500
    */

    }

    // Update is called once per frame
    void Update()
    {
        if(bancodedados.carregarint("car"+carro_player)>0){  }
        n_car_text.text = n_car+"";
        n_lap_text.text = n_lap+"";
        money_text.text = "$"+ bancodedados.carregarint("money");
        if(n_dificuldade==0){dificuldade_text.text = "VERY" +"\n"+ "EASY";}
        if(n_dificuldade==1){dificuldade_text.text = "EASY";}
        if(n_dificuldade==2){dificuldade_text.text = "NORMAL";}
        if(n_dificuldade==3){dificuldade_text.text = "HARD";}
        if(n_dificuldade==4){dificuldade_text.text = "VERY" +"\n"+ "HARD";}
        if(carro_player==0){valor_car_text.text = "";botao_selecionar.SetActive(true);botao_comprar.SetActive(false);}
        if(carro_player==1){
            if(bancodedados.carregarint("car1")==1){botao_selecionar.SetActive(true);botao_comprar.SetActive(false);valor_car_text.text = "";}
            else{botao_selecionar.SetActive(false);botao_comprar.SetActive(true);valor_car_text.text = "$200";}
        }
        if(carro_player==2){
            if(bancodedados.carregarint("car2")==1){botao_selecionar.SetActive(true);botao_comprar.SetActive(false);valor_car_text.text = "";}
            else{botao_selecionar.SetActive(false);botao_comprar.SetActive(true);valor_car_text.text = "$750";}
        }
        if(carro_player==3){
            if(bancodedados.carregarint("car3")==1){botao_selecionar.SetActive(true);botao_comprar.SetActive(false);valor_car_text.text = "";}
            else{botao_selecionar.SetActive(false);botao_comprar.SetActive(true);valor_car_text.text = "$2500";}
        }
        
        
    }
    public void comprar_car(){
        int n = carro_player;
        int valor = bancodedados.carregarint("money");
        if(n == 1){if(valor>200){bancodedados.salvarint("car"+n,1);bancodedados.salvarint("money",valor-200);}}
        if(n == 2){if(valor>750){bancodedados.salvarint("car"+n,1);bancodedados.salvarint("money",valor-750);}}
        if(n == 3){if(valor>2500){bancodedados.salvarint("car"+n,1);bancodedados.salvarint("money",valor-2500);}}
        
    }

    public void aumentar_dificuldade(){
        n_dificuldade++;
        if(n_dificuldade>4){
            n_dificuldade = 4;
        }
    }
    public void diminuir_dificuldade(){
        n_dificuldade--;
        if(n_dificuldade<0){
            n_dificuldade = 0;
        }
    }

    public void selecionar_player(int numero){
        n_player = numero;
        menu1.SetActive(true);
        menu3.SetActive(false);
    }
    public void voltar2(){
        menu1.SetActive(false);
        menu3.SetActive(true);
    }

    public void mudar_imagem(){
        if(n_pista == 0){image_pista.sprite= sprite_1;}
        if(n_pista == 1){image_pista.sprite= sprite_2;}
    }
    public void mudar_imagem_carro(){
        if(carro_player == 0){image_carro.sprite= car1;nome_carro.text="KART";}
        if(carro_player == 1){image_carro.sprite= car2;nome_carro.text="POLICE CAR";}
        if(carro_player == 2){image_carro.sprite= car3;nome_carro.text="CLASSIC CAR";}
        if(carro_player == 3){image_carro.sprite= car4;nome_carro.text="SPORTING CAR";}
    }

    public void aumentar_n_player(){
        carro_player++;
        if(carro_player>3){carro_player=0;}
        mudar_imagem_carro();
    }
    public void diminuir_n_player(){
        carro_player--;
        if(carro_player<0){carro_player=3;}
       mudar_imagem_carro();
    }


    public void escolher_carro(){
        menu1.SetActive(false);
        menu2.SetActive(true);
    }
    public void volta1(){
        menu1.SetActive(true);
        menu2.SetActive(false);
    }
    public void aumentar_lap(){
        n_lap++;
        if(n_lap>10){n_lap=1;}
    }
    public void diminuir_lap(){
        n_lap--;
        if(n_lap<1){n_lap=10;}
    }
    public void aumentar_car(){
        n_car++;
        if(n_car>10){n_car=1;}
    }
    public void diminuir_car(){
        n_car--;
        if(n_car<1){n_car=10;}
    }
    public void aumentar_pista(){
        n_pista++;
        if(n_pista>1){n_pista=0;}
        mudar_imagem();
    }
    public void diminuir_pista(){
        n_pista--;
        if(n_pista<0){n_pista=1;}
        mudar_imagem();
    }
    public void iniciar(){
         SceneManager.LoadScene("cena1");
    }
}
