﻿using FunctionZero.TreeZero;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace TestTreeZero
{
    public class TestNode : Node<TestNode>
    {
        public TestNode(string name) : this(null, name)
        {
        }

        public TestNode(ObservableCollection<TestNode> children, string name) : base(children)
        {
            Name = name;
        }

        public string Name { get; }

        public TestNode OriginalParent { get; internal set; }

        public override string ToString()
        {
            return this.Name;
        }

        public string PrintTree()
        {
            StringBuilder result = new StringBuilder();
            return Build(result, true).ToString();
        }

        private StringBuilder Build(StringBuilder result, bool isFirst)
        {
            AppendIndent(result, isFirst);
            result.AppendLine(Name);
            bool first = true;
            foreach (TestNode child in Children)
            {
                child.Build(result, first);
                first = false;
            }
            return result;
        }

        void AppendIndent(StringBuilder output, bool isFirst)
        {
            int nest = this.NestLevel;

            while (nest > 0)
            {
                nest--;
                if (nest == 0 && isFirst == true)
                {
                    isFirst = false;
                    output.Append("->");
                }
                else
                    output.Append("  ");
            }
        }
    }
}
