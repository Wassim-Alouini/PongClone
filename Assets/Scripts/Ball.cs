using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Text scorerightText;
    public Text scoreleftText;
    int scoreRight;
    int scoreLeft;

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    public float speed = 30;

    // Update is called once per frame
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed ;
    }
    void FixedUpdate()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
     


        if (col.gameObject.name == "RacketLeft")
        {
            GetComponent<ParticleSystem>().Play();

            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            Vector2 dir = new Vector2(1, y).normalized;
            
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "RacketRight")
        {
            GetComponent<ParticleSystem>().Play();

            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            Vector2 dir = new Vector2(-1, y).normalized;


            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "LeftBorder")
        {
            scoreLeft ++;
            scoreleftText.text = scoreLeft.ToString();
        }
        if (col.gameObject.name == "RightBorder")
        {
            scoreRight ++;
            scorerightText.text = scoreRight.ToString();
        }
        if (scoreLeft == 5)
        {
            SceneManager.LoadScene(0);
        }
        else if (scoreRight == 5)
        {
            SceneManager.LoadScene(0);
        }
    }
}
