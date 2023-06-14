using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class Json : MonoBehaviour
{


    public ItemInventory Inventory;
    public void Click_NextStage()
    {
        SceneManager.LoadScene("Stage");
        var result = JsonConvert.SerializeObject(Inventory.Inventory);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
