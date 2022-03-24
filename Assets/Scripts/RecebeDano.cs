using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecebeDano : MonoBehaviour
{
    
    public float pontosDeVida;
    public Sprite imagemMachucada;
    public float velocidadeParaDano = 5;

    private float pontosDeVidaAtuais;
    private float velocidadeParaDanoQuadrado;
    private SpriteRenderer sRenderer;
    // Start is called before the first frame update
    void Start()
    {
        pontosDeVidaAtuais = pontosDeVida;
        velocidadeParaDanoQuadrado = velocidadeParaDano * velocidadeParaDano;
        sRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D colisao) 
    {
        if(!colisao.gameObject.CompareTag("Arma")){
            return;
        }
        if(colisao.relativeVelocity.sqrMagnitude < velocidadeParaDanoQuadrado){
            return;
        }
        sRenderer.sprite = imagemMachucada;
        pontosDeVida --;

        if(pontosDeVidaAtuais <=0){
            Matar();
        }
    }

    void Matar(){
        sRenderer.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
