
var target : Transform;
var distance = 2.0; 
var damping = 4.0; 

var xMaxPosition = 0.9; 
var xMinPosition = 0.1; 
var yMinPosition = 0.1;
var yMaxPosition = 0.9;
var mainCamera;


function Awake(){
mainCamera = GetComponent.<Camera>();
}

function LateUpdate () 
{ 
	transform.position.z = distance;
      var pos = mainCamera.WorldToViewportPoint (target.position); 
      if (pos.x > xMaxPosition) 
          transform.Translate (damping * Time.deltaTime, 0, 0); 
      if (pos.x < xMinPosition) 
          transform.Translate (-damping * Time.deltaTime, 0, 0);
	  if (pos.y > yMaxPosition) 
          transform.Translate (0, damping * Time.deltaTime, 0); 
      if (pos.y < yMinPosition) 
          transform.Translate (0, -damping * Time.deltaTime, 0); 
}