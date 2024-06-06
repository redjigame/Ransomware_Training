using System.Xml.Linq;

namespace Ransomware_Training;

public class SecurityManager
{
    public static string ReadDirFromXml()
    {
        try
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "status.xml");

            if (File.Exists(filePath))
            {
                XDocument doc = XDocument.Load(filePath);
                XElement dirElement = doc.Element("config")?.Element("encryptionSettings")?.Element("dir");

                if (dirElement != null)
                {
                    return dirElement.Value;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading dir from XML: {ex.Message}");
        }

        // Default value if dir is not found or an error occurs
        return "null";
    }

    public static string ReadEncryptionPasswordFromXml()
    {
        try
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "status.xml");

            if (File.Exists(filePath))
            {
                XDocument doc = XDocument.Load(filePath);
                XElement passwordElement = doc.Element("config")?.Element("encryptionSettings")?.Element("encryptionPassword");

                if (passwordElement != null)
                {
                    return passwordElement.Value;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading encryption password from XML: {ex.Message}");
        }

        // Default value if encryptionPassword is not found or an error occurs
        return "";
    }

    public static string ReadPassword(string prompt)
    {
        Console.Write(prompt);
        string password = string.Empty;
        ConsoleKey key;

        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && password.Length > 0)
            {
                Console.Write("\b \b");
                password = password[0..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                password += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }

    public static bool ReadStatusFromXml(string statusName)
    {
        try
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "status.xml");

            if (File.Exists(filePath))
            {
                XDocument doc = XDocument.Load("status.xml");
                XElement element = doc.Element("config")?.Element("status");

                if (element != null)
                {
                    return bool.Parse(element.Attribute(statusName)?.Value ?? "false");
                }
            }
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error reading status from XML: {ex.Message}");
        }

        return false;
    }

    public static void UpdateStatusInXml(string statusName, bool statusValue)
    {
        try
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "status.xml");

            XDocument doc;
            XElement element;

            if (File.Exists(filePath))
            {
                doc = XDocument.Load(filePath);
                element = doc.Element("config")?.Element("status");
            }
            else
            {
                element = new XElement("status");
                doc = new XDocument(new XElement("config", element));
            }

            if (element != null)
            {
                element.SetAttributeValue(statusName, statusValue);
                doc.Save(filePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating status in XML: {ex.Message}");
        }
    }
}
