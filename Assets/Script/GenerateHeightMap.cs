using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateHeightMap : MonoBehaviour
{
	float[,] map;
	[SerializeField]
	[Range(10,100)]
	int mapHeight,mapWidth;

	[SerializeField]
	[Range(0,100)]
	float blockSize,blockHeight,frequency,scale;

	public GameObject minecraftBlock;
    public GameObject waterBlock;

    // Start is called before the first frame update
    void Start()
    {
        map = new float[mapWidth,mapHeight];
        minecraftBlock.transform.localScale=new Vector3(blockSize,blockHeight,blockSize);
        initArray();
        displayArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initArray(){
    	map = new float[mapWidth,mapHeight];

    	for(int j=0;j<mapHeight;j++){
    		for(int i=0;i<mapWidth;i++){
    			float nx=i/mapWidth;
    			float ny=j/mapHeight;
    			map[i,j]=Mathf.PerlinNoise(i*1.0f/frequency+0.1f,j*1.0f/frequency+0.1f);
    		}
    	}
    }

    void displayArray(){
        float h;
    	for(int j=0;j<mapHeight;j++){
    		for(int i=0;i<mapWidth;i++){
                h=Mathf.Round(map[i,j]*blockHeight*scale);
                if(h>10){
                    GameObject t=(GameObject)(Instantiate(minecraftBlock,new Vector3(i*blockSize,h,j*blockSize),Quaternion.identity));                   
                }
                else{
                    GameObject t=(GameObject)(Instantiate(waterBlock,new Vector3(i*blockSize,10,j*blockSize),Quaternion.identity));
                }

    		}
    	}
    }
}
