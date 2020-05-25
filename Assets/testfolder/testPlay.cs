using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AniPlayable;
public class testPlay : MonoBehaviour
{
    public PlayableAnimator animator; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI() {
        if(GUI.Button(new Rect(0,100,100f,30),"add testtrigger"))
        {
            animator.SetBool("testtrigger",true);
        }
        if(GUI.Button(new Rect(0,0,100f,30f),"add test"))
        {
            animator.SetInt("test",2);
        }

        if(GUI.Button(new Rect(0,50,100f,30),"add testbool"))
        {
             animator.SetBool("testbool",true);
        }

        
    }
}
