using UnityEngine;
using System.Collections;

public class ExplosionDestroy : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Destroy(this.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    // Update is called once per frame
    void Update() {

    }


}
