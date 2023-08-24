using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColliderAvatar : MonoBehaviour
{
    public GameObject bangkit;
    public GameObject tult;
    public GameObject fik;
    public GameObject fit;
    public GameObject fkb;
    public GameObject feb;
   
    public void Back()
    {
        fit.SetActive(false);
        fik.SetActive(false);
        fkb.SetActive(false);
        feb.SetActive(false);
        tult.SetActive(false);
        bangkit.SetActive(false);
    }
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "FIT")
        {
            fit.SetActive(true);
            Debug.Log(collision.gameObject.tag);
        }
        else if (collision.gameObject.tag == "FIK")
        {
            fik.SetActive(true);
            Debug.Log(collision.gameObject.tag);
        }
        else if (collision.gameObject.tag == "Bangkit")
        {
            bangkit.SetActive(true);
        }
        else if (collision.gameObject.tag == "FKB")
        {
            fkb.SetActive(true);
            Debug.Log(collision.gameObject.tag);
        }
        else if (collision.gameObject.tag == "FEB")
        {
            feb.SetActive(true);
            Debug.Log(collision.gameObject.tag);
        }
        else if (collision.gameObject.tag == "TULT")
        {
            tult.SetActive(true);
        }
    }
    public void OpenBangkit()
    {
        Application.OpenURL("https://ar.blippar.com/pog1985xnes749m250c1f9nfrx1ct0immqfpdqrc");
    }
    public void OpenFIT()
    {
        Application.OpenURL("https://ar.blippar.com/1gd3w0xxtbx7zu9fusaex29mdug4zh5ojb7e40v9");
    }
    public void OpenFIK()
    {
        Application.OpenURL("https://ar.blippar.com/quom070gu6krb404hzcaqw3v23llsp6wjbjmoz8m");
    }
    public void OpenFKB()
    {
        Application.OpenURL("https://ar.blippar.com/zh0o2vrk8jya8l01gtricxbyvhsgdbw63xkewps1");
    }
    public void OpenFEB()
    {
        Application.OpenURL("https://ar.blippar.com/lgcjtqfizrd24yjrm69mi30pwuwygs5hnd8prizc");
    }
    public void OpenTult()
    {
        Application.OpenURL("https://ar.blippar.com/idlhg0j9s9r73bfsjeb29d95srwk421y347cfv2z");
    }
}
