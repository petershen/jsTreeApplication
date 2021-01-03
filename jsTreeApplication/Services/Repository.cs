﻿using jsTreeApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace jsTreeApplication.Services
{
    public class Repository : IRepository
    {
        public async Task<IEnumerable<TreeNode>> GetTreeNodes()
        {
            IEnumerable<TreeNode> treeNodes;
            using (StreamReader r = new StreamReader(@".\NodeDefinitionJson\TreeNodes.json"))
            {
                string json = await r.ReadToEndAsync();
                treeNodes = JsonConvert.DeserializeObject<IEnumerable<TreeNode>>(json);
            }
            return treeNodes;
        }

        public async Task<IEnumerable<TreeNode>> AddTreeNode(TreeNode treeNode)
        {
            string fileName = @".\NodeDefinitionJson\TreeNodes.json";

            IList <TreeNode> treeNodes;
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = await r.ReadToEndAsync();
                treeNodes = JsonConvert.DeserializeObject<IList<TreeNode>>(json);
            }

            treeNodes.Add(treeNode);

            using (StreamWriter w = new StreamWriter(fileName))
            {
                string json = JsonConvert.SerializeObject(treeNodes);
                await w.WriteAsync(json);
            }

            using (StreamReader r = new StreamReader(fileName))
            {
                string json = await r.ReadToEndAsync();
                treeNodes = JsonConvert.DeserializeObject<IList<TreeNode>>(json);
            }

            return treeNodes;
        }
    }
}