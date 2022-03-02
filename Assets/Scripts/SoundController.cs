using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController _instance;
    public AudioSource win, lose, getpos;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 0-win,1-lose,2-get
    /// </summary>
    /// <param name="value"></param>
    public void PlaySound(int value)
    {
        if (value == 0)
        {
            win.Play();
        }
        else if (value == 1)
        {
            lose.Play();
        }
        else if (value == 2)
        {
            getpos.Play();
        }
       
    }

}
