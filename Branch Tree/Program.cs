namespace REIZ_TECH
{  
    public class Branch
    {
        /* Define the object Branch with the following properties:
            1) ID, 
            2) Name, and 
            3) List of Sub-Branches   
        */
        public int ID { get; set; }
        public string? Name { get; set; }
        public ICollection<Branch> subBranches { get; set; }

        // Default constructor takes ID and Name of the Branch
        public Branch(int _id, string _name)
        {
            this.ID = _id;
            this.Name = _name;
            this.subBranches = new List<Branch>();
        }

        // Recursive function to open new sub-branches under the parent branch 
        public void OpenSubBranch(Branch parentBranch, Branch newBranch)
        {
            // Restrict the maximum number of sub-branches to two (2), for parent branches.
            if (parentBranch.subBranches.Count <= 1)
            {
                parentBranch.subBranches.Add(newBranch);
                Console.WriteLine("{0} -> {1}", parentBranch.Name, newBranch.Name);
            }
            // If a parent branch has two sub-branches, already
            // Choose either one of the sub-branches as a parent branch, and 
            // Open new branches underneath them.
            else
                OpenSubBranch(parentBranch.subBranches.ElementAt(new Random().Next(0, 2)), newBranch);
        }

        // Calculate depth of branches
        public int GetBranchDepth(Branch parentBranch)
        {
            // Travers to sub-branch if there exists atleast one 
            if (parentBranch.subBranches.Count > 0)
            {
                int depth = 0;
                // If a branch has only one sub branch, its depth depends on that sub-branch
                if (parentBranch.subBranches.Count == 1)
                    depth = GetBranchDepth(parentBranch.subBranches.ElementAt(0));      
                // If a branch has multiple sub-branches, its depth is the maximum of the depth of those sub-branch
                else if (parentBranch.subBranches.Count == 2)
                    depth = Math.Max(GetBranchDepth(parentBranch.subBranches.ElementAt(0)), GetBranchDepth(parentBranch.subBranches.ElementAt(1)));  
                // Include the current parent branch when calculating the depth 
                return (depth + 1);
            }
            // Start counting from the last sub-branch that exists at the bottom of the tree
            else
                // The last sub-branch is the first (1) branch when we count from the bottom to up
                return 1;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // Define the main branch
            var mainBranch = new Branch(0, "Main Branch");

            // Open sub-branches under the main branch
            for (int i = 0; i < 6; i++)
                mainBranch.OpenSubBranch(mainBranch, new Branch((i+1), "Sub Branch "+ (i+1)));

            // Traverse sub-branches under the main branch to calculate depth
            int depth = mainBranch.GetBranchDepth(mainBranch);
            Console.WriteLine("\nThe branch tree depth is: {0}", depth);
        }
    } 
}