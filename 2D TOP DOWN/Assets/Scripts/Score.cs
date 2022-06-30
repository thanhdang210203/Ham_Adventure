using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Score : MonoBehaviour
{
    public Text ScoreText;
    public int ScoreNum = 0;
    public GameObject spawner;
    public int scoreToPass;
    public GameObject levelPass;
    public Transform levelPassLo;
    //[SerializeField] private int addScore;
    // Start is called before the first frame update
    public void Start()
    {
        ScoreText.text = "Score: " + ScoreNum;
    }

    // Update is called once per frame
    public void Update()
    {
        ScoreText.text = "Score: " + ScoreNum;

        if(ScoreNum >= scoreToPass)
        {
            Destroy(spawner);
            Instantiate(levelPass, levelPassLo.position, Quaternion.identity);
        }
    }

    //public void AddScore(int addScore)
    //{
    //    ScoreNum += addScore;
    //    ScoreText.text = "Score: " + ScoreNum;
    //}
}