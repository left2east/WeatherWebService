using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
public class FileRW
{
    private string _FilePath = "";
    /// <summary>
    /// 不定的某信文件的完整路径
    /// </summary>
    public string FilePath
    {
        get { return _FilePath; }
        set { _FilePath = value; }
    }
    private string _FileName = "";
    /// <summary>
    /// 在当前程序目录下的文件
    /// </summary>
    public string FileName
    {
        get { return _FileName; }
        set { _FileName = value; }
    }
    /// <summary>
    /// 获取一个文本文件的内容
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    public static string GetText(string filepath)
    {
        using (StreamReader reader = new StreamReader(filepath))
        {
            //string strLine = reader.ReadLine();
            return reader.ReadToEnd();
        }
    }
    /// <summary>
    /// 向指定的文本文件里写入信息
    /// </summary>
    /// <param name="filepath"></param>
    /// <param name="myStr"></param>
    public static void WriteText(string filepath, string myStr)
    {
        using (StreamWriter writer = new StreamWriter(filepath))
        {
            writer.WriteLine(myStr);
        }
    }
    /// <summary>
    /// 将指定信息写入程序日志（当前程序目示下的LOG文件夹内）
    /// </summary>
    /// <param name="sMsg"></param>
    public void WriteLog(string sMsg)
    {
        if (sMsg != "")
        {
            //Random randObj = new Random(DateTime.Now.Millisecond);
            //int file = randObj.Next() + 1;
            string filename = DateTime.Now.ToString("yyyyMMdd") + ".log";
            try
            {
                FileInfo fi = new FileInfo(_FilePath + filename);
                if (!fi.Exists)
                {
                    using (StreamWriter sw = fi.CreateText())
                    {
                        sw.WriteLine(DateTime.Now + "\n" + sMsg + "\n");
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = fi.AppendText())
                    {
                        sw.WriteLine(DateTime.Now + "\n" + sMsg + "\n");
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
    public bool WriteLine(string dataText)
    {

        FileStream fs = null;
        StreamWriter sw = null;
        bool ret = true;
        try
        {
            string FileName = _FilePath;
            //CHECK文件目录存在不   
            if (!Directory.Exists(FileName))
            {
                Directory.CreateDirectory(FileName);
            }
            FileName += "\\" + _FileName;
            //CHECK文件存在不   
            if (!File.Exists(FileName))
            {
                FileStream tempfs = File.Create(FileName);
                tempfs.Close();
            }
            fs = new FileStream(
                FileName,
                FileMode.Append,
                FileAccess.Write,
                FileShare.None);
            fs.Seek(0, System.IO.SeekOrigin.End);
            sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            sw.WriteLine(dataText);
            if (sw != null)
            {
                sw.Close();
                sw = null;
            }
            if (fs != null)
            {
                fs.Close();
                fs = null;
            }
        }
        catch (Exception)
        {
            ret = false;
        }
        finally
        {
            try
            {
                if (sw != null)
                {
                    sw.Close();
                    sw = null;
                }
                if (fs != null)
                {
                    fs.Close();
                    fs = null;
                }
            }
            catch
            {
            }
        }
        return ret;
    }
}