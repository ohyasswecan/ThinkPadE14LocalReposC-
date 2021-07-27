using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PracticeGameDigitalTechnologyVer1._4
{
    //此文件用于加载初始化xml文件以及处理xml数据的更新和编写
    class XmlEditor
    {
        XmlDocument xmlDocument = new XmlDocument();
        //Tuple is a new function after C# 4.0, which is very powerful, even though this function was inspired by python.......
        public Tuple<int,int> XmlReader(string gamename)//gamename specify the game you want to pick. XMLReader函数仅用于上传单个游戏的记录到实体类
        {
            xmlDocument.Load(@"..\..\GameRecord.xml");
            XmlNode xmlNode = xmlDocument.SelectSingleNode("gamerecord");//{0} as place holder to accept us to read content from specified place.
            XmlNodeList gameList = xmlNode.ChildNodes;
            GameRecord gameRecord = new GameRecord();
            foreach(XmlNode data in gameList)
            {
                XmlElement xmlElement = (XmlElement)data;
                if(xmlElement.GetAttribute("name") != gamename)
                {
                    continue;
                }
                else
                {
                    XmlNodeList gameData = xmlElement.ChildNodes;
                   foreach(XmlNode Data in gameData)
                    {
                        if(Data.Name == "death")
                        {
                            gameRecord.Death = Convert.ToInt32(Data.InnerText);
                        }
                        else if(Data.Name == "score")
                        {
                            gameRecord.Score = Convert.ToInt32(Data.InnerText);
                        }
                    }
                }
            }
            return Tuple.Create(gameRecord.Death, gameRecord.Score);//Using Tuple to return multiple values.
            
        }
        public object XmlWriter(string gamename,int scoreAdding,int deathNum)
        {
            xmlDocument.Load(@"..\..\GameRecord.xml");
            XmlNode xmlNode = xmlDocument.SelectSingleNode("gamerecord");//firstchild is xml data value instead of element
            XmlNodeList gameList = xmlNode.ChildNodes;
            GameRecord gameRecord = new GameRecord();
            foreach (XmlNode data in gameList)//The code in this part is gross , need more improvement
            {
                XmlElement xmlElement = (XmlElement)data;//元素化是对其所包含的元素列表化的必须过程
                if(xmlElement.GetAttribute("name") != gamename)
                {
                    continue;
                }
                else
                {
                    XmlNodeList gameData = xmlElement.ChildNodes;
                    foreach(XmlNode Data in gameData)
                    {
                        if(Data.Name == "death")
                        {
                           if(gamename == "pennygame")//need add a new death func for pennygame
                            {
                                Data.InnerText = Convert.ToString(deathNum);
                                gameRecord.Death = deathNum;
                                continue;
                            }
                            int death = Convert.ToInt32(Data.InnerText);
                            death += deathNum;
                            Data.InnerText = Convert.ToString(death);
                            gameRecord.Death = death; 
                        }
                        else if(Data.Name == "score")
                        {
                            int score = Convert.ToInt32(Data.InnerText);
                            if(scoreAdding > score)
                            {
                                score = scoreAdding;
                            }
                            Data.InnerText = Convert.ToString(score);
                            gameRecord.Score = score;
                        }
                    }
                }
                xmlDocument.Save(@"..\..\GameRecord.xml");
            }
            return gameRecord;//return result
        }

    }
}
