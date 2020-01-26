using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMazeRandom : MonoBehaviour
{
	const int N = 1, S = 2, E=3, W=4;
	int[,] grid;
	[SerializeField]
	[Range(5,100)]
	int width, height;

	[SerializeField]
	[Range(5,100)]
	int wallSize;

	public GameObject verticalWall, horizontalWall;
	public GameObject player;

	GameObject[,] gridObjectsH, gridObjectsV;
	GameObject[] allObjectsInScene;

	float wallHeight;

	private void Init(){
		height = width;
		wallHeight = 4;
		verticalWall.transform.localScale = new Vector3(.1f,wallHeight,wallSize);
		horizontalWall.transform.localScale = new Vector3(wallSize,wallHeight,.1f);

		grid = new int[width,height];
		gridObjectsV = new GameObject[width+1,height+1];
		gridObjectsH = new GameObject[width+1,height+1];

		drawFullgrid();

		GameObject.Find("ground").transform.localScale = new Vector3((width+1)*wallSize,1,(height+1)*wallSize);
		GameObject.Find("ceiling").transform.localScale = new Vector3((width + 1) * wallSize, 1, (height + 1) * wallSize);  
		GameObject.Find("ceiling").transform.position = new Vector3(GameObject.Find("ceiling").transform.position.x, wallSize-1, GameObject.Find("ceiling").transform.position.z);
}

	void drawFullgrid(){
		for(int i=0;i<=height;i++){
			for(int j=0;j<=width;j++){
				if(i<height){
					float vWallSize = verticalWall.transform.localScale.z;
					float xOffset,zOffset;
					xOffset = -(width*vWallSize)/2;
					zOffset = -(height*vWallSize)/2;

					gridObjectsV[j,i] = (GameObject)(Instantiate(verticalWall,new Vector3(-vWallSize/2+j*vWallSize+xOffset,wallSize/2,i*vWallSize+zOffset),Quaternion.identity));

					gridObjectsV[j,i].active = true;
					gridObjectsV[j,i].name = "v"+i+j;
					gridObjectsV[j,i].tag = "wall";
				}

				if(j<width){
					float hWallSize=horizontalWall.transform.localScale.x;
					float xOffset,zOffset;
					xOffset = -(width*hWallSize)/2;
					zOffset = -(height*hWallSize)/2;

					gridObjectsH[j, i] = (GameObject)(Instantiate(horizontalWall, new Vector3(j * hWallSize + xOffset, wallSize/2, -(hWallSize / 2) + i * hWallSize + zOffset), Quaternion.identity));
					gridObjectsH[j,i].active=true;
					gridObjectsH[j,i].name="h"+i+j;
					gridObjectsH[j,i].tag="wall";
				}
			}
		}
	}

	void GenerateMazeBinary(){
		for(int row = 0;row<height;row++){
			for(int cell=0;cell<width;cell++){
				float randomNumber=Random.Range(0,100);
				int carvingDirection;
				if(randomNumber>30)
				carvingDirection=N;
				else
				carvingDirection=E;
				if(cell == width-1){
					if(row<height-1)
					carvingDirection=N;
					else
					carvingDirection=W;
				}
				else if(row == height-1)
				{
					if(cell<width-1)
					carvingDirection=E;
					else
					carvingDirection=-1;
				}
				grid[cell,row]=carvingDirection;
			}
		}
	}

	void DisplayGrid()
	{
		for(int row=0;row<height;row++){
			for(int cell = 0;cell<width;cell++){
				if(grid[cell,row]==N)
				gridObjectsH[cell,row+1].active=false;
				if(grid[cell,row]==E)
				gridObjectsV[cell+1,row].active=false;
			}
		}
	}

	void AddPlayer()
	{
		float xOffset=-(width*wallSize)/2;
		float zOffset=-(height*wallSize)/2;
		GameObject p=(GameObject)(Instantiate(player,new Vector3(xOffset,1.0f,zOffset),Quaternion.identity));
		p.name="player";
	}
    // Start is called before the first frame update
    void Start()
    {
        Init();
        GenerateMazeBinary();
        DisplayGrid();
        AddPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
