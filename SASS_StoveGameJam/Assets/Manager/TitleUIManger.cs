using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUIManger : MonoBehaviour
{

    public void ChangeStage(int stageidx)
    {
        SceneManager.LoadScene(stageidx);
    }
}
