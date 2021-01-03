using jsTreeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jsTreeApplication.Services
{
    public interface IRepository
    {
        Task<IEnumerable<TreeNode>> GetTreeNodes();
        Task<IEnumerable<TreeNode>> AddTreeNode(TreeNode treeNode);
    }
}
