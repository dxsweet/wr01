using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Collections.Generic;




namespace wr01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            string dir1 = textBox6.Text.Trim();
            string[] arr = new string[] { };
            List<string> list1 = new List<string>(arr);



            if (checkBox1.Checked == true)
            {
                if (!Directory.Exists(dir1 + "\\weatherchart-h000"))
                {
                    Directory.CreateDirectory(dir1 + "\\weatherchart-h000");
                }

                list1.Add("http://www.nmc.cn/publish/observations/china/dm/weatherchart-h000.htm");
            }

            if (checkBox2.Checked == true)
            {
                if (!Directory.Exists(dir1 + "\\FY4A-infrared"))
                {
                    Directory.CreateDirectory(dir1 + "\\FY4A-infrared");
                }
                list1.Add("http://www.nmc.cn/publish/satellite/FY4A-infrared.htm");
            }

            if (checkBox3.Checked == true)
            {
                if (!Directory.Exists(dir1 + "\\chinaall"))
                {
                    Directory.CreateDirectory(dir1 + "\\chinaall");
                }
                //  list1.Add("http://www.nmc.cn/publish/radar/chinaall.html");



                int startHour = Convert.ToInt32(textBox4.Text);
                int endHour = Convert.ToInt32(textBox5.Text);

                string strpic;

                for (int i = startHour; i < endHour; i++)
                {
                    for (int j = 0; j <= 54; j += 6)
                    {
                        strpic = "http://image.nmc.cn/product/" + textBox1.Text + "/" + textBox2.Text.PadLeft(2, '0') + "/" + textBox3.Text.PadLeft(2, '0') + "/RDCP/medium/SEVP_AOC_RDCP_SLDAS_EBREF_ACHN_L88_PI_" + textBox1.Text + textBox2.Text.PadLeft(2, '0') + textBox3.Text.PadLeft(2, '0') + i.ToString().PadLeft(2, '0') + j.ToString().PadLeft(2, '0') + "00001.PNG";

                        // MessageBox.Show(strpic);
                        SaveAsWebImg(strpic, dir1 + "\\chinaall");
                    }
                }





            }

            if (checkBox4.Checked == true)
            {
                if (!Directory.Exists(dir1 + "\\huazhong"))
                {
                    Directory.CreateDirectory(dir1 + "\\huazhong");
                }
                // list1.Add("http://www.nmc.cn/publish/radar/huazhong.html");


                int startHour = Convert.ToInt32(textBox4.Text);
                int endHour = Convert.ToInt32(textBox5.Text);

                string strpic;

                for (int i = startHour; i < endHour; i++)
                {
                    for (int j = 0; j <= 54; j += 6)
                    {
                        strpic = "http://image.nmc.cn/product/" + textBox1.Text + "/" + textBox2.Text.PadLeft(2, '0') + "/" + textBox3.Text.PadLeft(2, '0') + "/RDCP/SEVP_AOC_RDCP_SLDAS_EBREF_ACCN_L88_PI_" + textBox1.Text + textBox2.Text.PadLeft(2, '0') + textBox3.Text.PadLeft(2, '0') + i.ToString().PadLeft(2, '0') + j.ToString().PadLeft(2, '0') + "00001.PNG";

                        //MessageBox.Show(strpic);

                        SaveAsWebImg(strpic, dir1 + "\\huazhong");
                    }
                }

            }
            if (checkBox5.Checked == true)
            {
                if (!Directory.Exists(dir1 + "\\seaplatform1"))
                {
                    Directory.CreateDirectory(dir1 + "\\seaplatform1");
                }
                list1.Add("http://www.nmc.cn/publish/sea/seaplatform1.html");
            }
            if (checkBox6.Checked == true)
            {
                if (!Directory.Exists(dir1 + "\\changsha"))
                {
                    Directory.CreateDirectory(dir1 + "\\changsha");
                }
                list1.Add("http://www.nmc.cn/publish/station/hour/changsha.html");


            }
            if (checkBox7.Checked == true)
            {
                if (!Directory.Exists(dir1 + "\\changsha"))
                {
                    Directory.CreateDirectory(dir1 + "\\changsha");
                }

                list1.Add("http://www.nmc.cn/publish/station/rhtw/changsha.html");


            }

            if (checkBox8.Checked == true)
            {
                if (!Directory.Exists(dir1 + "\\weatherchart-h925"))
                {
                    Directory.CreateDirectory(dir1 + "\\weatherchart-h925");
                }
                list1.Add("http://www.nmc.cn/publish/observations/china/dm/weatherchart-h925.htm");
            }

            if (checkBox9.Checked == true)
            {
                if (!Directory.Exists(dir1 + "\\weatherchart-h850"))
                {
                    Directory.CreateDirectory(dir1 + "\\weatherchart-h850");
                }
                list1.Add("http://www.nmc.cn/publish/observations/china/dm/weatherchart-h850.htm");
            }

            if (checkBox10.Checked == true)
            {
                if (!Directory.Exists(dir1 + "\\weatherchart-h700"))
                {
                    Directory.CreateDirectory(dir1 + "\\weatherchart-h700");
                }
                list1.Add("http://www.nmc.cn/publish/observations/china/dm/weatherchart-h700.htm");
            }

            if (checkBox11.Checked == true)
            {
                if (!Directory.Exists(dir1 + "\\weatherchart-h500"))
                {
                    Directory.CreateDirectory(dir1 + "\\weatherchart-h500");
                }
                list1.Add("http://www.nmc.cn/publish/observations/china/dm/weatherchart-h500.htm");
            }

            arr = list1.ToArray();

            foreach (string url1 in arr)
            {

                if (url1 == "" || dir1 == "")
                {
                    MessageBox.Show("请输入网址和图片保存地址");
                }

                else
                {

                    string str = GetHtmlStr(url1);

                    string regstr = "http://image.nmc.cn/product/.+?.(PNG|png|jpg|JPG)";

                    string[] substrings1 = url1.Split('/');
                    string substringh = substrings1[substrings1.Length - 1];
                    string[] subdirs = substringh.Split('.');
                    string subdir = subdirs[0];


                    String dir2 = dir1 + "\\" + subdir;

                    foreach (Match match in Regex.Matches(str, regstr))
                    {
                        //使用正则表达式解析网页文本，获得图片地址     

                        //下载图片
                        SaveAsWebImg(match.Value, dir2);

                    }


                }
            }
            MessageBox.Show("下载完毕");
            Application.DoEvents();
            button1.Enabled = true;


        }

        /// 获取网页的HTML码  
        /// <param name="url">链接地址</param>  


        public static string GetHtmlStr(string url)
        {
            string httpStr = "";
            if (!String.IsNullOrEmpty(url))
            {

                HttpClient client = new HttpClient();
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        httpStr = content.ReadAsStringAsync().Result;
                    }

                }

                return httpStr;
            }
            else
            {
                return "";
            }


        }


        /// 下载网站图片 
        /// <param name="picUrl"></param> 
        /// <returns></returns> 
        public static async void SaveAsWebImg(string picUrl, string path)
        {


            try
            {
                //判断图片是否为空或者null
                if (!String.IsNullOrEmpty(picUrl))
                {

                    //文件名
                    string[] urlstra = picUrl.Split('/');
                    string fileName = urlstra[urlstra.Length - 1];

                    using var hClient = new HttpClient();
                    hClient.Timeout = TimeSpan.FromSeconds(5);
                    byte[] imageBytes = await hClient.GetByteArrayAsync(picUrl);
                    File.WriteAllBytes(path + "\\" + fileName, imageBytes);

                    //webClient.DownloadFile(picUrl, path + "\\" + fileName);
              

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("下载有误");
            }

        }
    }



}