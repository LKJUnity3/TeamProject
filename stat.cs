using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    public class stat
    {
        public string Name { get; set; }
        public enum JobList
        {
            검사,
            궁수,
            주술사,
            약사
        }
        public int atk { get; set; }
        public int def { get; set; }
        public int hp { get; set; }
        public int lv { get; set; }

    }
}
