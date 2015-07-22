using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

    public void onStop()
    {
        Destroy(this.transform.gameObject);
    }
}