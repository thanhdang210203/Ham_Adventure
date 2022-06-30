using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingPoint : MonoBehaviour
{
    public int scoretoPass;
    private Score scoreManager;
    public GameObject spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        if (scoretoPass <= scoreManager.ScoreNum)
        {
            spawner.SetActive(false);
            Debug.Log("spawn deactivate");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoretoPass <= scoreManager.ScoreNum)
        {
            spawner.SetActive(false);
            Debug.Log("spawn deactivate");
        }
    }
}
