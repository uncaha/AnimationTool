using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AniPlayable;
public class testPlay : MonoBehaviour
{
    public AniPlayable.InstanceAnimation.AnimationInstancing animator; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI() {
        if(GUI.Button(new Rect(0,100,100f,30),"add key1"))
        {
            animator.SetInt("ani1",2);
        }
        if(GUI.Button(new Rect(0,0,100f,30f),"add key2"))
        {
            animator.SetBool("ani2",true);
        }
        if(GUI.Button(new Rect(0,50,100f,30),"add key3"))
        {
             animator.SetFloat("ani3",3);
        }

        if(GUI.Button(new Rect(120,100,100f,30),"remove key1"))
        {
            animator.SetInt("ani1",0);
        }
        if(GUI.Button(new Rect(120,0,100f,30f),"remove key2"))
        {
            animator.SetBool("ani2",false);
        }
        if(GUI.Button(new Rect(120,50,100f,30),"remove key3"))
        {
             animator.SetFloat("ani3",0);
        }

    }
}
