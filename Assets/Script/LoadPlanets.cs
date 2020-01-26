using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class LoadPlanets : MonoBehaviour
{
	public GameObject planetTemplate;
    // Start is called before the first frame update
    void Start()
    {
        LoadAllPlanets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadAllPlanets(){
    	TextAsset textAsset=(TextAsset)Resources.Load("planets");
    	XmlDocument doc = new XmlDocument();
    	doc.LoadXml(textAsset.text);
    	foreach(XmlNode planet in doc.SelectNodes("planets/planet")){
    		string name,diameter,distancetoSun,rotationPeriod,orbitalVelocity;
    		name = planet.Attributes.GetNamedItem("name").Value;
    		diameter = planet.Attributes.GetNamedItem("diameter").Value;
    		distancetoSun = planet.Attributes.GetNamedItem("distancetoSun").Value;
    		rotationPeriod = planet.Attributes.GetNamedItem("rotationPeriod").Value;
    		orbitalVelocity = planet.Attributes.GetNamedItem("orbitalVelocity").Value;
    		Color color=selectColor(planet.Attributes.GetNamedItem("color").Value);

    		Debug.Log("Planet name:"+name);

    		float diameter2,distancetoSun2,rotationPeriod2,orbitalVelocity2;
    		diameter2=float.Parse(diameter);
    		distancetoSun2=float.Parse(distancetoSun);
    		rotationPeriod2=float.Parse(rotationPeriod);
    		orbitalVelocity2=float.Parse(orbitalVelocity);
    		print("Planet"+name+":Diameter"+diameter2+";Distance"+distancetoSun2);

    		GameObject g=Instantiate(planetTemplate);
    		g.GetComponent<Planet>().SetDistanceToSun(distancetoSun2);    		
    		g.GetComponent<Planet>().SetOrbitSpeed(orbitalVelocity2);
    		g.GetComponent<Planet>().SetRotationalSpeed(1/rotationPeriod2);    		
    		g.GetComponent<Planet>().SetName(name);
    		g.GetComponent<Planet>().SetRadius(diameter2);
    		g.GetComponent<Planet>().SetColor(color);
    	}
    }

    Color selectColor(string col){
    	switch(col){
    		case "red":
    			return Color.red;
    			break;
    		case "blue":
    			return Color.blue;
    			break;
    		case "cyan":
    			return Color.cyan;
    			break;
    		case "yellow":
    			return Color.yellow;
    			break;
    		case "green":
    			return Color.green;
    			break; 
    		default:
    			return Color.white;
    			break;
    	}
    }
}
