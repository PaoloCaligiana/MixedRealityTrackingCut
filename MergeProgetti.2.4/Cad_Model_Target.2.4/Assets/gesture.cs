using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gesture : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void taglio()
    {
        print("chiudo->taglio");
        GameObject Blade = GameObject.Find("blade");
        ExampleUseof_MeshCut script = Blade.GetComponent<ExampleUseof_MeshCut>();
        script.taglia = true;
       

    }
}
