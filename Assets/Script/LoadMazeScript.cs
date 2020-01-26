using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class LoadMazeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Wall;
    public Dropdown drop;
    void Start()
    { 	
        drop.GetComponent<Dropdown>().onValueChanged.AddListener(loadLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadLevel(int level){
    	TextAsset t1=(TextAsset)Resources.Load("level1",typeof(TextAsset));
    	TextAsset t2=(TextAsset)Resources.Load("level2",typeof(TextAsset));
    	TextAsset t3=(TextAsset)Resources.Load("level3",typeof(TextAsset));
    	string s;
    	switch(level){
    		case 0:
    			Distroy();
    			print("level 1");
		        s = t1.text;
		        s = s.Replace("\r\n","");
		        for(int i = 0;i<s.Length;i++){
		        	if(s[i]=='1'){
		        		int col, row;
		        		col = i%10;
		        		row = i/10;
		        		GameObject t;
		        		t = (GameObject)(Instantiate(Wall, new Vector3(50-col*10-5,1.5f,50-row*10-5),Quaternion.identity));
		        	}
		        }
    			break;
    		case 1:
    			Distroy();
    			print("level 2");		
		        s = t2.text;
		        s = s.Replace("\r\n","");
		        for(int i = 0;i<s.Length;i++){
		        	if(s[i]=='1'){
		        		int col, row;
		        		col = i%10;
		        		row = i/10;
		        		GameObject t;
		        		t = (GameObject)(Instantiate(Wall, new Vector3(50-col*10-5,1.5f,50-row*10-5),Quaternion.identity));
		        	}
		        }
    			break;
    		case 2:
    			print("level 3");
    			s = t3.text;
		        s = s.Replace("\r\n","");
		        for(int i = 0;i<s.Length;i++){
		        	if(s[i]=='1'){
		        		int col, row;
		        		col = i%10;
		        		row = i/10;
		        		GameObject t;
		        		t = (GameObject)(Instantiate(Wall, new Vector3(50-col*10-5,1.5f,50-row*10-5),Quaternion.identity));
		        	}
		        }
    			break;
    	}
    }

    void Distroy(){
    	 GameObject[] walls;		 
		 walls = GameObject.FindGameObjectsWithTag("wall");		 
		 foreach(GameObject wall in walls)
		 {
		     Destroy(wall);
		 }
    }
}
