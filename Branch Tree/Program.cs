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
                parentBranch.subBranches.Add(newBranch);
            // If a parent branch has two sub-branches, already
            // Choose either one of the sub-branches as a parent branch, and 
            // Open new branches underneath them.
            else
                OpenSubBranch(parentBranch.subBranches.ElementAt(new Random().Next(0, 2)), newBranch);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Define the main branch
            var mainBranch = new Branch(0, "Main Branch");
            // Open sub-branches under the main branch
            for (int i = 0; i < 14; i++)
                mainBranch.OpenSubBranch(mainBranch, new Branch((i+1), "Sub Branch "+ (i+1)));
            
        }
    } 
}