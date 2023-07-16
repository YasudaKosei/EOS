using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Security.Cryptography;
using System.Text;

public class RebindSaveManager : MonoBehaviour
{
    // �ΏۂƂȂ�InputActionAsset
    [SerializeField] private InputActionAsset _actionAsset;

    // �㏑�����̕ۑ�
    public void Save()
    {
        if (_actionAsset == null) return;

#if UNITY_EDITOR
        //UnityEditor��Ȃ�
        //Asset�t�@�C���̒���Save�t�@�C���̃p�X������
        string path = Application.dataPath + "/Save";

#else
        //�����łȂ����
        //.exe������Ƃ����Save�t�@�C�����쐬�������̃p�X������
        Directory.CreateDirectory("Save");
        string path = Directory.GetCurrentDirectory() + "/Save";

#endif

        //�Z�[�u�t�@�C���̃p�X��ݒ�
        string SaveFilePath = path + "/InputActionOverrides.bytes";

        // InputActionAsset�̏㏑�����̕ۑ�
        var json = _actionAsset.SaveBindingOverridesAsJson();

        // �������byte�z��ɕϊ�
        byte[] bytes = Encoding.UTF8.GetBytes(json);

        // AES�Í���
        byte[] arrEncrypted = AesEncrypt(bytes);

        // �w�肵���p�X�Ƀt�@�C�����쐬
        FileStream file = new FileStream(SaveFilePath, FileMode.Create, FileAccess.Write);

        // �t�@�C���ɕۑ�
        try
        {
            // �t�@�C���ɕۑ�
            file.Write(arrEncrypted, 0, arrEncrypted.Length);

        }
        finally
        {
            // �t�@�C�������
            if (file != null)
            {
                file.Close();
            }
        }

        Load();
    }

    // �㏑�����̓ǂݍ���
    public void Load()
    {
        if (_actionAsset == null) return;

#if UNITY_EDITOR
        //UnityEditor��Ȃ�
        //Asset�t�@�C���̒���Save�t�@�C���̃p�X������
        string path = Application.dataPath + "/Save";

#else
        //�����łȂ����
        //.exe������Ƃ����Save�t�@�C�����쐬�������̃p�X������
        Directory.CreateDirectory("Save");
        string path = Directory.GetCurrentDirectory() + "/Save";

#endif
        //�Z�[�u�t�@�C���̃p�X��ݒ�
        string SaveFilePath = path + "/InputActionOverrides.bytes";

        //�Z�[�u�t�@�C�������邩
        if (File.Exists(SaveFilePath))
        {
            //�t�@�C�����[�h���I�[�v���ɂ���
            FileStream file = new FileStream(SaveFilePath, FileMode.Open, FileAccess.Read);
            try
            {
                // �t�@�C���ǂݍ���
                byte[] arrRead = File.ReadAllBytes(SaveFilePath);

                // ������
                byte[] arrDecrypt = AesDecrypt(arrRead);

                // byte�z��𕶎���ɕϊ�
                string decryptStr = Encoding.UTF8.GetString(arrDecrypt);

                // InputActionAsset�̏㏑������ݒ�
                _actionAsset.LoadBindingOverridesFromJson(decryptStr);

            }
            finally
            {
                // �t�@�C�������
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        else
        {
            Debug.Log("�Z�[�u�t�@�C��������܂���");
        }
    }


    /// <summary>
    ///  AesManaged�}�l�[�W���[���擾
    /// </summary>
    /// <returns></returns>
    private AesManaged GetAesManager()
    {
        //�C�ӂ̔��p�p��16����(Read.cs�Ɠ������)
        string aesIv = "6325424674315321";
        string aesKey = "4328689359652135";

        AesManaged aes = new AesManaged();
        aes.KeySize = 128;
        aes.BlockSize = 128;
        aes.Mode = CipherMode.CBC;
        aes.IV = Encoding.UTF8.GetBytes(aesIv);
        aes.Key = Encoding.UTF8.GetBytes(aesKey);
        aes.Padding = PaddingMode.PKCS7;
        return aes;
    }

    /// <summary>
    /// AES�Í���
    /// </summary>
    /// <param name="byteText"></param>
    /// <returns></returns>
    public byte[] AesEncrypt(byte[] byteText)
    {
        // AES�}�l�[�W���[�̎擾
        AesManaged aes = GetAesManager();
        // �Í���
        byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return encryptText;
    }

    /// <summary>
    /// AES������
    /// </summary>
    /// <param name="byteText"></param>
    /// <returns></returns>
    public byte[] AesDecrypt(byte[] byteText)
    {
        // AES�}�l�[�W���[�擾
        var aes = GetAesManager();
        // ������
        byte[] decryptText = aes.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return decryptText;
    }

    //�Z�[�u�f�[�^�폜
    public void Init()
    {
#if UNITY_EDITOR
        //UnityEditor��Ȃ�
        //Asset�t�@�C���̒���Save�t�@�C���̃p�X������
        string path = Application.dataPath + "/Save";

#else
        //�����łȂ����
        //.exe������Ƃ����Save�t�@�C�����쐬�������̃p�X������
        Directory.CreateDirectory("Save");
        string path = Directory.GetCurrentDirectory() + "/Save";

#endif

        //�t�@�C���폜
        File.Delete(path + "/InputActionOverrides.bytes");

        //�����[�h
        Load();

        Debug.Log("�f�[�^�̍폜���I���܂���");
    }
}