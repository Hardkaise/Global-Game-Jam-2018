using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    Board board;
    void InitGame()
    {
        board.SetupScene();
    }
// Use this for initialization
void Start () {
          board = GetComponent<Board>();
          InitGame();

    }

    // Update is called once per frame
    void Update () {
		
	}
}
