using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ABManager : SingletonAutoMono<ABManager>
{
    private AssetBundle mainAB = null;

    private AssetBundleManifest manifest = null;

    private Dictionary<string, AssetBundle> abDict = new Dictionary<string,AssetBundle>();
    private string PathUrl
    {
        get
        {
            return Application.streamingAssetsPath + "/";
        }
    }

    private string MainAB_Name
    {
        get
        {
            return "PC";
        }
    }

    //ͬ������

    private void LoadAB(string abName)
    {
        //��������
        if (mainAB == null)
        {
            mainAB = AssetBundle.LoadFromFile(PathUrl + MainAB_Name);
            manifest = mainAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        }
        //��ȡ��������
        string[] strs = manifest.GetAllDependencies(abName);
        AssetBundle ab = null;
        //����������
        for (int i = 0; i < strs.Length; i++)
        {
            if (!abDict.ContainsKey(strs[i]))
            {
                ab = AssetBundle.LoadFromFile(PathUrl + strs[i]);
                abDict.Add(strs[i], ab);
            }
        }
        if (!abDict.ContainsKey(abName))
        {
            ab = AssetBundle.LoadFromFile(PathUrl + abName);
            if (ab == null)
                Debug.LogError("Can't LoadFromFile"+PathUrl+abName);
            abDict.Add(abName, ab);
        }
    }
    public Object LoadRes(string abName, string resName)
    {
        LoadAB(abName);
        //����Ŀ���
        Object obj = abDict[abName].LoadAsset(resName);
        return obj;     
    }
    //TYPEָ������
    public Object LoadRes(string abName, string resName,System.Type type)
    {
        LoadAB(abName);
        Object obj = abDict[abName].LoadAsset(resName, type);
        return obj;
    }
    //����ָ������
    public T LoadRes<T>(string abName,string resName)where T : Object
    {
        LoadAB(abName);
        T obj = abDict[abName].LoadAsset<T>(resName);
        return obj;
    }
    //�첽����
    public void LoadResAsync(string abName,string resName,UnityAction<Object> callBack)
    {
        StartCoroutine(ILoadResAsync(abName, resName, callBack));
    }
    private IEnumerator ILoadResAsync(string abName,string resName,UnityAction<Object> callBack)
    {
        LoadAB(abName);
        AssetBundleRequest abr = abDict[abName].LoadAssetAsync(resName);
        yield return abr;
        callBack(abr.asset);  
    }
    public void LoadResAsync(string abName, string resName,System.Type type, UnityAction<Object> callBack)
    {
        StartCoroutine(ILoadResAsync(abName, resName,type, callBack));
    }
    private IEnumerator ILoadResAsync(string abName, string resName, System.Type type, UnityAction<Object> callBack)
    {
        LoadAB(abName);
        AssetBundleRequest abr = abDict[abName].LoadAssetAsync(resName,type);
        yield return abr;
        callBack(abr.asset);
    }
    public void LoadResAsync<T>(string abName, string resName, UnityAction<T> callBack)where T:Object
    {
        StartCoroutine(ILoadResAsync<T>(abName, resName, callBack));
    }
    private IEnumerator ILoadResAsync<T>(string abName, string resName, UnityAction<T> callBack)where T:Object
    {
        LoadAB(abName);
        AssetBundleRequest abr = abDict[abName].LoadAssetAsync<T>(resName);
        yield return abr;
        callBack(abr.asset as T);
    }

    //����ж��
    public void UnLoad(string abName)
    {
        if (abDict.ContainsKey(abName))
        {
            abDict[abName].Unload(false);
            abDict.Remove(abName);
        }
    }
    //���а�ж��
    public void UnLoadAll()
    {
        AssetBundle.UnloadAllAssetBundles(false);
        abDict.Clear();
        mainAB = null;
        manifest = null;
    }
}
