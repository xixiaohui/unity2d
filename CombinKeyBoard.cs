using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombinKeyBoard : MonoBehaviour {


    public Texture imgup;
    public Texture imgdown;
    public Texture imgleft;
    public Texture imgright;
    public Texture success;

    //自定义方向键的存储值
    public const int KEY_UP = 0;
    public const int KEY_DOWN = 1;
    public const int KEY_RIGHT = 2;
    public const int KEY_LEFT = 3;
    public const int KEY_FIRE = 4;

    public const int FRAME_COUNT = 100;

    public const int SAMPLE_SIZE = 3;
    public const int SAMPLE_COUNT = 5;

    // 仓库技能
    int[,] SAMPLE = new int[SAMPLE_SIZE, SAMPLE_COUNT]
    {
        //下+前+下+前+拳
        {KEY_DOWN,KEY_RIGHT,KEY_DOWN,KEY_RIGHT, KEY_FIRE},
        // 下前下后拳
        { KEY_DOWN,KEY_RIGHT,KEY_DOWN,KEY_LEFT,KEY_FIRE},
        //下后下后拳
        { KEY_DOWN,KEY_LEFT,KEY_DOWN,KEY_LEFT,KEY_FIRE}  
    };

    //记录当前按下按键的键值
    int currentkeyCode = 0;
    bool startFrame = false;
    int currentFrame = 0;
    //保存一段时间内玩家输入的按键组合
    List<int> playerSample;

    bool isSuccess = false;

    // Use this for initialization
    void Start ()
    {
        playerSample = new List <int>();

	}

    void OnGUI()
    {
        //获得按键组合链表中存储按键的数量
        int size = playerSample.Count;
        for (int i =0; i < size; i++)
        {
            int key = playerSample[i];
            Texture temp = null;
            switch (key)
            {
                case KEY_UP:
                    temp = imgup;
                    break;
                case KEY_DOWN:
                    temp = imgdown;
                    break;
                case KEY_LEFT:
                    temp = imgleft;
                    break;
                case KEY_RIGHT:
                    temp = imgright;
                    break;
            }
            if(temp != null)
            {
                GUILayout.Label(temp);
            }
        }
        if (isSuccess)
        {
            GUILayout.Label(success);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateKey();
        if (Input.anyKeyDown)
        {
            if (isSuccess)
            {
                isSuccess = false;
                Reset();
            }

            if (!startFrame)
            {
                startFrame = true;
            }
            playerSample.Add(currentkeyCode);

            int size = playerSample.Count;
            if (size == SAMPLE_COUNT)
            {
                for (int i =0;i< SAMPLE_SIZE; i++)
                {
                    int successCount = 0;
                    for (int j = 0;j<SAMPLE_COUNT;j++)
                    {
                        int temp = playerSample[j];
                        if(temp == SAMPLE[i,j])
                        {
                            successCount++;
                        }
                    }

                    if (successCount == SAMPLE_COUNT)
                    {
                        isSuccess = true;
                        break;
                    }
                }
            }

        }

        if (startFrame)
        {
            currentFrame++;
        }

        if (currentFrame >= FRAME_COUNT)
        {
            if (!isSuccess)
            {
                Reset();
            }
        }
	}

    void Reset()
    {
        currentFrame = 0;
        startFrame = false;
        if (playerSample != null)
        {
            playerSample.Clear();
        }
    }

    void UpdateKey()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            currentkeyCode = KEY_UP;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            currentkeyCode = KEY_DOWN;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            currentkeyCode = KEY_LEFT;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            currentkeyCode = KEY_RIGHT;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            currentkeyCode = KEY_FIRE;
        }
    }


}