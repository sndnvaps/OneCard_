using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using WindowsUI.WebMonitor.Model;

namespace WindowsUI.WebMonitor.Public
{
    public class XMLOperate
    {
        private string path = @"Monitor.xml";
        private XmlDocument xml;

        public XMLOperate()
        {
            initXML();
        }

        /// <summary>
        /// 初始XML对象
        /// </summary>
        private void initXML()
        {
            if(xml == null)
            {
                xml = new XmlDocument();
                xml.Load(path);
            }
        }

        private void SaveXML()
        {
            if(xml != null)
            {
                xml.Save(path);
            }
        }

        /// <summary>
        /// 获取所有ID列表
        /// </summary>
        /// <returns></returns>
        public List<MonitorBox> GetMonitorList()
        {
            List<MonitorBox> mbList = new List<MonitorBox>();

            try
            {
                //XmlNode root = xml.SelectSingleNode("/MonitorList");
                XmlNodeList nodeList = xml.SelectNodes("/MonitorList/Monitor");
                if (nodeList != null)
                {
                    foreach (XmlNode xnlist in nodeList)//遍历所有子节点 
                    {
                        MonitorBox mbInfo = new MonitorBox();

                        foreach (XmlNode xn in xnlist.ChildNodes)//遍历所有子节点 
                        {
                            XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 
                            
                            // mbInfo.Number = Int32.Parse(xe.GetAttribute("No"));
                            switch(xe.Name)
                            {
                                case "IP":
                                    mbInfo.IP = xe.InnerText;
                                    break;
                                case "Name":
                                    mbInfo.Name = xe.InnerText;
                                    break;
                                case "No":
                                    mbInfo.Number = xe.InnerText;
                                    break;
                                case "ID":
                                    mbInfo.ID = xe.InnerText;
                                    break;
                            }
                        }

                        mbInfo.Index = mbList.Count + 1;
                        mbList.Add(mbInfo);
                    }
                }
            }
            catch
            {

            }
            return mbList;
        }

        /// <summary>
        /// 保存IP
        /// </summary>
        /// <param name="info"></param>
        public void SaveMonitorInfo(MonitorBox info)
        {

            XmlNode root = xml.SelectSingleNode("MonitorList");//查找<Employees> 
            XmlElement xe1 = xml.CreateElement("Monitor");//创建一个<Node>节点 

            XmlElement xesub1 = xml.CreateElement("No");
            xesub1.InnerText = info.Number;//设置文本节点 
            xe1.AppendChild(xesub1);//添加到<Node>节点中 

            XmlElement xesub2 = xml.CreateElement("Name");
            xesub2.InnerText = info.Name;
            xe1.AppendChild(xesub2);

            XmlElement xesub3 = xml.CreateElement("IP");
            xesub3.InnerText = info.IP;
            xe1.AppendChild(xesub3);

            XmlElement xesub4 = xml.CreateElement("ID");
            xesub4.InnerText = Guid.NewGuid().ToString();
            xe1.AppendChild(xesub4);

            root.AppendChild(xe1);//添加到<Employees>节点中 

            SaveXML();
        }

        public void UpdateMonitorInfo(MonitorBox info)
        {
            try
            {
                XmlNodeList nodeList = xml.SelectNodes("/MonitorList/Monitor");
                if (nodeList != null)
                {
                    foreach (XmlNode xnlist in nodeList)//遍历所有子节点 
                    {
                        foreach (XmlNode xn in xnlist.ChildNodes)//遍历所有子节点 
                        {
                            XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 

                            // mbInfo.Number = Int32.Parse(xe.GetAttribute("No"));

                            if (xe.Name == "ID" && xe.InnerText == info.ID)
                            {
                                foreach (XmlNode eduitNode in xnlist.ChildNodes)
                                {
                                    XmlElement eduitxe = (XmlElement)eduitNode;

                                    switch (eduitxe.Name)
                                    {
                                        case "IP":
                                            eduitxe.InnerText = info.IP;
                                            break;
                                        case "Name":
                                            eduitxe.InnerText = info.Name;
                                            break;
                                        case "No":
                                            eduitxe.InnerText = info.Number;
                                            break;
                                    }
                                }
                                break;
                            }
                        }
                    }

                    SaveXML();
                } 
            }
            catch
            {

            }
        }

        public void DeleteMonitorInfo(MonitorBox info)
        {
            try
            {
                XmlNode root = xml.SelectSingleNode("MonitorList");

                XmlNodeList nodeList = xml.SelectNodes("/MonitorList/Monitor");
                if (nodeList != null)
                {
                    foreach (XmlNode xnlist in nodeList)//遍历所有子节点 
                    {
                        XmlElement xe1 = (XmlElement)xnlist;

                        foreach (XmlNode xn in xnlist.ChildNodes)//遍历所有子节点 
                        {
                            XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 

                            // mbInfo.Number = Int32.Parse(xe.GetAttribute("No"));

                            if (xe.Name == "ID" && xe.InnerText == info.ID)
                            {
                                root.RemoveChild(xnlist);
                            }
                        }
                    }

                    SaveXML();
                }
            }
            catch
            {

            }
        }
    }
}
