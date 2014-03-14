using UnityEngine;
using System.Collections;
using System;
public  class PlayerSetting {

	public static Matrix gameMatrix;


	public static void SavePlayerProgress()//保存用户的进度
	{
	}




	public static void SavePlayerScore()
	{

	}



	public static void SaveGameMatrix(Matrix matrix)
	{
		for(int y = 0; y < matrix.GetMatrixHeight();y++)
		{
			for(int x = 0; x < matrix.GetMatrixWidth();x++)
			{
				PlayerPrefs.SetInt(y.ToString()+x.ToString(),(int)matrix.GetValueByXY(x,y));
			}
		}

		PlayerPrefs.SetInt("width",matrix.GetMatrixHeight());
		PlayerPrefs.SetInt("height",matrix.GetMatrixWidth());

		
	}


	public static Matrix ReadMatrixFromPref()
	{
		int M = PlayerPrefs.GetInt("height",3);
		int N = PlayerPrefs.GetInt("width",3);
		Matrix matrix = new Matrix(M,N);
		for(int y = 0; y < M;y ++)
		{
			for(int  x = 0; x < N;x++)
			{
				string key = y.ToString() + x.ToString();
				int value = PlayerPrefs.GetInt(key,1);
				matrix.setValueInXY(x,y,(byte)value);
			}
		}

		return matrix;
		
	}

}
