using UnityEngine;
using System.Collections;
using Leap.Unity.Interaction; //funzionalità di Leap Motion con interazione

public class ExampleUseof_MeshCut : MonoBehaviour {
    

	public Material capMaterial;
    public float bladeLength;
    public bool taglia = false;


	// Use this for initialization
	void Start () {
    }
    void Update(){

        if (taglia){
		//if(Input.GetMouseButtonDown(0)){//se premo il tasto sinistro del mouse (0)
           

            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);//ReycastAll restituisce un array di tutti gli hit colpiti dal raggio
            if (hits.Length>0  ){
                for (int i = 0; i < hits.Length; i++)
                {
                    RaycastHit hit = hits[i];
                    if (bladeLength>0 && hit.distance < bladeLength || bladeLength<=0 )//se ho settato la lunghezza del coltello,taglio solo gli oggetti 
                    {                                                                  //entro tale lunghezza,altrimenti tutti quelli che incontro.
                        GameObject victim = hit.collider.gameObject;
                        //GameObject[] pieces = 
                        BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

                        //funzionalità per utilizzare LeapMotion 
                        if (victim != null)
                        {
                            GameObject Scalpel = GameObject.Find("Scalpel");
                            Scalpel.transform.position = new Vector3(0.07f, -0.03f, 0.06f);
                            Scalpel.transform.rotation = Quaternion.Euler(-6, 21.8f, -92f);
                        }
                        Destroy(victim);
                        
                    }
                }
            }
		}
        taglia = false;
	}
    //nota: drawline prende in ingresso un vettore "from" e un vettore "to".
	void OnDrawGizmos() {

		Gizmos.color = Color.red;//colore del coltello.
        //disegno le linee del coltello:
        if (bladeLength <= 0)
        {
            //Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward * 500.0f);//prima riga
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * 500.0f);//seconda riga
            //Gizmos.DrawLine(transform.position + -transform.up * 0.5f, transform.position + -transform.up * 0.5f + transform.forward * 500.0f);//terza riga

            //Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);//prima verticale
            //Gizmos.DrawLine(transform.position, transform.position + -transform.up * 0.5f);//seconda verticale
        }
        else
        {
           // Gizmos.DrawLine(transform.position + transform.up * 0.5f, transform.position + transform.up * 0.5f + transform.forward * bladeLength);//prima riga
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * bladeLength);//seconda riga
            //Gizmos.DrawLine(transform.position + -transform.up * 0.5f, transform.position + -transform.up * 0.5f + transform.forward * bladeLength);//terza riga

            //Gizmos.DrawLine(transform.position, transform.position + transform.up * 0.5f);//prima verticale
            //Gizmos.DrawLine(transform.position, transform.position + -transform.up * 0.5f);//seconda verticale
        }
        
	}

}
