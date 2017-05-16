using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Win
{
    class Block
    {
        int page;          //当前块保存的是第几页
        int count;         //使用次数

        public Block(int p)
        {
            // TODO: Complete member initialization
            this.page = p;
        }

        public Block(int p,int c)
        {
            this.page = p;
            this.count = c;
        }

        public void clear_count()
        {
            this.count = 0;
        }

        public int get_page()
        {
            return this.page;
        }

        public void add_count()
        {
            this.count++;
        }

        public int get_count()
        {
            return this.count;
        }
        public bool Equals(Block x)    //比较x和y对象是否相同，按照地址比较
        {
            return x.page == this.page;
        }

        public int GetHashCode(Block obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}
