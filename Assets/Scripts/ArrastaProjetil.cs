using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrastaProjetil : MonoBehaviour
{
    bool clicou;
    public float esticadaMaxima = 3.0f;
    float esticadaMaximaQuadrada;
    SpringJoint2D  mola;
    Rigidbody2D meuRigidbody;
    Transform estilingue;
    Ray raioParaMouse;
    // Start is called before the first frame update
    void Start()
    {
        mola = GetComponent<SpringJoint2D>();
        estilingue = mola.connectedBody.transform;
        esticadaMaximaQuadrada = esticadaMaxima * esticadaMaxima;
        raioParaMouse = new Ray(estilingue.position, Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        if(clicou==true){
            Arrastar();
        }
    }

    private void OnMouseDown() {
        clicou= true;
    }
    private void OnMouseUp() {
        clicou = false;    
    }

    void Arrastar(){
        Vector3 positionMouseMundo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 estilingueParaMouse = positionMouseMundo - estilingue.position;
        

        if(estilingueParaMouse.sqrMagnitude > esticadaMaxima){
            raioParaMouse.direction = estilingueParaMouse;
            positionMouseMundo = raioParaMouse.GetPoint(esticadaMaxima);
        }
        positionMouseMundo.z = 0; 
        transform.position = positionMouseMundo;
    }
}
