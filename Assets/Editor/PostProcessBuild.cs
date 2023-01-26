#if UNITY_5

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.iOS.Xcode;
using UnityEditor;
using System.IO;
using UnityEditor.Callbacks;

/// <summary>
/// 导出Xcode后执行自动化操作: 
/// 1. 自动导入TencentLBS.framework包, 不再需要手动导入; 
/// 2. 自动给Info.plist添加定位权限, 不再需要手动添加;
/// </summary>
public class PostProcessBuild  {


	#region 导出Xcode后执行自动化操作

	[PostProcessBuild]
	public static void OnPostprocessBuild(BuildTarget buildTarget, string path)
	{
		if (BuildTarget.iOS != buildTarget)
		{
			return;
		}

		ModifyPBXProject(path);

		ModifyPlist(path);

		Debug.Log("Xcode修改完毕");
	}


	private static void ModifyPBXProject(string path)
	{
		string projPath = PBXProject.GetPBXProjectPath(path);
		PBXProject proj = new PBXProject();

		proj.ReadFromString(File.ReadAllText(projPath));
		string target = proj.TargetGuidByName("Unity-iPhone");

		//添加 TencentLBS.framework 定位SDK包
		proj.AddFrameworkToProject(target, "TencentLBS.framework", false);

		//执行修改操作
		File.WriteAllText(projPath, proj.WriteToString());
	}


	private static void ModifyPlist(string path)
	{
		//Info.plist
		string plistPath = path + "/Info.plist";
		PlistDocument plist = new PlistDocument();
		plist.ReadFromString(File.ReadAllText(plistPath));

		//get root
		PlistElementDict rootDict = plist.root;

		//执行修改操作, 添加定位权限;
		rootDict.SetString ("NSLocationWhenInUseUsageDescription", "LBS");

		//写入
		File.WriteAllText(plistPath, plist.WriteToString());
	}

	#endregion

}

#endif