using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AutoLogInShadowsocks
{
    public static class GeneralTool
    {

        public static Dictionary<string, string> parsePageInfo(string content)
        {
            string[] lst;
            Dictionary<string, string> dicArray = new Dictionary<string, string>();

            string replaceText = content.Replace("<span>", "：").Replace("</span>", "：").Replace("<b>", "：").Replace("</b>", "：").Replace("<br>", "：").Replace("\n\t", "：");//将读取信息中的非实用数据用：替代

            lst = replaceText.Split('：');//将信息字符中以：分割到字符串数组中
            lst = lst.Where(s => !string.IsNullOrEmpty(s)).ToArray();//lambda语法，好爽     将解析后的字符串数组中为空的项去掉
            for (int i = 0; i < lst.Length; i = i + 2)
            {
                dicArray.Add(lst[i], lst[i + 1]);//将解析后的字符串按照Dictionary<string, string>结构存储，方便之后使用
            }
            return dicArray;
        }

        public static void modifyServerInfo(string path, Dictionary<string, string> listinfo)
        {
            try
            {
                string proName = "Shadowsocks";
                foreach (Process pro in Process.GetProcessesByName(proName))
                {
                    if (!pro.CloseMainWindow())
                    {
                        pro.Kill();
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            byte[] pageInfo = new byte[1024];//写死了1024大小是个弊端，不过文件大小小于1K，可以接受
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);//打开文件流，当文件不存在时用create所以是FileMode.OpenOrCreate

            int isReadEnd = fs.Read(pageInfo, 0, 1024);//将文件信息读取到pageInfo数组中
            if (isReadEnd > 0)//如果文件里有内容
            {
                StringBuilder modifiedData = new StringBuilder();//节省开销的字符串类型
                fs.Close();//关闭文件
                fs.Dispose();
                fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);//关闭再打开是为了重写文件信息而不是添加
                string configData = System.Text.Encoding.Default.GetString(pageInfo);//byte[]类型转成字符串类型
                
                int pos = configData.IndexOf("server");
                modifiedData.Append(configData.Substring(0, pos - 1));
                modifiedData.Append("\"server\" : \"" + listinfo["服务器IP"] + "\", \r\n\"server_port\" : " + listinfo["端口"] + ", \r\n\"password\" : \"" + listinfo["密码"] + "\",\r\n");
                pos = configData.IndexOf("method");
                modifiedData.Append(configData.Substring(pos - 1, configData.IndexOf("enabled") - 1 - (pos - 1)));
                modifiedData.Append("\"enabled\" : true,\r\n");
                pos = configData.IndexOf("shareOverLan");
                modifiedData.Append(configData.Substring(pos - 1, configData.IndexOf("false}") + 6 - (pos - 1)));//重写文件信息的思路是取得原文件信息的头和尾，将中间的部分用解析后的内容按照原格式填写上

                fs.Flush();
                fs.Write(System.Text.Encoding.Default.GetBytes(modifiedData.ToString().ToCharArray()), 0, modifiedData.Length);//写入文件，其中将StringBuilder类型转换成byte[]类型为关键
                fs.Close();
                fs.Dispose();
            }
            else//如果不存在该文件，则自动创建配置文件，配置文件内容按照取头取尾方法创建，与上面的读取也相似，只不过如果未来文件格式有修改，上面的形式更不容易出现错误
            {
                StringBuilder modifiedData = new StringBuilder();
                modifiedData.Append("{\r\n\"configs\" : [\r\n{\r\n");
                modifiedData.Append("\"server\" : \"" + listinfo["服务器IP"] + "\", \r\n\"server_port\" : " + listinfo["端口"] + ", \r\n\"password\" : \"" + listinfo["密码"] + "\",\r\n");
                modifiedData.Append("\"method\" : \"aes-256-cfb\",\r\n\"remarks\" : \"\"}],\r\n\"strategy\" : null,\r\n\"index\" : 0,\r\n\"global\" : false,\r\n\"enabled\" : true,\r\n\"shareOverLan\" : false,\r\n\"isDefault\" : false,\r\n\"localPort\" : 1080,\r\n\"pacUrl\" : null,\r\n\"useOnlinePac\" : false}\r\n");

                fs.Write(System.Text.Encoding.Default.GetBytes(modifiedData.ToString().ToCharArray()), 0, modifiedData.Length);
                fs.Close();
                fs.Dispose();
            }

            System.Diagnostics.Process.Start(path.Replace("gui-config.json", "Shadowsocks.exe"));//启动系统中的Shadowsocks.exe程序

        }
    }
}
