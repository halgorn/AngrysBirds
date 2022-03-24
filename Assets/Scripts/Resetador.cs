using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetador : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D alvo;

    SpringJoint2D mola;

    public float velocidadeParada = 0.025f;
    float velocidadeParadaQuadrada;
    
    void Awake(){
        mola = alvo.GetComponent<SpringJoint2D>();
    }
    void Start()
    {
       velocidadeParadaQuadrada = velocidadeParada * velocidadeParada;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            Resetar();
        }

        if(alvo.velocity.sqrMagnitude < velocidadeParadaQuadrada && mola == null){
            Resetar();
        }
    }

    void Resetar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.GetComponent<Rigidbody2D>() == alvo){
            Resetar();
        }
    }
}
