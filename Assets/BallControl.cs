using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public KeyCode startKey = KeyCode.Space;
    public bool isStart = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindWithTag("Player");
        if(isStart) {
            var playerPosition = player.transform.position;
            var ballPos = transform.position;

            ballPos.x = playerPosition.x + 0.2f;
            ballPos.y = playerPosition.y + 0.25f;

            transform.position = ballPos;

            if(Input.GetKey(startKey)){
                ballStart();
                isStart = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag == "Brick"){
            Destroy(coll.gameObject);
        }
        if(coll.gameObject.tag == "Player"){
            var vel = rb2d.linearVelocity;
            if(transform.position.x <= coll.gameObject.transform.position.x){
                vel.x = -vel.x;
                rb2d.linearVelocity = vel;
            }
        }
    }

    void ballStart(){
        rb2d.AddForce(new Vector2(20, 10));
    }


}
