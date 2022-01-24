using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhoulController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    float horizontal;
    float vertical;
    float startingTime = 14f;
    float currentTime = 0f;

    public float speed;

    public int score = 0;
    public int maxScore = 5;

    public Text scoreText;
    public Text timerText;
    public Text winText;
    public Text loseText;

    public AudioClip winMusic;
    public AudioClip loseMusic;

    public float delay = 2;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        loseText.text = "";
        winText.text = "";
        currentTime = startingTime;
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        scoreText.text = "Souls: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("0");

        if(currentTime <= 2 && score == 5)
        {
            winText.text = "You Win! Game Created By: Mia Torres";
            AudioSource.PlayClipAtPoint(winMusic, transform.position, 1f);
            Destroy(winText, 2);
            Destroy(gameObject);
        }

        if(currentTime <= 2 && score < 5)
        {
            loseText.text = "You Lose! Game Created By: Mia Torres";
            AudioSource.PlayClipAtPoint(loseMusic, transform.position, 1f);
            Destroy(loseText, 2);
            Destroy(gameObject);
        }

        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 3.0f * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeScore(int amount)
    {
        score += 1;
        scoreText.text = "Souls: " + score.ToString();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
