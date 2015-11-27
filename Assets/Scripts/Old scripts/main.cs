using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {
    Game game;
    
    // Update is called once per frame
    void Update () {
        game.update();
    }
    
    void Start () {
        game = new Game();
        loadImagesAndModels();
        loadSounds();
    }
    
    void loadImagesAndModels() {
    }
    
    void loadSounds() {
    }

}
