using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedAstronaut : MonoBehaviour
{
    private Transform player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Mathf.Abs(player.position.x - transform.position.x) < 1f)
        {
            anim.SetTrigger("Saved");
        }
    }
}
