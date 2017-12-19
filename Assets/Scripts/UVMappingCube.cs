using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVMappingCube : MonoBehaviour {
    
	void Start () {
        Mesh mesh = transform.GetComponent<MeshFilter>().mesh;
        Vector2[] newUV = mesh.uv;

        newUV[2] = new Vector2(0, 0.75f);
        newUV[3] = new Vector2(0.25f, 0.75f);
        newUV[0] = new Vector2(0, 0.5f);
        newUV[1] = new Vector2(0.25f, 0.5f);
        
        newUV[17] = new Vector2(0.25f, 0.75f);
        newUV[18] = new Vector2(0.5f, 0.75f);
        newUV[19] = new Vector2(0.5f, 0.5f);
        newUV[16] = new Vector2(0.25f, 0.5f);

        newUV[6] = new Vector2(0.75f, 0.5f);
        newUV[7] = new Vector2(0.5f, 0.5f);
        newUV[10] = new Vector2(0.75f, 0.75f);
        newUV[11] = new Vector2(0.5f, 0.75f);

        newUV[21] = new Vector2(0.75f, 0.75f);
        newUV[22] = new Vector2(1, 0.75f);
        newUV[23] = new Vector2(1, 0.5f);
        newUV[20] = new Vector2(0.75f, 0.5f);
        
        newUV[8] = new Vector2(0f, 0.75f);
        newUV[4] = new Vector2(0f, 1);
        newUV[9] = new Vector2(0.25f, 0.75f);
        newUV[5] = new Vector2(0.25f, 1);
        
        newUV[14] = new Vector2(0.25f, 0.5f);
        newUV[15] = new Vector2(0.25f, 0.25f);
        newUV[12] = new Vector2(0f, 0.25f);
        newUV[13] = new Vector2(0f, 0.5f);
        
        mesh.uv = newUV;
    }
	
}
