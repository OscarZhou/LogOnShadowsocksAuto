using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Windows;

namespace AutoLogInShadowsocks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        } 
    }

    public partial class Form1 : Form
    {
        bool firstNav = true;//WebBrowser首次导向的标志
        Dictionary<string, string> listInfo = new Dictionary<string, string>();//存储解析后的服务器信息


        /** 
           获取 shadowsocks 的路径，路径名用于之后将IP地址等数据挂接到软件上 
        **/
        private void btn_path_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();//创建文件窗口类
            openfile.Filter = "*.exe文件|*.exe";

            DialogResult result = openfile.ShowDialog();//显示窗口，为用户选择
            if (result == DialogResult.OK)
            {
                int pos = openfile.FileName.IndexOf("Shadowsocks.exe");
                if (pos < 0)
                {
                    MessageBox.Show("请选择指定程序");
                }
                else
                {
                    lb_path.Text = openfile.FileName.ToString();//将选择文件路径显示到文件路径标签上
                }
            }
        }


        /** 
            导向shadowsocks的官网，获取页面信息 
        **/
        private void btn_matching_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(lb_path.Text))
            {
                MessageBox.Show("请先选择Shadowsocks.exe文件，再进行匹配");
            }
            else
            {
                webbrowser.Navigate("http://www.shadowsocksgo.com/page/testss.html");//WebBrowser控件的实例导向页面
                firstNav = true;
            }
        }


        /** 
            获取页面信息之后触发的事件
         * 
        **/
        private void webbrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (firstNav)//此事件在navigate到页面后，会多次调用，所以用firstNav限制访问次数
            {
                string ipInfo = webbrowser.Document.Body.All[86].InnerHtml.Trim();//选中页面中第一组IP信息，86为根据页面元素查找出的，这块是个缺点，无法根据html代码自动搜查
                listInfo = GeneralTool.parsePageInfo(ipInfo);//解析

                if (listInfo["测试节点"].Contains("美国"))//如果是美国的测试IP，则为首选
                {
                    lb_content.Text = "Server IP: " + listInfo["服务器IP"] + "\t\nPort: " + listInfo["端口"] + "\t\nPassword: " + listInfo["密码"];
                    GeneralTool.modifyServerInfo(lb_path.Text.Replace("Shadowsocks.exe", "gui-config.json"), listInfo);//修改配置文件
                }
                else
                {
                    ipInfo = webbrowser.Document.Body.All[94].InnerHtml.Trim();//选中页面中第二组IP信息，86为根据页面元素查找出的，这块是个缺点，无法根据html代码自动搜查
                    listInfo = GeneralTool.parsePageInfo(ipInfo);//解析
                    lb_content.Text = "Server IP: " + listInfo["服务器IP"] + "\t\nPort: " + listInfo["端口"] + "\t\nPassword: " + listInfo["密码"];
                    GeneralTool.modifyServerInfo(lb_path.Text.Replace("Shadowsocks.exe", "gui-config.json"), listInfo);//修改配置文件
                }

                firstNav = false;
            }
        }
    }
}
