using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadPanel : MonoBehaviour
{
    //Populate the panel based on the # of saved animation in the SavedAnimation folder
    int num;
    public string pathStr;
    string path;
    public string[] ClipList;

    public GameObject LoadIconPrefab;
    public GameObject Canvas;

    private void Start()
    {
        ClipList = new string[18];
        path = Application.dataPath + "/Resources" + pathStr;
        num = GetCount();
        DisplayIcons(GetCount());

    }
    private void Update()
    {
        if(num != GetCount())
        {
            UpdateIcons(GetCount());
            num = GetCount();
        }
    }

    int GetCount()
    {
        int n = 0;
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] info = dir.GetFiles("*.anim");
        foreach(FileInfo f in info)
        {
            ClipList[n] = f.Name;
            n++;
        }

        return n;

    }

   void DisplayIcons(int n)
    {

        for (int i = 0; i < n; i++)
        {
            var newIcon = Instantiate(LoadIconPrefab, gameObject.transform.position, Quaternion.identity);
            newIcon.transform.name = "File " + (i+1);
            newIcon.transform.SetParent(gameObject.transform,false);
        }

    }

    void UpdateIcons(int n)
    {
        //Clear list and child
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

     
        DisplayIcons(n);
    }

}
