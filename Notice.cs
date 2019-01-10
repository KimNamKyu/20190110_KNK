using System;
using MySql.Data.MySqlClient;
using System.Collections;
using _20190110_KNK;

namespace _20190110_KNK.Modules
{
    public class Test
    {
        // public string id{set;get;}
        // public string name{set;get;}
        // public string passwd{set;get;}
        public string nNo{set; get;}
        public string nTitle{set; get;}
        public string nContents{set; get;}
    }

    public class Query
    {
        public static ArrayList GetSelect()
        {
            MYsql my = new MYsql();
            string sql = string.Format("select * from Notice where delYn = 'N';");
            MySqlDataReader sdr = my.Reader(sql);

            ArrayList list = new ArrayList();   //string 이 아닌 배열 형식으로 
            while(sdr.Read())
            {
                Hashtable ht = new Hashtable();
                for(int i = 0; i< sdr.FieldCount; i++)
                {
                    ht.Add(sdr.GetName(i),sdr.GetValue(i));
                }
                list.Add(ht);
            }
            return list;
        }
        public static ArrayList Getinsert(Test test)
        {
            MYsql my = new MYsql();
            string sql = string.Format("insert into Notice (nTitle,nContents) values ('{0}','{1}');",test.nTitle,test.nContents);
            if(my.NonQuery(sql))
            {
                return GetSelect();
            }
            else
            {
                return new ArrayList();
            }
        }

        public static ArrayList GetUpdate(Test test)
        {
            MYsql my = new MYsql();
            string sql = string.Format("update Notice set nTitle = '{1}', nContents = '{2}' where nNo = {0};",test.nNo,test.nTitle,test.nContents);
            if(my.NonQuery(sql))
            {
                return GetSelect();
            }
            else
            {
                return new ArrayList();
            }
    }
        public static ArrayList GetDelete(Test test)
        {
            MYsql my = new MYsql();
            string sql = string.Format("update Notice set delYn = 'Y' where nNo = {0};",test.nNo);
            if(my.NonQuery(sql))
            {
                return GetSelect();
            }
            else
            {
                return new ArrayList();
            }
        }
    
    }
}