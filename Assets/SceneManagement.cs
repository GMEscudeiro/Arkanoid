using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    private Scene scene;
    private string sceneName;

    public GameObject blueBrick;
    public GameObject redBrick;
    public GameObject greenBrick;
    public GameObject greyBrick;
    public GameObject purpleBrick;
    public GameObject yellowBrick;

    private GameObject[] bricks;
    private int rows = 1;
    private int screenWidth = 13;

    public int totalBricks = 0;
    public int level = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
        if(sceneName != "MainMenu" || sceneName != "GoodEnding" || sceneName != "BadEnding"){
            int.TryParse(sceneName.Split("_")[1], out level);
            createLevel();
        }    
    }

    void NextLevel(){
        int nextSceneIndex = level + 1;
        if (nextSceneIndex < 6) {
            SceneManager.LoadScene("Level_" + nextSceneIndex);
        }else{
            SceneManager.LoadScene("GoodEnding");
        }
    }

    public void badEnding(){
        SceneManager.LoadScene("BadEnding");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && (sceneName == "MainMenu" || sceneName == "GoodEnding" || sceneName == "BadEnding")){
            SceneManager.LoadScene("Level_1");
            level = 1;
        }
    }

    void createLevel(){
        createRows();
    }

    public void BrickDestroyed(){
        totalBricks--;
        if (totalBricks <= 0){
            NextLevel();
        }
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
        totalBricks++;
    }

    void createRows(){
        float y = 0.15f;
        for(int i = 0; i < level; i++){
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
