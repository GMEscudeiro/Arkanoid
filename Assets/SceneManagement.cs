using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    private Scene scene;

    public GameObject blueBrick;
    public GameObject redBrick;
    public GameObject greenBrick;
    public GameObject greyBrick;
    public GameObject purpleBrick;
    public GameObject yellowBrick;

    private GameObject[] bricks;
    private int rows = 8;
    private int screenWidth = 13;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       scene = SceneManager.GetActiveScene();
       createLevel();
    }

    // Update is called once per frame
    void Update()
    {
    //    Scene scene = SceneManager.GetActiveScene();
    //    GameObject[] gos = GameObject.FindGameObjectsWithTag("Brick");
    //    print(gos.Length);

    //    if(gos.Length == 0 ){
    //     if(scene.name == "level_one"){
    //         SceneManager.LoadScene("level_two");
    //     }
    //    }
    }

    void createLevel(){
        createRows();
    }

    void instantiateBrick(int id, float x, float y){
        if(id == 1){
            Instantiate(blueBrick, new Vector3(x,y,0), Quaternion.identity);
        }
        else if(id == 2){
            Instantiate(redBrick, new Vector3(x,y,0), Quaternion.identity);
        }
        else if(id == 3){
            Instantiate(greyBrick, new Vector3(x,y,0), Quaternion.identity);
        }
        else if(id == 4){
            Instantiate(greenBrick, new Vector3(x,y,0), Quaternion.identity);
        }
        else if(id == 5){
            Instantiate(purpleBrick, new Vector3(x,y,0), Quaternion.identity);
        }
        else if(id == 6){
            Instantiate(yellowBrick, new Vector3(x,y,0), Quaternion.identity);
        }
    }

    void createRows(){
        float y = 0.15f;
        for(int i = 0; i <= rows; i++){
            float x = -8.3f;
            for(int j = -screenWidth; j < screenWidth; j++){
                int color = Random.Range(1,7);
                instantiateBrick(color, x, y);
                x = x + 0.66f;
            }
            y = y + 0.50f;
        }
    }
}
