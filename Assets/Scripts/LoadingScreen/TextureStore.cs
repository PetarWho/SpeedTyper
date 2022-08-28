using UnityEngine;

public class TextureStore : MonoBehaviour
{
    public static void WriteTextureToPlayerPrefs (string tag, Texture2D tex)
    {
        // if texture is png otherwise you can use tex.EncodeToJPG().
        byte[] texByte = tex.EncodeToPNG ();

        // convert byte array to base64 string
        string base64Tex = System.Convert.ToBase64String (texByte);

        // write string to playerpref
        PlayerPrefs.SetString (tag, base64Tex);
        PlayerPrefs.Save ();
    }

    public static Texture2D ReadTextureFromPlayerPrefs (string tag)
    {
        // load string from playerpref
        string base64Tex = PlayerPrefs.GetString (tag, null);

        if (!string.IsNullOrEmpty (base64Tex)) {
            // convert it to byte array
            byte[] texByte = System.Convert.FromBase64String (base64Tex);
            Texture2D tex = new Texture2D (2, 2);

            //load texture from byte array
            if (tex.LoadImage (texByte)) {
                return tex;
            }
        }

        return null;
    }
}
