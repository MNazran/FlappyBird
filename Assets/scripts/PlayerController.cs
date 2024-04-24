using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rigibody;

    public bool StartGame = false;

    public float Score = 0;
    public TextMeshProUGUI ScoreUI;

    public GameManager _GameManager;

    public AudioSource _Hit;
    public AudioSource _Wing;
    public AudioSource _Point;

    // Start is called before the first frame update
    void Start()
    {
        _rigibody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Score")
        {
            Score = Score + 1;
            _Point.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor" || 
            collision.gameObject.name == "Pipe_Up" || 
            collision.gameObject.name == "Pipe_Down")
        {
            _GameManager.SetHighScore(Score);
            _GameManager.GameOver();
            _Hit.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUI.text = Score.ToString();
        
        if (!StartGame)
        {
            _rigibody.simulated = false;
        }
        else
        {
            _rigibody.simulated = true;
            if (Input.GetMouseButtonDown(0))
            {
                _rigibody.velocity = Vector2.up * speed;
                _Wing.Play();
            }
        }
    }

}
