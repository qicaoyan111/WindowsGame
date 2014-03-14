using UnityEngine;
using System.Collections;

public class Matrix  {

	// Use this for initialization
	private int M;//矩阵的高
	private int N;//矩阵的宽
	private byte[] values;
	public const int LEFT = 0x11;
	public const int RIGHT = 0x12;
	public const int TOP = 0x13;
	public const int BOTTOM = 0x14;
	public const int NULL = 10;

	public Matrix(int M,int N)
	{
		this.M = M;
		this.N = N;
		this.values = new byte[M*N];
		for(int i = 0;i < M*N;i++)
		{
			this.values[i] = 1;
		}
	}


	//获取矩阵的宽
	public int GetMatrixWidth()
	{

		return this.N;
	}

	//获取矩阵的高
	public int GetMatrixHeight()
	{
		return this.M;
	}

	public byte GetValueByXY(int x,int y)
	{
		return this.values[y*N + x];
	}


	public void setValueInXY(int x,int y,byte value)
	{
		this.values[y*N + x] = value;
	}

	public void SaveMatrix()//用以后续保存玩家状态
	{

	}


	public void ReadFromPreference()//
	{
	}


	public byte GetCrossValue(int x, int y , int direction)//用以获取交叉部分的value
	{
	
		switch(direction)
		{
		case Matrix.LEFT:
			if(x == 0)
				return NULL;
			else
				return GetValueByXY(x-1,y);

			break;
		case Matrix.TOP:
			if(y == 0)
				return NULL;
			else
				return GetValueByXY(x,y-1);
			break;

		case Matrix.RIGHT:
			if(x == N - 1)
				return NULL;
			else 
				return GetValueByXY(x+1,y);
			break;
		case Matrix.BOTTOM:
			if( y == M - 1)
				return NULL;
			else
				return GetValueByXY(x,y+1);
			break;
		}

		return NULL;

	}



}
