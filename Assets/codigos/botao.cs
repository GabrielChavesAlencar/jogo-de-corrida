using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class botao : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public float input;
    public float sensibility = 3;
    public bool pressing;
    public carros jog;
    public string acao;
    public HUD_carro objcanvas;
    private void OnEnable()
    {
        jog =  objcanvas.carro;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pressing = true;
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressing = false;
        if (acao == "acelerar")
        {
            jog.andar(-10);
        }
        if (acao == "re")
        {
            jog.andar(10);
        }
        if (acao == "esquerda")
        {
            jog.angulo_giro = 0;
        }
        if (acao == "direita")
        {
            jog.angulo_giro = 0;
        }

    }

    private void Update()
    {
        if (pressing) {
            if (acao == "acelerar")
            {
                jog.andar(2);
            }
            if (acao == "re")
            {
                jog.andar(-2);
            }
            if (acao == "esquerda")
            {
                jog.angulo_giro = -1;
            }
            if (acao == "direita")
            {
                jog.angulo_giro = 1;
            }
        }
    }


}