using System.Collections.Generic;

namespace testConsoleApplication1
{
    internal class Program
    {
        public static Dictionary<string, string> dictionary = new Dictionary<string, string>();

        private static void Main(string[] args)
        {
            string get_group_name_list_mask2Result =
                "{\"retcode\":0,\"result\":{\"gmasklist\":[{\"gid\":1000,\"mask\":0},{\"gid\":1236893932,\"mask\":0},{\"gid\":3752743143,\"mask\":0},{\"gid\":611650738,\"mask\":0},{\"gid\":73197273,\"mask\":0},{\"gid\":3350534774,\"mask\":0},{\"gid\":136274113,\"mask\":0},{\"gid\":4132498485,\"mask\":0},{\"gid\":3626173745,\"mask\":0},{\"gid\":845269773,\"mask\":0},{\"gid\":2296556148,\"mask\":0},{\"gid\":3014301433,\"mask\":0},{\"gid\":129691598,\"mask\":0},{\"gid\":312585024,\"mask\":0},{\"gid\":3205160744,\"mask\":0},{\"gid\":957676861,\"mask\":0},{\"gid\":994522,\"mask\":0},{\"gid\":1694278600,\"mask\":0},{\"gid\":417312414,\"mask\":0},{\"gid\":4031230010,\"mask\":0},{\"gid\":1820338895,\"mask\":0},{\"gid\":1859419260,\"mask\":2},{\"gid\":2970213718,\"mask\":2},{\"gid\":51060196,\"mask\":0},{\"gid\":699480889,\"mask\":0},{\"gid\":3736118761,\"mask\":0}],\"gnamelist\":[{\"flag\":16777217,\"name\":\"大良业余足球俱乐部\",\"gid\":3014301433,\"code\":2877023123},{\"flag\":1048593,\"name\":\"电子商务设计师群\",\"gid\":4177629741,\"code\":3172960774},{\"flag\":16777217,\"name\":\"计应071通知群\",\"gid\":3736118761,\"code\":1530968776},{\"flag\":16778257,\"name\":\".NET学习交流一群\",\"gid\":2587861919,\"code\":318091396},{\"flag\":184550417,\"name\":\"ASP.NET MVC\",\"gid\":3352053507,\"code\":1655802395},{\"flag\":184550417,\"name\":\"DTcms技术1群\",\"gid\":1859419260,\"code\":3360128402},{\"flag\":16777233,\"name\":\"初三（2）班\",\"gid\":51060196,\"code\":20062231},{\"flag\":16777217,\"name\":\"佛警七中队\",\"gid\":76874640,\"code\":4173471951},{\"flag\":16777217,\"name\":\"广轻澄海071\",\"gid\":2970213718,\"code\":3957302348},{\"flag\":16778257,\"name\":\"天天团购网09\",\"gid\":3626173745,\"code\":1309749271},{\"flag\":16777217,\"name\":\"曾是(貳、叁)班\",\"gid\":957676861,\"code\":2240470181},{\"flag\":16778257,\"name\":\"计算机071\",\"gid\":699480889,\"code\":2323714431},{\"flag\":185598993,\"name\":\"网鸟-刺客巅峰\",\"gid\":3845367827,\"code\":610648917},{\"flag\":16777217,\"name\":\"IT的彼岸\",\"gid\":994522,\"code\":1507722536},{\"flag\":17826817,\"name\":\"IT技术群\",\"gid\":1694278600,\"code\":3570418289},{\"flag\":16777217,\"name\":\"新基路小学\",\"gid\":4031230010,\"code\":3381048432},{\"flag\":16778241,\"name\":\"锦之鑫VIP会员②群\",\"gid\":1820338895,\"code\":193849077},{\"flag\":16777217,\"name\":\"广轻计算机科技部\",\"gid\":129691598,\"code\":4043731022},{\"flag\":16777217,\"name\":\"紫莹\",\"gid\":417312414,\"code\":1387738177},{\"flag\":16777217,\"name\":\"C#高级群\",\"gid\":312585024,\"code\":2245384418},{\"flag\":16777217,\"name\":\"10届顺德就业指导群4\",\"gid\":611650738,\"code\":859314631},{\"flag\":17825793,\"name\":\"广轻音频\",\"gid\":3205160744,\"code\":4281703127},{\"flag\":1,\"name\":\"计算机技术交流群\",\"gid\":845269773,\"code\":2993365158},{\"flag\":16777217,\"name\":\"momoka\",\"gid\":2338287231,\"code\":1401705744},{\"flag\":1025,\"name\":\"魔兽群\",\"gid\":3350534774,\"code\":3830598088},{\"flag\":1041,\"name\":\"ASP.NET交流群\",\"gid\":136274113,\"code\":1126180925},{\"flag\":1,\"name\":\"宇平大魔王与小弟们\",\"gid\":90743358,\"code\":1746459988},{\"flag\":16778257,\"name\":\"Q协网3号群\",\"gid\":2702939300,\"code\":3761643247},{\"flag\":1049617,\"name\":\"LOL杀手群\",\"gid\":2296556148,\"code\":673248719},{\"flag\":1,\"name\":\"『 ゞ驚歎號℡』 \",\"gid\":2997118971,\"code\":2461203819},{\"flag\":1,\"name\":\"休闲③\",\"gid\":4186867721,\"code\":3596102798},{\"flag\":184549393,\"name\":\"顺-雇员总群\",\"gid\":1725601248,\"code\":1649249320},{\"flag\":1090519041,\"name\":\"启超科技\",\"gid\":2253501055,\"code\":1740259256},{\"flag\":16777217,\"name\":\"硬伤团\",\"gid\":1244358192,\"code\":29731725}],\"gmarklist\":[]}}";

            int group_name_list_begin = get_group_name_list_mask2Result.LastIndexOf("gnamelist");
            int group_name_list_end = get_group_name_list_mask2Result.LastIndexOf("gmarklist");

            string markNames = get_group_name_list_mask2Result.Substring(group_name_list_begin + 12,
                group_name_list_end - group_name_list_begin - 15);
            get_group_name_list(markNames);
        }

        public static void get_group_name_list(string group_name_list)
        {
            int pos1 = group_name_list.LastIndexOf("{");
            if (pos1 < 1)
                return;
            string name = getQqNumStr(group_name_list, "name", "gid");
            string code = getQqNumStr(group_name_list, "code", "}");
            dictionary.Add(name, code);
            string sub = group_name_list.Substring(0, pos1 - 1);
            get_group_name_list(sub);
        }

        public static string getQqNumStr(string src, string begin, string end)
        {
            int pos1 = src.LastIndexOf(begin);
            int pos2 = src.LastIndexOf(end);
            string str = src.Substring(pos1 + begin.Length + 2, pos2 - pos1 - (begin.Length + 2));
            return str;
        }
    }
}