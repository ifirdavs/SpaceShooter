using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;

public class MenuManager : MonoBehaviour {

    public Button[] options = new Button[4];
    private int sel;
    public Texture2D texture;
    public GameObject mainMenu;
    public GameObject rankMenu;
    public GameObject infoMenu;
    public Text rankingText;
    private string path;
    private int infoSel;

    // Use this for initialization
    void Start() {
        sel = 5;
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.ForceSoftware);
        Cursor.visible = true;
        path = "Assets/Resources/rank.txt";
        rankMenu.SetActive(false);
        infoMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            sel--;
            checkSelected();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            sel++;
            checkSelected();
        }

        for (int i = 0; i < 4; i++) {
            if (i == sel) {
                options[i].GetComponentInChildren<Text>().fontSize = 60;
                options[i].GetComponentInChildren<Text>().color = Color.gray;
            } else {
                options[i].GetComponentInChildren<Text>().fontSize = 50;
                options[i].GetComponentInChildren<Text>().color = Color.white;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            if (sel == 0)
                PlayGame();
            else if (sel == 1)
                ShowRank();
            else if (sel == 2)
                ShowInfo();
            else if (sel == 3)
                QuitGame();
        }

        if (infoMenu.activeSelf == true) {
            for (int i = 1; i <= 9; i++) {
                GameObject go = infoMenu.transform.Find(i.ToString()).gameObject;
                if (i == infoSel) {
                    go.SetActive(true);
                } else {
                    go.SetActive(false);
                }
            }
        }

    }

    public void checkSelected() {
        if (sel > 3)
            sel = 0;

        if (sel < 0)
            sel = 3;
    }

    public void PlayGame() {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ShowRank() {
        StreamReader reader = new StreamReader(path);
        string line;
        string[] temp = null;
        string[] names = new string[10];
        int[] scores = new int[10];
        int i = 0;
        while ((line = reader.ReadLine()) != null) {
            temp = line.Split(char.Parse(" "));
            scores[i] = int.Parse(temp[0]);
            names[i] = temp[1];
            i++;
        }
        int t;
        string ts;
        for (int j = 0; j <= 8; j++) {
            for (int x = 0; x <= 8; x++) {
                if (scores[x] < scores[x + 1]) {
                    t = scores[x + 1];
                    ts = names[x + 1];
                    scores[x + 1] = scores[x];
                    names[x + 1] = names[x];
                    scores[x] = t;
                    names[x] = ts;
                }
            }
        }
        rankingText.text = "";
        for (int j = 0; j < 10; j++) {
            if (scores[j] > 0)
                rankingText.text += ((j + 1).ToString() + ". " + names[j] + ": " + scores[j] + "\n");
        }
        mainMenu.SetActive(false);
        rankMenu.SetActive(true);
    }


    public void ShowInfo() {
        infoSel = 1;
        mainMenu.SetActive(false);
        infoMenu.SetActive(true);
    }

    public void CloseRank() {
        mainMenu.SetActive(true);
        rankMenu.SetActive(false);
    }

    public void BackInfo() {
        infoMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void infoNext() {
        Debug.Log(infoSel);
        if (infoSel < 9) {
            infoSel++;
        }
        Debug.Log(infoSel);
    }

    public void infoPrev() {
        Debug.Log(infoSel);
        if (infoSel > 1) {
            infoSel--;
        }
    }

    public void ButtonHover(Button button) {
        button.GetComponentInChildren<Text>().fontSize = 60;
        button.GetComponentInChildren<Text>().color = Color.gray;
        sel = int.Parse(button.tag);
    }

    public void ButtonHoverOut(Button button) {
        button.GetComponentInChildren<Text>().fontSize = 50;
        button.GetComponentInChildren<Text>().color = Color.white;
        sel = 5;
    }

    public void ButtonHoverGen(Button button) {
        button.GetComponentInChildren<Text>().fontSize = 35;
        button.GetComponentInChildren<Text>().color = Color.gray;
    }

    public void ButtonHoverOutGen(Button button) {
        button.GetComponentInChildren<Text>().fontSize = 30;
        button.GetComponentInChildren<Text>().color = Color.white;
    }

    public void ButtonHoverInfo(Button button) {
        button.GetComponentInChildren<Text>().color = Color.gray;
    }

    public void ButtonHoverOutInfo(Button button) {
        button.GetComponentInChildren<Text>().color = Color.white;
    }


}
