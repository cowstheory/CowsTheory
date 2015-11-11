using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {
    Game game;
    
    // Update is called once per frame
    void Update () {
        game.update(key);
    }
    
    void drawGame(ref Game game) {
        //surface.fill(game.bgColor)
        game.draw();
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
