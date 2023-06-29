using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class bancodedados 
{
     public static void salvarint(string texto,int valor) 
    {
        PlayerPrefs.SetInt(texto,valor);
    }
    public static int carregarint(string texto)
    {
        int salvo = PlayerPrefs.GetInt(texto,0);
        return salvo;
    }
}
