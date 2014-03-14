using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
public class WindowOpenCloseControl : MonoBehaviour {

	// Use this for initialization
	private Matrix windowMatrix;
	private tk2dSpriteAnimator anim;
	private string spriteRootName;
	public const bool OPEN = true;
	public const bool CLOSE = false;
	private bool  mode;//判断窗是该关还是该开
	void Start () {
	    
		//windowMatrix = new Matrix(3,3);
		windowMatrix = PlayerSetting.ReadMatrixFromPref();
		spriteRootName = "AnimatedSprite";
		InitWindowStatus();

	   

	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButtonDown(0))
		{

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit))
			{
				if (hit.collider != null)
				{
					string[] name = Regex.Split(hit.collider.name,"_");
					anim = GameObject.Find(hit.collider.name).GetComponent<tk2dSpriteAnimator>();
					int y = int.Parse(name[1][0].ToString());
					int x = int.Parse(name[1][1].ToString());
					this.OnWindowAction(x,y);
					PlayerSetting.SaveGameMatrix(windowMatrix);
				}
			}
		}

	}



	public void InitWindowStatus()
	{
		for(int y = 0 ; y < windowMatrix.GetMatrixHeight();y++)
		{
			for(int  x = 0;x < windowMatrix.GetMatrixWidth();x++)
			{
				tk2dSpriteAnimator animator = GameObject.Find(this.spriteRootName + "_" + y + x).GetComponent<tk2dSpriteAnimator>();
				if(windowMatrix.GetValueByXY(x,y) == 1)
					animator.Play("startlighton");
				else if(windowMatrix.GetValueByXY(x,y) == 0)
					animator.Play("startlightoff");
			}
		}
	}


	public void OnWindowAction(int x, int y)
	{
		byte[] crossValues = new byte[5];
		crossValues[0] = windowMatrix.GetCrossValue(x,y,Matrix.LEFT);
		crossValues[1] = windowMatrix.GetCrossValue(x,y,Matrix.TOP);
		crossValues[2] = windowMatrix.GetValueByXY(x,y);
		crossValues[3] = windowMatrix.GetCrossValue(x,y,Matrix.RIGHT);
		crossValues[4] = windowMatrix.GetCrossValue(x,y,Matrix.BOTTOM);
		tk2dSpriteAnimator animator = null;
		for(int i = 0; i < 5;i++)
		{
			if(crossValues[i] != Matrix.NULL && crossValues[i] == 0)
			{
			    animator = this.GetAnimatorByIndex(x,y,i);
				animator.Play("lightoff-on");
				this.SetValuesByIndex(x,y,i,1);
			}
			else if(crossValues[i] != Matrix.NULL && crossValues[i] == 1)
			{
				animator = this.GetAnimatorByIndex(x,y,i);
				animator.Play("lighton-off");
				this.SetValuesByIndex(x,y,i,0);
			}
		}
	}

	//根据索引值找到方向，左、上、中、右、下
	public tk2dSpriteAnimator GetAnimatorByIndex(int x, int y,int index)
	{
		tk2dSpriteAnimator animator = null;
		switch(index)
		{
		case 0:
			animator = GameObject.Find(spriteRootName + "_" + y + (x-1)).GetComponent<tk2dSpriteAnimator>();
	   
			break;
		case 1:
			animator = GameObject.Find(spriteRootName + "_" + (y-1) + x).GetComponent<tk2dSpriteAnimator>();
			break;
		case 2:
			animator = GameObject.Find(spriteRootName + "_" + y + x).GetComponent<tk2dSpriteAnimator>();
			break;
		case 3:
			animator = GameObject.Find(spriteRootName + "_" + y + (x+1)).GetComponent<tk2dSpriteAnimator>();
			break;
		case 4:
			animator = GameObject.Find(spriteRootName + "_" + (y+1) + x).GetComponent<tk2dSpriteAnimator>();
			break;
			
		}

		return animator;
	}

	//通过索引值找到方向，再进行矩阵赋值
	public void SetValuesByIndex(int x,int y,int index,byte value)
	{
		switch(index)
		{
		case 0:
			windowMatrix.setValueInXY(x-1,y,value);
			
			break;
		case 1:
			windowMatrix.setValueInXY(x,y-1,value);
			break;
		case 2:
			windowMatrix.setValueInXY(x,y,value);
			break;
		case 3:
			windowMatrix.setValueInXY(x+1,y,value);
			break;
		case 4:
			windowMatrix.setValueInXY(x,y+1,value);
			break;
			
		}
	}
}
