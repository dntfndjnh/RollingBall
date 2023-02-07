using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ : MonoBehaviour
{
  //  int sec_temp;
   // sec_temp=(int)sec_count.sec//+click_num.click;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Text>().text = (sec_to + click_num.click).ToString();
        GetComponent<Text>().text ="Score:"+ jump_.total_score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
