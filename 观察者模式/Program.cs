using System;
using System.Collections.Generic;

namespace 观察者模式
{
    internal class Program
    {
        //报纸接口
        private static void Main(string[] args)
        {
            var paper = new PeopleNewsPaper();
            var xiaoMing = new SubHuman("小明");
            var zhaoYun = new SubHuman("赵云");
            var liuBei = new SubHuman("刘备");
            paper.RegisterSubscriber(xiaoMing); //小明订报
            paper.RegisterSubscriber(zhaoYun); //赵云订报
            paper.RegisterSubscriber(liuBei); //刘备订报
            paper.SendPaper(); //有新报纸了
            Console.WriteLine("---------------发完报纸了------------------");
            paper.RemoveSubScriber(xiaoMing); //小明不想订了，取消报纸
            paper.SendPaper(); //又有新报纸了  就没有小明的报纸 了
            Console.ReadLine();
        }

        public interface INewsPaper
        {
            void RegisterSubscriber(ISubScribe fSubScribe); //添加订阅者
            void RemoveSubScriber(ISubScribe fSubScribe); //取消订阅
            void SendPaper(); //发送报纸
        }

        public interface ISubScribe
        {
            void HasNewPaper(); //有新的报纸了就会被执行通知
        }

        public class PeopleNewsPaper : INewsPaper
        {
            private readonly List<ISubScribe> _subList = new List<ISubScribe>(); //容器 

            public void RegisterSubscriber(ISubScribe fSubScribe)
            {
                _subList.Add(fSubScribe);
            }

            public void RemoveSubScriber(ISubScribe fSubScribe)
            {
                if (_subList.IndexOf(fSubScribe) >= 0)
                {
                    _subList.Remove(fSubScribe);
                }
            }

            public void SendPaper()
            {
                foreach (var sub in _subList)
                {
                    sub.HasNewPaper();
                }
            }
        }

        public class SubHuman : ISubScribe
        {
            private readonly string _pName;

            public SubHuman(string fName)
            {
                _pName = fName;
            }

            public void HasNewPaper()
            {
                Console.WriteLine(_pName + "!! 有新的报纸了，请查收！");
            }
        }
    }
}