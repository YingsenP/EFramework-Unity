//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using  UnityEngine ;


namespace U3DEventFrame
{
	public class IABManifestLoader
	{


		public AssetBundleManifest assetManifeset;
		
		public  byte  loadState;
		
		public AssetBundle manifesetLoader;
		
		
		public string  manifestPath;


        public bool isUsingWWW = false;

        public void SetManifestPath(string path)
        {
            manifestPath = path;
        }


        public IABManifestLoader ()
		{

			assetManifeset = null;
			manifesetLoader = null;
			loadState = 0;
			
			manifestPath = null;


            //file:///E:/BaiduYunDownload/Assets/Assets/StreamingAssets/AssetBundles/Windows/Windows
            manifestPath = IPathTools.GetAssetBundleFilePath(IPathTools.GetRuntimeFolder()) ;


            if (!IFileTools.IsExistFile(manifestPath))
            {
                isUsingWWW = true;
                manifestPath = IPathTools.GetAssetBundleWWWStreamPath(IPathTools.GetRuntimeFolder()) ;
            }

            Debuger.Log("manifestPath ==="+ manifestPath);

            Debuger.Log("manifestPath 222===" + isUsingWWW.ToString());
            // manifestPath = "C:/Users/yujie/AppData/LocalLow/JFYD/Fish/AssetBundles/Android/Android";
            //  manifestPath =  Application.persistentDataPath + "/AssetBundles/Android/Android";
            //  Debug.Log("manifestPath =111=" + manifestPath);
        }

		private static IABManifestLoader instance  =null;

	    public static	IABManifestLoader  Instance
		{
			get 
			{
				if(instance == null)
				{
					instance = new IABManifestLoader();


				}
				return instance ;
			}



		}


		public bool  IsLoadFinish()
		{
			if(loadState ==2)
			{

				return  true ;

			}
			else
			{
				return false ;

			}
		}
		


		public IEnumerator LoadManifeset()
		{
			
	
			loadState =1 ;



            AssetBundle tmpBundle = null;
            if (isUsingWWW)
            {
				WWW bundle = WWW.LoadFromCacheOrDownload(manifestPath,FrameTools.VersionId);

                yield return bundle;



                if (!string.IsNullOrEmpty(bundle.error))
                {
                   

                    Debuger.Log("manifestPath   == "+bundle.error);
                }
                else
                {
                  //  Debug.Log("manifestPath =777777=" + bundle.progress);
                }

                tmpBundle = bundle.assetBundle;
            }
            else
            {
                tmpBundle = AssetBundle.LoadFromFile(manifestPath);
            }

           

           

            if (tmpBundle != null)
            {
               // Debug.Log("manifestPath =44444444444=" + manifestPath);
                SetAssetBundleLoader(tmpBundle);

            

                SetLoadingState(2);
                yield return null;

            }
            else
            {

                Debug.Log("manifestPath =33333333333333=" + manifestPath);
            }




        }



        //public static IABManager Instance;



        /// <summary>
        ///   assetbundle 包名  
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string[] GetDepedences(string name)
        {

            return assetManifeset.GetAllDependencies(name);
        }





        /// <summary>
        ///  加载 manifeset
        /// </summary>
        /// <param name="bundle"></param>
        public void SetAssetBundleLoader(AssetBundle  bundle)
			{
				
				manifesetLoader = bundle;
				
				assetManifeset = manifesetLoader.LoadAsset("AssetBundleManifest") as AssetBundleManifest;
             string[]  tmp =   assetManifeset.GetAllAssetBundles();


           // Debug.Log("  777777777777777AssetBundleManifest7777==="+tmp.Length);



            }
			
			public void  SetAssetManifest(AssetBundleManifest  tmpManifest)
			{
				assetManifeset = tmpManifest;
			}
			
			public void SetLoadingState(byte state)
			{
				loadState = state;
			}
			

			
		  //卸载 mainifeset
			public void UnloadManifeset()
			{
				manifesetLoader.Unload(true);
			}

	}



}




