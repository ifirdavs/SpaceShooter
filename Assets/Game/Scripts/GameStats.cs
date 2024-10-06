using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameStats : MonoBehaviour {

    public int points;
    public int specialPoints;
    public float health;
    public int special;
    public Text score;
    public Sprite[] hearts = new Sprite[3];
    public GameObject health_hearts;
    public GameObject pause_menu;
    public GameObject end_menu;
    public GameObject new_top_menu;
    public bool isPaused;
    public bool specialActived;
    public Texture2D texture;
    public InputField name_field;
    private string path;
    private string[] names;
    private int[] scores;
    private string player_name;
    private int pos;

    // Use this for initialization
    void Start() {

        points = 0;
        specialPoints = 0;
        health = 100;
        end_menu = GameObject.FindGameObjectWithTag("EndMenu");
        pause_menu = GameObject.FindGameObjectWithTag("PauseMenu");
        new_top_menu = GameObject.FindGameObjectWithTag("InsertMenu");
        isPaused = false;
        pause_menu.SetActive(false);
        end_menu.SetActive(false);
        new_top_menu.SetActive(false);
        special = 5000;
        specialActived = false;
        Vector2 cursorHotspot = new Vector2(texture.width / 2, texture.height / 2);
        Cursor.SetCursor(texture, cursorHotspot, CursorMode.ForceSoftware);
        path = "Assets/Resources/rank.txt";
        player_name = null;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            checkPause();
        if (name_field.isFocused && name_field.text != "" && Input.GetKey(KeyCode.Return)) {
            player_name = name_field.text;
            name_field.text = "";
            new_top_menu.SetActive(false);
            UpdateRank();
        }
    }

    void FixedUpdate() {

        score.text = points.ToString();
        if (health <= 0) {
            CheckNewRecord();
            end_menu.gameObject.transform.Find("FinalScore").GetComponent<Text>().text = "SCORE: " + points.ToString();
            checkPause();
            end_menu.SetActive(true);
        }


    }

    public void increasePoint(int increment) {
        points += increment;
    }

    public void increaseSpecialPoint(int increment) {
        specialPoints += increment;
    }

    public void decreaseLife(int damage) {
        health -= damage;
    }

    public void ButtonHover(Button button) {
        button.GetComponent<Image>().color = Color.gray;
    }

    public void ButtonHoverOut(Button button) {
        button.GetComponent<Image>().color = Color.white;
    }

    public void PlayButton() {
        isPaused = true;
        checkPause();
    }

    public void checkPause() {
        if (isPaused) {
            Time.timeScale = 1.0f;
            pause_menu.SetActive(false);
        } else {
            Time.timeScale = 0.0f;
            pause_menu.SetActive(true);
        }
        isPaused = !isPaused;
    }

    public void CloseGame() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame() {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game");
    }


    public void CheckNewRecord() {
        int newScore = points;
        StreamReader reader = new StreamReader(path);
        string line;
        string[] temp = null;
        names = new string[10];
        scores = new int[10];
        int i = 0;
        while ((line = reader.ReadLine()) != null) {
            temp = line.Split(char.Parse(" "));
            scores[i] = int.Parse(temp[0]);
            names[i] = temp[1];
            i++;
        }
        reader.Close();
        int j_min = 0;
        for (int j = 1; j < 10; j++) {
            if (scores[j_min] > scores[j]) {
                j_min = j;
            }
        }
        if (scores[j_min] < newScore) {
            pos = j_min;
            new_top_menu.SetActive(true);
        }

    }

    public void UpdateRank() {
        scores[pos] = points;
        names[pos] = player_name;
        StreamWriter writer = new StreamWriter(path);
        string file_content = "";
        for (int x = 0; x < 10; x++) {
            file_content += (scores[x].ToString() + " " + names[x] + "\n");
        }
        writer.Write(file_content);
        writer.Close();
    }




}
