using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
	
	private int lengthOfLineRenderer = 100;

	float rotationalSpeed=10f;
	float orbitalSpeed=0.20f;
	float orbitalAngle=0.0f;
	float angle=0.0f;
	float orbitalRotationalSpeed=20;
	float distanceToSun=150;
    Color c1=Color.blue;

	GameObject sun;

    public void SetColor(Color col){
            c1=col;
    }
	public void SetRotationalSpeed(float s){
		rotationalSpeed=s*rotationalSpeed;
	}

	public void SetOrbitSpeed(float os){
		orbitalSpeed=os*orbitalSpeed;
	}
	public void SetDistanceToSun(float d){
		distanceToSun = distanceToSun*d;
	}
	public void SetName(string name){
		this.name = name;
		transform.Find("label").GetComponent<TextMesh>().text=name;
	}
	public void SetRadius(float radius){
		transform.localScale=new Vector3(radius,radius,radius);
	}

    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.Find("sun");
        transform.position = new Vector3(distanceToSun,0,distanceToSun);
        drawOrbit();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up,rotationalSpeed*Time.deltaTime,Space.World);
        float tempx,tempy,tempz;
        orbitalAngle+=Time.deltaTime*orbitalSpeed;
        tempx=sun.transform.position.x+distanceToSun*Mathf.Cos(orbitalAngle);
        tempz=sun.transform.position.z+distanceToSun*Mathf.Sin(orbitalAngle);
        tempy=sun.transform.position.y;
        transform.position=new Vector3(tempx,transform.position.y,tempz);
    }

    void drawOrbit(){
    	LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
    	lineRenderer.material = new Material(Shader.Find("Legacy Shaders/Particles/Additive"));
    	lineRenderer.SetColors(c1,c1);
    	lineRenderer.SetWidth(1.0F,1.0F);
    	lineRenderer.SetVertexCount(lengthOfLineRenderer+1);

    	int i=0;
    	while(i<=lengthOfLineRenderer){
    		float unitAngle=(float)(2*3.14)/lengthOfLineRenderer;
    		float currentAngle = (float)unitAngle*i;
    		Vector3 pos = new Vector3(distanceToSun*Mathf.Cos(currentAngle),0,distanceToSun*Mathf.Sin(currentAngle));
    		lineRenderer.SetPosition(i,pos);
    		i++;
    	}
    }
}
