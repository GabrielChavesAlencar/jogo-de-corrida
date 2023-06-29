using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carros : MonoBehaviour
{
    public string nome;
    public int numero_player;
    public WheelCollider [] rodas_frente;
    public AnimationCurve curva_roda;
    public Rigidbody rig;
    public int voltas;
    public float acelerar;
    public float forca;
    public float angulo_giro;
    public float veloKMH;
    public float rpm;
    public float maxRPM;
    public float minRPM;
    public float maxTorque;
    public float forca_freio;
    public Vector3 forcafinal;
    public float  instabilidadeTravar;

    public int checkpoint_contagem;



    public float [] cambio;
    public int marcha_atual;

    public float somPitch;

    public Transform centro_massa;

    public AudioClip [] somCarro;
    public AudioSource audioDerrapar;
    public AudioSource audioCarro;



    //outros
    public Waypoint [] lista_waipoints;
    public Transform [] lista_transform_waiponts;
    public GameObject parent_waiponts;
    public int atual;

    public int posicao;
    public carros [] lista_carros;
    public int [] pos_carros;
    public int [] volta_carros;
    public int pos_temp;
    public int volta_temp;
    public int pos_volta_temp;


    //rodas
    public Vector3 pos;
    public Quaternion rot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void somarVolta(){
        voltas ++;
    }
    public void descapotar(){
        if(transform.eulerAngles.z>40||transform.eulerAngles.z<-40){transform.localRotation = Quaternion.Euler( transform.eulerAngles.x,  transform.eulerAngles.y, 0);}
        
    }
    public void incializar(){
        rig = GetComponent<Rigidbody>();
        parent_waiponts = GameObject.Find("wayp3");
        lista_waipoints = parent_waiponts.GetComponentsInChildren<Waypoint>();
        lista_transform_waiponts = parent_waiponts.GetComponentsInChildren<Transform>();
        
        //audioCarro = GetComponent<AudioSource>();
        rig.centerOfMass = centro_massa.localPosition;
        if(audioCarro!=null){audioCarro.clip = somCarro[0];}
        lista_carros = FindObjectsOfType<carros>();


        
    }

    public void voltar_a_pista(){
        if(transform.position.y<-30){
            transform.position = lista_waipoints[atual].transform.position;
        }
    }
    public void derrapar(){
        
        if(veloKMH > 40f){
            float angulo = Vector3.Angle(transform.forward, rig.velocity);
            float valorfinal = (angulo / 10f) - 0.3f;
            if(audioDerrapar!=null){audioDerrapar.volume = Mathf.Clamp(valorfinal,0f,1f);}
        }
        
        if(audioDerrapar!=null){if(veloKMH<=20){audioDerrapar.volume =0;}}
    }

    public void virar(float valor){
        for(int i = 0; i < rodas_frente.Length; i++) {
                rodas_frente[i].steerAngle = valor * curva_roda.Evaluate(veloKMH);
                rodas_frente[i].motorTorque = 1f;

        }
    }

    public void verificador_posicao(){
       // atual
            //contador de posicao global
        pos_temp=0;
        volta_temp = 0;
        int posicao_temp = lista_carros.Length;
        for(int i = 0; i <lista_carros.Length; i++) {

            if(atual>lista_carros[i].atual){pos_temp++;}
            if(voltas>lista_carros[i].voltas){volta_temp++;}
        }
        pos_volta_temp = pos_temp + (volta_temp*1000);
        for(int i = 0; i <lista_carros.Length; i++) {
            if(pos_volta_temp>lista_carros[i].pos_volta_temp){
                posicao_temp--;
            }
        }
        posicao = posicao_temp;

             
        
    }

    public void contway(){
        if(lista_waipoints.Length !=0){
            if(Vector3.Distance(transform.position,lista_waipoints[atual].transform.position) < 40f){
                atual++;
                if(atual == lista_waipoints.Length){
                    atual = 0;
                }
            }
      }
    }

    public void andar(float valor){
        voltar_a_pista();
        if(valor < -0.5f){
            valor = 0;
            rig.AddForce(-transform.forward * forca_freio);
            rig.AddTorque((transform.up * instabilidadeTravar * veloKMH / 45f)*valor);
        }

        forcafinal = transform.forward * (maxTorque / (marcha_atual + 1) + maxTorque/1.35f)* valor;
        //rig.AddForce(transform.forward * 2000 * valor);
        rig.AddForce(forcafinal);


        veloKMH  = rig.velocity.magnitude *3.6f;
        rpm  = veloKMH * cambio[marcha_atual] * 15f;
        if(audioCarro!=null){audioCarro.pitch = rpm / somPitch;}
        
        derrapar();
        

        //marchas
        if(rpm > maxRPM){
            marcha_atual++;
            if(marcha_atual >= cambio.Length){
                marcha_atual--;
            }
            if(audioCarro!=null){
                audioCarro.Stop();
                audioCarro.clip = somCarro[marcha_atual];
                audioCarro.Play();
            }
        }
        if(rpm < minRPM){
            marcha_atual--;
            if(marcha_atual < 0){
                marcha_atual = 0;
            }
            if(audioCarro!=null){
                audioCarro.Stop();
                audioCarro.clip = somCarro[marcha_atual];
                audioCarro.Play();
            }
        }
        


    }
}
