using System;
using System.Collections.Generic;
using System.Text;

namespace CodeProblems.Tree
{
    public class Tree<T>
    { 
        public T value { get; set; }
        public Tree<T> left { get; set; }
        public Tree<T> right { get; set; }        
    }

}