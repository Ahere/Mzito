     #pragma strict
     
     var speed = 4.0;
     
     function Update() {
         var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         var plane = new Plane(Vector3.up, transform.position);
         var dist : float;
         if (plane.Raycast(ray, dist)) {
             transform.position = Vector3.MoveTowards(transform.position, ray.GetPoint(dist), speed * Time.deltaTime);
         }
     }