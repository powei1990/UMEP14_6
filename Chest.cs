using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest :Interactable {
    bool Interacted = true;
    public GameObject Item = null;
    private Transform SpawnPoint = null;
    private int powerY = 400;    //y方向彈出力道
    private Animation Animation;

    public override void Interact()
    {
            OpenChest();
       // Debug.Log(Interacted);
    }

 

    private void OpenChest()
    {
       
        if (Interacted)
        {
            Animation = GetComponent<Animation>();
            Animation.Play("open");
            Interacted = false;
            //Debug.Log("Opened");
            SpawnItem();
            AudioManager.instance.Play("Chest");
        }
    }

    private void SpawnItem()
    {
        SpawnPoint = transform.Find("SpawnPoint");//找物件名為"SpawnPoint"
        GameObject item = Instantiate(Item, SpawnPoint);
        Rigidbody rb = item.GetComponent<Rigidbody>();
        rb.AddForce(Random.Range(25, 50), powerY, Random.Range(25, 50));
        rb.AddTorque(0,1000,0);//加上旋轉效果
        Debug.Log("Spawn the Item");
    }

}
