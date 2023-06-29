using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadordePilotoInimigo : MonoBehaviour
{
    public GameObject [] pilotos;
    public Transform localdeSpaw;
    private int rand;
    private int rand_n;
    private string nome;
    //public GameObject e
    // Start is called before the first frame update
    void Start()
    {
        rand_n=Random.Range(0,pilotos.Length);
        GameObject temp = Instantiate(pilotos[rand_n], localdeSpaw) as GameObject;
        temp.transform.SetParent(gameObject.transform);
        rand = Random.Range(1,26);
       switch (rand) {
        case 1:nome = "Andrew";break;
        case 2:nome = "Anthony";break;
        case 3:nome = "Benjamin";break;
        case 4:nome = "Brandon";break;
        case 5:nome = "Brian";break;
        case 6:nome = "Bruce";break;
        case 7:nome = "Charles";break;
        case 8:nome = "Christopher";break;
        case 9:nome = "Colin";break;
        case 10:nome = "David";break;
        case 11:nome = "Dener";break;
        case 12:nome = "Dickson";break;
        case 13:nome = "Edward";break;
        case 14:nome = "Franklin";break;
        case 15:nome = "George";break;
        case 16:nome = "Henry";break;
        case 17:nome = "Jacob";break;
        case 18:nome = "Kalel";break;
        case 19:nome = "Larry";break;
        case 20:nome = "Nicholas";break;
        case 21:nome = "Patrick";break;
        case 22:nome = "Ronald";break;
        case 23:nome = "Steven";break;
        case 24:nome = "Thomas";break;
        case 25:nome = "William";break;
        case 26:nome = "Oliver";break;
        
        default :
            nome = "erro";
            break;
       }

        GetComponent<carroAI>().nome=nome;
        GetComponent<carroAI>().numero_player=rand_n;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
