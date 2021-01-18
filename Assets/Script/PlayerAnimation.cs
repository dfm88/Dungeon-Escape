using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator _anim;
    

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>(); //in children perchè l'animazione è nello Sprite che è figlio di Player
    }

   public void moveAnimation(float move)
    {
        //rendo il float in valore assoluto perchè il Float dell'animation riconosce solo il comando "Greater than" 
        //per il movimento, mentre per lo stato Idle riconosce solo Les than (0,1). Quando ci muoviamo a sx
        //avremmo un valore negativo, allora lo prendo in valore assoluto
        move = Mathf.Abs(move);
        _anim.SetFloat("Move", move);
    }

    public void jumpAnimation(bool isGrounded)
    {

        _anim.SetBool("Jumping", !(isGrounded));
        
    }

    


}
