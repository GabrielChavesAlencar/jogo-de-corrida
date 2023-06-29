using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HUD_carro : MonoBehaviour
{
    public carros carro;

    public RectTransform agulhaRPM;
    public Text veloKMH;
    public Vector3 rotAgulha;
    public Text volta;
    public Text fim_jogo;
    public Text posicao_text;
    public int n_voltas;
    public int money;
    public float nova_rotacao;
    public carros [] lista_carros;
    public Text valor_texto;
    public Text [] tex_nomes;


    public GameObject [] obj_UI_pos;
    public GameObject [] obj_UI_nomes;
    public GameObject [] obj_UI_Imagens;
    
    public GameObject menu_pausa_UI;
    public GameObject menu_pausa_UI_fim;

    //controle das imagens
    public Image [] images_player;
    public Sprite [] sprites_ape;


    
    private bool pausa;
    private bool contagem_dinheiro;
 

    private void Start() {
        contagem_dinheiro= false;
        Time.timeScale =1;
        pausa = false;
        carro = transform.parent.GetComponent<carros>();
        lista_carros = FindObjectsOfType<carros>();
        n_voltas=menu.n_lap;

        for(int i = 0; i < lista_carros.Length; i++) {
           obj_UI_pos[i].SetActive(true);
           obj_UI_nomes[i].SetActive(true);
           obj_UI_Imagens[i].SetActive(true);
        }



    }
    void Update(){

        posicao_text.text = carro.posicao + "TH";

        //lap
        volta.text = "LAP"+"\n"+carro.voltas+"/"+n_voltas;
        
        if(carro.voltas>=n_voltas){
           if(!contagem_dinheiro){contabilizar_money();}
            if(carro.posicao==1){ fim_jogo.text = "YOU WIN"; }
            else
            {
                fim_jogo.text = "YOU LOSE";
            }
           
            Time.timeScale = 0;
        }
        for(int numero_do_car = 0; numero_do_car < lista_carros.Length; numero_do_car++) {
            for(int pos = 0; pos < lista_carros.Length; pos++) {
                if(lista_carros[numero_do_car].posicao==pos+1){
                    //tex_pos[pos].text = lista_carros[numero_do_car].posicao+1+" th";
                    tex_nomes[pos].text  = lista_carros[numero_do_car].nome;
                    images_player[pos].sprite = sprites_ape[lista_carros[numero_do_car].numero_player];
                }
            }
        }
    }
    public void contabilizar_money(){
        int valor = 0;
        int valorfi = 0;
        valor = n_voltas*lista_carros.Length*10*(menu.n_dificuldade+1);
        menu_pausa_UI_fim.SetActive(true);
        money = bancodedados.carregarint("money");
        bancodedados.salvarint("money",valor+money);
        valorfi = bancodedados.carregarint("money");
        valor_texto.text = money+"\n"+valor+"\n"+"______"+"\n"+valorfi;
        contagem_dinheiro=true;

    }
    public void pausar() {
        pausa = !pausa;
        menu_pausa_UI.SetActive(pausa);
        if(pausa){Time.timeScale =0;}
        else{Time.timeScale =1;}
        
    }
    public void menu_pausa() {
        Time.timeScale =1;
        SceneManager.LoadScene("menu");
        
    }

    private void FixedUpdate() {
        veloKMH.text =  string.Format("{0:0}",carro.veloKMH)+" KM/H";
        rotAgulha = agulhaRPM.rotation.eulerAngles;

        nova_rotacao = Mathf.Lerp(nova_rotacao, carro.rpm, 0.3f);
        rotAgulha.z = ((nova_rotacao * 180f) / carro.maxRPM)*-1;

        agulhaRPM.eulerAngles = rotAgulha;
        
    }


}
