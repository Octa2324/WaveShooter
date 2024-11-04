using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TargetCursor : MonoBehaviour
{
    public static TargetCursor Instance;  
    public Image targetImage;
    private Camera mainCam;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start()
    {
        Cursor.visible = false;
        mainCam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        targetImage.transform.position = mousePos;
    }

    public void ShowCursor(bool visible)
    {
        Cursor.visible = visible;
        targetImage.enabled = !visible; 
    }
}
