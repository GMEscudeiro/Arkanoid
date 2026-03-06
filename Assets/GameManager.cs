using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int lives = 3;

    public GUISkin layout;
    private GUIStyle labelStyle;

    GameObject ball;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        if(ball){
            spriteRenderer = ball.GetComponent<SpriteRenderer>();
        }
    }

    public void die(){
        lives--;
        
        ball.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        if(lives <= 0){
            
            FindObjectOfType<SceneManagement>().badEnding();
            lives = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ball){
            Vector3 ballSize = spriteRenderer.bounds.size;
            Vector3 ballPos = ball.transform.position;

            if(ballPos.y + ballSize.y/2 <= -5){
                die();
            }
        }
    }
}
