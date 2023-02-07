using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class jump_ : MonoBehaviour
{   Rigidbody2D rb;
    int count=0;//땅에 닿는 횟수 카운트
    int temp;//점프속도를 저장하는 임시변수
    bool game_over=false;
    float time;//시간
    public bool m_bjump=false;
    int jump_pow=0;//점프 파워 Update()마다 점프 파워 증가
    int is_fly = 1;//지금 공이 체공 중인지 여부
    int crash = 0;//공이 너무 높이 뛰어서 위에 천장에 닿았는지 여부에 대한 변수
    public static int total_score=0;// 총점 체공시간+클릭수
    int conve_rt;//시간을 반올림한 값을 저장할 변수
    int clk;//클릭수
    
    // Start is called before the first frame update
    void Start()
    {rb=GetComponent<Rigidbody2D>();
        AudioSource audio = GetComponent<AudioSource>();//오디오 파일 불러오기
        
    }

    // Update is called once per frame
    void Update()
    {jump_pow+=30;//점프 파워가 매 순간순간마다 증가
        if ((count == 1)&&(is_fly==1))//땅에 한번 닿았으면서 체공에 들어갔을 경우
        {
            sec_count.sec += 1 * Time.deltaTime;//시간 카운트를 재기 시작한다
        }
        if (Input.GetMouseButtonDown(0))//마우스를 클릭할때
     {
            GetComponent<AudioSource>().Play();//점프소리 재생
            if (count == 0)//땅에 아직 한번도 안닿은 상태라면
            {
                
                rb.velocity = Vector2.up * (jump_pow*5 ) * Time.deltaTime*0;//터치를 해도 점프가 되지를 않음
                temp = jump_pow;//임시변수에 점프값을 저장
                //rb.velocity=Vector2.right*(jump_pow%5);
                jump_pow = 0;//점프를 사용했으므로 다시 점프의 파워를 0으로 리셋
            }
            else if (count == 1)//만약 한번 땅에 닿았을경우
            {
                is_fly = 1;//땅에 한번 닿은 상태에서 마우스를 클릭했으므로 체공 상태를 1로 변환
               click_num.click++;// 화면에 출력 할 클릭 수를 매 클릭마다 계산함
                
                rb.velocity = Vector2.up * (jump_pow / 16) * Time.deltaTime;// 클릭하면 점프파워의 일정비율만큼 점프를 함
                temp = jump_pow;//임시변수에 현 점프파워 저장<-나중에 천장에 맞고 튕겨나올때 점프파워가 쎌수록 많이 튀어 나오게 하기 위함 
                //rb.velocity=Vector2.right*(jump_pow%5);
                jump_pow = 0;//다시 점프파워를 0으로 리셋
            }

     }
     if(count==2)//만약 땅에 두번 닿았을 경우 게임 종료할 것임
     {
       // Canvas.score.text((int)time%60).ToString();
        //Time.timeScale=0;
            if ((crash == 1)&&(sec_count.sec<3))//천장에 닿았으면서 시간초가 3초미만이면 충돌로 인한 게임오버로 간주 할 것임
            {

                click_num.click = 0;//클릭값 0으로 초기화
                sec_count.sec = 0;//초시간 0으로 초기화
                jump_pow = 0;// 점프파워 0으로 초기화
                SceneManager.LoadScene("gameover");//씬변경
               

            }
            else//만약 충돌로 인한 게임오버가 아닐 경우
            {
                conve_rt=Convert.ToInt32(sec_count.sec);//변수에 시간을 반올림한 값을 저장
                clk =Convert.ToInt32( click_num.click);//클릭 횟수를 변수에 저장
                total_score = clk + conve_rt;//클릭횟수와 반올림한 시간을 더한 후
                Debug.Log(clk + "+" + conve_rt + "=" + total_score);// 그 더한 값을 Score로 출력
                click_num.click = 0;//게임 초기화 위해 값들을 0으로 변환
                sec_count.sec = 0;//
                jump_pow = 0;//
                SceneManager.LoadScene("gameend");//씬을 변경
                
            }
        }
    

    
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
     {  
        if(collision.collider.gameObject.CompareTag("wall"))
        {
            crash = 1;
            rb.velocity=Vector2.down * (temp/100);
        }
        if(collision.collider.gameObject.CompareTag("road"))
        {
            is_fly = 0;
            rb.velocity=Vector2.right*1/2;
            count++;
           
        }
      


    }  


}
