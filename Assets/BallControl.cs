using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    public KeyCode startKey = KeyCode.Space;
    public bool isStart = true;
    public float vel = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindWithTag("Player");
        var playerPosition = player.transform.position;
        var ballPos = transform.position;

        if(isStart) {

            ballPos.x = playerPosition.x + 0.2f;
            ballPos.y = playerPosition.y + 0.25f;

            transform.position = ballPos;

            if(Input.GetKey(startKey)){
                ballStart();
                isStart = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Brick"){
            FindObjectOfType<SceneManagement>().BrickDestroyed();
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.CompareTag("Player"))
        {
            float x = impactRadius(transform.position, 
                                          coll.transform.position, 
                                          coll.collider.bounds.size.x);

            Vector2 direcao = new Vector2(x, 1).normalized;

            GetComponent<Rigidbody2D>().linearVelocity = direcao * vel;
        }
    }

    float impactRadius(Vector2 posBola, Vector2 posRaquete, float larguraRaquete)
    {
        return (posBola.x - posRaquete.x) / larguraRaquete;
    }

    void ballStart(){
        rb2d.AddForce(new Vector2(20, 10));
    }

    void RestartGame(){
        isStart = true;
        rb2d.linearVelocity = Vector2.zero;
    }


}
